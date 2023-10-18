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
    public partial class AnalysisForm : Form
    {
        Analysis analysis;
        DataManager dataManager;

        public AnalysisForm(DataManager dataManager)
        {
            this.dataManager = dataManager;
            analysis = new Analysis(this, dataManager);
            InitializeComponent();
        }
        
        #region GUI Updates
        // Update Something
        public void UpdateSomething()
        {
            if (InvokeRequired) { Invoke(new MethodInvoker(delegate { _UpdateSomething(); })); }
            else { _UpdateSomething(); }
        }
        private void _UpdateSomething()
        {
            // update something
        }
        #endregion
    }
}
