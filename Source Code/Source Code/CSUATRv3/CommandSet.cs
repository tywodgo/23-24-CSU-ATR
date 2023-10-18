using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class CommandSet
    {
        #region Instrument Parameters
        public string nickname;
        #endregion

        #region Event Functions
        public virtual bool Connect(string address) { return false; }
        public virtual bool Disconnect() { return false; }
        public virtual bool TestConnection() { return false; }

        public virtual bool Setup() { return false; }

        public virtual bool Measure() { return false; }
        public virtual bool CollectData(Measurement measurement) { return false; }

        public virtual bool SetSParameter(string sparam) { return false; }
        public virtual bool SetSourcePower(double power) { return false; }
        public virtual bool SetStartFrequency(double freq) { return false; }
        public virtual bool SetStopFrequency(double freq) { return false; }
        public virtual bool SetIFBandwidth(double freq) { return false; }
        public virtual bool SetSweepPoints(int points) { return false; }
        public virtual bool SetAveragePoints(int points) { return false; }
        #endregion
        

    }
}
