using Agilent.CommandExpert.ScpiNet.AgN99xx_NA_A_06_23;
using NationalInstruments.Visa;
using Ivi.Visa;
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
    public class N99xxA_VISA_NI : CommandSet
    {
        #region Classes
        Instrument instrument;
        ResourceManager rm;
        IVisaSession sesh;
        MessageBasedSession session;
        EventQueueStatus _eventStatus;
        EventQueueStatus eventStatus
        {
            get { return _eventStatus; }
            set
            {
                _eventStatus = value;
                Handler();
            }
        }
        #endregion

        public N99xxA_VISA_NI(Instrument instrument)
        {
            this.instrument = instrument;
            rm = new ResourceManager();
            nickname = "N99xxA_VISA_NI";
        }

        #region Event Functions
        public override bool Connect(string address)
        {
            sesh = rm.Open(address, AccessModes.None, 2000);
            sesh.TimeoutMilliseconds = 2000; // redundant but can be changed
            sesh.EnableEvent(EventType.ServiceRequest);
            session = (MessageBasedSession)sesh;
            //session.ServiceRequest += new EventHandler<VisaEventArgs>(
            //    delegate (object o, VisaEventArgs args)
            //    {
            //        instrument.CollectData();
            //    });
            return true;
        }
        public override bool Disconnect()
        {
            session.Dispose();
            rm.Dispose();
            return true;
        }
        public override bool TestConnection()
        {
            string idn;
            session.RawIO.Write(@"*IDN?");
            idn = session.FormattedIO.ReadString();
            return true;
        }
        public override bool Setup()
        {
            // Setup Instrument Operation
            session.Clear();
            session.RawIO.Write(@"*CLS"); // clear status byte in device
            session.RawIO.Write(@"*RST"); // reset device
            session.RawIO.Write(@"*SRE"); // enable status register

            session.RawIO.Write(":INSTrument:SELect \"NA\""); // set Network Analyzer (NA) mode
            session.RawIO.Write(":SENSe:AVERage:MODE POINt"); // set averaging mode (Point vs. Sweep)

            session.RawIO.Write(":FORMat:DATA REAL,64"); // set data format

            session.RawIO.Write(":DISPlay:WINDow:SPLit D1"); // set display to show 1 trace at a time
            session.RawIO.Write(":CALCulate:PARameter1:SELect"); // set the selected trace
            session.RawIO.Write(":CALCulate:SELected:FORMat MLOGarithmic"); // set display to be logarithmic

            session.RawIO.Write(":INITiate:CONTinuous 0"); // disable continuous scanning

            // Get current instrument characteristics
            string sParameter;
            double sourcePower;
            double startFrequency;
            double stopFrequency;
            double ifBandwidth;
            int sweepPoints;
            int averagePoints;

            session.RawIO.Write(":CALCulate:PARameter:DEFine?");
            sParameter = session.FormattedIO.ReadString().Replace("\n", String.Empty);

            session.RawIO.Write(":SOURce:POWer?");
            sourcePower = session.FormattedIO.ReadDouble();

            session.RawIO.Write(":SENSe:FREQuency:STARt?");
            startFrequency = session.FormattedIO.ReadDouble();

            session.RawIO.Write(":SENSe:FREQuency:STOP?");
            stopFrequency = session.FormattedIO.ReadDouble();

            session.RawIO.Write(":SENSe:BWID?");
            ifBandwidth = session.FormattedIO.ReadDouble();

            session.RawIO.Write(":SENSe:SWEep:POINts?");
            sweepPoints = (int)session.FormattedIO.ReadDouble();

            session.RawIO.Write(":SENSe:AVERage:COUNt?");
            averagePoints = (int)session.FormattedIO.ReadDouble();

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
            session.RawIO.Write(@"*RST"); // reset device
            session.RawIO.Write(@"*OPC");
            session.RawIO.Write(":INITiate:IMMediate"); // run a single sweep
            //session.WaitOnEvent(EventType.ServiceRequest, out eventStatus);
            //session.WaitOnEvent(EventType.ServiceRequest); // ask to wait for sweep to finish
            return true;
        }
        public override bool CollectData(Measurement measurement)
        {
            // collect sweep data
            double[] frequency = null;
            double[] real = null;
            double[] imaginary = null;
            double[] raw = null;

            session.RawIO.Write(":DISPlay:WINDow:TRACe:Y:SCALe:AUTO"); // autoscale the trace
            session.RawIO.Write(":SENSe:FREQuency:DATA?");
            frequency = session.FormattedIO.ReadListOfDouble(1000000);
            session.RawIO.Write(":CALCulate:SELected:DATA:SDATa?");
            raw = session.FormattedIO.ReadListOfDouble(1000000);

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
                session.RawIO.Write(string.Format(":CALCulate:PARameter:DEFine {0}", sparam));
                session.RawIO.Write(":CALCulate:PARameter:DEFine?");
                sParameter = session.FormattedIO.ReadString().Replace("\n", String.Empty);
                instrument.sParameter = sParameter;
            }
            return true;
        }
        public override bool SetSourcePower(double power)
        {
            // Set source power
            double sourcePower;
            session.RawIO.Write(string.Format(":SOURce:POWer {0}", power));
            session.RawIO.Write(":SOURce:POWer?");
            sourcePower = session.FormattedIO.ReadDouble();
            instrument.sourcePower = sourcePower;
            return true;
        }
        public override bool SetStartFrequency(double freq)
        {
            // Set the start frequency for the current sweep (lower limit)
            double startFrequency;
            session.RawIO.Write(string.Format(":SENSe:FREQuency:STARt {0}", freq));
            session.RawIO.Write(":SENSe:FREQuency:STARt?");
            startFrequency = session.FormattedIO.ReadDouble();
            instrument.startFrequency = startFrequency;
            return true;
        }
        public override bool SetStopFrequency(double freq)
        {
            // Set the stop frequency for the current sweep (upper limit)
            double stopFrequency;
            session.RawIO.Write(string.Format(":SENSe:FREQuency:STOP {0}", freq));
            session.RawIO.Write(":SENSe:FREQuency:STOP?");
            stopFrequency = session.FormattedIO.ReadDouble();
            instrument.stopFrequency = stopFrequency;
            return true;
        }
        public override bool SetIFBandwidth(double freq)
        {
            // Set IF Bandwidth
            double ifBandwidth;
            session.RawIO.Write(string.Format(":SENSe:BWID {0}", freq));
            session.RawIO.Write(":SENSe:BWID?");
            ifBandwidth = session.FormattedIO.ReadDouble();
            instrument.ifBandwidth = ifBandwidth;
            return true;
        }
        public override bool SetSweepPoints(int points)
        {
            // Set the number of data points accumulated in a sweep
            int sweepPoints;
            session.RawIO.Write(string.Format(":SENSe:SWEep:POINts {0}", points));
            session.RawIO.Write(":SENSe:SWEep:POINts?");
            sweepPoints = (int)session.FormattedIO.ReadDouble();
            instrument.sweepPoints = sweepPoints;
            return true;
        }
        public override bool SetAveragePoints(int points)
        {
            // Set the number of points used to average each data point in a sweep
            int averagePoints;
            session.RawIO.Write(string.Format(":SENSe:AVERage:COUNt {0}", points));
            session.RawIO.Write(":SENSe:AVERage:COUNt?");
            averagePoints = (int)session.FormattedIO.ReadDouble();
            instrument.averagePoints = averagePoints;
            return true;
        }

        private void Handler()
        {
            instrument.CollectData();
        }

        #endregion
    }
}
