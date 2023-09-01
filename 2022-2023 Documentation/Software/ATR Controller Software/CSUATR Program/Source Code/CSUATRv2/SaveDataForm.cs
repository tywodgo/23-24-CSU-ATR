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
    public partial class SaveDataForm : Form
    {
        DataManager dataManager;
        EventManager eventManager;

        bool warned = false;
        string metaFolder = "Meta"; // assumed to be the same as MainForm

        public SaveDataForm(DataManager dataManager, EventManager eventManager)
        {
            this.dataManager = dataManager;
            this.eventManager = eventManager;

            InitializeComponent();

            textBoxFoldername.Text = dataManager.folder;
            textBoxFilename.Text = dataManager.file;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxFoldername.Text.Equals(metaFolder))
            {
                MessageBox.Show(string.Format("You are not permitted to save to the {0} folder", metaFolder));
                return;
            }
            if (
                textBoxFoldername.Text.Equals(dataManager.folder) &&
                textBoxFilename.Text.Equals(dataManager.file) &&
                warned == false)
            {
                MessageBox.Show("Attention! This will overwrite your last data file. Press OK again to save");
                warned = true;
                return;
            }
            if (string.IsNullOrEmpty(textBoxFoldername.Text) || !textBoxFilename.Text.EndsWith(".txt"))
            {
                MessageBox.Show("Folder must have a name AND filename must end with '.txt'");
                return;
            }
            dataManager.folder = textBoxFoldername.Text;
            dataManager.file = textBoxFilename.Text;
            eventManager.AddEvent(new Function(dataManager.SaveData, new object[] { }));
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
