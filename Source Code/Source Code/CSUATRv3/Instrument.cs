using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CSUATRv3
{
    public class Instrument
    {
        #region Classes
        private Terminal terminal;
        private CommandSet device;
        private Measurement measurement;
        #endregion

        #region Instrument Parameters
        public string address { get; set; }
        public string sParameter { get; set; }
        public double sourcePower { get; set; }
        public double startFrequency { get; set; }
        public double stopFrequency { get; set; }
        public double ifBandwidth { get; set; }
        public int sweepPoints { get; set; }
        public int averagePoints { get; set; }
        #endregion

        #region Callbacks
        private Callback measureCallback;
        private Callback waitCallback;
        #endregion

        #region Flags
        private bool expectedConnection;
        private bool _connected;
        private bool _ready;
        public bool connected { get; set; }
        public bool ready { get; set; }
        #endregion

        #region Timers
        private System.Timers.Timer sweepTimer;
        private double sweepTime = 1000; // default value (milliseconds)
        private System.Timers.Timer waitTimer;
        private double waitTime = 1000; // in milliseconds
        #endregion

        public Instrument(CommandSet device, Measurement measurement, Terminal terminal)
        {
            this.device = device;
            this.measurement = measurement;
            this.terminal = terminal;

            sweepTimer = new System.Timers.Timer(sweepTime);
            sweepTimer.Elapsed += CollectData;
            sweepTimer.Enabled = false;
            sweepTimer.AutoReset = false;

            waitTime = 100; // milliseconds
            waitTimer = new System.Timers.Timer(waitTime);
            waitTimer.Elapsed += OnWaitTimerEvent;
            waitTimer.Enabled = false;
            waitTimer.AutoReset = false;

            connected = false;
            ready = false;
        }

        #region Event Functions
        public void Connect(string address, Callback callback)
        {
            try
            {
                expectedConnection = true;
                this.address = address;

                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.DoWork += new DoWorkEventHandler(
                delegate (object o, DoWorkEventArgs args)
                {
                    try
                    {
                        BackgroundWorker b = o as BackgroundWorker;
                        device.Connect(address);
                    }
                    catch { }
                });
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate (object o, RunWorkerCompletedEventArgs args)
                {
                    EvaluateConnection(callback);
                });
                bw.RunWorkerAsync();
            }
            catch { EvaluateConnection(callback); }
        }
        public void Disconnect(Callback callback)
        {
            try
            {
                expectedConnection = false;
                device.Disconnect();
            }
            catch { }
            EvaluateConnection(callback);
        }
        private void EvaluateConnection(Callback callback)
        {
            // test communications with instrument
            bool connection;
            try
            {
                device.TestConnection();
                connection = true;
            }
            catch { connection = false; }

            if (connection == true)
            {
                connected = true;
                ready = false;
                Setup();
                terminal.Write(string.Format("{0} connected", address));
                if (expectedConnection == true) { callback.Call(true); }
                else { callback.Call(false); }
            }
            else
            {
                connected = false;
                ready = false;
                terminal.Write(string.Format("{0} disconnected", address));
                if (expectedConnection == false) { callback.Call(true); }
                else { callback.Call(false); }
            }
        }
        private void Setup()
        {
            if (connected == true)
            {
                ready = false;
                try
                {
                    device.Setup();
                    ready = true;
                }
                catch
                {
                    ready = false;
                    terminal.Write(string.Format(" Failed to properly setup {0}", address));
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address));
            }
        }

        public void Measure(Callback callback)
        {
            if (ready == true && connected == true)
            {
                ready = false;
                try
                {
                    device.Measure();
                    measureCallback = callback;
                    sweepTime = (1 + 0.007 * sweepPoints) * 1000;
                    sweepTimer.Interval = sweepTime;
                    sweepTimer.Stop();
                    sweepTimer.Start();
                    terminal.Write("Measurement initiated");
                }
                catch
                {
                    ready = true;
                    terminal.Write(string.Format("{0} failed to initiate measurement", address));
                    callback.Call(false);
                    return;
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address));
                callback.Call(false);
                return;
            }
        }
        private void CollectData(object source, ElapsedEventArgs e)
        {
            // collect sweep data
            try
            {
                device.CollectData(measurement);
                ready = true;
                terminal.Write("Data Collected");
                measureCallback.Call(true);
                return;
            }
            catch
            {
                ready = true;
                terminal.Write(string.Format("{0} failed to collect data", address));
                measureCallback.Call(false);
                return;
            }
        }

        public void SetSParameter(string sparam, Callback callback)
        {
            // Set the S parameter
            if (ready == true && connected == true)
            {
                ready = false;
                if (!sparam.Equals(sParameter))
                {
                    try
                    {
                        device.SetSParameter(sparam);
                        ready = true;
                        callback.Call(true);
                        return;
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set mode", address));
                        callback.Call(false);
                        return;
                    }
                }
                else
                {
                    ready = true;
                    callback.Call(true);
                    return;
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address));
                callback.Call(false);
                return;
            }
        }
        public void SetSourcePower(double power, Callback callback)
        {
            // Set source power
            if (ready == true && connected == true)
            {
                ready = false;
                if (power != sourcePower)
                {
                    try
                    {
                        device.SetSourcePower(power);
                        ready = true;
                        callback.Call(true);
                        return;
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set source power", address));
                        callback.Call(false);
                        return;
                    }
                }
                else
                {
                    ready = true;
                    callback.Call(true);
                    return;
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address));
                callback.Call(false);
                return;
            }
        }
        public void SetStartFrequency(double freq, Callback callback)
        {
            // Set the start frequency for the current sweep (lower limit)
            if (ready == true && connected == true)
            {
                ready = false;
                if (freq != startFrequency)
                {
                    try
                    {
                        if (freq > stopFrequency)
                        {
                            terminal.Write("Start Frequency higher than stop frequency");
                            ready = true;
                            callback.Call(false);
                            return;
                        }
                        else
                        {
                            device.SetStartFrequency(freq);
                            ready = true;
                            callback.Call(true);
                            return;
                        }
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set start-frequency", address));
                        callback.Call(false);
                        return;
                    }
                }
                else
                {
                    ready = true;
                    callback.Call(true);
                    return;
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address));
                callback.Call(false);
                return;
            }
        }
        public void SetStopFrequency(double freq, Callback callback)
        {
            // Set the stop frequency for the current sweep (upper limit)
            if (ready == true && connected == true)
            {
                ready = false;
                if (freq != stopFrequency)
                {
                    try
                    {
                        if (freq < startFrequency)
                        {
                            terminal.Write("Stop Frequency lower than start frequency");
                            ready = true;
                            callback.Call(false);
                            return;
                        }
                        else
                        {
                            device.SetStopFrequency(freq);
                            ready = true;
                            callback.Call(true);
                            return;
                        }
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set stop-frequency", address));
                        callback.Call(false);
                        return;
                    }
                }
                else
                {
                    ready = true;
                    callback.Call(true);
                    return;
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address));
                callback.Call(false);
                return;
            }
        }
        public void SetIFBandwidth(double freq, Callback callback)
        {
            // Set IF Bandwidth
            if (ready == true && connected == true)
            {
                ready = false;
                if (freq != ifBandwidth)
                {
                    try
                    {
                        device.SetIFBandwidth(freq);
                        ready = true;
                        callback.Call(true);
                        return;
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set IF-Bandwidth", address));
                        callback.Call(false);
                        return;
                    }
                }
                else
                {
                    ready = true;
                    callback.Call(true);
                    return;
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address));
                callback.Call(false);
                return;
            }
        }
        public void SetSweepPoints(int points, Callback callback)
        {
            // Set the number of data points accumulated in a sweep
            if (ready == true && connected == true)
            {
                ready = false;
                if (points != sweepPoints)
                {
                    try
                    {
                        device.SetSweepPoints(points);
                        ready = true;
                        callback.Call(true);
                        return;
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set sweep-points", address));
                        callback.Call(false);
                        return;
                    }
                }
                else
                {
                    ready = true;
                    callback.Call(true);
                    return;
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address));
                callback.Call(false);
                return;
            }
        }
        public void SetAveragePoints(int points, Callback callback)
        {
            // Set the number of points used to average each data point in a sweep
            if (ready == true && connected == true)
            {
                ready = false;
                if (points != averagePoints)
                {
                    try
                    {
                        device.SetAveragePoints(points);
                        ready = true;
                        callback.Call(true);
                        return;
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set point-average-quantity", address));
                        callback.Call(false);
                        return;
                    }
                }
                else
                {
                    ready = true;
                    callback.Call(true);
                    return;
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address));
                callback.Call(false);
                return;
            }
        }

        public void Wait(Callback callback)
        {
            waitCallback = callback;
            waitTimer.Stop();
            waitTimer.Start();
        }
        private void OnWaitTimerEvent(object source, ElapsedEventArgs e)
        {
            waitCallback.Call(true);
        }
        #endregion

        #region Call Methods
        public void Connect(object[] args, Callback callback)
        {
            string address = (string)args[0];
            Connect(address, callback);
        }
        public void Disconnect(object[] args, Callback callback)
        {
            Disconnect(callback);
        }
        public void Measure(object[] args, Callback callback)
        {
            Measure(callback);
        }
        public void SetSParameter(object[] args, Callback callback)
        {
            string sparam = (string)args[0];
            SetSParameter(sparam, callback);
        }
        public void SetSourcePower(object[] args, Callback callback)
        {
            double power = (double)args[0];
            SetSourcePower(power, callback);
        }
        public void SetStartFrequency(object[] args, Callback callback)
        {
            double freq = (double)args[0];
            SetStartFrequency(freq, callback);
        }
        public void SetStopFrequency(object[] args, Callback callback)
        {
            double freq = (double)args[0];
            SetStopFrequency(freq, callback);
        }
        public void SetIFBandwidth(object[] args, Callback callback)
        {
            double freq = (double)args[0];
            SetIFBandwidth(freq, callback);
        }
        public void SetSweepPoints(object[] args, Callback callback)
        {
            int points = (int)args[0];
            SetSweepPoints(points, callback);
        }
        public void SetAveragePoints(object[] args, Callback callback)
        {
            int points = (int)args[0];
            SetAveragePoints(points, callback);
        }
        public void Wait(object[] args, Callback callback)
        {
            Wait(callback);
        }
        #endregion

    }
}
