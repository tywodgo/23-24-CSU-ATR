using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATR
{
    // Container for ATR Data
    public class Point
    {
        #region Position Parameters
        public float polarization;
        public float vertical;
        public float horizontal;
        public float depth;
        public float azimuth;
        public float elevation;
        #endregion

        #region Network Analyzer Parameters
        public string mode;
        public double sourcePower;
        public int pointAvgQuantity;
        #endregion

        #region Response Parameters
        public double[] frequency;
        public double[] real;
        public double[] imag;
        public double[] mag;
        public double[] phase;
        #endregion

        #region Constructors
        public Point(
            string type,
            float polarization,
            float vertical,
            float horizontal,
            float depth,
            float azimuth,
            float elevation,
            string mode,
            double sourcePower,
            int pointAvgQuantity,
            double[] frequency,
            double[] set1,
            double[] set2)
        {
            this.polarization = polarization;
            this.vertical = vertical;
            this.horizontal = horizontal;
            this.depth = depth;
            this.azimuth = azimuth;
            this.elevation = elevation;
            this.mode = mode;
            this.sourcePower = sourcePower;
            this.pointAvgQuantity = pointAvgQuantity;
            this.frequency = frequency;
            if (type.Equals("mp")) // "mp" magnitude and phase
            {
                mag = set1;
                phase = set2;
                Real();
                Imaginary();
            }
            else // "ri" real and imaginary
            {
                real = set1;
                imag = set2;
                Magnitude();
                Phase();
            }
        }

        public Point(
            float polarization,
            float vertical,
            float horizontal,
            float depth,
            float azimuth,
            float elevation,
            string mode,
            double sourcePower,
            int pointAvgQuantity,
            double[] frequency,
            double[] real,
            double[] imag,
            double[] mag,
            double[] phase)
        {
            this.polarization = polarization;
            this.vertical = vertical;
            this.horizontal = horizontal;
            this.depth = depth;
            this.azimuth = azimuth;
            this.elevation = elevation;
            this.mode = mode;
            this.sourcePower = sourcePower;
            this.pointAvgQuantity = pointAvgQuantity;
            this.frequency = frequency;
            this.real = real;
            this.imag = imag;
            this.mag = mag;
            this.phase = phase;
        }
        #endregion

        #region Conversion Functions
        private void Real()
        {
            // Assumes that Magnitude and Phase data exist
            real = new double[frequency.Length];
            for (int i = 0; i < frequency.Length; i++)
            {
                real[i] = Math.Pow(10, mag[i] / 20) * Math.Cos(phase[i] * Math.PI / 180.0);
            }
        }

        private void Imaginary()
        {
            // Assumes that Magnitude and Phase data exist
            imag = new double[frequency.Length];
            for (int i = 0; i < frequency.Length; i++)
            {
                imag[i] = Math.Pow(10, mag[i] / 20) * Math.Sin(phase[i] * Math.PI / 180.0);
            }
        }

        private void Magnitude()
        {
            // Assumes that Real and Imaginary data exist
            mag = new double[frequency.Length];
            for (int i = 0; i < frequency.Length; i++)
            {
                mag[i] = 20 * Math.Log10( Math.Sqrt(real[i] * real[i] + imag[i] * imag[i]) );
                if (Double.IsNaN(mag[i]) || Double.IsNegativeInfinity(mag[i])) { mag[i] = 0; }
            }
        }

        private void Phase() // in degrees
        {
            // Assumes that Real and Imaginary data exist
            phase = new double[frequency.Length];
            for (int i = 0; i < frequency.Length; i++)
            {
                phase[i] = Math.Atan2(imag[i], real[i]) * 180.0 / Math.PI;
            }
        }
        #endregion
    }
}
