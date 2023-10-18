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
    public class NetworkAnalyzer
    {
        #region Instrument Parameters
        public string address;
        #endregion

        #region Flags
        public bool connected;
        public bool ready;
        #endregion

        #region Measurement Parameters
        public string mode;
        public decimal sourcePower;
        public decimal startFrequency;
        public decimal stopFrequency;
        public int sweepPoints;
        public int pointAvgQuantity;
        public string idn = null;
        public double[] frequency = null;
        public double[] real = null;
        public double[] imag = null;
        #endregion

        #region Functions
        public virtual void Connect() { }
        public virtual void Disconnect() { }

        public virtual bool Measure() { return false; }

        public virtual bool SetMode(string mode) { return false; }
        public virtual bool SetSourcePower(decimal power) { return false; }
        public virtual bool SetStartFrequency(decimal freq) { return false; }
        public virtual bool SetStopFrequency(decimal freq) { return false; }
        public virtual bool SetSweepPoints(int points) { return false; }
        public virtual bool SetPointAvgQuantity(int points) { return false; }
        #endregion
    }
}
