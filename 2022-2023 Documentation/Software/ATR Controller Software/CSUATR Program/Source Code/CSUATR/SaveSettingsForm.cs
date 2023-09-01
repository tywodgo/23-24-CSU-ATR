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
    public partial class SaveSettingsForm : Form
    {
        MainForm mainForm;
        string foldername;
        string filename;
        bool warned = false;

        public SaveSettingsForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            foldername = mainForm.settingsFolder;
            filename = mainForm.settingsFile;
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
            if (foldername == mainForm.settingsFolder && filename == mainForm.settingsFile && warned == false)
            {
                MessageBox.Show("Attention! This will overwrite your current settings. Press OK again to save");
                warned = true;
                return;
            }
            if (string.IsNullOrEmpty(foldername) || !filename.EndsWith(".txt"))
            {
                MessageBox.Show("Folder must have a name AND filename must end with '.txt'");
                return;
            }
            mainForm.SaveSettings(foldername, filename);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
