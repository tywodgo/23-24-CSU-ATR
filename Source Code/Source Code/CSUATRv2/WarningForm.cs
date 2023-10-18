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
    public partial class WarningForm : Form
    {
        private new Action<int> Action;

        public WarningForm(Action<int> Action)
        {
            this.Action = Action;

            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Action(0);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
