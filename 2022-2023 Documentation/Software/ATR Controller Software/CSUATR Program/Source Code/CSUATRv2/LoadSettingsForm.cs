using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATRv2
{
    public partial class LoadSettingsForm : Form
    {
        FileManager settings;
        private new Action<int> Load;
        string metaFolder = "Meta"; // assumed to be the same as MainForm

        public LoadSettingsForm(FileManager settings, Action<int> Load)
        {
            this.settings = settings;
            this.Load = Load;
            InitializeComponent();

            PopulateItems_Folders();
            comboBoxFolder.Text = settings.folder;
            comboBoxFile.Text = settings.file;

            comboBoxFile.Enabled = false;
        }

        #region Buttons
        private void buttonOk_Click(object sender, EventArgs e)
        {
            settings.folder = comboBoxFolder.Text;
            settings.file = comboBoxFile.Text;
            Load(0);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        public void PopulateItems_Folders()
        {
            string[] subdirectories = Directory.GetDirectories(settings.basePath);
            for (int i = 0; i < subdirectories.Length; i++)
            {
                string[] temp = subdirectories[i].Split('\\');
                subdirectories[i] = temp[temp.Length - 1];
            }
            comboBoxFolder.Items.Clear();
            comboBoxFolder.Items.AddRange(subdirectories);
            comboBoxFolder.Items.Remove(metaFolder);
        }
    }
}
