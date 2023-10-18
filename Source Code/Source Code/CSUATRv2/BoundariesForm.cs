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
    public partial class BoundariesForm : Form
    {
        private Positioner positioner;

        private SaveSettingsForm saveSettingsForm;
        private LoadSettingsForm loadSettingsForm;

        public BoundariesForm(Positioner positioner)
        {
            this.positioner = positioner;
            InitializeComponent();
            SetCurrentValues();
        }

        #region Set Parameters
        private void SetCurrentValues()
        {
            try
            {
                if (positioner.enforceBoundaries == true) { checkBoxEnforceBounds.Checked = true; }
                else { checkBoxEnforceBounds.Checked = false; }

                lowerHorizontal.Value = (decimal)positioner.lowerHorizontal;
                lowerVertical.Value = (decimal)positioner.lowerVertical;
                lowerDepth.Value = (decimal)positioner.lowerDepth;
                lowerAzimuth.Value = (decimal)positioner.lowerAzimuth;
                lowerElevation.Value = (decimal)positioner.lowerElevation;
                lowerPolarization.Value = (decimal)positioner.lowerPolarization;

                upperHorizontal.Value = (decimal)positioner.upperHorizontal;
                upperVertical.Value = (decimal)positioner.upperVertical;
                upperDepth.Value = (decimal)positioner.upperDepth;
                upperAzimuth.Value = (decimal)positioner.upperAzimuth;
                upperElevation.Value = (decimal)positioner.upperElevation;
                upperPolarization.Value = (decimal)positioner.upperPolarization;
            }
            catch
            {
                MessageBox.Show("Boundaries form failed to load. Check current boundary settings values and restart program");
            }

        }
        #endregion
        #region Values Changed
        private void checkBoxEnforceBounds_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnforceBounds.Checked == true) { positioner.enforceBoundaries = true; }
            else { positioner.enforceBoundaries = false; }
        }

        private void lowerHorizontal_ValueChanged(object sender, EventArgs e)
        {
            positioner.lowerHorizontal = (double)lowerHorizontal.Value;
        }
        private void lowerVertical_ValueChanged(object sender, EventArgs e)
        {
            positioner.lowerVertical = (double)lowerVertical.Value;
        }
        private void lowerDepth_ValueChanged(object sender, EventArgs e)
        {
            positioner.lowerDepth = (double)lowerDepth.Value;
        }
        private void lowerAzimuth_ValueChanged(object sender, EventArgs e)
        {
            positioner.lowerAzimuth = (double)lowerAzimuth.Value;
        }
        private void lowerElevation_ValueChanged(object sender, EventArgs e)
        {
            positioner.lowerElevation = (double)lowerElevation.Value;
        }
        private void lowerPolarization_ValueChanged(object sender, EventArgs e)
        {
            positioner.lowerPolarization = (double)lowerPolarization.Value;
        }

        private void upperHorizontal_ValueChanged(object sender, EventArgs e)
        {
            positioner.upperHorizontal = (double)upperHorizontal.Value;
        }
        private void upperVertical_ValueChanged(object sender, EventArgs e)
        {
            positioner.upperVertical = (double)upperVertical.Value;
        }
        private void upperDepth_ValueChanged(object sender, EventArgs e)
        {
            positioner.upperDepth = (double)upperDepth.Value;
        }
        private void upperAzimuth_ValueChanged(object sender, EventArgs e)
        {
            positioner.upperAzimuth = (double)upperAzimuth.Value;
        }
        private void upperElevation_ValueChanged(object sender, EventArgs e)
        {
            positioner.upperElevation = (double)upperElevation.Value;
        }
        private void upperPolarization_ValueChanged(object sender, EventArgs e)
        {
            positioner.upperPolarization = (double)upperPolarization.Value;
        }
        #endregion
        #region Menu
        private void menuSave_Click(object sender, EventArgs e)
        {
            if (saveSettingsForm != null) { saveSettingsForm.Close(); }
            saveSettingsForm = new SaveSettingsForm(positioner.settings, positioner.SaveSettings);
            saveSettingsForm.Show();
        }
        private void menuLoad_Click(object sender, EventArgs e)
        {
            if (loadSettingsForm != null) { loadSettingsForm.Close(); }
            loadSettingsForm = new LoadSettingsForm(positioner.settings, positioner.LoadSettings);
            loadSettingsForm.Show();
        }
        private void menuHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Edits to values in this form immediately reflect parameters in the program.\n" +
                "Enforce Boundaries: Boundaries only take effect if this is checked.",
                "Help - Boundaries",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
        #endregion
    }
}
