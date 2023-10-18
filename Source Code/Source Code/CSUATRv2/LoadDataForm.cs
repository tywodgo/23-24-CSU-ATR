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
    public partial class LoadDataForm : Form
    {
        private DataManager dataManager;
        private EventManager eventManager;

        private string metaFolder = "Meta"; // assumed to be the same as MainForm

        public LoadDataForm(DataManager dataManager, EventManager eventManager)
        {
            this.dataManager = dataManager;
            this.eventManager = eventManager;

            InitializeComponent();

            comboBoxFolder.Text = dataManager.folder;
            comboBoxFile.Text = dataManager.file;
            PopulateItems_Folders();
            PopulateItems_Files();
        }

        private void comboBoxFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateItems_Files();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            dataManager.folder = comboBoxFolder.Text;
            dataManager.file = comboBoxFile.Text;
            eventManager.AddEvent(new Function(dataManager.LoadData, new object[] { }));
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void PopulateItems_Folders()
        {
            string[] subdirectories = Directory.GetDirectories(dataManager.basePath);
            for (int i = 0; i < subdirectories.Length; i++)
            {
                string[] temp = subdirectories[i].Split('\\');
                subdirectories[i] = temp[temp.Length - 1];
            }
            comboBoxFolder.Items.Clear();
            comboBoxFolder.Items.AddRange(subdirectories);
            comboBoxFolder.Items.Remove(metaFolder);
        }

        public void PopulateItems_Files()
        {
            string[] files = Directory.GetFiles(dataManager.basePath + @"\" + comboBoxFolder.Text);
            for (int i = 0; i < files.Length; i++)
            {
                string[] temp = files[i].Split('\\');
                files[i] = temp[temp.Length - 1];
            }
            comboBoxFile.Items.Clear();
            comboBoxFile.Items.AddRange(files);
        }


    }
}
