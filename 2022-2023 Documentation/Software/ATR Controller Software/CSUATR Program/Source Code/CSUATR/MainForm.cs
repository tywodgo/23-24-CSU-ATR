using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OxyPlot.WindowsForms;
using OxyPlot;

namespace CSUATR
{
    public partial class MainForm : Form
    {
        #region Classes
        // Other classes
        public Arduino arduino;
        public Positioner positioner;
        public NetworkAnalyzer networkAnalyzer;
        public DataManager dataManager;
        public Scanner scanner;
        public Plotter plotter;
        #endregion

        #region Forms
        public ChangeSettingsLocationForm changeSettingsLocationForm;
        public SaveSettingsForm saveSettingsForm;
        public SaveDataForm saveDataForm;
        public LoadDataForm loadDataForm;
        public ExitApplicationForm exitApplicationForm;

        public ClearDatasetForm clearDatasetForm;

        public HelpForm helpForm;
        #endregion

        #region Plotting
        public PlotView plotview;
        public PlotModel plot;
        #endregion

        #region File IO
        // File IO (these do not change)
        public string basePath = Directory.GetCurrentDirectory();
        public string metaFolder = "Meta";
        public string metaFile = "CSUATRMeta.txt";

        // File IO (these can change) (defaults)
        public string settingsFolder = "Settings";
        public string settingsFile = "CSUATRSettings.txt";
        #endregion

        public MainForm() 
        {
            // initialize gui
            InitializeComponent();

            // initialize plot
            plotview = new PlotView();
            plotview.Location = new System.Drawing.Point(0, 0);
            plotview.Size = groupBoxPlot.Size;
            groupBoxPlot.Controls.Add(plotview);
            plot = new PlotModel();
            plotview.Model = plot;

            // initialize other program parts 
            arduino = new Arduino(this);
            positioner = new Positioner(this, arduino);
            dataManager = new DataManager(this);
            networkAnalyzer = new FieldFox(this, positioner, dataManager); // Change this if the instrument changes
            scanner = new Scanner(this, positioner, networkAnalyzer, dataManager);
            plotter = new Plotter(this, dataManager, plot);


            // initialize more gui
            PopulateItems_Port();
            PopulateItems_ScanType();
            ClearDataSelection();
            PopulateItems_Visual();

            // initialize files
            CheckMeta();
            ReadMeta();
            CheckSettingsFile(); // actually checks folder and file
            ReadSettings_Positioning();
            ReadSettings_Measurement();
            ReadSettings_ScanSettings();
            ReadSettings_Other();

            // initialize more gui
            UpdateEnabledButtons_ArduinoConnection();
            UpdateEnabledButtons_NAConnection();
            UpdateEnabledButtons_Positioning();
            UpdateEnabledButtons_Measurement();
            UpdateEnabledButtons_ScanSettings();
            UpdateEnabledDataSelections_Visual();

            // update current position of motors
            UpdateStatus_Positioning();
        }

        #region File Management

        #region Save and Change Settings
        // Save settings
        public void SaveSettings(string folder, string file)
        {
            string tempfoldername = settingsFolder;
            string tempfilename = settingsFile;
            settingsFolder = folder;
            settingsFile = file;
            CheckSettingsFolder();
            WriteSettings(); // this writes over existing document OR writes new document if none exists yet
            settingsFolder = tempfoldername;
            settingsFile = tempfilename;
            WriteToOutput(string.Format("Settings saved to: {0}\\{1}", folder, file));
        }
        // Change settings folder
        public void ChangeSettingsFolder(string folder)
        {
            settingsFolder = folder;
            CheckSettingsFolder();
            WriteMeta();
            WriteToOutput(string.Format("Settings folder changed to: {0}", folder));
        }
        // Change settings file
        public void ChangeSettingsFile(string file)
        {
            settingsFile = file;
            CheckSettingsFile();
            WriteMeta();
            WriteToOutput(string.Format("Settings file changed to: {0}", file));
        }
        #endregion

