using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Agilent.CommandExpert.ScpiNet.AgN99xx_NA_A_06_23;

namespace CSUATR
{
    public class FieldFox : NetworkAnalyzer
    {
        // Other considerations:
        // For file io, look into MMEMory and DISPlay.KEYWord

        #region Classes
        MainForm mainForm;
        Positioner positioner;
        DataManager dataManager;
        // Referenced this assembly : [C:\ProgramData\Keysight\Command Expert\ScpiNetDrivers\AgN99xx_NA_A_06_23.dll]
        AgN99xx_NA N9923A;
        System.Timers.Timer sweepTimer;
        #endregion

        #region Instrument Parameters
        private string nickName = "FieldFox";
        private double sweepTime = 1000; // default value (milliseconds)
        #endregion

        #region Constants
        private decimal MEGAHERTZ = 1000000;
        private decimal GIGAHERTZ = 1000000000;
        #endregion

        public FieldFox(MainForm mainForm, Positioner positioner, DataManager dataManager)
        {
            this.mainForm = mainForm;
            this.positioner = positioner;
            this.dataManager = dataManager;

            sweepTimer = new System.Timers.Timer(sweepTime);
            sweepTimer.Elapsed += OnSweepTimerEvent;
            sweepTimer.Enabled = false;
            sweepTimer.AutoReset = false;

            address = @"TCPIP0::129.82.226.75::inst0::INSTR"; // default for first time starting program
            connected = false;
            ready = false;
        }

        public override void Connect()
        {
            try
            {
                N9923A = new AgN99xx_NA(address);
            }
            catch { }
            EvaluateConnection();
        }

        public override void Disconnect()
        {
            try
            {
                N9923A = null;
            }
            catch { }
            EvaluateConnection();
        }

        private void EvaluateConnection()
        {
            // test communications with instrument
            bool connection;
            try
            {
                N9923A.SCPI.IDN.Query(out idn);
                connection = true;
            }
            catch { connection = false; }
            
            if (connection == true)
            {
                connected = true;
                mainForm.WriteToOutput(string.Format("{0} connected", nickName));
                Setup();
            }
            else
            {
                connected = false;
                ready = false;
                mainForm.scanner.Pause();
                mainForm.WriteToOutput(string.Format("{0} disconnected", nickName));
            }
            mainForm.UpdateEnabledButtons_NAConnection();
            mainForm.UpdateEnabledButtons_Measurement();
            mainForm.UpdateEnabledButtons_ScanSettings();
        }

        private void Setup()
        {
            try
            {
                N9923A.SCPI.CLS.Command(); // clear status byte in device
                N9923A.SCPI.RST.Command(); // reset device

                N9923A.SCPI.INSTrument.SELect.Command("NA"); // make sure the FieldFox is in Network Analyzer mode
                N9923A.SCPI.SENSe.AVERage.MODE.Command("POINt"); // set averaging mode (default) (may not be necessary to call)

                N9923A.SCPI.FORMat.DATA.Command("REAL", 64);  // set the format that data is sent in

                N9923A.SCPI.DISPlay.WINDow.SPLit.Command("D1"); // set the display to only show 1 trace at a time
                N9923A.SCPI.CALCulate.PARameter.SELect.Command(1u); // set the selected trace to the first trace
                N9923A.SCPI.INITiate.CONTinuous.Command(false); // disable continuous scanning

                N9923A.SCPI.CALCulate.SELected.FORMat.Command("MLOGarithmic"); // set the format to be logarithmic (this may change later)

                ready = true; // this comes after general setup but before the next set of sequences

                // setup the default startup parameters
                SetSourcePower(-1);
                SetStopFrequency(6000000000);
                SetStartFrequency(2000000);
                SetSweepPoints(100);
                SetPointAvgQuantity(10);
            }
            catch
            {
                mainForm.WriteToOutput(string.Format(" Failed to properly setup {0}", nickName));
                return;
            }
        }

