using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATRv2
{
    public class Analysis
    {
        private AnalysisForm mainForm;
        private DataManager dataManager;

        private double myParameter;

        public Analysis(AnalysisForm mainForm, DataManager dataManager)
        {
            this.mainForm = mainForm;
            this.dataManager = dataManager;
            // Setup logic
            myParameter = 5;
        }

        public void DoSomething(int x)
        {
            myParameter += x;
            UpdateSomething();
        }

        #region GUI Updates
        // Update Something
        public void UpdateSomething()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateSomething(); })); }
            else { _UpdateSomething(); }
        }
        private void _UpdateSomething()
        {
            // update something
        }
        #endregion
    }
}
