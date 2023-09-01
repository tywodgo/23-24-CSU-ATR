using Agilent.CommandExpert.ScpiNet.AgN99xx_NA_A_06_23;
using Ivi.Visa.Interop;
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
    public class N99xxA_VISA_Keysight : CommandSet
    {
        #region Classes
        Instrument instrument;
        ResourceManager rm;
        FormattedIO488 session;
        //AgN99xx_NA agN99Xx_NA;

        private System.Timers.Timer sweepTimer;
        private double sweepTime = 1000; // default value (milliseconds)
        #endregion

        public N99xxA_VISA_Keysight(Instrument instrument)
        {
            this.instrument = instrument;
            rm = new ResourceManager();
            session = new FormattedIO488();
            nickname = "N99xxA_VISA";
            
            sweepTimer = new System.Timers.Timer(sweepTime);
            sweepTimer.Elapsed += SweepTimer_Elapsed;
            sweepTimer.Enabled = false;
            sweepTimer.AutoReset = false;
        }

        #region Event Functions
        public override bool Connect(string address)
        {
            session.IO = (IMessage)rm.Open(address, AccessMode.NO_LOCK, 2000, null);
            session.IO.Timeout = 10000; // redundant but can be changed
            //agN99Xx_NA = new AgN99xx_NA(address);
            return true;
        }
        public override bool Disconnect()
        {
            session.IO.Close();
            session.IO = null;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(session);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(rm);
            //agN99Xx_NA = null;
            return true;
        }
        public override bool TestConnection()
        {
            string idn;
            session.WriteString(@"*IDN?");
            idn = session.ReadString();
            //agN99Xx_NA.SCPI.IDN.Query(out idn);
            return true;
        }

        public override bool Setup()
        {
            // Setup Instrument Operation
            session.IO.Clear();
            session.WriteString("*CLS");
            session.WriteString("*RST");
            //agN99Xx_NA.SCPI.CLS.Command(); // clear status byte in device
            //agN99Xx_NA.SCPI.RST.Command(); // reset device

            session.WriteString(":INSTrument:SELect \"NA\"");
            session.WriteString(":SENSe:AVERage:MODE POINt");
            //agN99Xx_NA.SCPI.INSTrument.SELect.Command("NA");    // set Network Analyzer (NA) mode
            //agN99Xx_NA.SCPI.SENSe.AVERage.MODE.Command("POINt");// set averaging mode (Point vs. Sweep)

            session.WriteString(":FORMat:DATA REAL,64");
            //agN99Xx_NA.SCPI.FORMat.DATA.Command("REAL", 64);// set data format

            session.WriteString(":DISPlay:WINDow:SPLit D1");
            session.WriteString(":CALCulate:PARameter1:SELect");
            session.WriteString(":CALCulate:SELected:FORMat MLOGarithmic");
            //agN99Xx_NA.SCPI.DISPlay.WINDow.SPLit.Command("D1");     // set display to show 1 trace at a time
            //agN99Xx_NA.SCPI.CALCulate.PARameter.SELect.Command(1u); // set the selected trace
            //agN99Xx_NA.SCPI.CALCulate.SELected.FORMat.Command("MLOGarithmic"); // set display to be logarithmic

            session.WriteString(":INITiate:CONTinuous 0");
            //agN99Xx_NA.SCPI.INITiate.CONTinuous.Command(false);     // disable continuous scanning

            // Get current instrument characteristics
            string sParameter;
            double sourcePower;
            double startFrequency;
            double stopFrequency;
            double ifBandwidth;
            int sweepPoints;
            int averagePoints;

            session.WriteString(":CALCulate:PARameter:DEFine?");
            sParameter = session.ReadString().Replace("\n", String.Empty);
            //agN99Xx_NA.SCPI.CALCulate.PARameter.DEFine.Query(1u, out sParameter);
            session.WriteString(":SOURce:POWer?");
            sourcePower = session.ReadNumber();
            //agN99Xx_NA.SCPI.SOURce.POWer.Query(out sourcePower);
            session.WriteString(":SENSe:FREQuency:STARt?");
            startFrequency = session.ReadNumber();
            //agN99Xx_NA.SCPI.SENSe.FREQuency.STARt.Query(out startFrequency);
            session.WriteString(":SENSe:FREQuency:STOP?");
            stopFrequency = session.ReadNumber();
            //agN99Xx_NA.SCPI.SENSe.FREQuency.STOP.Query(out stopFrequency);
            session.WriteString(":SENSe:BWID?");
            ifBandwidth = session.ReadNumber();
            //agN99Xx_NA.SCPI.SENSe.BWID.Query(out ifBandwidth);
            session.WriteString(":SENSe:SWEep:POINts?");
            sweepPoints = (int)session.ReadNumber();
            //agN99Xx_NA.SCPI.SENSe.SWEep.POINts.Query(out sweepPoints);
            session.WriteString(":SENSe:AVERage:COUNt?");
            averagePoints = (int)session.ReadNumber();
            //agN99Xx_NA.SCPI.SENSe.AVERage.COUNt.Query(out averagePoints);

            instrument.sParameter = sParameter;
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
            session.WriteString(":INITiate:IMMediate");
            //agN99Xx_NA.SCPI.INITiate.IMMediate.Command(); // run a single sweep
            sweepTime = (1 + 0.007 * instrument.sweepPoints) * 1000;
            sweepTimer.Interval = sweepTime;
            sweepTimer.Stop();
            sweepTimer.Start();
            return true;
        }
        public override bool CollectData(Measurement measurement)
        {
            // collect sweep data
            double[] frequency = null;
            double[] real = null;
            double[] imaginary = null;
            double[] raw = null;

            session.WriteString(":DISPlay:WINDow:TRACe:Y:SCALe:AUTO");
            session.WriteString(":SENSe:FREQuency:DATA?");
            frequency = (double[])session.ReadIEEEBlock(IEEEBinaryType.BinaryType_R8);
            session.WriteString(":CALCulate:SELected:DATA:SDATa?");
            raw = (double[])session.ReadIEEEBlock(IEEEBinaryType.BinaryType_R8);
            //agN99Xx_NA.SCPI.DISPlay.WINDow.TRACe.Y.SCALe.AUTO.Command(null); // autoscale the trace
            //agN99Xx_NA.SCPI.SENSe.FREQuency.DATA.QueryBlockReal64(out frequency);
            //agN99Xx_NA.SCPI.CALCulate.SELected.DATA.SDATa.QueryBlockReal64(out raw);

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

        public override bool SetSParameter(string sparam)
        {
            if (sparam.Equals("S11") || sparam.Equals("S12") || sparam.Equals("S21") || sparam.Equals("S22"))
            {
                string sParameter;
                session.WriteString(string.Format(":CALCulate:PARameter:DEFine {0}", sparam));
                session.WriteString(":CALCulate:PARameter:DEFine?");
                sParameter = session.ReadString().Replace("\n", String.Empty);
                //agN99Xx_NA.SCPI.CALCulate.PARameter.DEFine.Command(1u, sparam);
                //agN99Xx_NA.SCPI.CALCulate.PARameter.DEFine.Query(1u, out sParameter);
                instrument.sParameter = sParameter;
            }
            return true;
        }
        public override bool SetSourcePower(double power)
        {
            // Set source power
            double sourcePower;
            session.WriteString(string.Format(":SOURce:POWer {0}", power));
            session.WriteString(":SOURce:POWer?");
            sourcePower = session.ReadNumber();
            //agN99Xx_NA.SCPI.SOURce.POWer.Command(power);
            //agN99Xx_NA.SCPI.SOURce.POWer.Query(out sourcePower);
            instrument.sourcePower = sourcePower;
            return true;
        }
        public override bool SetStartFrequency(double freq)
        {
            // Set the start frequency for the current sweep (lower limit)
            double startFrequency;
            session.WriteString(string.Format(":SENSe:FREQuency:STARt {0}", freq));
            session.WriteString(":SENSe:FREQuency:STARt?");
            startFrequency = session.ReadNumber();
            //agN99Xx_NA.SCPI.SENSe.FREQuency.STARt.Command(freq);
            //agN99Xx_NA.SCPI.SENSe.FREQuency.STARt.Query(out startFrequency);
            instrument.startFrequency = startFrequency;
            return true;
        }
        public override bool SetStopFrequency(double freq)
        {
            // Set the stop frequency for the current sweep (upper limit)
            double stopFrequency;
            session.WriteString(string.Format(":SENSe:FREQuency:STOP {0}", freq));
            session.WriteString(":SENSe:FREQuency:STOP?");
            stopFrequency = session.ReadNumber();
            //agN99Xx_NA.SCPI.SENSe.FREQuency.STOP.Command(freq);
            //agN99Xx_NA.SCPI.SENSe.FREQuency.STOP.Query(out stopFrequency);
            instrument.stopFrequency = stopFrequency;
            return true;
        }
        public override bool SetIFBandwidth(double freq)
        {
            // Set IF Bandwidth
            double ifBandwidth;
            session.WriteString(string.Format(":SENSe:BWID {0}", freq));
            session.WriteString(":SENSe:BWID?");
            ifBandwidth = session.ReadNumber();
            //agN99Xx_NA.SCPI.SENSe.BWID.Command(freq);
            //agN99Xx_NA.SCPI.SENSe.BWID.Query(out ifBandwidth);
            instrument.ifBandwidth = ifBandwidth;
            return true;
        }
        public override bool SetSweepPoints(int points)
        {
            // Set the number of data points accumulated in a sweep
            int sweepPoints;
            session.WriteString(string.Format(":SENSe:SWEep:POINts {0}", points));
            session.WriteString(":SENSe:SWEep:POINts?");
            sweepPoints = (int)session.ReadNumber();
            //agN99Xx_NA.SCPI.SENSe.SWEep.POINts.Command(points);
            //agN99Xx_NA.SCPI.SENSe.SWEep.POINts.Query(out sweepPoints);
            instrument.sweepPoints = sweepPoints;
            return true;
        }
        public override bool SetAveragePoints(int points)
        {
            // Set the number of points used to average each data point in a sweep
            int averagePoints;
            session.WriteString(string.Format(":SENSe:AVERage:COUNt {0}", points));
            session.WriteString(":SENSe:AVERage:COUNt?");
            averagePoints = (int)session.ReadNumber();
            //agN99Xx_NA.SCPI.SENSe.AVERage.COUNt.Command(points);
            //agN99Xx_NA.SCPI.SENSe.AVERage.COUNt.Query(out averagePoints);
            instrument.averagePoints = averagePoints;
            return true;
        }

        private void SweepTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            instrument.CollectData();
        }

        #endregion
    }
}
