using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATR
{
    partial class MainForm
    {
        #region Parameters
        private int maxLogLines = 500;
        private bool directionDown = true;
        #endregion

        #region Functions
        public void WriteToOutput(string output)
        {
            if (directionDown == true)
            {
                if (InvokeRequired) { Invoke(new MethodInvoker(delegate { WriteToOutputDown(output); })); }
                else { WriteToOutputDown(output); } 
            }
            else
            {
                if (InvokeRequired) { Invoke(new MethodInvoker(delegate { WriteToOutputUp(output); })); }
                else { WriteToOutputUp(output); }
            }
        }

        private void WriteToOutputDown(string output)
        {
            // keep only a few lines in the log
            while (listBoxOutput.Items.Count > maxLogLines) { listBoxOutput.Items.RemoveAt(0); }
            // add this line at the bottom of the log
            int index = listBoxOutput.Items.Count;
            listBoxOutput.Items.Insert(index, output);
            // Move the current index to the last item added
            listBoxOutput.TopIndex = listBoxOutput.Items.Count - 1;
        }

        private void WriteToOutputUp(string output)
        {
            // add this line at the top of the log
            listBoxOutput.Items.Insert(0, output);
            // keep only a few lines in the log
            while (listBoxOutput.Items.Count > maxLogLines) { listBoxOutput.Items.RemoveAt(listBoxOutput.Items.Count - 1); }
        }
        #endregion

    }
}