        public override bool Measure()
        {
            if (ready == true)
            {
                ready = false;
                try
                {
                    N9923A.SCPI.INITiate.IMMediate.Command(); // run a single sweep
                    sweepTime = (1 + 0.007 * sweepPoints) * 1000;
                    //mainForm.WriteToOutput(string.Format("sweepTime: {0:N3}", sweepTime));
                    sweepTimer.Interval = sweepTime;
                    sweepTimer.Stop();
                    sweepTimer.Start();
                    mainForm.WriteToOutput("Measurement initiated");
                    mainForm.UpdateEnabledButtons_NAConnection();
                    mainForm.UpdateEnabledButtons_Measurement();
                    mainForm.UpdateEnabledButtons_ScanSettings();
                    return true;
                }
                catch
                {
                    ready = true;
                    mainForm.WriteToOutput(string.Format("{0} failed to initiate measurement", nickName));
                    return false;
                }
            }
            else
            {
                mainForm.WriteToOutput(string.Format("{0} is not ready to initiate a measurement", nickName));
                return false;
            }
        }

        private void OnSweepTimerEvent(object source, ElapsedEventArgs e)
        {
            // collect sweep data
            try
            {
                N9923A.SCPI.DISPlay.WINDow.TRACe.Y.SCALe.AUTO.Command(null); // autoscale the trace
                N9923A.SCPI.SENSe.FREQuency.DATA.QueryBlockReal64(out frequency);
                double[] raw = null;
                N9923A.SCPI.CALCulate.SELected.DATA.SDATa.QueryBlockReal64(out raw);
                real = new double[raw.Length / 2];
                imag = new double[raw.Length / 2];
                for (int index = 0; index < real.Length; index++)
                {
                    real[index] = raw[index * 2];
                    imag[index] = raw[index * 2 + 1];
                }
                //PopulateFakeData(); // for testing purposes only
                if (mainForm.InvokeRequired)
                {
                    mainForm.Invoke(new MethodInvoker(delegate
                    {
                        dataManager.AddPoint(new Point(
                            "ri",
                            positioner.currentPositionPolar,
                            positioner.currentPositionVertical,
                            positioner.currentPositionHorizontal,
                            positioner.currentPositionDepth,
                            positioner.currentPositionAzimuth,
                            positioner.currentPositionElevation,
                            mode,
                            (double)sourcePower,
                            pointAvgQuantity,
                            frequency,
                            real,
                            imag));
                    }));
                }
                else
                {
                    dataManager.AddPoint(new Point(
                        "ri",
                        positioner.currentPositionPolar,
                        positioner.currentPositionVertical,
                        positioner.currentPositionHorizontal,
                        positioner.currentPositionDepth,
                        positioner.currentPositionAzimuth,
                        positioner.currentPositionElevation,
                        mode,
                        (double)sourcePower,
                        pointAvgQuantity,
                        frequency,
                        real,
                        imag));
                }
                ready = true;
                mainForm.WriteToOutput(string.Format("Data Collected: {0} Values", frequency.Length));
            }
            catch
            {
                ready = true;
                mainForm.WriteToOutput(string.Format("{0} failed to collect data", nickName));
            }
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new MethodInvoker(delegate
                {
                    mainForm.UpdateEnabledButtons_NAConnection();
                    mainForm.UpdateEnabledButtons_Measurement();
                    mainForm.UpdateEnabledButtons_ScanSettings();
                    mainForm.scanner.OnSweepStopEvent();
                }));
            }
            else
            {
                mainForm.UpdateEnabledButtons_NAConnection();
                mainForm.UpdateEnabledButtons_Measurement();
                mainForm.UpdateEnabledButtons_ScanSettings();
                mainForm.scanner.OnSweepStopEvent();
            }
        }

        private void PopulateFakeData()
        {
            // Unused
            int length = 100;
            frequency = new double[length];
            real = new double[frequency.Length];
            imag = new double[frequency.Length];
            for (int index = 0; index < frequency.Length; index++)
            {
                frequency[index] = index;
                real[index] = Math.Exp(-0.1 * frequency[index]) * Math.Sin(0.1 * frequency[index]);
                imag[index] = Math.Exp(-0.1 * frequency[index]) * Math.Sin(0.2 * frequency[index]);
            }
        }

        // Set the S parameter
        public override bool SetMode(string mode)
        {
            if (ready == true)
            {
                ready = false;
                if (!mode.Equals(this.mode))
                {
                    try
                    {
                        if (mode.Equals("S11"))
                        {
                            N9923A.SCPI.CALCulate.PARameter.DEFine.Command(1u, "S11");
                            this.mode = mode;
                            mainForm.WriteToOutput(string.Format("Mode: {0}", this.mode));
                            ready = true;
                            return true;
                        }
                        else if (mode.Equals("S12"))
                        {
                            N9923A.SCPI.CALCulate.PARameter.DEFine.Command(1u, "S12");
                            this.mode = mode;
                            mainForm.WriteToOutput(string.Format("Mode: {0}", this.mode));
                            ready = true;
                            return true;
                        }
                        else if (mode.Equals("S21"))
                        {
                            N9923A.SCPI.CALCulate.PARameter.DEFine.Command(1u, "S21");
                            this.mode = mode;
                            mainForm.WriteToOutput(string.Format("Mode: {0}", this.mode));
                            ready = true;
                            return true;
                        }
                        else if (mode.Equals("S22"))
                        {
                            N9923A.SCPI.CALCulate.PARameter.DEFine.Command(1u, "S22");
                            this.mode = mode;
                            mainForm.WriteToOutput(string.Format("Mode: {0}", this.mode));
                            ready = true;
                            return true;
                        }
                        else
                        {
                            ready = true;
                            return false;
                        }
                    }
                    catch
                    {
                        ready = true;
                        mainForm.WriteToOutput(string.Format("{0} failed to set mode", nickName));
                        return false;
                    }
                }
                else
                {
                    ready = true;
                    return true;
                }
            }
            else
            {
                mainForm.WriteToOutput(string.Format("{0} not ready to collect data", nickName));
                return false;
            }
        }

        // Set source power
        public override bool SetSourcePower(decimal power)
        {
            if (ready == true)
            {
                ready = false;
                if (power != sourcePower)
                {
                    try
                    {
                        if (power == 0) { N9923A.SCPI.SOURce.POWer.ALC.MODE.Command("HIGH"); }
                        else { N9923A.SCPI.SOURce.POWer.Command((double)power); }
                        sourcePower = power;
                        mainForm.WriteToOutput(string.Format("Source Power: {0}", power));
                        mainForm.UpdateStatus_Measurement();
                        ready = true;
                        return true;
                    }
                    catch
                    {
                        ready = true;
                        mainForm.WriteToOutput(string.Format("{0} failed to set source power", nickName));
                        return false;
                    }
                }
                else
                {
                    ready = true;
                    return true;
                }
            }
            else
            {
                mainForm.WriteToOutput(string.Format("{0} not ready to set source power", nickName));
                return false;
            }
        }

        // Set the start frequency for the current sweep (lower limit)
        public override bool SetStartFrequency(decimal freq)
        {
            if (ready == true)
            {
                ready = false;
                if (freq != startFrequency)
                {
                    try
                    {
                        // Range 2MHz to 6GHz
                        //if (freq > 6000000000) { mainForm.WriteToOutput("Start Frequency too high"); ready = true; return false; }
                        //else if (freq < 2000000) { mainForm.WriteToOutput("Start Frequency too low"); ready = true; return false; }
                        if (freq > stopFrequency) { mainForm.WriteToOutput("Start Frequency higher than stop frequency"); ready = true; return false; }
                        else
                        {
                            N9923A.SCPI.SENSe.FREQuency.STARt.Command((double)freq);
                            startFrequency = freq;
                            mainForm.UpdateStatus_Measurement();
                            if (startFrequency < GIGAHERTZ)
                            {
                                mainForm.WriteToOutput(string.Format("Start Frequency: {0:N3}MHz", startFrequency / MEGAHERTZ));
                            }
                            else
                            {
                                mainForm.WriteToOutput(string.Format("Start Frequency: {0:N3}GHz", startFrequency / GIGAHERTZ));
                            }
                            ready = true;
                            return true;
                        }
                    }
                    catch
                    {
                        ready = true;
                        mainForm.WriteToOutput(string.Format("{0} failed to set start-frequency", nickName));
                        return false;
                    }
                }
                else
                {
                    ready = true;
                    return true;
                }
            }
            else
            {
                mainForm.WriteToOutput(string.Format("{0} not ready to set start-frequency", nickName));
                return false;
            }
        }

        // Set the stop frequency for the current sweep (upper limit)
        public override bool SetStopFrequency(decimal freq)
        {
            if (ready == true)
            {
                ready = false;
                if (freq != stopFrequency)
                {
                    try
                    {
                        // Range 2MHz to 6GHz
                        //if (freq > 6000000000) { mainForm.WriteToOutput("Stop Frequency too high"); ready = true; return false; }
                        //else if (freq < 2000000) { mainForm.WriteToOutput("Stop Frequency too low"); ready = true; return false; }
                        if (freq < startFrequency) { mainForm.WriteToOutput("Stop Frequency lower than start frequency"); ready = true; return false; }
                        else
                        {
                            N9923A.SCPI.SENSe.FREQuency.STOP.Command((double)freq);
                            stopFrequency = freq;
                            mainForm.UpdateStatus_Measurement();
                            if (stopFrequency < GIGAHERTZ)
                            {
                                mainForm.WriteToOutput(string.Format("Stop Frequency: {0:N3}MHz", stopFrequency / MEGAHERTZ));
                            }
                            else
                            {
                                mainForm.WriteToOutput(string.Format("Stop Frequency: {0:N3}GHz", stopFrequency / GIGAHERTZ));
                            }
                            ready = true;
                            return true;
                        }
                    }
                    catch
                    {
                        ready = true;
                        mainForm.WriteToOutput(string.Format("{0} failed to set stop-frequency", nickName));
                        return false;
                    }
                }
                else
                {
                    ready = true;
                    return true;
                }
            }
            else
            {
                mainForm.WriteToOutput(string.Format("{0} not ready to set stop-frequency", nickName));
                return false;
            }
        }

        // Set the number of data points accumulated in a sweep
        public override bool SetSweepPoints(int points)
        {
            if (ready == true)
            {
                ready = false;
                if (points != sweepPoints)
                {
                    try
                    {
                        // frequency points range 3 to 10001
                        if (points > 10001) { mainForm.WriteToOutput("Number of Sweep Points too high"); ready = true; return false; }
                        else if (points < 3) { mainForm.WriteToOutput("Number of Sweep Points too low"); ready = true; return false; }
                        else
                        {
                            N9923A.SCPI.SENSe.SWEep.POINts.Command(points);
                            sweepPoints = points;
                            mainForm.WriteToOutput(string.Format("Number of Sweep Points: {0}", sweepPoints));
                            mainForm.UpdateStatus_Measurement();
                            ready = true;
                            return true;
                        }
                    }
                    catch
                    {
                        ready = true;
                        mainForm.WriteToOutput(string.Format("{0} failed to set sweep-points", nickName));
                        return false;
                    }
                }
                else
                {
                    ready = true;
                    return true;
                }
            }
            else
            {
                mainForm.WriteToOutput(string.Format("{0} not ready to set sweep-points", nickName));
                return false;
            }
        }

        // Set the number of points used to average each data point in a sweep
        public override bool SetPointAvgQuantity(int points)
        {
            if (ready == true)
            {
                ready = false;
                if (points != pointAvgQuantity)
                {
                    try
                    {
                        // this can only go from 1 to 100 (for averaging)
                        if (points > 101) { mainForm.WriteToOutput("Averaging Points too high"); ready = true; return false; }
                        else if (points < 1) { mainForm.WriteToOutput("Averaging Points too low"); ready = true; return false; }
                        else
                        {
                            N9923A.SCPI.SENSe.AVERage.COUNt.Command(points);
                            pointAvgQuantity = points;
                            mainForm.WriteToOutput(string.Format("Averaging Points: {0}", pointAvgQuantity));
                            mainForm.UpdateStatus_Measurement();
                            ready = true;
                            return true;
                        }
                    }
                    catch
                    {
                        ready = true;
                        mainForm.WriteToOutput(string.Format("{0} failed to set point-average-quantity", nickName));
                        return false;
                    }
                }
                else
                {
                    ready = true;
                    return true;
                }
            }
            else
            {
                mainForm.WriteToOutput(string.Format("{0} not ready to set point-average-quantity", nickName));
                return false;
            }
        }
    }
}
