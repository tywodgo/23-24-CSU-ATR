using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class Controller
    {
        #region Classes
        private Terminal terminal;
        private SerialPort port;
        #endregion

        #region Flags
        public bool connected { get; set; }
        private bool expectedConnection;
        #endregion

        #region Serial Parameters
        private char delimiter = '>';
        private const int bufferLength = 1000;
        private char[] inputBuffer = new char[bufferLength];
        private int inputLength = 0;
        private bool receiving = false;
        public string portName { get; set; } = " ";
        #endregion

        Action<string> handler;

        public Controller(Terminal terminal, Action<string> handler)
        {
            this.terminal = terminal;
            this.handler = handler;
            port = new SerialPort();
            connected = false;
        }

        #region Event Functions
        public void Connect(string portName, Callback callback)
        {
            //Try to connect to arduino
           expectedConnection = true;
            try
            {
                this.portName = portName;
                SetupSerialPort();
                port.Open();
            }
            catch { }
            EvaluateConnection(callback);
        }
        public void Disconnect(Callback callback)
        {
            //Try to disconnect from arduino
           expectedConnection = false;
            try
            {
                port.Close();
            }
            catch { }
            EvaluateConnection(callback);
        }
        private void SetupSerialPort()
        {
            //Setup port for serial communication
            try
                {
                    port.PortName = portName;
                    port.BaudRate = 9600; //115200;
                    port.DtrEnable = true;
                    port.ReadTimeout = 1000;
                    port.WriteTimeout = 1000;
                    port.NewLine = "\r";
                    port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                }
                catch
                {
                    terminal.Write(string.Format("Failed to setup serial port: {0}", portName));
                }
        }
        private void EvaluateConnection(Callback callback = null)
        {
            //Evaluate connection status
            try
            {
                if (port.IsOpen)
                {
                    connected = true;
                    terminal.Write("Controller connected");
                    if (callback != null)
                    {
                        if (expectedConnection == true) { callback.Call(true); }
                        else { callback.Call(false); }
                    }
                }
                else
                {
                    connected = false;
                    terminal.Write("Controller disconnected");
                    if (callback != null)
                    {
                        if (expectedConnection == false) { callback.Call(true); }
                        else { callback.Call(false); }
                    }
                }
            }
            catch
            {
                connected = false;
                terminal.Write("Controller disconnected");
                if (callback != null)
                {
                    if (expectedConnection == false) { callback.Call(true); }
                    else { callback.Call(false); }
                }
            }
        }
        #endregion

        public void Send(string output)
        {
            //Send string to arduino(output string CANNOT contain delimiter character)
            try
            {
                if (port.IsOpen)
                {
                    port.Write(output);
                    port.Write(delimiter.ToString());
                }
                else
                {
                    terminal.Write("Failed to send to Arduino");
                    EvaluateConnection();
                }
            }
            catch
            {
                terminal.Write("Failed to send to Arduino");
                EvaluateConnection();
            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //Event handler for characters received

           SerialPort sp = (SerialPort)sender;
            string buffer = sp.ReadExisting();
            foreach (char c in buffer)
            {
                Console.WriteLine(String.Format("recieved: {0}", c)); // Used for printing every single character that is received
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
                    handler(input); // process the output string
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