        #region Meta
        // If the meta directory/file does not exist yet (start program for first time), one is created
        public void CheckMeta()
        {
            string folderpath = basePath + @"\" + metaFolder + @"\";
            string filepath = basePath + @"\" + metaFolder + @"\" + metaFile;
            // Test if path exists
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
                WriteToOutput(string.Format("Meta folder created: {0}", metaFolder));
            }
            // Test if file exists
            if (!File.Exists(filepath))
            {
                WriteToOutput(string.Format("Meta file created: {0}", metaFile));
                WriteMeta();
            }
        }
        // Overwrite meta file (if exists) with new meta file containg program parameters
        public void WriteMeta()
        {
            string filepath = basePath + @"\" + metaFolder + @"\" + metaFile;
            using (StreamWriter sw = File.CreateText(filepath))
            {
                sw.WriteLine("Project Meta Parameters go in here. Only edit values, not parameter names");
                sw.WriteLine("");
                sw.WriteLine("Settings Folder: {0}", settingsFolder);
                sw.WriteLine("Settings File: {0}", settingsFile);
                sw.WriteLine("");
                sw.WriteLine("Data Folder: {0}", dataManager.dataFolder);
                sw.WriteLine("Data File: {0}", dataManager.dataFile);
                sw.WriteLine("");
                sw.WriteLine("Instrument Address: {0}", networkAnalyzer.address);
                sw.WriteLine("");
                sw.WriteLine("---------- Any additional comments can be added below ----------");
            }
            WriteToOutput(string.Format("Wrote to meta file: {0}", metaFile));
        }
        // Set current meta parameters
        public void ReadMeta()
        {
            try
            {
                // Read meta file and set current parameters
                string filepath = basePath + @"\" + metaFolder + @"\" + metaFile;
                using (StreamReader sr = File.OpenText(filepath))
                {
                    string s;
                    for (int lineCount = 1; lineCount <= 9; lineCount++)
                    {
                        s = sr.ReadLine();
                             if (lineCount == 3) { string value = s.Split(new[] { ':' }, 2)[1]; value = value.Replace(" ", ""); settingsFolder = value; }
                        else if (lineCount == 4) { string value = s.Split(new[] { ':' }, 2)[1]; value = value.Replace(" ", ""); settingsFile = value; }

                        else if (lineCount == 6) { string value = s.Split(new[] { ':' }, 2)[1]; value = value.Replace(" ", ""); dataManager.dataFolder = value; }
                        else if (lineCount == 7) { string value = s.Split(new[] { ':' }, 2)[1]; value = value.Replace(" ", ""); dataManager.dataFile = value; }

                        else if (lineCount == 9) { string value = s.Split(new[] { ':' }, 2)[1]; value = value.Replace(" ", ""); networkAnalyzer.address = value; }
                    }
                }
                WriteToOutput(string.Format("Read meta file: {0}", metaFile));
            }
            catch
            {
                WriteToOutput(string.Format("Failed to read meta file: {0}", metaFile));
            }
        }
        #endregion

