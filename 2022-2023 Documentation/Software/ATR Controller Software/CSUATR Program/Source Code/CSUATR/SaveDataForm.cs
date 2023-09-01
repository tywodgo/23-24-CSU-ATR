using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATR
{
    public partial class SaveDataForm : Form
    {
        MainForm mainForm;
        DataManager dataManager;
        string foldername;
        string filename;
        bool warned = false;

        public SaveDataForm(MainForm mainForm, DataManager dataManager)
        {
            this.mainForm = mainForm;
            this.dataManager = dataManager;
            InitializeComponent();

            foldername = dataManager.dataFolder;
            filename = dataManager.dataFile;
            textBoxFoldername.Text = foldername;
            textBoxFilename.Text = filename;
        }

        #region GUI Functions
        private void textBoxFoldername_TextChanged(object sender, EventArgs e)
        {
            foldername = textBoxFoldername.Text;
        }

        private void textBoxFilename_TextChanged(object sender, EventArgs e)
        {
            filename = textBoxFilename.Text;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (foldername == mainForm.metaFolder)
            {
                MessageBox.Show(string.Format("You are not permitted to save to {0} folder", mainForm.metaFolder));
                return;
            }
            if (foldername == dataManager.dataFolder && filename == dataManager.dataFile && warned == false)
            {
                MessageBox.Show("Attention! This will overwrite your current data file. Press OK again to save");
                warned = true;
                return;
            }
            if (string.IsNullOrEmpty(foldername) || !filename.EndsWith(".dat"))
            {
                MessageBox.Show("Folder must have a name AND filename must end with '.dat'");
                return;
            }
            dataManager.SaveData(foldername, filename);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
