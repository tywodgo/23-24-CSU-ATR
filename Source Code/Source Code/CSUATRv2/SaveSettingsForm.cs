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
    public partial class SaveSettingsForm : Form
    {
        FileManager settings;
        private Action<int> Save;
        bool warned = false;
        string metaFolder = "Meta"; // assumed to be the same as MainForm

        public SaveSettingsForm(FileManager settings, Action<int> Save)
        {
            this.settings = settings;
            this.Save = Save;
            InitializeComponent();

            textBoxFoldername.Text = settings.folder;
            textBoxFilename.Text = settings.file;

            textBoxFilename.Enabled = false;
        }

        #region Buttons
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxFoldername.Text.Equals(metaFolder))
            {
                MessageBox.Show(string.Format("You are not permitted to save to the {0} folder", metaFolder));
                return;
            }
            // This commented out region can be uncommented to enable a warning message that will be toggled
            // if the user attemps to save over their current settings
            //if (
            //    textBoxFoldername.Text.Equals(settings.folder) &&
            //    textBoxFilename.Text.Equals(settings.file) &&
            //    warned == false)
            //{
            //    MessageBox.Show("Attention! This will overwrite your current settings. Press OK again to save");
            //    warned = true;
            //    return;
            //}
            if (string.IsNullOrEmpty(textBoxFoldername.Text) || !textBoxFilename.Text.EndsWith(".txt"))
            {
                MessageBox.Show("Folder must have a name AND filename must end with '.txt'");
                return;
            }
            settings.folder = textBoxFoldername.Text;
            settings.file = textBoxFilename.Text;
            Save(0);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void SaveSettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
