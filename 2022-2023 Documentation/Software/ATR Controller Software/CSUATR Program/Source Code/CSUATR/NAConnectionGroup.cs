using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSUATR
{
    partial class MainForm
    {
        #region GUI Parameters
        // mode
        #endregion

        #region Active Functions
        private void buttonNAConnect_Click(object sender, EventArgs e)
        {
            if (networkAnalyzer.connected == false)
            {
                ReadMeta();
                networkAnalyzer.Connect();
                if (networkAnalyzer.ready == true)
                {
                    networkAnalyzer.SetMode(mode.Text);
                }
            }
            else
            {
                networkAnalyzer.Disconnect();
            }
        }
        private void mode_TextChanged(object sender, EventArgs e)
        {
            if (networkAnalyzer.ready == true)
            {
                networkAnalyzer.SetMode(mode.Text);
            }
        }
        #endregion

        public void UpdateEnabledButtons_NAConnection()
        {
            if (networkAnalyzer.connected == true)
            {
                buttonNAConnect.Text = "Disconnect";
            }
            else
            {
                buttonNAConnect.Text = "Connect";
            }
            if (scanner.inProgress == true || networkAnalyzer.connected == false || networkAnalyzer.ready == false)
            {
                mode.Enabled = false;
            }
            else
            {
                mode.Enabled = true;
            }
        }

    }
}
