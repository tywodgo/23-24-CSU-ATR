using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATRv2
{
    public class Position
    {
        public MainForm mainForm;
        public FileManager settings;

        private double _horizontal;
        public double horizontal
        {
            get { return _horizontal; }
            set
            {
                _horizontal = value;
                UpdateStatusHorizontal();
            }
        }
        private double _vertical;
        public double vertical
        {
            get { return _vertical; }
            set
            {
                _vertical = value;
                UpdateStatusVertical();
            }
        }
        private double _depth;
        public double depth
        {
            get { return _depth; }
            set
            {
                _depth = value;
                UpdateStatusDepth();
            }
        }
        private double _azimuth;
        public double azimuth
        {
            get { return _azimuth; }
            set
            {
                _azimuth = value;
                UpdateStatusAzimuth();
            }
        }
        private double _elevation;
        public double elevation
        {
            get { return _elevation; }
            set
            {
                _elevation = value;
                UpdateStatusElevation();
            }
        }
        private double _polarization;
        public double polarization
        {
            get { return _polarization; }
            set
            {
                _polarization = value;
                UpdateStatusPolarization();
            }
        }

        public Position(MainForm mainForm, FileManager settings)
        {
            this.mainForm = mainForm;
            this.settings = settings;
            LoadSettings(0);
        }

        #region Settings
        public void SaveSettings(int i)
        {
            List<object[]> lines = new List<object[]>();
            lines.Add(new object[] { "Horizontal", horizontal });
            lines.Add(new object[] { "Vertical", vertical });
            lines.Add(new object[] { "Depth", depth });
            lines.Add(new object[] { "Azimuth", azimuth });
            lines.Add(new object[] { "Elevation", elevation });
            lines.Add(new object[] { "Polarization", polarization });
            settings.Write(lines);
        }
        public void LoadSettings(int i)
        {
            List<string[]> lines = settings.Read();
            if (lines.Any())
            {
                foreach (string[] line in lines)
                {
                    if (line[0].Equals("Horizontal")) { horizontal = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Vertical")) { vertical = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Depth")) { depth = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Azimuth")) { azimuth = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Elevation")) { elevation = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Polarization")) { polarization = Convert.ToDouble(line[1]); }
                }
            }
            else
            {
                SaveSettings(0);
            }
        }
        #endregion

        #region GUI Updates
        // Horizontal
        public void UpdateStatusHorizontal()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusHorizontal(); })); }
            else { _UpdateStatusHorizontal(); }
        }
        private void _UpdateStatusHorizontal() { mainForm.statusHorizontal.Text = horizontal.ToString("N2"); }
        // Vertical
        public void UpdateStatusVertical()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusVertical(); })); }
            else { _UpdateStatusVertical(); }
        }
        private void _UpdateStatusVertical() { mainForm.statusVertical.Text = vertical.ToString("N2"); }
        // Depth
        public void UpdateStatusDepth()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusDepth(); })); }
            else { _UpdateStatusDepth(); }
        }
        private void _UpdateStatusDepth() { mainForm.statusDepth.Text = depth.ToString("N2"); }
        // Azimuth
        public void UpdateStatusAzimuth()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusAzimuth(); })); }
            else { _UpdateStatusAzimuth(); }
        }
        private void _UpdateStatusAzimuth() { mainForm.statusAzimuth.Text = azimuth.ToString("N2"); }
        // Elevation
        public void UpdateStatusElevation()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusElevation(); })); }
            else { _UpdateStatusElevation(); }
        }
        private void _UpdateStatusElevation() { mainForm.statusElevation.Text = elevation.ToString("N2"); }
        // Polarization
        public void UpdateStatusPolarization()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusPolarization(); })); }
            else { _UpdateStatusPolarization(); }
        }
        private void _UpdateStatusPolarization() { mainForm.statusPolarization.Text = polarization.ToString("N2"); }
        #endregion
    }
}
