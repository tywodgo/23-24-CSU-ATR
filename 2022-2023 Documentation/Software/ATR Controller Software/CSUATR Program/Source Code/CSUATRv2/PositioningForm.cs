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
    public partial class PositioningForm : Form
    {
        #region Classes
        MainForm mainForm;
        FileManager settings;
        EventManager eventManager;
        Positioner positioner;
        #endregion
        #region Forms
        SaveSettingsForm saveSettingsForm;
        LoadSettingsForm loadSettingsForm;
        #endregion
        #region Flags
        public bool engagedPolar = false;
        public bool engagedVertical = false;
        public bool engagedHorizontal = false;
        public bool engagedDepth = false;
        public bool engagedAzimuth = false;
        public bool engagedElevation = false;
        #endregion

        public PositioningForm(MainForm mainForm, FileManager settings, EventManager eventManager, Positioner positioner)
        {
            this.mainForm = mainForm;
            this.settings = settings;
            this.eventManager = eventManager;
            this.positioner = positioner;
            InitializeComponent();
            addWait.Checked = false;
            LoadSettings(0);
            UpdateEnables();
        }

        #region Settings
        public void SaveSettings(int i)
        {
            List<object[]> lines = new List<object[]>();
            lines.Add(new object[] { "Horizontal Engaged", engagedHorizontal });
            lines.Add(new object[] { "Vertical Engaged", engagedVertical });
            lines.Add(new object[] { "Depth Engaged", engagedDepth });
            lines.Add(new object[] { "Azimuth Engaged", engagedAzimuth });
            lines.Add(new object[] { "Elevation Engaged", engagedElevation });
            lines.Add(new object[] { "Polarization Engaged", engagedPolar });
            lines.Add(new object[] { "Move-To Horizontal", moveToHorizontal.Value });
            lines.Add(new object[] { "Move-To Vertical", moveToVertical.Value });
            lines.Add(new object[] { "Move-To Depth", moveToDepth.Value });
            lines.Add(new object[] { "Move-To Azimuth", moveToAzimuth.Value });
            lines.Add(new object[] { "Move-To Elevation", moveToElevation.Value });
            lines.Add(new object[] { "Move-To Polarization", moveToPolar.Value });
            lines.Add(new object[] { "Move-By Horizontal", moveByHorizontal.Value });
            lines.Add(new object[] { "Move-By Vertical", moveByVertical.Value });
            lines.Add(new object[] { "Move-By Depth", moveByDepth.Value });
            lines.Add(new object[] { "Move-By Azimuth", moveByAzimuth.Value });
            lines.Add(new object[] { "Move-By Elevation", moveByElevation.Value });
            lines.Add(new object[] { "Move-By Polarization", moveByPolar.Value });
            settings.Write(lines);
        }
        public void LoadSettings(int i)
        {
            List<string[]> lines = settings.Read();
            if (lines.Any())
            {
                foreach (string[] line in lines)
                {
                    if (line[0].Equals("Horizontal Engaged"))   { engagedHorizontal = Convert.ToBoolean(line[1]);
                        if (engagedHorizontal == true) { buttonEngageHorizontal.Text = "Engaged"; }
                        else { buttonEngageHorizontal.Text = "Unengaged"; }
                    }
                    if (line[0].Equals("Vertical Engaged"))     { engagedVertical = Convert.ToBoolean(line[1]);
                        if (engagedVertical == true) { buttonEngageVertical.Text = "Engaged"; }
                        else { buttonEngageVertical.Text = "Unengaged"; }
                    }
                    if (line[0].Equals("Depth Engaged"))        { engagedDepth = Convert.ToBoolean(line[1]);
                        if (engagedDepth == true) { buttonEngageDepth.Text = "Engaged"; }
                        else { buttonEngageDepth.Text = "Unengaged"; }
                    }
                    if (line[0].Equals("Azimuth Engaged"))      { engagedAzimuth = Convert.ToBoolean(line[1]);
                        if (engagedAzimuth == true) { buttonEngageAzimuth.Text = "Engaged"; }
                        else { buttonEngageAzimuth.Text = "Unengaged"; }
                    }
                    if (line[0].Equals("Elevation Engaged"))    { engagedElevation = Convert.ToBoolean(line[1]);
                        if (engagedElevation == true) { buttonEngageElevation.Text = "Engaged"; }
                        else { buttonEngageElevation.Text = "Unengaged"; }
                    }
                    if (line[0].Equals("Polarization Engaged")) { engagedPolar = Convert.ToBoolean(line[1]);
                        if (engagedPolar == true) { buttonEngagePolar.Text = "Engaged"; }
                        else { buttonEngagePolar.Text = "Unengaged"; }
                    }

                    if (line[0].Equals("Move-To Horizontal"))   { moveToHorizontal.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Move-To Vertical"))     { moveToVertical.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Move-To Depth"))        { moveToDepth.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Move-To Azimuth"))      { moveToAzimuth.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Move-To Elevation"))    { moveToElevation.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Move-To Polarization")) { moveToPolar.Value = Convert.ToDecimal(line[1]); }

                    if (line[0].Equals("Move-By Horizontal"))   { moveByHorizontal.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Move-By Vertical"))     { moveByVertical.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Move-By Depth"))        { moveByDepth.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Move-By Azimuth"))      { moveByAzimuth.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Move-By Elevation"))    { moveByElevation.Value = Convert.ToDecimal(line[1]); }
                    if (line[0].Equals("Move-By Polarization")) { moveByPolar.Value = Convert.ToDecimal(line[1]); }
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
                "(1) Home: Currently zeros out all motor positions.\n" +
                "(2) Stop: Stop current motor movement.\n" +
                "(3) Move-To: Sends commands to move all enabled motors to specified positions.\n" +
                "(4) Move-By: Sends commands to move all enabled motors by specified amounts.\n" +
                "(5) Add Wait: Adds a wait period (in seconds) before very motor movement.",
                "Help - Positioner",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
        #endregion
        #region Buttons
        #region Functions
        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (addWait.Checked == true && mainForm.addMode.Text.Equals("Push") == false)
            { eventManager.AddEvent(new Function(positioner.WaitTime, new object[] { (double)waitTime.Value })); }
            eventManager.AddEvent(new Function(positioner.MoveToHome, new object[] { }));
            if (addWait.Checked == true && mainForm.addMode.Text.Equals("Push") == true)
            { eventManager.AddEvent(new Function(positioner.WaitTime, new object[] { (double)waitTime.Value })); }
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            positioner.Stop();
        }
        private void buttonMoveTo_Click(object sender, EventArgs e)
        {
            if (addWait.Checked == true && mainForm.addMode.Text.Equals("Push") == false)
            { eventManager.AddEvent(new Function(positioner.WaitTime, new object[] { (double)waitTime.Value })); }
            if (engagedHorizontal == true)
            { eventManager.AddEvent(new Function(positioner.MoveToPosition, new object[] { 'H', (double)moveToHorizontal.Value })); }
            if (engagedVertical == true)
            { eventManager.AddEvent(new Function(positioner.MoveToPosition, new object[] { 'V', (double)moveToVertical.Value })); }
            if (engagedDepth == true)
            { eventManager.AddEvent(new Function(positioner.MoveToPosition, new object[] { 'D', (double)moveToDepth.Value })); }
            if (engagedAzimuth == true)
            { eventManager.AddEvent(new Function(positioner.MoveToPosition, new object[] { 'A', (double)moveToAzimuth.Value })); }
            if (engagedElevation == true)
            { eventManager.AddEvent(new Function(positioner.MoveToPosition, new object[] { 'E', (double)moveToElevation.Value })); }
            if (engagedPolar == true)
            { eventManager.AddEvent(new Function(positioner.MoveToPosition, new object[] { 'P', (double)moveToPolar.Value })); }
            if (addWait.Checked == true && mainForm.addMode.Text.Equals("Push") == true)
            { eventManager.AddEvent(new Function(positioner.WaitTime, new object[] { (double)waitTime.Value })); }
        }
        private void buttonMoveBy_Click(object sender, EventArgs e)
        {
            if (addWait.Checked == true && mainForm.addMode.Text.Equals("Push") == false)
            { eventManager.AddEvent(new Function(positioner.WaitTime, new object[] { (double)waitTime.Value })); }
            if (engagedHorizontal == true)
            { eventManager.AddEvent(new Function(positioner.MoveByAmount, new object[] { 'H', (double)moveByHorizontal.Value })); }
            if (engagedVertical == true)
            { eventManager.AddEvent(new Function(positioner.MoveByAmount, new object[] { 'V', (double)moveByVertical.Value })); }
            if (engagedDepth == true)
            { eventManager.AddEvent(new Function(positioner.MoveByAmount, new object[] { 'D', (double)moveByDepth.Value })); }
            if (engagedAzimuth == true)
            { eventManager.AddEvent(new Function(positioner.MoveByAmount, new object[] { 'A', (double)moveByAzimuth.Value })); }
            if (engagedElevation == true)
            { eventManager.AddEvent(new Function(positioner.MoveByAmount, new object[] { 'E', (double)moveByElevation.Value })); }
            if (engagedPolar == true)
            { eventManager.AddEvent(new Function(positioner.MoveByAmount, new object[] { 'P', (double)moveByPolar.Value })); }
            if (addWait.Checked == true && mainForm.addMode.Text.Equals("Push") == true)
            { eventManager.AddEvent(new Function(positioner.WaitTime, new object[] { (double)waitTime.Value })); }
        }
        #endregion
        #region Engage
        private void buttonEngageHorizontal_Click(object sender, EventArgs e)
        {
            if (engagedHorizontal == true)
            {
                engagedHorizontal = false;
                buttonEngageHorizontal.Text = "Unengaged";
            }
            else
            {
                engagedHorizontal = true;
                buttonEngageHorizontal.Text = "Engaged";
            }
            UpdateEnables();
        }
        private void buttonEngageVertical_Click(object sender, EventArgs e)
        {
            if (engagedVertical == true)
            {
                engagedVertical = false;
                buttonEngageVertical.Text = "Unengaged";
            }
            else
            {
                engagedVertical = true;
                buttonEngageVertical.Text = "Engaged";
            }
            UpdateEnables();
        }
        private void buttonEngageDepth_Click(object sender, EventArgs e)
        {
            if (engagedDepth == true)
            {
                engagedDepth = false;
                buttonEngageDepth.Text = "Unengaged";
            }
            else
            {
                engagedDepth = true;
                buttonEngageDepth.Text = "Engaged";
            }
            UpdateEnables();
        }
        private void buttonEngageAzimuth_Click(object sender, EventArgs e)
        {
            if (engagedAzimuth == true)
            {
                engagedAzimuth = false;
                buttonEngageAzimuth.Text = "Unengaged";
            }
            else
            {
                engagedAzimuth = true;
                buttonEngageAzimuth.Text = "Engaged";
            }
            UpdateEnables();
        }
        private void buttonEngageElevation_Click(object sender, EventArgs e)
        {
            if (engagedElevation == true)
            {
                engagedElevation = false;
                buttonEngageElevation.Text = "Unengaged";
            }
            else
            {
                engagedElevation = true;
                buttonEngageElevation.Text = "Engaged";
            }
            UpdateEnables();
        }
        private void buttonEngagePolar_Click(object sender, EventArgs e)
        {
            if (engagedPolar == true)
            {
                engagedPolar = false;
                buttonEngagePolar.Text = "Unengaged";
            }
            else
            {
                engagedPolar = true;
                buttonEngagePolar.Text = "Engaged";
            }
            UpdateEnables();
        }
        private void addWait_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnables();
        }
        #endregion
        #endregion

        public void UpdateEnables()
        {
            if (engagedPolar == true) { moveToPolar.Enabled = true; moveByPolar.Enabled = true; }
            else { moveToPolar.Enabled = false; moveByPolar.Enabled = false; }

            if (engagedVertical == true) { moveToVertical.Enabled = true; moveByVertical.Enabled = true; }
            else { moveToVertical.Enabled = false; moveByVertical.Enabled = false; }

            if (engagedHorizontal == true) { moveToHorizontal.Enabled = true; moveByHorizontal.Enabled = true; }
            else { moveToHorizontal.Enabled = false; moveByHorizontal.Enabled = false; }

            if (engagedDepth == true) { moveToDepth.Enabled = true; moveByDepth.Enabled = true; }
            else { moveToDepth.Enabled = false; moveByDepth.Enabled = false; }

            if (engagedAzimuth == true) { moveToAzimuth.Enabled = true; moveByAzimuth.Enabled = true; }
            else { moveToAzimuth.Enabled = false; moveByAzimuth.Enabled = false; }

            if (engagedElevation == true) { moveToElevation.Enabled = true; moveByElevation.Enabled = true; }
            else { moveToElevation.Enabled = false; moveByElevation.Enabled = false; }

            if (addWait.Checked == true) { waitTime.Enabled = true; }
            else { waitTime.Enabled = false; }
        }


    }
}
