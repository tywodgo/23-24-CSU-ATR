using Ivi.Visa;
using Ivi.Visa.FormattedIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CSUATRv2
{
    public class E8364B : CommandSet
    {
        // See this website for more information:
        // http://na.support.keysight.com/pna/help/WebHelp7_5/help.htm

        #region Classes
        Instrument instrument;

        IMessageBasedSession session;
        MessageBasedFormattedIO formattedIO;
        //AgPNA agPNA;

        private System.Timers.Timer interruptTimer;
        private double interruptTime = 250; // default value (milliseconds)

        private string Mname = "MyMeas"; // necessary for identifying trace
        #endregion

        public E8364B(Instrument instrument)
        {
            this.instrument = instrument;
            nickname = "E8364B";

            interruptTimer = new System.Timers.Timer(interruptTime);
            interruptTimer.Elapsed += InterruptTimer_Elapsed;
            interruptTimer.Enabled = false;
            interruptTimer.AutoReset = true;
        }

        #region Event Functions
        public override bool Connect(string address)
        {
            session = GlobalResourceManager.Open(address) as IMessageBasedSession;
            formattedIO = new MessageBasedFormattedIO(session);
            if (session.ResourceName.Contains("ASRL") || session.ResourceName.Contains("SOCKET"))
            { session.TerminationCharacterEnabled = true; }
            session.TimeoutMilliseconds = 10000; // 10 second timeout
            return true;
        }
        public override bool Disconnect()
        {
            session.Dispose();
            return true;
        }
        public override bool TestConnection()
        {
            string idn;
            formattedIO.WriteLine("*IDN?");
            idn = formattedIO.ReadLine();
            return true;
        }

        public override bool Setup()
        {
            // Setup Instrument Operation
            //formattedIO.WriteLine("*RST"); // reset device
            //formattedIO.WriteLine("*CLS"); // clear status byte in device

            string sParameter = "S21";
            formattedIO.WriteLine("CALCulate:PARameter:DELete:ALL");
            formattedIO.WriteLine(string.Format("CALCulate:PARameter:DEFine '{0}',{1}", Mname, sParameter));
            formattedIO.WriteLine(string.Format("DISPlay:WINDow:TRACe:FEED '{0}'", Mname));
            formattedIO.WriteLine(string.Format("CALCulate:PARameter:SELect '{0}'", Mname)); // set the selected trace
            instrument.sParameter = sParameter;

            formattedIO.WriteLine("SENSe:AVERage ON"); // set averaging mode
            //formattedIO.WriteLine(string.Format("FORMat:DATA {0},{1}", "REAL", 64)); // set data format
            formattedIO.WriteLine(string.Format("FORMat:DATA {0},{1}", "ASCii", 0)); // set data format
            formattedIO.WriteLine(string.Format("CALCulate:FORMat {0}", "MLOGarithmic")); // set display to be logarithmic
            formattedIO.WriteLine(string.Format("INITiate:CONTinuous {0}", "ON")); // disable continuous scanning
            formattedIO.WriteLine(string.Format("SENSe:SWEep:TYPE {0}", "LINear")); // set sweep type to linear

            // Get current instrument characteristics
            double sourcePower;
            double startFrequency;
            double stopFrequency;
            double ifBandwidth;
            int sweepPoints;
            int averagePoints;

            formattedIO.WriteLine("SOUR:POW:LEV:IMM:AMPL?");
            //formattedIO.WriteLine("SENSe:POWer:ATTenuation?");
            sourcePower = formattedIO.ReadLineDouble();

            formattedIO.WriteLine("SENSe:FREQuency:STARt?");
            startFrequency = formattedIO.ReadLineDouble();

            formattedIO.WriteLine("SENSe:FREQuency:STOP?");
            stopFrequency = formattedIO.ReadLineDouble();

            formattedIO.WriteLine("SENSe:BANDwidth?");
            ifBandwidth = formattedIO.ReadLineDouble();

            formattedIO.WriteLine("SENSe:SWEep:POINts?");
            sweepPoints = (int)formattedIO.ReadLineDouble();

            formattedIO.WriteLine("SENSe:AVERage:COUNt?");
            averagePoints = (int)formattedIO.ReadLineDouble();

            instrument.sourcePower = sourcePower;
            instrument.startFrequency = startFrequency;
            instrument.stopFrequency = stopFrequency;
            instrument.ifBandwidth = ifBandwidth;
            instrument.sweepPoints = sweepPoints;
            instrument.averagePoints = averagePoints;

            return true;
        }

        public override bool Measure()
        {
            
            formattedIO.WriteLine("INITiate:IMMediate"); // run a single sweep
            formattedIO.WriteLine("*OPC");
            interruptTimer.Enabled = true;
            return true;
        }
        public override bool CollectData(Measurement measurement)
        {
            // collect sweep data
            double[] frequency = null;
            double[] raw = null;
            double[] real = null;
            double[] imaginary = null;

            formattedIO.WriteLine("DISPlay:WINDow1:TRACe1:Y:SCALe:AUTO"); // autoscale the trace

            formattedIO.WriteLine("SENSe:X?");
            frequency = formattedIO.ReadLineListOfDouble();
            //Console.WriteLine(string.Format("Frequency points: {0}", frequency.Length));
            //for (int i = 0; i < frequency.Length; i++)
            //{ Console.WriteLine(frequency[i]); }

            formattedIO.WriteLine(string.Format("CALCulate:DATA? {0}", "SDATA")); // get real and imaginary values
            raw = formattedIO.ReadLineListOfDouble();
            //Console.WriteLine(string.Format("Raw points: {0}", raw.Length));
            //for (int i = 0; i < raw.Length; i++)
            //{ Console.WriteLine(raw[i]); }

            real = new double[raw.Length / 2];
            imaginary = new double[raw.Length / 2];
            for (int index = 0; index < real.Length; index++)
            {
                real[index] = raw[index * 2];
                imaginary[index] = raw[index * 2 + 1];
            }

            measurement.frequency = frequency;
            measurement.real = real;
            measurement.imaginary = imaginary;

            return true;
        }

        public override bool Abort()
        {
            formattedIO.WriteLine("ABORt");
            return true;
        }

        public override bool SetSParameter(string sparam)
        {
            if (sparam.Equals("S11") || sparam.Equals("S12") || sparam.Equals("S21") || sparam.Equals("S22"))
            {
                formattedIO.WriteLine("CALCulate:PARameter:DELete:ALL");
                //formattedIO.WriteLine(string.Format("CALCulate:PARameter:DELete '{0}'", Mname));
                formattedIO.WriteLine(string.Format("CALCulate:PARameter:DEFine '{0}',{1}", Mname, sparam));
                formattedIO.WriteLine(string.Format("DISPlay:WINDow:TRACe:FEED '{0}'", Mname));
                formattedIO.WriteLine(string.Format("CALCulate:PARameter:SELect '{0}'", Mname));
                instrument.sParameter = sparam;
            }
            return true;
        }
        public override bool SetSourcePower(double power)
        {
            // Set source power
            double sourcePower;
            formattedIO.WriteLine(string.Format("SOUR:POW:LEV:IMM:AMPL {0}", power));
            //formattedIO.WriteLine(string.Format("SENSe:POWer:ATTenuation AREC,{0}", power));
            formattedIO.WriteLine("SOUR:POW:LEV:IMM:AMPL?");
            //formattedIO.WriteLine("SENSe:POWer:ATTenuation?");
            sourcePower = formattedIO.ReadLineDouble();
            instrument.sourcePower = sourcePower;
            return true;
        }
        public override bool SetStartFrequency(double freq)
        {
            // Set the start frequency for the current sweep (lower limit)
            double startFrequency;
            formattedIO.WriteLine(string.Format("SENSe:FREQuency:STARt {0}", freq));
            formattedIO.WriteLine("SENSe:FREQuency:STARt?");
            startFrequency = formattedIO.ReadLineDouble();
            instrument.startFrequency = startFrequency;
            return true;
        }
        public override bool SetStopFrequency(double freq)
        {
            // Set the stop frequency for the current sweep (upper limit)
            double stopFrequency;
            formattedIO.WriteLine(string.Format("SENSe:FREQuency:STOP {0}", freq));
            formattedIO.WriteLine("SENSe:FREQuency:STOP?");
            stopFrequency = formattedIO.ReadLineDouble();
            instrument.stopFrequency = stopFrequency;
            return true;
        }
        public override bool SetIFBandwidth(double freq)
        {
            // Set IF Bandwidth
            double ifBandwidth;
            formattedIO.WriteLine(string.Format("SENSe:BANDwidth {0}", freq));
            formattedIO.WriteLine("SENSe:BANDwidth?");
            ifBandwidth = formattedIO.ReadLineDouble();
            instrument.ifBandwidth = ifBandwidth;
            return true;
        }
        public override bool SetSweepPoints(int points)
        {
            // Set the number of data points accumulated in a sweep
            int sweepPoints;
            formattedIO.WriteLine(string.Format("SENSe:SWEep:POINts {0}", points));
            formattedIO.WriteLine("SENSe:SWEep:POINts?");
            sweepPoints = (int)formattedIO.ReadLineDouble();
            instrument.sweepPoints = sweepPoints;
            return true;
        }
        public override bool SetAveragePoints(int points)
        {
            // Set the number of points used to average each data point in a sweep
            int averagePoints;
            formattedIO.WriteLine(string.Format("SENSe:AVERage:COUNt {0}", points));
            formattedIO.WriteLine("SENSe:AVERage:COUNt?");
            averagePoints = (int)formattedIO.ReadLineDouble();
            instrument.averagePoints = averagePoints;
            return true;
        }

        private void InterruptTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                int esr = 0;
                formattedIO.WriteLine("*ESR?");
                esr = (int)formattedIO.ReadLineDouble();
                if (esr != 0)
                {
                    interruptTimer.Enabled = false;
                    instrument.CollectData();
                }
            }
            catch
            { Console.WriteLine("Failed to check ESR"); }

        }

        #endregion
    }
}
