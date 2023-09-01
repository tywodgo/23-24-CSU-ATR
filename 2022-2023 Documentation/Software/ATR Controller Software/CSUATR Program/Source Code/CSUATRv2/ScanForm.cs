using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATRv2
{
    public partial class ScanForm : Form
    {
        #region Classes
        FileManager settings;
        Scanner scanner;
        #endregion
        #region Forms
        SaveSettingsForm saveSettingsForm;
        LoadSettingsForm loadSettingsForm;
        #endregion
        #region Flags
        public bool unlockedPolar = false;
        public bool unlockedVertical = false;
        public bool unlockedHorizontal = false;
        public bool unlockedDepth = false;
        public bool unlockedAzimuth = false;
        public bool unlockedElevation = false;
        #endregion
        #region Constants
        decimal KILOHERTZ = 1000;
        decimal MEGAHERTZ = 1000000;
        #endregion

        public ScanForm(FileManager settings, Scanner scanner)
        {
            this.settings = settings;
            this.scanner = scanner;
            InitializeComponent();
            addSave.Checked = true;
            scanType.Items.Clear();
            scanType.Items.AddRange(scanner.scanTypes);
            LoadSettings(0);
            UpdateEnables();
        }

        #region Settings
        public void SaveSettings(int i)
        {
            List<object[]> lines = new List<object[]>();
            lines.Add(new object[] { "Horizontal Unlocked", unlockedHorizontal });
            lines.Add(new object[] { "Vertical Unlocked", unlockedVertical });
            lines.Add(new object[] { "Depth Unlocked", unlockedDepth });
            lines.Add(new object[] { "Azimuth Unlocked", unlockedAzimuth });
            lines.Add(new object[] { "Elevation Unlocked", unlockedElevation });
            lines.Add(new object[] { "Polarization Unlocked", unlockedPolar });

            lines.Add(new object[] { "Horizontal Lower Limit", lowerLimitHorizontal.Value });
            lines.Add(new object[] { "Vertical Lower Limit", lowerLimitVertical.Value });
            lines.Add(new object[] { "Depth Lower Limit", lowerLimitDepth.Value });
            lines.Add(new object[] { "Azimuth Lower Limit", lowerLimitAzimuth.Value });
            lines.Add(new object[] { "Elevation Lower Limit", lowerLimitElevation.Value });
            lines.Add(new object[] { "Polarization Lower Limit", lowerLimitPolar.Value });

            lines.Add(new object[] { "Horizontal Upper Limit", upperLimitHorizontal.Value });
            lines.Add(new object[] { "Vertical Upper Limit", upperLimitVertical.Value });
            lines.Add(new object[] { "Depth Upper Limit", upperLimitDepth.Value });
            lines.Add(new object[] { "Azimuth Upper Limit", upperLimitAzimuth.Value });
            lines.Add(new object[] { "Elevation Upper Limit", upperLimitElevation.Value });
            lines.Add(new object[] { "Polarization Upper Limit", upperLimitPolar.Value });

            lines.Add(new object[] { "Horizontal Resolution", resolutionHorizontal.Value });
            lines.Add(new object[] { "Vertical Resolution", resolutionVertical.Value });
            lines.Add(new object[] { "Depth Resolution", resolutionDepth.Value });
            lines.Add(new object[] { "Azimuth Resolution", resolutionAzimuth.Value });
            lines.Add(new object[] { "Elevation Resolution", resolutionElevation.Value });
            lines.Add(new object[] { "Polarization Resolution", resolutionPolar.Value });

            lines.Add(new object[] { "Scan Type", scanType.Text });

            settings.Write(lines);
        }
        public void LoadSettings(int i)
        {
            List<string[]> lines = settings.Read();
            if (lines.Any())
            {
                foreach (string[] line in lines)
                {
                    if (line[0].Equals("Horizontal Unlocked"))
                    {
                        unlockedHorizontal = Convert.ToBoolean(line[1]);
                        if (unlockedHorizontal == true) { buttonLockHorizontal.Text = "Unlocked"; }
                        else { buttonLockHorizontal.Text = "Locked"; }
                    }
                    if (line[0].Equals("Vertical Unlocked"))
                    {
                        unlockedVertical = Convert.ToBoolean(line[1]);
                        if (unlockedVertical == true) { buttonLockVertical.Text = "Unlocked"; }
                        else { buttonLockVertical.Text = "Locked"; }
                    }
                    if (line[0].Equals("Depth Unlocked"))
                    {
                        unlockedDepth = Convert.ToBoolean(line[1]);
                        if (unlockedDepth == true) { buttonLockDepth.Text = "Unlocked"; }
                        else { buttonLockDepth.Text = "Locked"; }
                    }
                    if (line[0].Equals("Azimuth Unlocked"))
                    {
                        unlockedAzimuth = Convert.ToBoolean(line[1]);
                        if (unlockedAzimuth == true) { buttonLockAzimuth.Text = "Unlocked"; }
                        else { buttonLockAzimuth.Text = "Locked"; }
                    }
                    if (line[0].Equals("Elevation Unlocked"))
                    {
                        unlockedElevation = Convert.ToBoolean(line[1]);
                        if (unlockedElevation == true) { buttonLockElevation.Text = "Unlocked"; }
                        else { buttonLockElevation.Text = "Locked"; }
                    }
                    if (line[0].Equals("Polarization Unlocked"))
                    {
                        unlockedPolar = Convert.ToBoolean(line[1]);
                        if (unlockedPolar == true) { buttonLockPolar.Text = "Unlocked"; }
                        else { buttonLockPolar.Text = "Locked"; }
                    }

                    if (line[0].Equals("Horizontal Lower Limit"))   { lowerLimitHorizontal.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Vertical Lower Limit"))     { lowerLimitVertical.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Depth Lower Limit"))        { lowerLimitDepth.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Azimuth Lower Limit"))      { lowerLimitAzimuth.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Elevation Lower Limit"))    { lowerLimitElevation.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Polarization Lower Limit")) { lowerLimitPolar.Value = Convert.ToDecimal(line[1]); }

                    if (line[0].Equals("Horizontal Upper Limit"))   { upperLimitHorizontal.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Vertical Upper Limit"))     { upperLimitVertical.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Depth Upper Limit"))        { upperLimitDepth.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Azimuth Upper Limit"))      { upperLimitAzimuth.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Elevation Upper Limit"))    { upperLimitElevation.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Polarization Upper Limit")) { upperLimitPolar.Value = Convert.ToDecimal(line[1]); }

                    if (line[0].Equals("Horizontal Resolution"))    { resolutionHorizontal.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Vertical Resolution"))      { resolutionVertical.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Depth Resolution"))         { resolutionDepth.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Azimuth Resolution"))       { resolutionAzimuth.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Elevation Resolution"))     { resolutionElevation.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Polarization Resolution"))  { resolutionPolar.Value = Convert.ToDecimal(line[1]); }

                    if (line[0].Equals("Scan Type")) { scanType.Text = line[1]; }
                }
            }
            else
            {
                SaveSettings(0);
            }
        }
        #endregion
        #region Menu
        private void menuSave_Click(object sender, EventArgs e)
        {
            if (saveSettingsForm != null) { saveSettingsForm.Close(); }
            saveSettingsForm = new SaveSettingsForm(settings, SaveSettings);
            saveSettingsForm.Show();
        }
        private void menuLoad_Click(object sender, EventArgs e)
        {
            if (loadSettingsForm != null) { loadSettingsForm.Close(); }
            loadSettingsForm = new LoadSettingsForm(settings, LoadSettings);
            loadSettingsForm.Show();
        }
        private void menuHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "(1) Scan Type:\n" +
                "     - Single: Takes only one unlocked motor to sweep.\n" +
                "     - Double: Takes only two unlocked motor to sweep.\n" +
                "(2) Resolution: Refers to the largest increment size acceptable for the sweeping motor.",
                "Help - Scan",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
        #endregion
        #region Buttons
        #region Functions
        private void buttonAddEvents_Click(object sender, EventArgs e)
        {
            scanner.Setup(this);
            scanner.AddEvents();
        }
        #endregion
        #region Locks
        private void buttonLockPolar_Click(object sender, EventArgs e)
        {
            if (unlockedPolar == true)
            {
                unlockedPolar = false;
                buttonLockPolar.Text = "Locked";
            }
            else
            {
                unlockedPolar = true;
                buttonLockPolar.Text = "Unlocked";
            }
            UpdateEnables();
        }
        private void buttonLockVertical_Click(object sender, EventArgs e)
        {
            if (unlockedVertical == true)
            {
                unlockedVertical = false;
                buttonLockVertical.Text = "Locked";
            }
            else
            {
                unlockedVertical = true;
                buttonLockVertical.Text = "Unlocked";
            }
            UpdateEnables();
        }
        private void buttonLockHorizontal_Click(object sender, EventArgs e)
        {
            if (unlockedHorizontal == true)
            {
                unlockedHorizontal = false;
                buttonLockHorizontal.Text = "Locked";
            }
            else
            {
                unlockedHorizontal = true;
                buttonLockHorizontal.Text = "Unlocked";
            }
            UpdateEnables();
        }
        private void buttonLockDepth_Click(object sender, EventArgs e)
        {
            if (unlockedDepth == true)
            {
                unlockedDepth = false;
                buttonLockDepth.Text = "Locked";
            }
            else
            {
                unlockedDepth = true;
                buttonLockDepth.Text = "Unlocked";
            }
            UpdateEnables();
        }
        private void buttonLockAzimuth_Click(object sender, EventArgs e)
        {
            if (unlockedAzimuth == true)
            {
                unlockedAzimuth = false;
                buttonLockAzimuth.Text = "Locked";
            }
            else
            {
                unlockedAzimuth = true;
                buttonLockAzimuth.Text = "Unlocked";
            }
            UpdateEnables();
        }
        private void buttonLockElevation_Click(object sender, EventArgs e)
        {
            if (unlockedElevation == true)
            {
                unlockedElevation = false;
                buttonLockElevation.Text = "Locked";
            }
            else
            {
                unlockedElevation = true;
                buttonLockElevation.Text = "Unlocked";
            }
            UpdateEnables();
        }
        #endregion
        #endregion

        public void UpdateEnables()
        {
            if (unlockedPolar == true) { lowerLimitPolar.Enabled = true; upperLimitPolar.Enabled = true; resolutionPolar.Enabled = true; }
            else { lowerLimitPolar.Enabled = false; upperLimitPolar.Enabled = false; resolutionPolar.Enabled = false; }

            if (unlockedVertical == true) { lowerLimitVertical.Enabled = true; upperLimitVertical.Enabled = true; resolutionVertical.Enabled = true; }
            else { lowerLimitVertical.Enabled = false; upperLimitVertical.Enabled = false; resolutionVertical.Enabled = false; }

            if (unlockedHorizontal == true) { lowerLimitHorizontal.Enabled = true; upperLimitHorizontal.Enabled = true; resolutionHorizontal.Enabled = true; }
            else { lowerLimitHorizontal.Enabled = false; upperLimitHorizontal.Enabled = false; resolutionHorizontal.Enabled = false; }

            if (unlockedDepth == true) { lowerLimitDepth.Enabled = true; upperLimitDepth.Enabled = true; resolutionDepth.Enabled = true; }
            else { lowerLimitDepth.Enabled = false; upperLimitDepth.Enabled = false; resolutionDepth.Enabled = false; }

            if (unlockedAzimuth == true) { lowerLimitAzimuth.Enabled = true; upperLimitAzimuth.Enabled = true; resolutionAzimuth.Enabled = true; }
            else { lowerLimitAzimuth.Enabled = false; upperLimitAzimuth.Enabled = false; resolutionAzimuth.Enabled = false; }

            if (unlockedElevation == true) { lowerLimitElevation.Enabled = true; upperLimitElevation.Enabled = true; resolutionElevation.Enabled = true; }
            else { lowerLimitElevation.Enabled = false; upperLimitElevation.Enabled = false; resolutionElevation.Enabled = false; }
        }
    }
}
