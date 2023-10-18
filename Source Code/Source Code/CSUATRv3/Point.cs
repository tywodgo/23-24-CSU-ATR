using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class Point
    {
        #region ID Parameter
        public long id;
        #endregion

        #region Position Parameters
        public double horizontal;
        public double vertical;
        public double depth;
        public double azimuth;
        public double elevation;
        public double polarization;
        #endregion

        #region Instrument Parameters
        public string sParameter;
        public double sourcePower;
        public double ifBandwidth;
        public int averagePoints;
        #endregion

        #region Response Parameters
        public double[] frequency;
        public double[] amplitude;
        public double[] magnitude;
        public double[] phase;
        public double[] real;
        public double[] imaginary;
        #endregion

        #region Constructor
        public Point(
            long id,

            double horizontal,
            double vertical,
            double depth,
            double azimuth,
            double elevation,
            double polarization,

            string sParameter,
            double sourcePower,
            double ifBandwidth,
            int averagePoints,

            double[] frequency,
            double[] real,
            double[] imaginary)
        {
            this.id = id;

            this.horizontal = horizontal;
            this.vertical = vertical;
            this.depth = depth;
            this.azimuth = azimuth;
            this.elevation = elevation;
            this.polarization = polarization;

            this.sParameter = sParameter;
            this.sourcePower = sourcePower;
            this.ifBandwidth = ifBandwidth;
            this.averagePoints = averagePoints;

            this.frequency = frequency;
            this.real = real;
            this.imaginary = imaginary;

            Amplitude();
            Magnitude();
            Phase();
        }
        #endregion

        #region Conversion Functions
        private void Amplitude()
        {
            amplitude = new double[frequency.Length];
            for (int i = 0; i < frequency.Length; i++)
            {
                amplitude[i] = Math.Sqrt(real[i] * real[i] + imaginary[i] * imaginary[i]);
                if (
                    double.IsNaN(amplitude[i]) ||
                    double.IsNegativeInfinity(amplitude[i]) ||
                    double.IsInfinity(amplitude[i])) { amplitude[i] = 0; }
            }
        }

        private void Magnitude()
        {
            magnitude = new double[frequency.Length];
            for (int i = 0; i < frequency.Length; i++)
            {
                magnitude[i] = 20 * Math.Log10(Math.Sqrt(real[i] * real[i] + imaginary[i] * imaginary[i]));
                if (
                    double.IsNaN(magnitude[i]) ||
                    double.IsNegativeInfinity(magnitude[i]) ||
                    double.IsInfinity(magnitude[i])) { magnitude[i] = 0; }
            }
        }

        private void Phase() // in degrees
        {
            phase = new double[frequency.Length];
            for (int i = 0; i < frequency.Length; i++)
            {
                phase[i] = Math.Atan2(imaginary[i], real[i]) * 180.0 / Math.PI;
                if (
                    double.IsNaN(phase[i]) ||
                    double.IsNegativeInfinity(phase[i]) ||
                    double.IsInfinity(phase[i])) { phase[i] = 0; }
            }
        }
        #endregion
    }
}
