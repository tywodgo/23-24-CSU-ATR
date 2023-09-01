using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CSUATRv2
{
    public class Instrument
    {
        #region Form Communications
        private MainForm mainForm;
        private Terminal terminal;
        #endregion
        #region Classes
        public CommandSet commandSet;
        private Measurement measurement;
        #endregion
        #region Instrument Parameters
        public string address { get; set; }
        private string _sParameter;
        public string sParameter
        {
            get { return _sParameter; }
            set
            {
                _sParameter = value;
                UpdateStatusSParameter();
            }
        }
        private double _sourcePower;
        public double sourcePower
        {
            get { return _sourcePower; }
            set
            {
                _sourcePower = value;
                UpdateStatusSourcePower();
            }
        }
        private double _startFrequency;
        public double startFrequency
        {
            get { return _startFrequency; }
            set
            {
                _startFrequency = value;
                UpdateStatusStartFrequency();
            }
        }
        private double _stopFrequency;
        public double stopFrequency
        {
            get { return _stopFrequency; }
            set
            {
                _stopFrequency = value;
                UpdateStatusStopFrequency();
            }
        }
        private double _ifBandwidth;
        public double ifBandwidth
        {
            get { return _ifBandwidth; }
            set
            {
                _ifBandwidth = value;
                UpdateStatusIFBandwidth();
            }
        }
        private int _sweepPoints;
        public int sweepPoints
        {
            get { return _sweepPoints; }
            set
            {
                _sweepPoints = value;
                UpdateStatusSweepPoints();
            }
        }
        private int _averagePoints;
        public int averagePoints
        {
            get { return _averagePoints; }
            set
            {
                _averagePoints = value;
                UpdateStatusAveragePoints();
            }
        }
        #endregion
        #region Flags
        private bool expectedConnection;
        private bool _connected;
        public bool connected
        {
            get { return _connected; }
            set
            {
                _connected = value;
                UpdateStatusInstrument();
            }
        }
        public bool ready { get; set; }
        #endregion
        #region Callbacks
        private Callback measureCallback;
        private Callback waitCallback;
        #endregion
        #region Timers
        private System.Timers.Timer waitTimer;
        private double waitTime = 1000; // in milliseconds
        #endregion
        #region Constants
        double KILOHERTZ = 1000;
        double MEGAHERTZ = 1000000;
        #endregion

        public Instrument(MainForm mainForm, Terminal terminal, Measurement measurement, CommandSet commandSet = null)
        {
            this.mainForm = mainForm;
            this.terminal = terminal;
            if (commandSet != null) { this.commandSet = commandSet; }
            else { this.commandSet = new CommandSet(); }
            this.measurement = measurement;

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
                        commandSet.Connect(address);
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
        public void Disconnect(string address, Callback callback)
        {
            try
            {
                expectedConnection = false;
                this.address = address;
                commandSet.Disconnect();
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
                connection = commandSet.TestConnection();
            }
            catch { connection = false; }

            if (connection == true)
            {
                connected = true;
                ready = false;
                Setup();
                terminal.Write(string.Format("{0} connected", address), 2);
                if (expectedConnection == true) { callback.Call(true); }
                else { callback.Call(false); }
            }
            else
            {
                connected = false;
                ready = false;
                terminal.Write(string.Format("{0} disconnected", address), 2);
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
                    commandSet.Setup();
                    ready = true;
                }
                catch
                {
                    ready = false;
                    terminal.Write(string.Format(" Failed to properly setup {0}", address), 3);
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address), 3);
            }
        }

        public void Measure(Callback callback)
        {
            if (ready == true && connected == true)
            {
                ready = false;
                try
                {
                    commandSet.Measure();
                    measureCallback = callback;
                    terminal.Write("Measurement initiated", 2);
                }
                catch
                {
                    ready = true;
                    terminal.Write(string.Format("{0} failed to initiate measurement", address), 3);
                    callback.Call(false);
                    return;
                }
            }
            else
            {
                terminal.Write(string.Format("{0} not ready", address), 3);
                callback.Call(false);
                return;
            }
        }
        public void CollectData()
        {
            // collect sweep data
            try
            {
                commandSet.CollectData(measurement);
                mainForm.dataManager.AddPoint();
                ready = true;
                terminal.Write("Data Collected", 1);
                measureCallback.Call(true);
                return;
            }
            catch
            {
                ready = true;
                terminal.Write(string.Format("{0} failed to collect data", address), 3);
                measureCallback.Call(false);
                return;
            }
        }
        public void Abort()
        {
            try
            {
                commandSet.Abort();
            }
            catch
            {
                terminal.Write("Failed to abort", 3);
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
                        commandSet.SetSParameter(sparam);
                        ready = true;
                        callback.Call(true);
                        return;
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set mode", address), 3);
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
                terminal.Write(string.Format("{0} not ready", address), 3);
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
                        commandSet.SetSourcePower(power);
                        ready = true;
                        callback.Call(true);
                        return;
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set source power", address), 3);
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
                terminal.Write(string.Format("{0} not ready", address), 3);
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
                            terminal.Write("Start Frequency higher than stop frequency", 3);
                            ready = true;
                            callback.Call(false);
                            return;
                        }
                        else
                        {
                            commandSet.SetStartFrequency(freq);
                            ready = true;
                            callback.Call(true);
                            return;
                        }
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set start-frequency", address), 3);
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
                terminal.Write(string.Format("{0} not ready", address), 3);
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
                            terminal.Write("Stop Frequency lower than start frequency" ,3);
                            ready = true;
                            callback.Call(false);
                            return;
                        }
                        else
                        {
                            commandSet.SetStopFrequency(freq);
                            ready = true;
                            callback.Call(true);
                            return;
                        }
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set stop-frequency", address), 3);
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
                terminal.Write(string.Format("{0} not ready", address), 3);
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
                        commandSet.SetIFBandwidth(freq);
                        ready = true;
                        callback.Call(true);
                        return;
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set IF-Bandwidth", address), 3);
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
                terminal.Write(string.Format("{0} not ready", address), 3);
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
                        commandSet.SetSweepPoints(points);
                        ready = true;
                        callback.Call(true);
                        return;
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set sweep-points", address), 3);
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
                terminal.Write(string.Format("{0} not ready", address), 3);
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
                        commandSet.SetAveragePoints(points);
                        ready = true;
                        callback.Call(true);
                        return;
                    }
                    catch
                    {
                        ready = true;
                        terminal.Write(string.Format("{0} failed to set point-average-quantity", address), 3);
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
                terminal.Write(string.Format("{0} not ready", address), 3);
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
            string address = (string)args[0];
            Disconnect(address, callback);
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

        #region GUI Updates
        // Connectivity
        public void UpdateStatusInstrument()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusInstrument(); })); }
            else { _UpdateStatusInstrument(); }
        }
        private void _UpdateStatusInstrument()
        {
            if (connected == true)
            {
                mainForm.statusInstrument.Text = "Connected";
            }
            else
            {
                mainForm.statusInstrument.Text = "Disconnected";
            }
        }
        // S Parameter
        public void UpdateStatusSParameter()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusSParameter(); })); }
            else { _UpdateStatusSParameter(); }
        }
        private void _UpdateStatusSParameter() { mainForm.statusSParameter.Text = sParameter; }
        // Source Power
        public void UpdateStatusSourcePower()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusSourcePower(); })); }
            else { _UpdateStatusSourcePower(); }
        }
        private void _UpdateStatusSourcePower() { mainForm.statusSourcePower.Text = sourcePower.ToString("N3"); }
        // Start Frequency
        public void UpdateStatusStartFrequency()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusStartFrequency(); })); }
            else { _UpdateStatusStartFrequency(); }
        }
        private void _UpdateStatusStartFrequency() { mainForm.statusStartFrequency.Text = (startFrequency / MEGAHERTZ).ToString("N3"); }
        // Stop Frequency
        public void UpdateStatusStopFrequency()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusStopFrequency(); })); }

            else { _UpdateStatusStopFrequency(); }
        }
        private void _UpdateStatusStopFrequency() { mainForm.statusStopFrequency.Text = (stopFrequency / MEGAHERTZ).ToString("N3"); }
        // IF Bandwidth
        public void UpdateStatusIFBandwidth()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusIFBandwidth(); })); }
            else { _UpdateStatusIFBandwidth(); }
        }
        private void _UpdateStatusIFBandwidth() { mainForm.statusIFBandwidth.Text = (ifBandwidth / KILOHERTZ).ToString("N3"); }
        // Sweep Points
        public void UpdateStatusSweepPoints()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusSweepPoints(); })); }
            else { _UpdateStatusSweepPoints(); }
        }
        private void _UpdateStatusSweepPoints() { mainForm.statusSweepPoints.Text = sweepPoints.ToString("N0"); }
        // Average Points
        public void UpdateStatusAveragePoints()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusAveragePoints(); })); }
            else { _UpdateStatusAveragePoints(); }
        }
        private void _UpdateStatusAveragePoints() { mainForm.statusAveragingPoints.Text = averagePoints.ToString("N0"); }
        #endregion
    }
}
