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
    public partial class MotorsForm : Form
    {
        private Motors motors;

        private SaveSettingsForm saveSettingsForm;
        private LoadSettingsForm loadSettingsForm;

        public MotorsForm(Motors motors)
        {
            this.motors = motors;
            InitializeComponent();
            SetCurrentBounds();
            SetCurrentValues();
        }

        #region Set Parameters
        private void SetCurrentBounds()
        {
            try
            {
                alphaH.Maximum = (decimal)motors.alphaBounds[1];
                alphaH.Minimum = (decimal)motors.alphaBounds[0];
                alphaV.Maximum = (decimal)motors.alphaBounds[1];
                alphaV.Minimum = (decimal)motors.alphaBounds[0];
                alphaD.Maximum = (decimal)motors.alphaBounds[1];
                alphaD.Minimum = (decimal)motors.alphaBounds[0];
                alphaA.Maximum = (decimal)motors.alphaBounds[1];
                alphaA.Minimum = (decimal)motors.alphaBounds[0];
                alphaE.Maximum = (decimal)motors.alphaBounds[1];
                alphaE.Minimum = (decimal)motors.alphaBounds[0];
                alphaP.Maximum = (decimal)motors.alphaBounds[1];
                alphaP.Minimum = (decimal)motors.alphaBounds[0];

                betaH.Maximum = (decimal)motors.betaBounds[1];
                betaH.Minimum = (decimal)motors.betaBounds[0];
                betaV.Maximum = (decimal)motors.betaBounds[1];
                betaV.Minimum = (decimal)motors.betaBounds[0];
                betaD.Maximum = (decimal)motors.betaBounds[1];
                betaD.Minimum = (decimal)motors.betaBounds[0];
                betaA.Maximum = (decimal)motors.betaBounds[1];
                betaA.Minimum = (decimal)motors.betaBounds[0];
                betaE.Maximum = (decimal)motors.betaBounds[1];
                betaE.Minimum = (decimal)motors.betaBounds[0];
                betaP.Maximum = (decimal)motors.betaBounds[1];
                betaP.Minimum = (decimal)motors.betaBounds[0];

                gammaH.Maximum = (decimal)motors.gammaBounds[1];
                gammaH.Minimum = (decimal)motors.gammaBounds[0];
                gammaV.Maximum = (decimal)motors.gammaBounds[1];
                gammaV.Minimum = (decimal)motors.gammaBounds[0];
                gammaD.Maximum = (decimal)motors.gammaBounds[1];
                gammaD.Minimum = (decimal)motors.gammaBounds[0];
                gammaA.Maximum = (decimal)motors.gammaBounds[1];
                gammaA.Minimum = (decimal)motors.gammaBounds[0];
                gammaE.Maximum = (decimal)motors.gammaBounds[1];
                gammaE.Minimum = (decimal)motors.gammaBounds[0];
                gammaP.Maximum = (decimal)motors.gammaBounds[1];
                gammaP.Minimum = (decimal)motors.gammaBounds[0];
            }
            catch
            {
                MessageBox.Show("Motors form failed to load. Check current motor settings values and restart program");
            }

        }
        private void SetCurrentValues()
        {
            try
            {
                alphaH.Value = (decimal)motors.alphaH;
                alphaV.Value = (decimal)motors.alphaV;
                alphaD.Value = (decimal)motors.alphaD;
                alphaA.Value = (decimal)motors.alphaA;
                alphaE.Value = (decimal)motors.alphaE;
                alphaP.Value = (decimal)motors.alphaP;

                betaH.Value = (decimal)motors.betaH;
                betaV.Value = (decimal)motors.betaV;
                betaD.Value = (decimal)motors.betaD;
                betaA.Value = (decimal)motors.betaA;
                betaE.Value = (decimal)motors.betaE;
                betaP.Value = (decimal)motors.betaP;

                gammaH.Value = (decimal)motors.gammaH;
                gammaV.Value = (decimal)motors.gammaV;
                gammaD.Value = (decimal)motors.gammaD;
                gammaA.Value = (decimal)motors.gammaA;
                gammaE.Value = (decimal)motors.gammaE;
                gammaP.Value = (decimal)motors.gammaP;
            }
            catch
            {
                MessageBox.Show("Motors form failed to load. Check current motor settings values and restart program");
            }

        }
        #endregion
        #region Modeling
        #region Alpha
        private void alphaH_ValueChanged(object sender, EventArgs e)
        {
            motors.alphaH = (double)alphaH.Value;
        }
        private void alphaV_ValueChanged(object sender, EventArgs e)
        {
            motors.alphaV = (double)alphaV.Value;
        }
        private void alphaD_ValueChanged(object sender, EventArgs e)
        {
            motors.alphaD = (double)alphaD.Value;
        }
        private void alphaA_ValueChanged(object sender, EventArgs e)
        {
            motors.alphaA = (double)alphaA.Value;
        }
        private void alphaE_ValueChanged(object sender, EventArgs e)
        {
            motors.alphaE = (double)alphaE.Value;
        }
        private void alphaP_ValueChanged(object sender, EventArgs e)
        {
            motors.alphaP = (double)alphaP.Value;
        }
        #endregion
        #region Beta
        private void betaH_ValueChanged(object sender, EventArgs e)
        {
            motors.betaH = (double)betaH.Value;
        }
        private void betaV_ValueChanged(object sender, EventArgs e)
        {
            motors.betaV = (double)betaV.Value;
        }
        private void betaD_ValueChanged(object sender, EventArgs e)
        {
            motors.betaD = (double)betaD.Value;
        }
        private void betaA_ValueChanged(object sender, EventArgs e)
        {
            motors.betaA = (double)betaA.Value;
        }
        private void betaE_ValueChanged(object sender, EventArgs e)
        {
            motors.betaE = (double)betaE.Value;
        }
        private void betaP_ValueChanged(object sender, EventArgs e)
        {
            motors.betaP = (double)betaP.Value;
        }
        #endregion
        #region Gamma
        private void gammaH_ValueChanged(object sender, EventArgs e)
        {
            motors.gammaH = (double)gammaH.Value;
        }
        private void gammaV_ValueChanged(object sender, EventArgs e)
        {
            motors.gammaV = (double)gammaV.Value;
        }
        private void gammaD_ValueChanged(object sender, EventArgs e)
        {
            motors.gammaD = (double)gammaD.Value;
        }
        private void gammaA_ValueChanged(object sender, EventArgs e)
        {
            motors.gammaA = (double)gammaA.Value;
        }
        private void gammaE_ValueChanged(object sender, EventArgs e)
        {
            motors.gammaE = (double)gammaE.Value;
        }
        private void gammaP_ValueChanged(object sender, EventArgs e)
        {
            motors.gammaP = (double)gammaP.Value;
        }
        #endregion
        #endregion
        #region Menu
        private void menuSave_Click(object sender, EventArgs e)
        {
            if (saveSettingsForm != null) { saveSettingsForm.Close(); }
            saveSettingsForm = new SaveSettingsForm(motors.settings, motors.SaveSettings);
            saveSettingsForm.Show();
        }
        private void menuLoad_Click(object sender, EventArgs e)
        {
            if (loadSettingsForm != null) { loadSettingsForm.Close(); }
            loadSettingsForm = new LoadSettingsForm(motors.settings, motors.LoadSettings);
            loadSettingsForm.Show();
        }
        private void menuHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Edits to values in this form immediately reflect parameters in the program.\n" +
                "These parameters are sent to the controller for each positioning event.",
                "Help - Motors",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
        #endregion


    }
}
