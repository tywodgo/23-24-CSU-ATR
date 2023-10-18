using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace CSUATR
{
    public class Arduino
    {
        #region Classes
        MainForm mainForm;
        SerialPort port;
        #endregion

        #region Flags
        public bool connected = false;
        #endregion

        #region Serial Parameters
        public char delimiter = '>';
        public const int bufferLength = 1000;
        public char[] inputBuffer = new char[bufferLength];
        public int inputLength = 0;
        public bool receiving = false;
        #endregion

        public Arduino(MainForm mainForm)
        {
            this.mainForm = mainForm;
            port = new SerialPort();
        }

        // Setup port for serial communication
        private void SetupSerialPort(string portName)
        {
            try
            {
                port.PortName = portName;
                port.BaudRate = 9600; //115200;
                port.DtrEnable = true;
                port.ReadTimeout = 5000;
                port.WriteTimeout = 500;
                port.NewLine = "\r";

                //port.PortName = portName;
                //port.BaudRate = 9600;
                //port.Parity = Parity.None;
                //port.StopBits = StopBits.One;
                //port.DataBits = 8;
                //port.Handshake = Handshake.None;
                //port.RtsEnable = true;
                //port.DtrEnable = true;
                //port.ReadTimeout = 5000;
                //port.WriteTimeout = 500;

                port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            }
            catch
            {
                mainForm.WriteToOutput(string.Format("Failed to setup serial port: {0}", portName));
            }
        }

        // Try to connect to arduino
        public void Connect(string portName)
        {
            try
            {
                SetupSerialPort(portName);
                port.Open();
            }
            catch { }
            EvaluateConnection();
        }

        // Try to disconnect from arduino
        public void Disconnect()
        {
            try
            {
                port.Close();
            }
            catch { }
            EvaluateConnection();
        }

        // Evaluate connection status
        private void EvaluateConnection()
        {
            try
            {
                if (port.IsOpen)
                {
                    connected = true;
                    mainForm.WriteToOutput("Arduino connected");
                }
                else
                {
                    mainForm.positioner.Reset();
                    connected = false;
                    mainForm.scanner.Pause();
                    mainForm.WriteToOutput("Arduino disconnected");
                }
            }
            catch
            {
                mainForm.positioner.Reset();
                connected = false;
                mainForm.scanner.Pause();
                mainForm.WriteToOutput("Arduino disconnected");
            }
            mainForm.UpdateEnabledButtons_ArduinoConnection();
            mainForm.UpdateEnabledButtons_Positioning();
            mainForm.UpdateEnabledButtons_ScanSettings();
        }

        // Send string to arduino (output string CANNOT contain delimiter character)
        public void Send(String output)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.Write(output);
                    port.Write(delimiter.ToString());
                }
                else
                {
                    mainForm.WriteToOutput("Failed to send to Arduino");
                    EvaluateConnection();
                }
            }
            catch
            {
                mainForm.WriteToOutput("Failed to send to Arduino");
                EvaluateConnection();
            }
        }

        // Event handler for characters received
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string buffer = sp.ReadExisting();
            foreach (char c in buffer)
            {
                //Console.WriteLine(String.Format("recieved: {0}", c)); // Used for printing every single character that is received
                if (receiving == false)
                {
                    receiving = true;
                    inputLength = 0;
                }
                if (c.CompareTo(delimiter) == 0)
                {
                    receiving = false;
                    string input = new string(inputBuffer);
                    input = input.Substring(0, inputLength);
                    mainForm.positioner.ProcessArduinoString(input); // process the output string
                }
                else
                {
                    inputBuffer[inputLength] = c;
                    inputLength++;
                }

            }
        }

    }
}