        #region Settings
        // If the settings directory does not exist yet, one is created
        public void CheckSettingsFolder()
        {
            string folderpath = basePath + @"\" + settingsFolder + @"\";
            // Test if path exists
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
                WriteToOutput(string.Format("Settings folder created: {0}", settingsFolder));
            }
        }
        // If the settings file does not exist yet, one is created
        public void CheckSettingsFile()
        {
            string folderpath = basePath + @"\" + settingsFolder + @"\";
            string filepath = basePath + @"\" + settingsFolder + @"\" + settingsFile;
            // Test if path exists
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
                WriteToOutput(string.Format("Settings folder created: {0}", settingsFolder));
            }
            // Test if file exists
            if (!File.Exists(filepath))
            {
                WriteToOutput(string.Format("Settings file created: {0}", settingsFile));
                WriteSettings();
            }
        }
        // Overwrite settings file (if exists) with new settings file containg current program parameters
        public void WriteSettings()
        {
            // Overwrite meta file (if exists) with new meta file containg program parameters
            string filepath = basePath + @"\" + settingsFolder + @"\" + settingsFile;
            using (StreamWriter sw = File.CreateText(filepath))
            {
                sw.WriteLine("Project Settings go in here. Only edit values, not parameter names");
                sw.WriteLine("");
                sw.WriteLine("---------- Positioning Parameters ----------");
                sw.WriteLine("Polar Engaged: {0}", engagedPolar);
                sw.WriteLine("Vertical Engaged: {0}", engagedVertical);
                sw.WriteLine("Horizontal Engaged: {0}", engagedHorizontal);
                sw.WriteLine("Depth Engaged: {0}", engagedDepth);
                sw.WriteLine("Azimuth Engaged: {0}", engagedAzimuth);
                sw.WriteLine("Elevation Engaged: {0}", engagedElevation);
                sw.WriteLine("");
                sw.WriteLine("Move-To Polar: {0}", moveToPolar.Value);
                sw.WriteLine("Move-To Vertical: {0}", moveToVertical.Value);
                sw.WriteLine("Move-To Horizontal: {0}", moveToHorizontal.Value);
                sw.WriteLine("Move-To Depth: {0}", moveToDepth.Value);
                sw.WriteLine("Move-To Azimuth: {0}", moveToAzimuth.Value);
                sw.WriteLine("Move-To Elevation: {0}", moveToElevation.Value);
                sw.WriteLine("");
                sw.WriteLine("Move-By Polar: {0}", moveByPolar.Value);
                sw.WriteLine("Move-By Vertical: {0}", moveByVertical.Value);
                sw.WriteLine("Move-By Horizontal: {0}", moveByHorizontal.Value);
                sw.WriteLine("Move-By Depth: {0}", moveByDepth.Value);
                sw.WriteLine("Move-By Azimuth: {0}", moveByAzimuth.Value);
                sw.WriteLine("Move-By Elevation: {0}", moveByElevation.Value);
                sw.WriteLine("");
                sw.WriteLine("---------- Measurement Parameters ----------");
                sw.WriteLine("Set-To Source Power: {0}", setToSourcePower.Value);
                sw.WriteLine("Set-To Start Frequency: {0}", setToStartFrequency.Value);
                sw.WriteLine("Set-To Stop Frequency: {0}", setToStopFrequency.Value);
                sw.WriteLine("Set-To # Sweep Points: {0}", setToSweepPoints.Value);
                sw.WriteLine("Set-To # Averaging Points: {0}", setToAvgPoints.Value);
                sw.WriteLine("");
                sw.WriteLine("---------- Scan Settings Parameters ----------");
                sw.WriteLine("Polar Unlocked: {0}", unlockedPolar);
                sw.WriteLine("Vertical Unlocked: {0}", unlockedVertical);
                sw.WriteLine("Horizontal Unlocked: {0}", unlockedHorizontal);
                sw.WriteLine("Depth Unlocked: {0}", unlockedDepth);
                sw.WriteLine("Azimuth Unlocked: {0}", unlockedAzimuth);
                sw.WriteLine("Elevation Unlocked: {0}", unlockedElevation);
                sw.WriteLine("");
                sw.WriteLine("Polar Lower Limit: {0}", lowerLimitPolar.Value);
                sw.WriteLine("Vertical Lower Limit: {0}", lowerLimitVertical.Value);
                sw.WriteLine("Horizontal Lower Limit: {0}", lowerLimitHorizontal.Value);
                sw.WriteLine("Depth Lower Limit: {0}", lowerLimitDepth.Value);
                sw.WriteLine("Azimuth Lower Limit: {0}", lowerLimitAzimuth.Value);
                sw.WriteLine("Elevation Lower Limit: {0}", lowerLimitElevation.Value);
                sw.WriteLine("");
                sw.WriteLine("Polar Upper Limit: {0}", upperLimitPolar.Value);
                sw.WriteLine("Vertical Upper Limit: {0}", upperLimitVertical.Value);
                sw.WriteLine("Horizontal Upper Limit: {0}", upperLimitHorizontal.Value);
                sw.WriteLine("Depth Upper Limit: {0}", upperLimitDepth.Value);
                sw.WriteLine("Azimuth Upper Limit: {0}", upperLimitAzimuth.Value);
                sw.WriteLine("Elevation Upper Limit: {0}", upperLimitElevation.Value);
                sw.WriteLine("");
                sw.WriteLine("Polar Resolution: {0}", resolutionPolar.Value);
                sw.WriteLine("Vertical Resolution: {0}", resolutionVertical.Value);
                sw.WriteLine("Horizontal Resolution: {0}", resolutionHorizontal.Value);
                sw.WriteLine("Depth Resolution: {0}", resolutionDepth.Value);
                sw.WriteLine("Azimuth Resolution: {0}", resolutionAzimuth.Value);
                sw.WriteLine("Elevation Resolution: {0}", resolutionElevation.Value);
                sw.WriteLine("");
                sw.WriteLine("Frequency Lower Limit: {0}", lowerLimitFrequency.Value);
                sw.WriteLine("Frequency Upper Limit: {0}", upperLimitFrequency.Value);
                sw.WriteLine("# Sweep Points: {0}", scanSweepPoints.Value);
                sw.WriteLine("");
                sw.WriteLine("Source Power: {0}", scanSourcePower.Value);
                sw.WriteLine("# Averaging Points: {0}", scanAvgPoints.Value);
                sw.WriteLine("");
                sw.WriteLine("Scan Type: {0}", scanType.Text);
                sw.WriteLine("");
                sw.WriteLine("---------- Other Parameters ----------");
                sw.WriteLine("Arduino Port: {0}", port.Text);
                sw.WriteLine("");
                sw.WriteLine("PNA Mode: {0}", mode.Text);
                sw.WriteLine("");
                sw.WriteLine("---------- Any additional comments can be added below ----------");
            }
            WriteToOutput(string.Format("Wrote to settings file: {0}", settingsFile));
        }
        // Read Positioning parameters and set them
        public void ReadSettings_Positioning()
        {
            try
            {
                int groupStart = 3;
                string filepath = basePath + @"\" + settingsFolder + @"\" + settingsFile;
                using (StreamReader sr = File.OpenText(filepath))
                {
                    string s;
                    for (int lineCount = 1; lineCount <= 23; lineCount++)
                    {
                        s = sr.ReadLine();
                        if (lineCount == groupStart + 1) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); engagedPolar = System.Convert.ToBoolean(value);
                            if (engagedPolar == true) { buttonEngagePolar.Text = "Engaged"; }
                            else { buttonEngagePolar.Text = "Unengaged"; }
                        }
                        else if (lineCount == groupStart + 2) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); engagedVertical = System.Convert.ToBoolean(value);
                            if (engagedVertical == true) { buttonEngageVertical.Text = "Engaged"; }
                            else { buttonEngageVertical.Text = "Unengaged"; }
                        }
                        else if (lineCount == groupStart + 3) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); engagedHorizontal = System.Convert.ToBoolean(value);
                            if (engagedHorizontal == true) { buttonEngageHorizontal.Text = "Engaged"; }
                            else { buttonEngageHorizontal.Text = "Unengaged"; }
                        }
                        else if (lineCount == groupStart + 4) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); engagedDepth = System.Convert.ToBoolean(value);
                            if (engagedDepth == true) { buttonEngageDepth.Text = "Engaged"; }
                            else { buttonEngageDepth.Text = "Unengaged"; }
                        }
                        else if (lineCount == groupStart + 5) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); engagedAzimuth = System.Convert.ToBoolean(value);
                            if (engagedAzimuth == true) { buttonEngageAzimuth.Text = "Engaged"; }
                            else { buttonEngageAzimuth.Text = "Unengaged"; }
                        }
                        else if (lineCount == groupStart + 6) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); engagedElevation = System.Convert.ToBoolean(value);
                            if (engagedElevation == true) { buttonEngageElevation.Text = "Engaged"; }
                            else { buttonEngageElevation.Text = "Unengaged"; }
                        }

                        else if (lineCount == groupStart + 8) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveToPolar.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 9) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveToVertical.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 10) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveToHorizontal.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 11) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveToDepth.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 12) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveToAzimuth.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 13) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveToElevation.Value = System.Convert.ToDecimal(value); }

                        else if (lineCount == groupStart + 15) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveByPolar.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 16) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveByVertical.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 17) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveByHorizontal.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 18) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveByDepth.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 19) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveByAzimuth.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 20) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); moveByElevation.Value = System.Convert.ToDecimal(value); }
                    }
                }
                WriteToOutput(string.Format("Read positioning settings in file: {0}", settingsFile));
                UpdateEnabledButtons_Positioning();
            }
            catch
            {
                WriteToOutput(string.Format("Failed to read settings file: {0}", settingsFile));
            }
        }
        // Read Network Analyzer parameters and set them
        public void ReadSettings_Measurement()
        {
            try
            {
                int groupStart = 25;
                string filepath = basePath + @"\" + settingsFolder + @"\" + settingsFile;
                using (StreamReader sr = File.OpenText(filepath))
                {
                    string s;
                    for (int lineCount = 1; lineCount <= 30; lineCount++)
                    {
                        s = sr.ReadLine();
                        if (lineCount == groupStart + 1) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); setToSourcePower.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 2) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); setToStartFrequency.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 3) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); setToStopFrequency.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 4) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); setToSweepPoints.Value = System.Convert.ToUInt32(value); }
                        else if (lineCount == groupStart + 5) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); setToAvgPoints.Value = System.Convert.ToUInt32(value); }
                    }
                }
                WriteToOutput(string.Format("Read measurement settings in file: {0}", settingsFile));
                UpdateEnabledButtons_Measurement();
            }
            catch
            {
                WriteToOutput(string.Format("Failed to read settings file: {0}", settingsFile));
            }
        }
        // Read Scan Settings parameters and set them
        public void ReadSettings_ScanSettings()
        {
            try
            {
                int groupStart = 32;
                string filepath = basePath + @"\" + settingsFolder + @"\" + settingsFile;
                using (StreamReader sr = File.OpenText(filepath))
                {
                    string s;
                    for (int lineCount = 1; lineCount <= 68; lineCount++)
                    {
                        s = sr.ReadLine();
                        if (lineCount == groupStart + 1) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); unlockedPolar = System.Convert.ToBoolean(value);
                            if (unlockedPolar == true) { buttonLockPolar.Text = "Unlocked"; }
                            else { buttonLockPolar.Text = "Locked"; }
                        }
                        else if (lineCount == groupStart + 2) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); unlockedVertical = System.Convert.ToBoolean(value);
                            if (unlockedVertical == true) { buttonLockVertical.Text = "Unlocked"; }
                            else { buttonLockVertical.Text = "Locked"; }
                        }
                        else if (lineCount == groupStart + 3) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); unlockedHorizontal = System.Convert.ToBoolean(value);
                            if (unlockedHorizontal == true) { buttonLockHorizontal.Text = "Unlocked"; }
                            else { buttonLockHorizontal.Text = "Locked"; }
                        }
                        else if (lineCount == groupStart + 4) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); unlockedDepth = System.Convert.ToBoolean(value);
                            if (unlockedDepth == true) { buttonLockDepth.Text = "Unlocked"; }
                            else { buttonLockDepth.Text = "Locked"; }
                        }
                        else if (lineCount == groupStart + 5) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); unlockedAzimuth = System.Convert.ToBoolean(value);
                            if (unlockedAzimuth == true) { buttonLockAzimuth.Text = "Unlocked"; }
                            else { buttonLockAzimuth.Text = "Locked"; }
                        }
                        else if (lineCount == groupStart + 6) {
                            string value = s.Split(':')[1]; value = value.Replace(" ", ""); unlockedElevation = System.Convert.ToBoolean(value);
                            if (unlockedElevation == true) { buttonLockElevation.Text = "Unlocked"; }
                            else { buttonLockElevation.Text = "Locked"; }
                        }

                        else if (lineCount == groupStart + 8) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); lowerLimitPolar.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 9) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); lowerLimitVertical.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 10) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); lowerLimitHorizontal.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 11) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); lowerLimitDepth.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 12) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); lowerLimitAzimuth.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 13) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); lowerLimitElevation.Value = System.Convert.ToDecimal(value); }

                        else if (lineCount == groupStart + 15) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); upperLimitPolar.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 16) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); upperLimitVertical.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 17) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); upperLimitHorizontal.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 18) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); upperLimitDepth.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 19) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); upperLimitAzimuth.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 20) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); upperLimitElevation.Value = System.Convert.ToDecimal(value); }

                        else if (lineCount == groupStart + 22) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); resolutionPolar.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 23) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); resolutionVertical.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 24) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); resolutionHorizontal.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 25) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); resolutionDepth.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 26) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); resolutionAzimuth.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 27) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); resolutionElevation.Value = System.Convert.ToDecimal(value); }

                        else if (lineCount == groupStart + 29) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); lowerLimitFrequency.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 30) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); upperLimitFrequency.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 31) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); scanSweepPoints.Value = System.Convert.ToUInt32(value); }

                        else if (lineCount == groupStart + 33) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); scanSourcePower.Value = System.Convert.ToDecimal(value); }
                        else if (lineCount == groupStart + 34) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); scanAvgPoints.Value = System.Convert.ToUInt32(value); }

                        else if (lineCount == groupStart + 36) { string value = s.Split(':')[1]; value = value.Replace(" ", ""); scanType.Text = value; }
                    }
                }
                WriteToOutput(string.Format("Read scan settings in file: {0}", settingsFile));
                UpdateEnabledButtons_ScanSettings();
            }
            catch
            {
                WriteToOutput(string.Format("Failed to read settings file: {0}", settingsFile));
            }
        }
        // Read port and mode and set them
        public void ReadSettings_Other()
        {
            try
            {
                int groupStart = 70;
                string filepath = basePath + @"\" + settingsFolder + @"\" + settingsFile;
                using (StreamReader sr = File.OpenText(filepath))
                {
                    string s;
                    for (int lineCount = 1; lineCount <= 73; lineCount++)
                    {
                        s = sr.ReadLine();
                             if (lineCount == groupStart + 1) { string value = s.Split(new[] { ':' }, 2)[1]; value = value.Replace(" ", ""); port.Text = value; }

                        else if (lineCount == groupStart + 3) { string value = s.Split(new[] { ':' }, 2)[1]; value = value.Replace(" ", ""); mode.Text = value; }

                    }
                }
                WriteToOutput(string.Format("Read other settings in file: {0}", settingsFile));
            }
            catch
            {
                WriteToOutput(string.Format("Failed to read settings file: {0}", settingsFile));
            }
        }

        #endregion

        #endregion


    }
}
