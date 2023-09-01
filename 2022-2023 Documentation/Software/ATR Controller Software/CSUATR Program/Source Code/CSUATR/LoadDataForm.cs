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

namespace CSUATR
{
    public partial class LoadDataForm : Form
    {
        MainForm mainForm;
        DataManager dataManager;
        string foldername;
        string filename;

        public LoadDataForm(MainForm mainForm, DataManager dataManager)
        {
            this.mainForm = mainForm;
            this.dataManager = dataManager;
            InitializeComponent();

            dataManager.CheckDataFile();

            foldername = dataManager.dataFolder;
            filename = dataManager.dataFile;

            PopulateItems_Folders();
            PopulateItems_Files();
        }

        #region GUI Functions
        private void comboBoxFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            foldername = comboBoxFolder.Text;
            PopulateItems_Files();
        }

        private void comboBoxFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            filename = comboBoxFile.Text;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            dataManager.LoadData(foldername, filename);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        public void PopulateItems_Folders()
        {
            string[] subdirectories = Directory.GetDirectories(mainForm.basePath);
            for (int i = 0; i < subdirectories.Length; i++)
            {
                string[] temp = subdirectories[i].Split('\\');
                subdirectories[i] = temp[temp.Length - 1];
            }
            comboBoxFolder.Items.Clear();
            comboBoxFolder.Items.AddRange(subdirectories);
            comboBoxFolder.Items.Remove(mainForm.metaFolder);
            comboBoxFolder.Text = foldername;
        }

        public void PopulateItems_Files()
        {
            string[] files = Directory.GetFiles(mainForm.basePath + @"\" + foldername);
            if (files.Length == 0)
            {
                comboBoxFile.Items.Clear();
                filename = "";
                comboBoxFile.Text = filename;
            }
            else
            {
                for (int i = 0; i < files.Length; i++)
                {
                    string[] temp = files[i].Split('\\');
                    files[i] = temp[temp.Length - 1];
                }
                comboBoxFile.Items.Clear();
                comboBoxFile.Items.AddRange(files);
                filename = files[0];
                comboBoxFile.Text = filename;
            }
        }


    }
}
