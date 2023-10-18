using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;


namespace CSUATR
{
    partial class MainForm
    {
        #region GUI Parameters
        // port
        #endregion

        #region Active Functions
        private void buttonArduinoConnect_Click(object sender, EventArgs e)
        {
            if (arduino.connected == false)
            {
                arduino.Connect(port.Text);
            }
            else
            {
                arduino.Disconnect();
            }
        }
        #endregion

        public void UpdateEnabledButtons_ArduinoConnection()
        {
            if (arduino.connected == true)
            {
                buttonArduinoConnect.Text = "Disconnect";
                port.Enabled = false;
            }
            else
            {
                buttonArduinoConnect.Text = "Connect";
                port.Enabled = true;
            }

        }

        public void PopulateItems_Port()
        {
            port.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            port.Items.AddRange(ports);
        }
    }
}
