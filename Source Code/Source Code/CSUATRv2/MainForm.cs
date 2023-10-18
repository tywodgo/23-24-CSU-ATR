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
    public partial class MainForm : Form
    {
        #region Forms
        public ConnectionForm connectionsForm;
        public PositioningForm positioningForm;
        public MeasurementForm measurementForm;
        public ScanForm scanForm;

        public DataForm dataForm;
        public List<PlottingForm> plottingForms;

        public SurveillanceForm surveillanceForm;
        public AnalysisForm analysisForm;
        public MotorsForm motorsForm;
        public BoundariesForm boundariesForm;

        public ExitForm exitForm;
        #endregion
        #region Classes
        public Terminal terminal;

        public Controller controller;

        public Position position;
        public Positioner positioner;

        public Measurement measurement;
        public Instrument instrument;
        public CommandSet commandSet;

        public DataManager dataManager;
        public EventManager eventManager;
        public Scanner scanner;

        public Motors motors;
        public Analysis analysis;
        #endregion
        #region File Managers
        public string metaFolder;
        public string metaFile;
        public char delimiter;
        FileManager meta;
        FileManager connectionSettings;
        FileManager positionerSettings;
        FileManager measurementSettings;
        FileManager scanSettings;
        FileManager motorSettings;
        FileManager positionSettings;
        FileManager boundarySettings;
        FileManager addressList;
        public bool reading = false;
        #endregion
        #region Flags
        public bool allowClosable = false;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            // Forms
            plottingForms = new List<PlottingForm>();

            // Output Terminal
            terminal = new Terminal(listBoxOutput, 2);

            // File managers
            metaFolder = "Meta";
            metaFile = "meta.txt";
            delimiter = ':';
            meta = new FileManager(this, terminal, metaFolder, metaFile, delimiter);
            addressList = new FileManager(this, terminal, "Settings", "addresses.txt", delimiter);
            connectionSettings = new FileManager(this, terminal, "Settings", "connection.txt", delimiter);
            positionerSettings = new FileManager(this, terminal, "Settings", "positioner.txt", delimiter);
            measurementSettings = new FileManager(this, terminal, "Settings", "measurement.txt", delimiter);
            scanSettings = new FileManager(this, terminal, "Settings", "scan.txt", delimiter);
            motorSettings = new FileManager(this, terminal, "Settings", "motors.txt", delimiter);
            positionSettings = new FileManager(this, terminal, "Settings", "position.txt", delimiter);
            boundarySettings = new FileManager(this, terminal, "Settings", "boundaries.txt", delimiter);

            // Serial Communications and Positoning
            controller = new Controller(this, terminal);
            position = new Position(this, positionSettings);
            motors = new Motors(terminal, motorSettings);
            positioner = new Positioner(this, terminal, controller, position, motors, boundarySettings);
            controller.handler = positioner.ProcessControllerString;

            // Instrumentation and Measurement
            measurement = new Measurement();
            instrument = new Instrument(this, terminal, measurement);

            // Data and Event Management
            dataManager = new DataManager(this, terminal, position, measurement, instrument);
            eventManager = new EventManager(this, terminal, positioner, instrument, eventQueueStrings, currentEventString);
            scanner = new Scanner(this, terminal, eventManager, controller, positioner, instrument, dataManager);

            ReadMeta();

            // Update Tab Control Statuses
            controller.UpdateStatusController();
            instrument.UpdateStatusInstrument();

            position.UpdateStatusHorizontal();
            position.UpdateStatusVertical();
            position.UpdateStatusDepth();
            position.UpdateStatusAzimuth();
            position.UpdateStatusElevation();
            position.UpdateStatusPolarization();

            instrument.UpdateStatusSParameter();
            instrument.UpdateStatusSourcePower();
            instrument.UpdateStatusStartFrequency();
            instrument.UpdateStatusStopFrequency();
            instrument.UpdateStatusIFBandwidth();
            instrument.UpdateStatusSweepPoints();
            instrument.UpdateStatusAveragePoints();

            dataManager.UpdateStatusDataPoints();
            dataManager.UpdateStatusSaved();

            eventManager.UpdateTimeRemaining();
            eventManager.UpdateEventsRemaining();

            // Update Event Queue Statuses
            addMode.Items.Clear();
            addMode.Items.Add("Append");
            addMode.Items.Add("Insert");
            addMode.Items.Add("Push");
            addMode.SelectedIndex = 0;
            continuous.Checked = true;
            eventQueueStrings.SelectionMode = SelectionMode.One;
            currentEventString.Text = "None";
        }

        #region Settings
        public void ReadMeta()
        {
            List<string[]> lines = meta.Read();
            if (lines.Any())
            {
                reading = true;
                foreach (string[] line in lines)
                {
                    if (line[0].Equals("Connection Settings Folder"))   { connectionSettings.folder = line[1]; }
                    if (line[0].Equals("Connection Settings File"))     { connectionSettings.file = line[1]; }

                    if (line[0].Equals("Positioner Settings Folder"))   { positionerSettings.folder = line[1]; }
                    if (line[0].Equals("Positioner Settings File"))     { positionerSettings.file = line[1]; }

                    if (line[0].Equals("Measurement Settings Folder"))  { measurementSettings.folder = line[1]; }
                    if (line[0].Equals("Measurement Settings File"))    { measurementSettings.file = line[1]; }

                    if (line[0].Equals("Scan Settings Folder"))         { scanSettings.folder = line[1]; }
                    if (line[0].Equals("Scan Settings File"))           { scanSettings.file = line[1]; }

                    if (line[0].Equals("Data Folder"))                  { dataManager.folder = line[1]; }
                    if (line[0].Equals("Data File"))                    { dataManager.file = line[1]; }

                    if (line[0].Equals("Motor Folder"))                 { motorSettings.folder = line[1]; }
                    if (line[0].Equals("Motor File"))                   { motorSettings.file = line[1]; }

                    if (line[0].Equals("Position Folder"))              { positionSettings.folder = line[1]; }
                    if (line[0].Equals("Position File"))                { positionSettings.file = line[1]; }

                    if (line[0].Equals("Addresses Folder"))             { addressList.folder = line[1]; }
                    if (line[0].Equals("Addresses File"))               { addressList.file = line[1]; }
                }
                reading = false;
            }
            else
            {
                WriteMeta();
            }
        }
        public void WriteMeta()
        {
            if (reading == false)
            {
                List<object[]> lines = new List<object[]>();
                lines.Add(new string[] { "Connection Settings Folder", connectionSettings.folder });
                lines.Add(new string[] { "Connection Settings File", connectionSettings.file });

                lines.Add(new string[] { "Positioner Settings Folder", positionerSettings.folder });
                lines.Add(new string[] { "Positioner Settings File", positionerSettings.file });

                lines.Add(new string[] { "Measurement Settings Folder", measurementSettings.folder });
                lines.Add(new string[] { "Measurement Settings File", measurementSettings.file });

                lines.Add(new string[] { "Scan Settings Folder", scanSettings.folder });
                lines.Add(new string[] { "Scan Settings File", scanSettings.file });

                lines.Add(new string[] { "Data Folder", dataManager.folder });
                lines.Add(new string[] { "Data File", dataManager.file });

                lines.Add(new string[] { "Motor Folder", motorSettings.folder });
                lines.Add(new string[] { "Motor File", motorSettings.file });

                lines.Add(new string[] { "Position Folder", positionSettings.folder });
                lines.Add(new string[] { "Position File", positionSettings.file });

                lines.Add(new string[] { "Addresses Folder", addressList.folder });
                lines.Add(new string[] { "Addresses File", addressList.file });

                meta.Write(lines);
            }
        }
        #endregion
        #region Menu Functions
        private void menuConnections_Click(object sender, EventArgs e)
        {
            if (connectionsForm != null && !connectionsForm.Disposing && !connectionsForm.IsDisposed)
            {
                connectionsForm.WindowState = FormWindowState.Normal;
                connectionsForm.BringToFront();
            }
            else
            {
                connectionsForm = new ConnectionForm(terminal, connectionSettings, addressList, eventManager, controller, instrument);
            }
            connectionsForm.Show();
        }
        private void menuPositioner_Click(object sender, EventArgs e)
        {
            if (positioningForm != null && !positioningForm.Disposing && !positioningForm.IsDisposed)
            {
                positioningForm.WindowState = FormWindowState.Normal;
                positioningForm.BringToFront();
            }
            else
            {
                positioningForm = new PositioningForm(this, positionerSettings, eventManager, positioner);
            }
            positioningForm.Show();
        }
        private void menuMeasurement_Click(object sender, EventArgs e)
        {
            if (measurementForm != null && !measurementForm.Disposing && !measurementForm.IsDisposed)
            {
                measurementForm.WindowState = FormWindowState.Normal;
                measurementForm.BringToFront();
            }
            else
            {
                measurementForm = new MeasurementForm(measurementSettings, eventManager, instrument);
            }
            measurementForm.Show();
        }
        private void menuScan_Click(object sender, EventArgs e)
        {
            if (scanForm != null && !scanForm.Disposing && !scanForm.IsDisposed)
            {
                scanForm.WindowState = FormWindowState.Normal;
                scanForm.BringToFront();
            }
            else
            {
                scanForm = new ScanForm(scanSettings, scanner);
            }
            scanForm.Show();
        }
        private void menuData_Click(object sender, EventArgs e)
        {
            if (dataForm != null && !dataForm.Disposing && !dataForm.IsDisposed)
            {
                dataForm.WindowState = FormWindowState.Normal;
                dataForm.BringToFront();
            }
            else
            {
                dataForm = new DataForm(dataManager, eventManager);
            }
            dataForm.Show();
        }
        private void menuPlotter_Click(object sender, EventArgs e)
        {
            int maxPlottingForms = 4;
            if (plottingForms.Count < maxPlottingForms)
            {
                plottingForms.Add(new PlottingForm(dataManager)); // TODO: find way to tell program that a plot form has been disposed of
                plottingForms.Last().Show();
            }
            else if (plottingForms.Count == maxPlottingForms)
            {
                for (int i = 0; i < maxPlottingForms; i++)
                {
                    if (plottingForms[i] == null || plottingForms[i].Disposing || plottingForms[i].IsDisposed)
                    {
                        plottingForms[i] = new PlottingForm(dataManager);
                        plottingForms[i].Show();
                        break;
                    }
                }
            }

        }
        private void menuSurveillance_Click(object sender, EventArgs e)
        {
            if (surveillanceForm != null && !surveillanceForm.Disposing && !surveillanceForm.IsDisposed)
            {
                surveillanceForm.WindowState = FormWindowState.Normal;
                surveillanceForm.BringToFront();
            }
            else
            {
                surveillanceForm = new SurveillanceForm();
            }
            surveillanceForm.Show();
        }
        private void menuAnalysis_Click(object sender, EventArgs e)
        {
            if (analysisForm != null && !analysisForm.Disposing && !analysisForm.IsDisposed)
            {
                analysisForm.WindowState = FormWindowState.Normal;
                analysisForm.BringToFront();
            }
            else
            {
                analysisForm = new AnalysisForm(dataManager);
            }
            analysisForm.Show();
        }
        private void menuMotors_Click(object sender, EventArgs e)
        {
            if (motorsForm != null && !motorsForm.Disposing && !motorsForm.IsDisposed)
            {
                motorsForm.WindowState = FormWindowState.Normal;
                motorsForm.BringToFront();
            }
            else
            {
                motorsForm = new MotorsForm(motors);
            }
            motorsForm.Show();
        }
        private void menuBoundaries_Click(object sender, EventArgs e)
        {
            if (boundariesForm != null && !boundariesForm.Disposing && !boundariesForm.IsDisposed)
            {
                boundariesForm.WindowState = FormWindowState.Normal;
                boundariesForm.BringToFront();
            }
            else
            {
                boundariesForm = new BoundariesForm(positioner);
            }
            boundariesForm.Show();
        }
        private void menuHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Welcome to the CSUATR Program!\n" +
                "\n" +
                "The 'Help' icon can be found at the top of every window (except for Plotter) to provide additional information for that window's funcationality.\n" +
                "\n" +
                "This program works on an 'Event-Based' System meaning that any action executed is first added to the 'Event Queue' and is then executed.\n" +
                "Continuous: If checked, program will execute any events in queue automatically. If an event fails, the event is pushed back on the queue and 'Continuous' is unchecked.\n" +
                "Add Mode: Decide how events are added to queue.\n" +
                "     - Append: Add to end of queue.\n" +
                "     - Insert: Add in front of selected queue event.\n" +
                "     - Push: Add in front of all other events.\n" +
                "     - Execute: Manually execute event at top of queue.\n" +
                "     - Remove: Delete selected event. If none selected, deletes top event.\n" +
                "     - Clear Queue: Deletes all events in queue.\n" +
                "\n" +
                "(1) Connections: Provides connection options for controllers and instruments\n" +
                "(2) Positioner: Provides motor position control\n" +
                "(3) Measurement: Provides instrument state control and measurement trigger\n" +
                "(4) Scan: Generates scan sequences for one and two motors\n" +
                "(5) Data: Provides access to current data points and data options\n" +
                "(6) Plotter: Allows user to plot current data points with the filters:\n" +
                "     - Plot Type: Line, Scatter\n" +
                "     - X Axis: Amplitude, Magnitude, Phase, Real, Imaginary\n" +
                "     - Y Axis: Frequency, Source Power, Horizontal, Vertical, Depth, Azimuth, Elevation, Polarization\n" +
                "(7) Motors: Allows user to modify motor control characterization parameters\n" +
                "(8) Boundaries: Allows user to define motor position boundaries (as observed by the program)",
                "Help - Main",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
        #endregion
        #region Buttons
        private void buttonExecute_Click(object sender, EventArgs e)
        {
            eventManager.Execute();
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            eventManager.Stop();
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            eventManager.Remove();
        }
        private void buttonClearQueue_Click(object sender, EventArgs e)
        {
            eventManager.ClearQueue();
        }
        #endregion
        #region Other
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitForm == null || exitForm.Disposing || exitForm.IsDisposed)
            {
                e.Cancel = true;

                if (exitForm != null) { exitForm.Close(); }
                exitForm = new ExitForm(this);
                exitForm.Show();
            }
            else if (allowClosable == false)
            {
                e.Cancel = true;
            }
        }
        #endregion

    }
}
