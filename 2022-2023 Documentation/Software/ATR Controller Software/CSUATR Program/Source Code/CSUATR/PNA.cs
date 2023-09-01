using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Ivi.Visa.Interop;

namespace CSUATR
{
    public class PNA : NetworkAnalyzer
    {

        #region Parameters
        MainForm mainForm;

        private string nickName = "PNA";

        // PNA Notes: http://na.tm.agilent.com/pna/help/WebHelp7_5/help.htm
        // TODO: make sure that abrupt disconnection from PNA updates GUI
        //Variables to hold the instance of Formatted IO; used in communication Agilent io COMMIN
        //private Ivi.Visa.Interop.ResourceManager rm;
        //private Ivi.Visa.Interop.FormattedIO488 formatIO;
        //private Ivi.Visa.Interop.IMessage msg;
        //private double startFreq, stopFreq;
        //private int dataPoints;
        //private string calibration;
        //private double sourcePower;
        //private int ifBW;
        //private int delay;
        ////List<string> calList = new List<string>();
        //private string measType = "S21";
        //private string calFileInitial = "X-Band-2017"; //Change this for a different Initial Cal File
        #endregion

        public PNA(MainForm mainForm)
        {
            this.mainForm = mainForm;
            address = @"TCPIP0::colostate-vna::hpib7,16::INSTR"; // default for first time starting program
            connected = false;
            ready = true;
        }

        public override void Connect()
        {
            try
            {
                // TODO: connect to  PNA
            }
            catch { }
            EvaluateConnection();
        }

        public override void Disconnect()
        {
            try
            {
                // TODO disconnect from PNA
            }
            catch { }
            EvaluateConnection();
        }

        private void EvaluateConnection()
        {
            // test communications with instrument
            bool conSuccess = true; // result from test
            if (conSuccess == true)
            {
                connected = true;
                mainForm.WriteToOutput(string.Format("{0} connected", nickName));
            }
            else
            {
                connected = false;
                mainForm.WriteToOutput(string.Format("{0} disconnected", nickName));
            }
            mainForm.UpdateEnabledButtons_NAConnection();
            mainForm.UpdateEnabledButtons_Measurement();
            mainForm.UpdateEnabledButtons_ScanSettings();
        }

        public override void Measure()
        {
            // TODO
            // Take measurement
            // Update gui
        }

        public override void SetMode(string mode)
        {
            this.mode = mode;
            // TODO
        }
        
        public override void SetSourcePower(decimal power)
        {
            sourcePower = power;
            // TODO
        }
        
        public override void SetFrequency(decimal freq)
        {
            frequency = freq;
            // TODO
        }

        public override void SetPointQuantity(int points)
        {
            pointQuantity = points;
            // TODO
        }

        public override void GetData()
        {
            // TODO
        }



