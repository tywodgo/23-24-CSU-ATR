using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATRv2
{
    public class Motors
    {
        public Terminal terminal;
        public FileManager settings;

        #region Modeling Parameters
        #region Bounds
        public double[] alphaBounds = { -10000, 10000 };
        public double[] betaBounds = { -10000, 10000 };
        public double[] gammaBounds = { -10000, 10000 };
        #endregion
        #region Alpha
        public double alphaH { get; set; } = 500;
        public double alphaV { get; set; } = 500;
        public double alphaD { get; set; } = 500;
        public double alphaA { get; set; } = 500;
        public double alphaE { get; set; } = 80;
        public double alphaP { get; set; } = 80;
        #endregion
        #region Beta
        public double betaH { get; set; } = 10000;
        public double betaV { get; set; } = 10000;
        public double betaD { get; set; } = 10000;
        public double betaA { get; set; } = 10000;
        public double betaE { get; set; } = 10000;
        public double betaP { get; set; } = 10000;
        #endregion
        #region Gamma
        public double gammaH { get; set; } = 1.0;
        public double gammaV { get; set; } = 8.1;
        public double gammaD { get; set; } = 0.9;
        public double gammaA { get; set; } = 12.75;
        public double gammaE { get; set; } = 9.075;
        public double gammaP { get; set; } = 8.7;
        #endregion
        #endregion
        #region Motion Start Position
        public double startHorizontal { get; set; } = 0;
        public double startVertical { get; set; } = 0;
        public double startDepth { get; set; } = 0;
        public double startAzimuth { get; set; } = 0;
        public double startElevation { get; set; } = 0;
        public double startPolarization { get; set; } = 0;
        #endregion

        public Motors(Terminal terminal, FileManager settings)
        {
            this.terminal = terminal;
            this.settings = settings;
            LoadSettings(0);
        }

        public void SetStartPosition(char motor, double pos)
        {
            if (motor == 'H') { startHorizontal = pos; }
            else if (motor == 'V') { startVertical = pos; }
            else if (motor == 'D') { startDepth = pos; }
            else if (motor == 'A') { startAzimuth = pos; }
            else if (motor == 'E') { startElevation = pos; }
            else if (motor == 'P') { startPolarization = pos; }
        }

        public double Alpha(char motor)
        {
            double alpha = 0;
            if (motor == 'H') { alpha = alphaH; }
            else if (motor == 'V') { alpha = alphaV; }
            else if (motor == 'D') { alpha = alphaD; }
            else if (motor == 'A') { alpha = alphaA; }
            else if (motor == 'E') { alpha = alphaE; }
            else if (motor == 'P') { alpha = alphaP; }
            return alpha;
        }
        public double Beta(char motor)
        {
            double beta = 0;
            if (motor == 'H') { beta = betaH; }
            else if (motor == 'V') { beta = betaV; }
            else if (motor == 'D') { beta = betaD; }
            else if (motor == 'A') { beta = betaA; }
            else if (motor == 'E') { beta = betaE; }
            else if (motor == 'P') { beta = betaP; }
            return beta;
        }
        public double Gamma(char motor)
        {
            double gamma = 0;
            if (motor == 'H') { gamma = gammaH; }
            else if (motor == 'V') { gamma = gammaV; }
            else if (motor == 'D') { gamma = gammaD; }
            else if (motor == 'A') { gamma = gammaA; }
            else if (motor == 'E') { gamma = gammaE; }
            else if (motor == 'P') { gamma = gammaP; }
            return gamma;
        }

        public double CalculatePosition(char motor, char direction, double quantity)
        {
            int dir = 1;
            if (direction == 'N') { dir = -1; }
            double pos = 0;
            if (motor == 'H')
            {
                pos = startHorizontal + dir * quantity;
            }
            else if (motor == 'V')
            {
                pos = startVertical + dir * quantity;
            }
            else if (motor == 'D')
            {
                pos = startDepth + dir * quantity;
            }
            else if (motor == 'A')
            {
                pos = startAzimuth + dir * quantity;
            }
            else if (motor == 'E')
            {
                pos = startElevation + dir * quantity;
            }
            else if (motor == 'P')
            {
                pos = startPolarization + dir * quantity;
            }
            return pos;
        }

        #region Settings
        public void CheckValues()
        {
            bool modified = false;
            if (alphaH < alphaBounds[0]) { alphaH = alphaBounds[0]; modified = true; }
            if (alphaH > alphaBounds[1]) { alphaH = alphaBounds[1]; modified = true; }
            if (alphaV < alphaBounds[0]) { alphaV = alphaBounds[0]; modified = true; }
            if (alphaV > alphaBounds[1]) { alphaV = alphaBounds[1]; modified = true; }
            if (alphaD < alphaBounds[0]) { alphaD = alphaBounds[0]; modified = true; }
            if (alphaD > alphaBounds[1]) { alphaD = alphaBounds[1]; modified = true; }
            if (alphaA < alphaBounds[0]) { alphaA = alphaBounds[0]; modified = true; }
            if (alphaA > alphaBounds[1]) { alphaA = alphaBounds[1]; modified = true; }
            if (alphaE < alphaBounds[0]) { alphaE = alphaBounds[0]; modified = true; }
            if (alphaE > alphaBounds[1]) { alphaE = alphaBounds[1]; modified = true; }
            if (alphaP < alphaBounds[0]) { alphaP = alphaBounds[0]; modified = true; }
            if (alphaP > alphaBounds[1]) { alphaP = alphaBounds[1]; modified = true; }

            if (betaH < betaBounds[0]) { betaH = betaBounds[0]; modified = true; }
            if (betaH > betaBounds[1]) { betaH = betaBounds[1]; modified = true; }
            if (betaV < betaBounds[0]) { betaV = betaBounds[0]; modified = true; }
            if (betaV > betaBounds[1]) { betaV = betaBounds[1]; modified = true; }
            if (betaD < betaBounds[0]) { betaD = betaBounds[0]; modified = true; }
            if (betaD > betaBounds[1]) { betaD = betaBounds[1]; modified = true; }
            if (betaA < betaBounds[0]) { betaA = betaBounds[0]; modified = true; }
            if (betaA > betaBounds[1]) { betaA = betaBounds[1]; modified = true; }
            if (betaE < betaBounds[0]) { betaE = betaBounds[0]; modified = true; }
            if (betaE > betaBounds[1]) { betaE = betaBounds[1]; modified = true; }
            if (betaP < betaBounds[0]) { betaP = betaBounds[0]; modified = true; }
            if (betaP > betaBounds[1]) { betaP = betaBounds[1]; modified = true; }

            if (gammaH < gammaBounds[0]) { gammaH = gammaBounds[0]; modified = true; }
            if (gammaH > gammaBounds[1]) { gammaH = gammaBounds[1]; modified = true; }
            if (gammaV < gammaBounds[0]) { gammaV = gammaBounds[0]; modified = true; }
            if (gammaV > gammaBounds[1]) { gammaV = gammaBounds[1]; modified = true; }
            if (gammaD < gammaBounds[0]) { gammaD = gammaBounds[0]; modified = true; }
            if (gammaD > gammaBounds[1]) { gammaD = gammaBounds[1]; modified = true; }
            if (gammaA < gammaBounds[0]) { gammaA = gammaBounds[0]; modified = true; }
            if (gammaA > gammaBounds[1]) { gammaA = gammaBounds[1]; modified = true; }
            if (gammaE < gammaBounds[0]) { gammaE = gammaBounds[0]; modified = true; }
            if (gammaE > gammaBounds[1]) { gammaE = gammaBounds[1]; modified = true; }
            if (gammaP < gammaBounds[0]) { gammaP = gammaBounds[0]; modified = true; }
            if (gammaP > gammaBounds[1]) { gammaP = gammaBounds[1]; modified = true; }

            if (modified == true)
            {
                terminal.Write("Motor settings out of bounds. Settings adjusted and resaved", 3);
                SaveSettings(0);
            }
        }
        public void SaveSettings(int i)
        {
            List<object[]> lines = new List<object[]>();
            lines.Add(new object[] { "Horizontal Alpha", alphaH });
            lines.Add(new object[] { "Vertical Alpha", alphaV });
            lines.Add(new object[] { "Depth Alpha", alphaD });
            lines.Add(new object[] { "Azimuth Alpha", alphaA });
            lines.Add(new object[] { "Elevation Alpha", alphaE });
            lines.Add(new object[] { "Polarization Alpha", alphaP });

            lines.Add(new object[] { "Horizontal Beta", betaH });
            lines.Add(new object[] { "Vertical Beta", betaV });
            lines.Add(new object[] { "Depth Beta", betaD });
            lines.Add(new object[] { "Azimuth Beta", betaA });
            lines.Add(new object[] { "Elevation Beta", betaE });
            lines.Add(new object[] { "Polarization Beta", betaP });

            lines.Add(new object[] { "Horizontal Gamma", gammaH });
            lines.Add(new object[] { "Vertical Gamma", gammaV });
            lines.Add(new object[] { "Depth Gamma", gammaD });
            lines.Add(new object[] { "Azimuth Gamma", gammaA });
            lines.Add(new object[] { "Elevation Gamma", gammaE });
            lines.Add(new object[] { "Polarization Gamma", gammaP });
            settings.Write(lines);
        }
        public void LoadSettings(int i)
        {
            List<string[]> lines = settings.Read();
            if (lines.Any())
            {
                foreach (string[] line in lines)
                {
                    if (line[0].Equals("Horizontal Alpha")) { alphaH = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Vertical Alpha")) { alphaV = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Depth Alpha")) { alphaD = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Azimuth Alpha")) { alphaA = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Elevation Alpha")) { alphaE = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Polarization Alpha")) { alphaP = Convert.ToDouble(line[1]); }

                    else if (line[0].Equals("Horizontal Beta")) { betaH = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Vertical Beta")) { betaV = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Depth Beta")) { betaD = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Azimuth Beta")) { betaA = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Elevation Beta")) { betaE = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Polarization Beta")) { betaP = Convert.ToDouble(line[1]); }

                    else if (line[0].Equals("Horizontal Gamma")) { gammaH = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Vertical Gamma")) { gammaV = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Depth Gamma")) { gammaD = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Azimuth Gamma")) { gammaA = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Elevation Gamma")) { gammaE = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Polarization Gamma")) { gammaP = Convert.ToDouble(line[1]); }
                }
                CheckValues();
            }
            else
            {
                SaveSettings(0);
            }
        }

        #endregion

    }
}
