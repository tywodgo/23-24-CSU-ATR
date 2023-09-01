using Agilent.CommandExpert.ScpiNet.AgN99xx_NA_A_06_23;
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
    public class N99xxA : CommandSet
    {
        #region Classes
        Instrument instrument;
        AgN99xx_NA agN99Xx_NA;

        private System.Timers.Timer interruptTimer;
        private double interruptTime = 250; // default value (milliseconds)
        #endregion

        public N99xxA(Instrument instrument)
        {
            this.instrument = instrument;
            nickname = "N99xxA";

            interruptTimer = new System.Timers.Timer(interruptTime);
            interruptTimer.Elapsed += InterruptTimer_Elapsed;
            interruptTimer.Enabled = false;
            interruptTimer.AutoReset = true;
        }

        #region Event Functions
        public override bool Connect(string address)
        {
            agN99Xx_NA = new AgN99xx_NA(address);
            return true;
        }
        public override bool Disconnect()
        {
            agN99Xx_NA = null;
            return true;
        }
        public override bool TestConnection()
        {
            string idn;
            agN99Xx_NA.SCPI.IDN.Query(out idn);
            return true;
        }

        public override bool Setup()
        {
            // Setup Instrument Operation
            agN99Xx_NA.SCPI.RST.Command(); // reset device
            agN99Xx_NA.SCPI.CLS.Command(); // clear status byte in device

            agN99Xx_NA.SCPI.INSTrument.SELect.Command("NA");    // set Network Analyzer (NA) mode
            agN99Xx_NA.SCPI.SENSe.AVERage.MODE.Command("POINt");// set averaging mode (Point vs. Sweep)

            agN99Xx_NA.SCPI.FORMat.DATA.Command("REAL", 64);// set data format

            agN99Xx_NA.SCPI.DISPlay.WINDow.SPLit.Command("D1");     // set display to show 1 trace at a time
            agN99Xx_NA.SCPI.CALCulate.PARameter.SELect.Command(1u); // set the selected trace
            agN99Xx_NA.SCPI.CALCulate.SELected.FORMat.Command("MLOGarithmic"); // set display to be logarithmic

            agN99Xx_NA.SCPI.INITiate.CONTinuous.Command(false);     // disable continuous scanning

            // Get current instrument characteristics
            string sParameter;
            double sourcePower;
            double startFrequency;
            double stopFrequency;
            double ifBandwidth;
            int sweepPoints;
            int averagePoints;
            agN99Xx_NA.SCPI.CALCulate.PARameter.DEFine.Query(1u, out sParameter);
            agN99Xx_NA.SCPI.SOURce.POWer.Query(out sourcePower);
            agN99Xx_NA.SCPI.SENSe.FREQuency.STARt.Query(out startFrequency);
            agN99Xx_NA.SCPI.SENSe.FREQuency.STOP.Query(out stopFrequency);
            agN99Xx_NA.SCPI.SENSe.BWID.Query(out ifBandwidth);
            agN99Xx_NA.SCPI.SENSe.SWEep.POINts.Query(out sweepPoints);
            agN99Xx_NA.SCPI.SENSe.AVERage.COUNt.Query(out averagePoints);
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
            agN99Xx_NA.SCPI.INITiate.IMMediate.Command(); // run a single sweep
            agN99Xx_NA.SCPI.OPC.Command();
            interruptTimer.Enabled = true;
            return true;
        }
        public override bool CollectData(Measurement measurement)
        {
            // collect sweep data
            double[] frequency = null;
            double[] real = null;
            double[] imaginary = null;
            double[] raw = null;

            agN99Xx_NA.SCPI.DISPlay.WINDow.TRACe.Y.SCALe.AUTO.Command(null); // autoscale the trace
            agN99Xx_NA.SCPI.SENSe.FREQuency.DATA.QueryBlockReal64(out frequency);
            agN99Xx_NA.SCPI.CALCulate.SELected.DATA.SDATa.QueryBlockReal64(out raw);
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
            return Setup();
        }

        public override bool SetSParameter(string sparam)
        {
            if (sparam.Equals("S11") || sparam.Equals("S12") || sparam.Equals("S21") || sparam.Equals("S22"))
            {
                string sParameter;
                agN99Xx_NA.SCPI.CALCulate.PARameter.DEFine.Command(1u, sparam);
                agN99Xx_NA.SCPI.CALCulate.PARameter.DEFine.Query(1u, out sParameter);
                instrument.sParameter = sParameter;
            }
            return true;
        }
        public override bool SetSourcePower(double power)
        {
            // Set source power
            double sourcePower;
            agN99Xx_NA.SCPI.SOURce.POWer.Command(power);
            agN99Xx_NA.SCPI.SOURce.POWer.Query(out sourcePower);
            instrument.sourcePower = sourcePower;
            return true;
        }
        public override bool SetStartFrequency(double freq)
        {
            // Set the start frequency for the current sweep (lower limit)
            double startFrequency;
            agN99Xx_NA.SCPI.SENSe.FREQuency.STARt.Command(freq);
            agN99Xx_NA.SCPI.SENSe.FREQuency.STARt.Query(out startFrequency);
            instrument.startFrequency = startFrequency;
            return true;
        }
        public override bool SetStopFrequency(double freq)
        {
            // Set the stop frequency for the current sweep (upper limit)
            double stopFrequency;
            agN99Xx_NA.SCPI.SENSe.FREQuency.STOP.Command(freq);
            agN99Xx_NA.SCPI.SENSe.FREQuency.STOP.Query(out stopFrequency);
            instrument.stopFrequency = stopFrequency;
            return true;
        }
        public override bool SetIFBandwidth(double freq)
        {
            // Set IF Bandwidth
            double ifBandwidth;
            agN99Xx_NA.SCPI.SENSe.BWID.Command(freq);
            agN99Xx_NA.SCPI.SENSe.BWID.Query(out ifBandwidth);
            instrument.ifBandwidth = ifBandwidth;
            return true;
        }
        public override bool SetSweepPoints(int points)
        {
            // Set the number of data points accumulated in a sweep
            int sweepPoints;
            agN99Xx_NA.SCPI.SENSe.SWEep.POINts.Command(points);
            agN99Xx_NA.SCPI.SENSe.SWEep.POINts.Query(out sweepPoints);
            instrument.sweepPoints = sweepPoints;
            return true;
        }
        public override bool SetAveragePoints(int points)
        {
            // Set the number of points used to average each data point in a sweep
            int averagePoints;
            agN99Xx_NA.SCPI.SENSe.AVERage.COUNt.Command(points);
            agN99Xx_NA.SCPI.SENSe.AVERage.COUNt.Query(out averagePoints);
            instrument.averagePoints = averagePoints;
            return true;
        }

        private void InterruptTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                int esr = 0;
                agN99Xx_NA.SCPI.ESR.Query(out esr);
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
