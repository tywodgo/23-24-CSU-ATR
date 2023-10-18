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
    public partial class ClearDatasetForm : Form
    {
        DataManager dataManager;

        public ClearDatasetForm(DataManager dataManager)
        {
            this.dataManager = dataManager;
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            dataManager.ClearDataset();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
