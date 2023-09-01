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
    public partial class MeasurementForm : Form
    {
        #region Classes
        FileManager settings;
        EventManager eventManager;
        Instrument instrument;
        #endregion
        #region Forms
        SaveSettingsForm saveSettingsForm;
        LoadSettingsForm loadSettingsForm;
        #endregion
        #region Constants
        string[] sParameters =
        {
            "S11",
            "S12",
            "S21",
            "S22"
        };
        double KILOHERTZ = 1000;
        double MEGAHERTZ = 1000000;
        #endregion

        public MeasurementForm(FileManager settings, EventManager eventManager, Instrument instrument)
        {
            this.settings = settings;
            this.eventManager = eventManager;
            this.instrument = instrument;
            InitializeComponent();
            PopulateSParameters();
            LoadSettings(0);
        }

        #region Settings
        public void SaveSettings(int i)
        {
            List<object[]> lines = new List<object[]>();
            lines.Add(new object[] { "S Parameter", sParameter.Text });
            lines.Add(new object[] { "Source Power", sourcePower.Value });
            lines.Add(new object[] { "Start Frequency", startFrequency.Value });
            lines.Add(new object[] { "Stop Frequency", stopFrequency.Value });
            lines.Add(new object[] { "IF Bandwidth", ifBandwidth.Value });
            lines.Add(new object[] { "Sweep Points", sweepPoints.Value });
            lines.Add(new object[] { "Average Points", averagePoints.Value });
            settings.Write(lines);
        }
        public void LoadSettings(int i)
        {
            List<string[]> lines = settings.Read();
            if (lines.Any())
            {
                foreach (string[] line in lines)
                {
                    if (line[0].Equals("S Parameter"))      { sParameter.Text = line[1]; }
                    else if (line[0].Equals("Source Power"))     { sourcePower.Value = Convert.ToDecimal(line[1]); }
                    else if (line[0].Equals("Start Frequency"))  { startFrequency.Value = Convert.ToDecimal(line[1]); }
                    else if (line[0].Equals("Stop Frequency"))   { stopFrequency.Value = Convert.ToDecimal(line[1]); }
                    else if (line[0].Equals("IF Bandwidth"))     { ifBandwidth.Value = Convert.ToDecimal(line[1]); }
                    else if (line[0].Equals("Sweep Points"))     { sweepPoints.Value = Convert.ToInt32(line[1]); }
                    else if (line[0].Equals("Average Points"))   { averagePoints.Value = Convert.ToInt32(line[1]); }
                }
            }
            else
            {
                SaveSettings(0);
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
                "(1) Measure: Triggers measurement on instrument.\n" +
                "(2) Set: For a given characteristic, the current instrument value is displayed in the main window.",
                "Help - Measurement",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
        #endregion
        #region Buttons
        private void buttonMeasure_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(instrument.Measure, new object[] { }));
        }
        private void buttonSetAll_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(instrument.SetSParameter, new object[] { sParameter.Text }));
            eventManager.AddEvent(new Function(instrument.SetSourcePower, new object[] { (double)sourcePower.Value }));
            eventManager.AddEvent(new Function(instrument.SetStartFrequency, new object[] { (double)startFrequency.Value * MEGAHERTZ }));
            eventManager.AddEvent(new Function(instrument.SetStopFrequency, new object[] { (double)stopFrequency.Value * MEGAHERTZ }));
            eventManager.AddEvent(new Function(instrument.SetIFBandwidth, new object[] { (double)ifBandwidth.Value * KILOHERTZ }));
            eventManager.AddEvent(new Function(instrument.SetSweepPoints, new object[] { (int)sweepPoints.Value }));
            eventManager.AddEvent(new Function(instrument.SetAveragePoints, new object[] { (int)averagePoints.Value }));
        }
        private void buttonSetSParameter_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(instrument.SetSParameter, new object[] { sParameter.Text }));
        }
        private void buttonSetSourcePower_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(instrument.SetSourcePower, new object[] { (double)sourcePower.Value }));
        }
        private void buttonSetStartFrequency_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(instrument.SetStartFrequency, new object[] { (double)startFrequency.Value * MEGAHERTZ }));
        }
        private void buttonSetStopFrequency_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(instrument.SetStopFrequency, new object[] { (double)stopFrequency.Value * MEGAHERTZ }));
        }
        private void buttonSetIfBandwidth_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(instrument.SetIFBandwidth, new object[] { (double)ifBandwidth.Value * KILOHERTZ }));
        }
        private void buttonSetSweepPoints_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(instrument.SetSweepPoints, new object[] { (int)sweepPoints.Value }));
        }
        private void buttonSetAveragePoints_Click(object sender, EventArgs e)
        {
            eventManager.AddEvent(new Function(instrument.SetAveragePoints, new object[] { (int)averagePoints.Value }));
        }
        #endregion

        public void PopulateSParameters()
        {
            sParameter.Items.Clear();
            sParameter.Items.AddRange(sParameters);
            if (sParameters.Length > 0) { sParameter.SelectedIndex = 2; }
        }


    }
}
