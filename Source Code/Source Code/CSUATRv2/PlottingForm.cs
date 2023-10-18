using OxyPlot;
using OxyPlot.WindowsForms;
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
    public partial class PlottingForm : Form
    {
        Plotter plotter;
        DataManager dataManager;

        #region Plotting
        public PlotView plotview;
        public PlotModel plot;
        #endregion

        #region Flags
        bool ready = true;
        #endregion

        public string[] plotTypes =
        {
            "Line",
            "Scatter"
        };
        public string[] xAxes =
        {
            "Frequency",
            "Source Power",
            "Horizontal",
            "Vertical",
            "Depth",
            "Azimuth",
            "Elevation",
            "Polarization"
        };
        public string[] yAxes =
        {
            "Amplitude",
            "Magnitude",
            "Phase",
            "Real",
            "Imaginary"
        };
        public string[] axes =
        {
            @"Magnitude/Phase",
            @"Real/Imaginary",
        };
        public string[] variables =
        {
            "Frequency",
            "Source Power",
            "Horizontal",
            "Vertical",
            "Depth",
            "Azimuth",
            "Elevation",
            "Polarization"
        };

        public string[] sParameters =
        {
            "S11",
            "S12",
            "S21",
            "S22"
        };

        double MEGAHERTZ = 1000000;

        public PlottingForm(DataManager dataManager)
        {
            this.dataManager = dataManager;
            InitializeComponent();

            // initialize plot
            plotview = new PlotView();
            tableLayoutPanel2.Controls.Add(plotview, 1, 0);
            plotview.Dock = DockStyle.Fill;
            
            plot = new PlotModel();
            plotview.Model = plot;
            plotter = new Plotter(this, dataManager, plot);

            plotType.Items.Clear();
            plotType.Items.AddRange(plotTypes);
            plotType.SelectedIndex = 0;
            plotter.currentPlotType = plotType.Text;
            UpdateForPlotType();

            sparamSelect.Items.Clear();
            sparamSelect.Items.AddRange(sParameters);
            sparamSelect.SelectedIndex = 0;
            plotter.currentSParam = sparamSelect.Text;

            continuous.Checked = true;

            RepopulateAllDataSelections();
            UpdateEnables();
            plotter.UpdatePlot();
        }

        #region GUI Functions
        private void buttonAutoScale_Click(object sender, EventArgs e)
        {
            plotter.AutoScalePlot();
        }

        private void plotType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                plotter.currentPlotType = plotType.Text;
                UpdateForPlotType();
                plotter.UpdatePlot();
            }
            catch { }
        }
        private void valueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                plotter.currentValueType = valueType.Text;
                plotter.UpdatePlot();
            }
            catch { }
        }
        private void variable_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnables();
            try
            {
                plotter.currentVariable = variable.Text;
                plotter.UpdatePlot();
            }
            catch { }
        }

        private void sparamSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                plotter.currentSParam = sparamSelect.Text;
                RepopulateAllDataSelections();
                plotter.UpdatePlot();
            }
            catch { }
        }

        private void idSelect_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //plotter.currentID = System.Convert.ToInt64(idSelect.Text);
                plotter.currentID = idSelect.Text;
                UpdateWithID();
            }
            catch { }
        }
        private void frequencySelect_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //plotter.currentFrequency = System.Convert.ToDouble(frequencySelect.Text) * MEGAHERTZ;
                plotter.currentFrequency = frequencySelect.Text;
                UpdateWithNormal();
            }
            catch { }
        }
        private void powerSelect_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //plotter.currentPower = System.Convert.ToDouble(powerSelect.Text);
                plotter.currentPower = powerSelect.Text;
                UpdateWithNormal();
            }
            catch { }
        }
        private void horizontalSelect_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //plotter.currentHorizontal = System.Convert.ToDouble(horizontalSelect.Text);
                plotter.currentHorizontal = horizontalSelect.Text;
                UpdateWithNormal();
            }
            catch { }
        }
        private void verticalSelect_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //plotter.currentVertical = System.Convert.ToDouble(verticalSelect.Text);
                plotter.currentVertical = verticalSelect.Text;
                UpdateWithNormal();
            }
            catch { }
        }
        private void depthSelect_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //plotter.currentDepth = System.Convert.ToDouble(depthSelect.Text);
                plotter.currentDepth = depthSelect.Text;
                UpdateWithNormal();
            }
            catch { }
        }
        private void azimuthSelect_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //plotter.currentAzimuth = System.Convert.ToDouble(azimuthSelect.Text);
                plotter.currentAzimuth = azimuthSelect.Text;
                UpdateWithNormal();
            }
            catch { }
        }
        private void elevationSelect_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //plotter.currentElevation = System.Convert.ToDouble(elevationSelect.Text);
                plotter.currentElevation = elevationSelect.Text;
                UpdateWithNormal();
            }
            catch { }
        }
        private void polarSelect_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                //plotter.currentPolarization = System.Convert.ToDouble(polarSelect.Text);
                plotter.currentPolarization = polarSelect.Text;
                UpdateWithNormal();
            }
            catch { }
        }

        private void UpdateWithNormal()
        {
            if (ready == true)
            {
                if (plotter.currentVariable.Equals("Frequency"))
                {
                    ready = false;
                    SetIDForSelection();
                    ready = true;
                }
                plotter.UpdatePlot();
            }
        }
        private void UpdateWithID()
        {
            if (ready == true)
            {
                if (plotter.currentVariable.Equals("Frequency"))
                {
                    ready = false;
                    SetSelectionForID();
                    ready = true;
                }
                plotter.UpdatePlot();
            }
        }
        public void SetSelectionForID()
        {
            try
            {
                for (int i = 0; i < dataManager.data.Count; i++)
                {
                    if (dataManager.data[i].id.ToString("N0") == plotter.currentID)
                    {
                        powerSelect.SelectedItem = dataManager.data[i].sourcePower.ToString("N3");
                        horizontalSelect.SelectedItem = dataManager.data[i].horizontal.ToString("N2");
                        verticalSelect.SelectedItem = dataManager.data[i].vertical.ToString("N2");
                        depthSelect.SelectedItem = dataManager.data[i].depth.ToString("N2");
                        azimuthSelect.SelectedItem = dataManager.data[i].azimuth.ToString("N2");
                        elevationSelect.SelectedItem = dataManager.data[i].elevation.ToString("N2");
                        polarSelect.SelectedItem = dataManager.data[i].polarization.ToString("N2");
                        break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Failed to set selection for ID");
            }
        }
        public void SetIDForSelection()
        {
            try
            {
                for (int i = 0; i < dataManager.data.Count; i++)
                {
                    if (
                        dataManager.data[i].sParameter.Equals(plotter.currentSParam) &&
                        dataManager.data[i].sourcePower.ToString("N3") == plotter.currentPower &&
                        dataManager.data[i].horizontal.ToString("N2") == plotter.currentHorizontal &&
                        dataManager.data[i].vertical.ToString("N2") == plotter.currentVertical &&
                        dataManager.data[i].depth.ToString("N2") == plotter.currentDepth &&
                        dataManager.data[i].azimuth.ToString("N2") == plotter.currentAzimuth &&
                        dataManager.data[i].elevation.ToString("N2") == plotter.currentElevation &&
                        dataManager.data[i].polarization.ToString("N2") == plotter.currentPolarization
                        )
                    {
                        idSelect.SelectedItem = dataManager.data[i].id.ToString();
                        // break; is not put here because, if there are repeat points, we want the latest one
                    }
                }
            }
            catch
            {
                Console.WriteLine("Failed to set ID for selection");
            }
        }
        #endregion

        #region Other Functions
        private void UpdateEnables()
        {
            idSelect.Enabled = false;
            frequencySelect.Enabled = true;

            powerSelect.Enabled = true;
            horizontalSelect.Enabled = true;
            verticalSelect.Enabled = true;
            depthSelect.Enabled = true;
            azimuthSelect.Enabled = true;
            elevationSelect.Enabled = true;
            polarSelect.Enabled = true;
            if (variable.Text.Equals("Frequency"))
            {
                frequencySelect.Enabled = false;
                idSelect.Enabled = true;
            }
            else if (variable.Text.Equals("Source Power")) { powerSelect.Enabled = false; }
            else if (variable.Text.Equals("Horizontal")) { horizontalSelect.Enabled = false; }
            else if (variable.Text.Equals("Vertical")) { verticalSelect.Enabled = false; }
            else if (variable.Text.Equals("Depth")) { depthSelect.Enabled = false; }
            else if (variable.Text.Equals("Azimuth")) { azimuthSelect.Enabled = false; }
            else if (variable.Text.Equals("Elevation")) { elevationSelect.Enabled = false; }
            else if (variable.Text.Equals("Polarization")) { polarSelect.Enabled = false; }
        }
        // Clear Data Selection
        public void ClearDataSelection()
        {
            if (InvokeRequired) { Invoke(new MethodInvoker(delegate { _ClearDataSelection(); })); }
            else { _ClearDataSelection(); }
        }
        private void _ClearDataSelection()
        {
            idSelect.Items.Clear();
            frequencySelect.Items.Clear();
            powerSelect.Items.Clear();
            horizontalSelect.Items.Clear();
            verticalSelect.Items.Clear();
            depthSelect.Items.Clear();
            azimuthSelect.Items.Clear();
            elevationSelect.Items.Clear();
            polarSelect.Items.Clear();

            idSelect.Text = "NULL";
            frequencySelect.Text = "NULL";
            powerSelect.Text = "NULL";
            horizontalSelect.Text = "NULL";
            verticalSelect.Text = "NULL";
            depthSelect.Text = "NULL";
            azimuthSelect.Text = "NULL";
            elevationSelect.Text = "NULL";
            polarSelect.Text = "NULL";
        }
        // Repopulate All Data Selections
        public void RepopulateAllDataSelections()
        {
            if (InvokeRequired) { Invoke(new MethodInvoker(delegate { _RepopulateAllDataSelections(); })); }
            else { _RepopulateAllDataSelections(); }
        }
        private void _RepopulateAllDataSelections()
        {
            ClearDataSelection();
            for (int i = 0; i < dataManager.data.Count; i++)
            {
                AppendDataSelection(i);
            }
        }
        // Append Data Selection
        public void AppendDataSelection(int index)
        {
            if (InvokeRequired) { Invoke(new MethodInvoker(delegate { _AppendDataSelection(index); })); }
            else { _AppendDataSelection(index); }
        }
        private void _AppendDataSelection(int index)
        {
            if (dataManager.data[index].sParameter.Equals(plotter.currentSParam))
            {
                // add dataset values that are recognized by the program (and can be chosen by the user)
                // averagePoints is not accounted for here
                // syntax used for converting values to strings needs to stay consistent throughout the program
                // (see data types that are used in positioner and instrument)
                // (see ToString format that is used in positioning and measurement)
                string idString = dataManager.data[index].id.ToString();
                if (!idSelect.Items.Contains(idString)) { idSelect.Items.Add(idString); }

                string powerString = dataManager.data[index].sourcePower.ToString("N3");
                if (!powerSelect.Items.Contains(powerString)) { powerSelect.Items.Add(powerString); }

                string horizontalString = dataManager.data[index].horizontal.ToString("N2");
                if (!horizontalSelect.Items.Contains(horizontalString)) { horizontalSelect.Items.Add(horizontalString); }

                string verticalString = dataManager.data[index].vertical.ToString("N2");
                if (!verticalSelect.Items.Contains(verticalString)) { verticalSelect.Items.Add(verticalString); }

                string depthString = dataManager.data[index].depth.ToString("N2");
                if (!depthSelect.Items.Contains(depthString)) { depthSelect.Items.Add(depthString); }

                string azimuthString = dataManager.data[index].azimuth.ToString("N2");
                if (!azimuthSelect.Items.Contains(azimuthString)) { azimuthSelect.Items.Add(azimuthString); }

                string elevationString = dataManager.data[index].elevation.ToString("N2");
                if (!elevationSelect.Items.Contains(elevationString)) { elevationSelect.Items.Add(elevationString); }

                string polarString = dataManager.data[index].polarization.ToString("N2");
                if (!polarSelect.Items.Contains(polarString)) { polarSelect.Items.Add(polarString); }

                string frequencyString;
                for (int i = 0; i < dataManager.data[index].frequency.Length; i++)
                {
                    frequencyString = (dataManager.data[index].frequency[i] / MEGAHERTZ).ToString("N3");
                    if (!frequencySelect.Items.Contains(frequencyString)) { frequencySelect.Items.Add(frequencyString); }
                }
            }
            if (idSelect.Items.Count == 1) { idSelect.SelectedItem = idSelect.Items[0]; }
        }
        // Update Continuously
        public void UpdateContinuously(int index)
        {
            if (InvokeRequired) { Invoke(new MethodInvoker(delegate { _UpdateContinuously(index); })); }
            else { _UpdateContinuously(index); }
        }
        private void _UpdateContinuously(int index)
        {
            try
            {
                if (continuous.Checked == true && ready == true)
                {
                    if (plotter.currentVariable.Equals("Frequency"))
                    {
                        idSelect.SelectedItem = dataManager.data[index].id.ToString(); // will call UpdatePlot()
                    }
                    else
                    {
                        plotter.UpdatePlot();
                    }
                }
            }
            catch
            {
                Console.WriteLine("UpdateContinuously failed");
            }
        }
        // Update for changes in plottype
        public void UpdateForPlotType()
        {
            if (InvokeRequired) { Invoke(new MethodInvoker(delegate { _UpdateForPlotType(); })); }
            else { _UpdateForPlotType(); }
        }
        private void _UpdateForPlotType()
        {
            if (plotType.Text.Equals("Line"))
            {
                labelValueType.Text = "Y Axis:";
                valueType.Items.Clear();
                valueType.Items.AddRange(yAxes);
                valueType.SelectedIndex = 0;
                plotter.currentValueType = valueType.Text;

                labelVariable.Text = "X Axis:";
                variable.Items.Clear();
                variable.Items.AddRange(xAxes);
                variable.SelectedIndex = 0;
                plotter.currentVariable = variable.Text;
            }
            else
            {
                labelValueType.Text = "Axes:";
                valueType.Items.Clear();
                valueType.Items.AddRange(axes);
                valueType.SelectedIndex = 0;
                plotter.currentValueType = valueType.Text;

                labelVariable.Text = "Variable:";
                variable.Items.Clear();
                variable.Items.AddRange(variables);
                variable.SelectedIndex = 0;
                plotter.currentVariable = variable.Text;
            }
        }
        #endregion


    }
}