        /*
        public void SetStartFreq(double freq)
        {
            startFreq = freq;
            formatIO.WriteString("SENS:FREQ:START " + startFreq, true);
        }

        public void SetStopFreq(double freq)
        {
            stopFreq = freq;
            formatIO.WriteString("SENS:FREQ:STOP " + stopFreq, true);
        }



        // Returns list of user calibration files
        //public List<string> CalList
        //{
        //    get { return calList; }
        //}

        // Start frequency setting



        //public double StartFreq
        //{
        //    get { return startFreq; }
        //    set
        //    {
        //        startFreq = value;
        //        formatIO.WriteString("SENS:FREQ:START " + startFreq, true);
        //    }
        //}

        // Stop frequency setting



        //public double StopFreq
        //{
        //    get { return stopFreq; }
        //    set
        //    {
        //        stopFreq = value;
        //        formatIO.WriteString("SENS:FREQ:STOP " + stopFreq, true);
        //    }
        //}

        // Set source power level
        public void SetSourcePower(double power)
        {
            sourcePower = power;
            formatIO.WriteString("SOUR:POW:LEV:IMM:AMPL " + sourcePower.ToString());
        }

        // Set measurement type
        public string MeasType
        {
            set
            {
                measType = value;
                // Delete old measurement
                formatIO.WriteString("CALCulate1:PARameter:DELete 'MyMeas'");
                if (measType == "S21")
                {
                    // Set new measurement type
                    formatIO.WriteString("CALCulate1:PARameter:DEFine 'MyMeas',S21", true);
                }
                else if (measType == "S11")
                {
                    formatIO.WriteString("CALCulate1:PARameter:DEFine 'MyMeas',S11", true);
                }
                else
                {
                    formatIO.WriteString("CALCulate1:PARameter:DEFine 'MyMeas',S22", true);
                }
                // Update trace
                formatIO.WriteString("DISPlay:WINDow1:TRACe1:FEED 'MyMeas'", true);

            }
        }

        // The number of different frequency data points in the measurement
        public int DataPoints
        {
            get { return dataPoints; }
            set
            {
                dataPoints = value;
                formatIO.WriteString("SENS1:SWE:POIN " + dataPoints.ToString(), true);
            }
        }

        // User calibration file
        public string Calibration
        {
            get { return calibration; }
            set
            {
                calibration = value;
                string tmpString = "SENS:CORR:CSET:ACT \"" + calibration + "\",1";
                formatIO.WriteString(tmpString, true);
            }

        }

        //TODO Needs help to set this to the correct sweepTime. Passing a number to it will not set to the number or the nearest rounded number either
        public void setSweepTime(int sweepTimeMilliSeconds)
        {

            formatIO.WriteString("SENS:SEGM:SWE:TIME:CONT ON", true);
            formatIO.WriteString("SENS:SWE:TIME:AUTO OFF", true);

            //formatIO.WriteString("SENS:SEGM:SWE:TIME " + sweepTimeMilliSeconds + "ms", true);
            //formatIO.WriteString("SENS:SWE:TIME " + sweepTimeMilliSeconds.ToString() + "ms");
            formatIO.WriteString("SENS:SWE:TIME MIN", true);
        }

        public int setIFBW
        {
            get { return ifBW; }
            set
            {
                ifBW = value;
                formatIO.WriteString("SENS:BANDwidth:resolution " + ifBW);
            }
        }

        public int setEDelay
        {
            get { return delay; }
            set
            {
                delay = value;
                formatIO.WriteString("CALC:CORR:EDEL:MED COAX");
                formatIO.WriteString("CALC:CORR:EDEL:TIME " + delay + "NS");
            }
        }

        // PNA address
        public PNA(MainForm mainForm)
        {
            this.mainForm = mainForm;
            //this.vnaAddress = vnaAddress;
            this.rm = new ResourceManager();
            formatIO = new FormattedIO488();
        }

        // From old teams code (Pre-2013)
        // Stores the address of the network analyzer
        // An example string is shown below
        // TCPIP0::A-E8363B-0824::hpib7,16::INSTR
        // A-E8363B-0824 = Computer name on the network
        public string VnaAddress
        {
            get { return vnaAddress; }
            set { vnaAddress = value; }
        }

        // Return true if a connection to the network analyzer is open
        public bool Connected()
        {
            if (formatIO.IO == null)
                return false;
            else
                return true;
        }

        // This is mostly untouched from previous teams (pre-2013)
        // Open up a connection to the network analyzer
        // Then get an identification string from the insturment
        // A message box will be shown if the connection fails
        public bool Open()
        {
            //string calFileInitial = "X-Band-2017";
            try
            {
                this.msg = (IMessage)(rm.Open(this.vnaAddress, AccessMode.NO_LOCK, 2000, ""));
                formatIO.IO = msg;

                formatIO.IO.Timeout = 7000;
                formatIO.WriteString("*RST", true);
                // Default is to use ASCII format but this is supposed to be slow.
                formatIO.WriteString("format:data ascii,0", true); // Set the data transfer format
                getCalibrations();


                // Preset the analyzer
                formatIO.WriteString("SYST:FPReset", true);
                // Create and turn on window 1
                formatIO.WriteString("DISPlay:WINDow1:STATE ON", true);
                // Define a measurement name, parameter
                // Initialize as an S21 type measurement
                formatIO.WriteString("CALCulate1:PARameter:DEFine 'MyMeas',S21", true);
                // Associate ("FEED") the measurement name ('MyMeas') to WINDow (1), and give the new TRACe a number (1).
                formatIO.WriteString("DISPlay:WINDow1:TRACe1:FEED 'MyMeas'", true);

                // Initialize source power to 2 dBm
                formatIO.WriteString("SOUR:POW:LEV:IMM:AMPL 2");
                // Initialize start/stop frequencies for X-band
                //StartFreq = 8e9;
                //StopFreq = 12e9;
                SetStartFreq(8e9);
                SetStopFreq(12e9);
                // Initialize appropriate calibration file for X-band
                string tmpString = "SENS:CORR:CSET:ACT \"" + calFileInitial + "\",1";
                formatIO.WriteString(tmpString, true);

                //Initialize the IF Bandwidth to 100 Hz
                formatIO.WriteString("sense1:bandwidth:resolution 100", true);

                return true;
            }
            catch (SystemException ex)
            {
                //why are we catching/displaying the message differently?
                MessageBox.Show("Open failed on " + this.vnaAddress + " " + ex.Source + "  " + ex.Message, "CSU ATR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formatIO.IO = null;
                return false;
            }
        }

        // Gets the user calibration files
        // Not really used any more to eliminate possible incorrect usage
        // of calibration files.  Proper file loading is hard coded.
        //TODO TODO TODO USE THIS METHOD TO CHOOSE FROM LIST OF CAL FILES
        public void getCalibrations()
        {
            // Get list of calibration files from PNA
            formatIO.WriteString("SENS:CORR:CSET:CAT? name", true);
            // Build array of strings from results
            string[] calibrations = formatIO.ReadString().Split(',');

            // First file name has a " character at the begining which we need to remove
            calibrations[0] = calibrations[0].Substring(1);
            // Last file has a " character at the end which we need to remove
            calibrations[calibrations.Length - 1] = calibrations[calibrations.Length - 1].Substring(0, calibrations[calibrations.Length - 1].Length - 2);

            // Add the values to the list of strings
            foreach (string cal in calibrations)
            {
                //cmbCalibration.Items.Add(cal);
                calList.Add(cal);
            }
            // Set selected item to the first in the collection
            //cmbCalibration.SelectedIndex = 0;

        }


        // Close the connection to the network analyzer
        // DMF - There is something wrong with this code.
        // Does not properly close out connection!!
        // Closing out form always closes connection, but this is 
        // something that needs to be addressed by future teams
        public void CloseConnection()
        {
            if (formatIO.IO != null)
                formatIO.IO.Close();

        }

        // Returns the instrument identification string
        // DMF - Not really necessary.  Displayed in startup message
        public string GetInstrumentID()
        {
            // If already connected to the VNA
            if (Connected())
            {
                formatIO.WriteString("*IDN?", true);
                return formatIO.ReadString();
            }
            else
            {
                return "Not Connectd";
            }
        }

        /// <summary>
        /// This will return the instrument identification string</summary>
        /// <param name="command"> The SCPI text command to send</param>
        /// <returns>
        /// String with a response from the command</returns>
        public string SendCommandString(string command)
        {
            if (Connected())
            {
                //check connected() still received a stop error after attempting to send message when disconnected
                formatIO.WriteString(command, true);
                return formatIO.ReadString();
            }
            else
            {
                return "Not Connected";
            }
        }

        /// <summary>
        /// Creates a new S21 measurement and displays it on the PNA screen
        /// </summary>
        /// <remarks>Some example code was from an example at 
        /// http://na.tm.agilent.com/pna/help/WebHelp7_5/Programming/GPIB_Example_Programs/Create_a_measurement_using_GPIB.htm
        // DMF - Lots of unecessary garbage going on in old code.
        // Currently, the measurement type is established elsewhere in code, and this simply 
        // sets the proper frequency range and triggers a measurement. Old code made a new measurement/trace every single 
        // time a measurement was triggered which was totally unecessary.
        public object[] TriggerMeasurement()
        {
            // Set to autoscale
            formatIO.WriteString("DISPlay:WINDow1:TRACe1:Y:SCALe:AUTO", true);
            //Put channel in Hold - channel will not trigger
            formatIO.WriteString("SENS1:SWE:MODE HOLD", true);
            // Set frequency range and number of frequency points to measure
            formatIO.WriteString("SENS:FREQ:START " + startFreq, true);
            formatIO.WriteString("SENS:FREQ:STOP " + stopFreq, true);
            formatIO.WriteString("SENS1:SWE:POIN " + dataPoints.ToString(), true);

            // Trigger the measurement
            continousScanTrigger(); // Marcus - put in for debug
                                    //  Trigger();
                                    // throw away result (DMF - no idea why we do this...)
                                    // formatIO.ReadString(); 

            // Unformated data (uW)
            //formatIO.WriteString("calculate:DATA? SDATA", true);
            // Formated data (dB)
            formatIO.WriteString(":CALCulate:DATA? FDATA", true);

            return (object[])formatIO.ReadList(IEEEASCIIType.ASCIIType_BSTR, ",");
        }


        // Trigger a measurement and pull data at set number of frequencies
        // eg. if data points set to 1, will return the measurement at start freq.
        // If set to 2, will return start and stop freq measurements.
        // If set to 3, will return start, stop and middle point.
        public void Trigger()
        {
            // PNA sends continuous trigger signals
            formatIO.WriteString("TRIG:SOUR IMMediate", true);// should this be Trig:sour BUS" ?--CPK

            // The following command makes the channel immediately sweep
            // *OPC? allows the measurement to complete before the 
            // controller sends another command
            formatIO.WriteString("SENS1:SWE:MODE SINGle;*OPC?; *wai", true);
        }

        //KEENANS Trigger Method for continuous scan
        public object[] continousScanTrigger()
        {
            //Set to internal manual triggering of new sweep
            //  DateTime a = DateTime.Now;
            //   DateTime total = DateTime.Now;
            formatIO.WriteString("TRIG:SOUR MANual");
            //  TimeSpan a_time = DateTime.Now - a;

            //Stops the current sweeps and immediately sends a trigger
            //  a = DateTime.Now;
            formatIO.WriteString("INITiate:IMMediate;*OPC?");
            //  a_time = DateTime.Now - a;

            // Formated data (dB)
            //  a = DateTime.Now;
            formatIO.WriteString(":CALCulate:DATA? FDATA", true);
            //  a_time = DateTime.Now - a;

            //  a = DateTime.Now;
            object[] data = formatIO.ReadList(IEEEASCIIType.ASCIIType_BSTR, ",");
            //  a_time = DateTime.Now - a;

            //TimeSpan a_total = DateTime.Now - total;
            return data;
        }
        */
    }
}
