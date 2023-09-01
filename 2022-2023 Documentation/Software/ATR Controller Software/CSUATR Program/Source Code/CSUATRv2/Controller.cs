using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATRv2
{
    public class Controller
    {
        #region Form Communications
        private MainForm mainForm;
        private Terminal terminal;
        #endregion

        #region Flags
        private bool _connected;
        public bool connected
        {
            get { return _connected; }
            set {
                _connected = value;
                UpdateStatusController();
                //Call(UpdateStatusController);
            }
        }
        private bool expectedConnection;
        #endregion

        #region Serial
        private SerialPort port;
        private char delimiter = '>';
        private const int bufferLength = 1000;
        private char[] inputBuffer = new char[bufferLength];
        private int inputLength = 0;
        private bool receiving = false;
        public string portName { get; set; }
        #endregion

        #region Callbacks
        public Action<string> handler { get; set; }
        #endregion

        public Controller(
            MainForm mainForm, 
            Terminal terminal, 
            Action<string> handler = null)
        {
            this.mainForm = mainForm;
            this.terminal = terminal;
            this.handler = handler;
            port = new SerialPort();
            connected = false;
            portName = " ";
        }

        #region Event Functions
        public void Connect(string portName, Callback callback)
        {
            // Try to connect to controller
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
            // Try to disconnect from controller
            expectedConnection = false;
            try
            {
                port.Close();
            }
            catch { }
            EvaluateConnection(callback);
        }
        #endregion
        #region Call Methods
        public void Connect(object[] args, Callback callback)
        {
            string portName = (string)args[0];
            Connect(portName, callback);
        }
        public void Disconnect(object[] args, Callback callback)
        {
            Disconnect(callback);
        }
        #endregion

        #region Assistant Methods
        private void SetupSerialPort()
        {
            // Setup port for serial communication
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
                terminal.Write(string.Format("Failed to setup serial port: {0}", portName), 3);
            }
        }
        private void EvaluateConnection(Callback callback = null)
        {
            // Evaluate connection status
            try
            {
                if (port.IsOpen)
                {
                    connected = true;
                    terminal.Write("Controller connected", 2);
                    if (callback != null)
                    {
                        if (expectedConnection == true) { callback.Call(true); }
                        else { callback.Call(false); }
                    }
                }
                else
                {
                    connected = false;
                    terminal.Write("Controller disconnected", 2);
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
                terminal.Write("Controller disconnected", 2);
                if (callback != null)
                {
                    if (expectedConnection == false) { callback.Call(true); }
                    else { callback.Call(false); }
                }
            }
        }
        #endregion
        #region Direct Methods
        public void Send(string output)
        {
            // Send string to controller (output string CANNOT contain delimiter character)
            try
            {
                if (port.IsOpen)
                {
                    port.Write(output);
                    port.Write(delimiter.ToString());
                    //Console.WriteLine(string.Format("Output String: {0}", output), 2);
                }
                else
                {
                    terminal.Write("Failed to send to controller", 3);
                    EvaluateConnection();
                }
            }
            catch
            {
                terminal.Write("Failed to send to controller", 3);
                EvaluateConnection();
            }
        }
        #endregion
        #region Interrupts
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //Event handler for characters received
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
                    handler(input); // process the output string
                }
                else
                {
                    inputBuffer[inputLength] = c;
                    inputLength++;
                }
            }
        }
        #endregion

        #region GUI Updates
        //private void Call(Action<int> function)
        //{
        //    try
        //    {
        //        if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { function(0); })); }
        //        else { function(0); }
        //    }
        //    catch { terminal.Write(string.Format("Failed to call: {0}", function.Method.Name)); }
        //}
        public void UpdateStatusController()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateStatusController(); })); }
            else { _UpdateStatusController(); }
        }
        private void _UpdateStatusController()
        {
            if (connected == true)
            {
                mainForm.statusController.Text = "Connected";
            }
            else
            {
                mainForm.statusController.Text = "Disconnected";
            }
        }
        #endregion
    }
}
