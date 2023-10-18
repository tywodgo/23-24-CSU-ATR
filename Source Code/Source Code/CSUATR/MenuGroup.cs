using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSUATR
{
    partial class MainForm
    {
        #region File
        private void menuItemChangeSettingsLocation_Click(object sender, EventArgs e)
        {
            changeSettingsLocationForm = new ChangeSettingsLocationForm(this);
            changeSettingsLocationForm.Show();
        }
        private void menuItemSaveSettings_Click(object sender, EventArgs e)
        {
            saveSettingsForm = new SaveSettingsForm(this);
            saveSettingsForm.Show();
        }
        private void menuItemSaveData_Click(object sender, EventArgs e)
        {
            saveDataForm = new SaveDataForm(this, dataManager);
            saveDataForm.Show();
        }
        private void menuItemLoadData_Click(object sender, EventArgs e)
        {
            loadDataForm = new LoadDataForm(this, dataManager);
            loadDataForm.Show();
        }
        private void menuItemRescanPorts_Click(object sender, EventArgs e)
        {
            PopulateItems_Port();
        }
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            exitApplicationForm = new ExitApplicationForm(this);
            exitApplicationForm.Show();
        }
        #endregion

        #region Data
        private void menuItemRemoveLastPoint_Click(object sender, EventArgs e)
        {
            dataManager.RemoveLastPoint();
        }
        private void menuItemClearDataset_Click(object sender, EventArgs e)
        {
            clearDatasetForm = new ClearDatasetForm(dataManager);
            clearDatasetForm.Show();
        }
        #endregion

        #region Help
        private void menuItemHelp_Click(object sender, EventArgs e)
        {
            if (helpForm != null) { helpForm.Close(); } // this can be implemented for all extra forms
            helpForm = new HelpForm();
            helpForm.Show();
        }
        #endregion
    }
}
