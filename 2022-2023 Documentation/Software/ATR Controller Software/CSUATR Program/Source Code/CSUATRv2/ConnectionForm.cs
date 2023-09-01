using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATRv2
{
    public partial class ConnectionForm : Form
    {
        #region Classes
        Terminal terminal;
        FileManager settings;
        FileManager addressList;
        EventManager eventManager;
        Controller controller;
        Instrument instrument;
        #endregion
        #region Forms
        SaveSettingsForm saveSettingsForm;
        LoadSettingsForm loadSettingsForm;
        #endregion
        #region Other
        // these two may eventually be part of a file manager
        string[] commandSets =
        {
            "N99xxA",
            "E8364B"
        };
        List<string> addresses = new List<string>();
        #endregion

        public ConnectionForm(
            Terminal terminal,
            FileManager settings,
            FileManager addressList,
            EventManager eventManager,
            Controller controller, 
            Instrument instrument)
        {
            this.terminal = terminal;
            this.settings = settings;
            this.addressList = addressList;
            this.eventManager = eventManager;
            this.controller = controller;
            this.instrument = instrument;
            InitializeComponent();

            // defalt addresses
            addresses.Add(@"TCPIP0::129.82.226.75::inst0::INSTR");
            addresses.Add(@"TCPIP0::129.82.224.235::inst0::INSTR");
            addresses.Add(@"TCPIP0::129.82.226.102::5025::SOCKET");

            PopulateCommandSets();
            PopulateAddresses();
            PopulatePorts();
            LoadAddresses();
            LoadSettings(0);
        }

        #region Settings
        public void SaveSettings(int i)
        {
            List<object[]> lines = new List<object[]>();
            lines.Add(new object[] { "Port", port.Text });
            lines.Add(new object[] { "Command Set", commandSet.Text });
            lines.Add(new object[] { "Instrument Address", address.Text });
            settings.Write(lines);
        }
        public void LoadSettings(int i)
        {
            List<string[]> lines = settings.Read();
            if (lines.Any())
            {
                foreach (string[] line in lines)
                {
                    if (line[0].Equals("Port"))                 { port.Text = line[1]; }
                    if (line[0].Equals("Command Set"))          { commandSet.Text = line[1]; }
                    if (line[0].Equals("Instrument Address"))   { address.Text = line[1]; }
                }
            }
            else
            {
                SaveSettings(0);
            }
        }
        public void SaveAddresses()
        {
            List<object[]> lines = new List<object[]>();
            foreach (string ad in addresses)
            {
                lines.Add(new object[] { "Address", ad });
            }
            addressList.Write(lines);
        }
        public void LoadAddresses()
        {
            List<string[]> lines = addressList.Read();
            if (lines.Any())
            {
                addresses.Clear();
                foreach (string[] line in lines)
                {
                    if (line[0].Equals("Address")) { addresses.Add(line[1]); }
                }
            }
            else
            {
                SaveAddresses();
            }
        }
        #endregion
        #region Menu
        private void menuSave_Click(object sender, EventArgs e)
        {
            if (saveSettingsForm != null) { saveSettingsForm.Close(); }
            saveSettingsForm = new SaveSettingsForm(settings, SaveSettings);
            saveSettingsForm.Show();
        }
        private void menuLoad_Click(object sender, EventArgs e)
        {
            if (loadSettingsForm != null) { loadSettingsForm.Close(); }
            loadSettingsForm = new LoadSettingsForm(settings, LoadSettings);
            loadSettingsForm.Show();
        }
        private void menuHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "(1) If your controller port does not show up on the list, try 'Rescan Ports'.\n" +
                "(2) If you would like the program to remember your instrument address, add it to the address.txt in your settings folder.",
                "Help - Connections",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
        #endregion
        #region Buttons
        private void buttonRescanPorts_Click(object sender, EventArgs e)
        {
            PopulatePorts();
        }
        private void buttonControllerConnect_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(controller.Connect, new object[] { port.Text }));
        }
        private void buttonControllerDisconnect_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(controller.Disconnect, new object[] { }));
        }
        private void buttonInstrumentConnect_Click(object sender, EventArgs e)
        {
            if (commandSet.Text.Equals("N99xxA")) { instrument.commandSet = new N99xxA(instrument); }
            if (commandSet.Text.Equals("E8364B")) { instrument.commandSet = new E8364B(instrument); }
            //else if (commandSet.Text.Equals("N99xxA_VISA_Keysight")) { instrument.commandSet = new N99xxA_VISA_Keysight(instrument); }
            //else if (commandSet.Text.Equals("N99xxA_VISA_NI")) { instrument.commandSet = new N99xxA_VISA_NI(instrument); }
            else
            {
                terminal.Write("CommandSet not found. Cannot connect", 3);
                return;
            }
            eventManager.AddEvent(new Function(instrument.Connect, new object[] { address.Text }));
        }
        private void buttonInstrumentDisconnect_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(instrument.Disconnect, new object[] { address.Text }));
        }
        #endregion
        
        #region Populate Functions
        public void PopulateCommandSets()
        {
            commandSet.Items.Clear();
            commandSet.Items.AddRange(commandSets);
            if (commandSets.Length > 0) { commandSet.SelectedIndex = 0; }
        }
        public void PopulateAddresses()
        {
            address.Items.Clear();
            foreach (string ad in addresses)
            {
                address.Items.Add(ad);
            }
            if (address.Items.Count > 0) { address.SelectedIndex = 0; }
        }
        public void PopulatePorts()
        {
            port.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            port.Items.AddRange(ports);
        }
        #endregion
    }
}
