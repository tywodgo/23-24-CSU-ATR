using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATR
{
    partial class MainForm
    {
        #region GUI Parameters
        // checkContinuous

        // checkReal
        // checkImag
        // checkMag
        // checkPhase

        // checkScatRI
        // checkScatMP

        // polarSelect
        // verticalSelect
        // horizontalSelect
        // depthSelect
        // azimuthSelect
        // elevationSelect
        // frequencySelect
        // powerSelect

        // indexSelect
        #endregion

        #region Flags
        bool indexAutoFill = false;
        #endregion

        #region Active Functions

        #region Check Functions
        // enable different data
        private void checkReal_Click(object sender, EventArgs e)
        {
            checkScatRI.Checked = false;
            checkScatMP.Checked = false;
            plotter.UpdatePlot();
        }
        private void checkImag_Click(object sender, EventArgs e)
        {
            checkScatRI.Checked = false;
            checkScatMP.Checked = false;
            plotter.UpdatePlot();
        }
        private void checkMag_Click(object sender, EventArgs e)
        {
            checkScatRI.Checked = false;
            checkScatMP.Checked = false;
            plotter.UpdatePlot();
        }
        private void checkPhase_Click(object sender, EventArgs e)
        {
            checkScatRI.Checked = false;
            checkScatMP.Checked = false;
            plotter.UpdatePlot();
        }
        private void checkScatRI_Click(object sender, EventArgs e)
        {
            checkReal.Checked = false;
            checkImag.Checked = false;
            checkMag.Checked = false;
            checkPhase.Checked = false;
            plotter.UpdatePlot();
        }
        private void checkScatMP_Click(object sender, EventArgs e)
        {
            checkReal.Checked = false;
            checkImag.Checked = false;
            checkMag.Checked = false;
            checkPhase.Checked = false;
            plotter.UpdatePlot();
        }
        #endregion

        #region User Selection Data Functions
        // data point selection
        private void polarSelect_TextChanged(object sender, EventArgs e)
        {
            if (indexAutoFill == false)
            {
                if (indepVariable.Text.Equals("Frequency"))
                {
                    SetAssociatedIndexForFrequencyVariable();
                }
                else { plotter.UpdatePlot(); }
            }
        }
        private void verticalSelect_TextChanged(object sender, EventArgs e)
        {
            if (indexAutoFill == false)
            {
                if (indepVariable.Text.Equals("Frequency"))
                {
                    SetAssociatedIndexForFrequencyVariable();
                }
                else { plotter.UpdatePlot(); }
            }
        }
        private void horizontalSelect_TextChanged(object sender, EventArgs e)
        {
            if (indexAutoFill == false)
            {
                if (indepVariable.Text.Equals("Frequency"))
                {
                    SetAssociatedIndexForFrequencyVariable();
                }
                else { plotter.UpdatePlot(); }
            }
        }
        private void depthSelect_TextChanged(object sender, EventArgs e)
        {
            if (indexAutoFill == false)
            {
                if (indepVariable.Text.Equals("Frequency"))
                {
                    SetAssociatedIndexForFrequencyVariable();
                }
                else { plotter.UpdatePlot(); }
            }
        }
        private void azimuthSelect_TextChanged(object sender, EventArgs e)
        {
            if (indexAutoFill == false)
            {
                if (indepVariable.Text.Equals("Frequency"))
                {
                    SetAssociatedIndexForFrequencyVariable();
                }
                else { plotter.UpdatePlot(); }
            }
        }
        private void elevationSelect_TextChanged(object sender, EventArgs e)
        {
            if (indexAutoFill == false)
            {
                if (indepVariable.Text.Equals("Frequency"))
                {
                    SetAssociatedIndexForFrequencyVariable();
                }
                else { plotter.UpdatePlot(); }
            }
        }
        private void frequencySelect_TextChanged(object sender, EventArgs e)
        {
            if (indexAutoFill == false)
            {
                if (indepVariable.Text.Equals("Frequency"))
                {
                    SetAssociatedIndexForFrequencyVariable();
                }
                else { plotter.UpdatePlot(); }
            }
        }
        private void powerSelect_TextChanged(object sender, EventArgs e)
        {
            if (indexAutoFill == false)
            {
                if (indepVariable.Text.Equals("Frequency"))
                {
                    SetAssociatedIndexForFrequencyVariable();
                }
                else { plotter.UpdatePlot(); }
            }
        }
        #endregion

        #region Other Functions
        private void buttonAutoScale_Click(object sender, EventArgs e)
        {
            plotter.AutoScalePlot();
        }
        private void indepVariable_TextChanged(object sender, EventArgs e)
        {
            UpdateEnabledDataSelections_Visual();
            plotter.UpdatePlot();
        }
        private void indexSelect_TextChanged(object sender, EventArgs e)
        {
            SetDataSelectionForIndex();
        }
        private void modeSelect_TextChanged(object sender, EventArgs e)
        {
            RepopulateEntireDataSelection();
        }
        #endregion

        #endregion

        #region Other Functions
        public void UpdateEnabledDataSelections_Visual()
        {
            polarSelect.Enabled = true;
            verticalSelect.Enabled = true;
            horizontalSelect.Enabled = true;
            depthSelect.Enabled = true;
            azimuthSelect.Enabled = true;
            elevationSelect.Enabled = true;
            frequencySelect.Enabled = true;
            powerSelect.Enabled = true;
            indexSelect.Enabled = false;
            if (indepVariable.Text == "Polarization") { polarSelect.Enabled = false; }
            else if (indepVariable.Text == "Vertical") { verticalSelect.Enabled = false; }
            else if (indepVariable.Text == "Horizontal") { horizontalSelect.Enabled = false; }
            else if (indepVariable.Text == "Depth") { depthSelect.Enabled = false; }
            else if (indepVariable.Text == "Azimuth") { azimuthSelect.Enabled = false; }
            else if (indepVariable.Text == "Elevation") { elevationSelect.Enabled = false; }
            else if (indepVariable.Text == "Source Power") { powerSelect.Enabled = false; }
            else if (indepVariable.Text == "Frequency")
            {
                frequencySelect.Enabled = false;
                indexSelect.Enabled = true;
                SetDataSelectionForIndex();
            }
        }
        public void PopulateItems_Visual()
        {
            // populate variables choices for the user to change the displayed plot and dataset
            indepVariable.Items.Clear();
            indepVariable.Items.AddRange(plotter.indepVariables);
        }
        public void RepopulateEntireDataSelection()
        {
            ClearDataSelection();
            for (int i = 0; i < dataManager.data.Count; i++)
            {
                AppendDataSelection(i);
            }
        }
        public void ClearDataSelection()
        {
            // clear all dataset values recognized by the program (this should be done at the same time as clearing the dataset)
            indexSelect.Items.Clear();
            polarSelect.Items.Clear();
            verticalSelect.Items.Clear();
            horizontalSelect.Items.Clear();
            depthSelect.Items.Clear();
            azimuthSelect.Items.Clear();
            elevationSelect.Items.Clear();
            powerSelect.Items.Clear();
            frequencySelect.Items.Clear();

            indexSelect.Text = "NULL";
            polarSelect.Text = "NULL";
            verticalSelect.Text = "NULL";
            horizontalSelect.Text = "NULL";
            depthSelect.Text = "NULL";
            azimuthSelect.Text = "NULL";
            elevationSelect.Text = "NULL";
            powerSelect.Text = "NULL";
            frequencySelect.Text = "NULL";
        }
        public void AppendDataSelection(int dataIndex)
        {
            if (dataManager.data[dataIndex].mode.Equals(modeSelect.Text))
            {
                // add dataset values that are recognized by the progarm (and can be chosen by the user)
                // pointAvgQuantity is not accounted for here
                // syntax used for converting values to strings needs to stay consistent throughout progarm
                // (see data types that are used in positioner and network analyzer)
                // (see ToString format that is used in positioning and measurement)
                string indexString = dataIndex.ToString();
                if (!indexSelect.Items.Contains(indexString)) { indexSelect.Items.Add(indexString); }

                string polarString = dataManager.data[dataIndex].polarization.ToString("N2");
                if (!polarSelect.Items.Contains(polarString)) { polarSelect.Items.Add(polarString); }

                string verticalString = dataManager.data[dataIndex].vertical.ToString("N2");
                if (!verticalSelect.Items.Contains(verticalString)) { verticalSelect.Items.Add(verticalString); }

                string horizontalString = dataManager.data[dataIndex].horizontal.ToString("N2");
                if (!horizontalSelect.Items.Contains(horizontalString)) { horizontalSelect.Items.Add(horizontalString); }

                string depthString = dataManager.data[dataIndex].depth.ToString("N2");
                if (!depthSelect.Items.Contains(depthString)) { depthSelect.Items.Add(depthString); }

                string azimuthString = dataManager.data[dataIndex].azimuth.ToString("N2");
                if (!azimuthSelect.Items.Contains(azimuthString)) { azimuthSelect.Items.Add(azimuthString); }

                string elevationString = dataManager.data[dataIndex].elevation.ToString("N2");
                if (!elevationSelect.Items.Contains(elevationString)) { elevationSelect.Items.Add(elevationString); }

                string powerString = dataManager.data[dataIndex].sourcePower.ToString("N3");
                if (!powerSelect.Items.Contains(powerString)) { powerSelect.Items.Add(powerString); }

                string frequencyString;
                for (int i = 0; i < dataManager.data[dataIndex].frequency.Length; i++)
                {
                    frequencyString = (dataManager.data[dataIndex].frequency[i] / MEGAHERTZ).ToString("N3");
                    if (!frequencySelect.Items.Contains(frequencyString)) { frequencySelect.Items.Add(frequencyString); }
                }
            }
            if (indexSelect.Items.Count == 1) { indexSelect.SelectedIndex = 0; }
        }
        public void SetDataSelectionForIndex()
        {
            // if selected index is changed while frequency is the selected variable, 
            // all othe fields are populated with those related to the selected index
            if (indexSelect.Items.Count > 0)
            {
                indexAutoFill = true;
                try
                {
                    Point point = dataManager.data[System.Convert.ToInt32(indexSelect.Text)];
                    polarSelect.SelectedItem = point.polarization.ToString("N2");
                    verticalSelect.SelectedItem = point.vertical.ToString("N2");
                    horizontalSelect.SelectedItem = point.horizontal.ToString("N2");
                    depthSelect.SelectedItem = point.depth.ToString("N2");
                    azimuthSelect.SelectedItem = point.azimuth.ToString("N2");
                    elevationSelect.SelectedItem = point.elevation.ToString("N2");
                    powerSelect.SelectedItem = point.sourcePower.ToString("N3");
                    if (frequencySelect.Text.Equals("NULL")) { frequencySelect.SelectedIndex = 0; }
                    indexAutoFill = false;
                    plotter.UpdatePlot();
                }
                catch
                {
                    WriteToOutput("Failed to set data selection for index");
                }
            }
        }
        public void UpdateForContinuous(int dataIndex)
        {
            if (checkContinuous.Checked == true)
            {
                try
                {
                    if (!dataManager.data[dataIndex].mode.Equals(modeSelect.Text))
                    {
                        modeSelect.SelectedItem = dataManager.data[dataIndex].mode;
                    }
                    if (indepVariable.Text.Equals("Frequency"))
                    {
                        indexSelect.SelectedItem = dataIndex.ToString(); // will call UpdatePlot()
                    }
                    else
                    {
                        plotter.UpdatePlot();
                    }
                }
                catch
                {
                    WriteToOutput("Exception Handled: UpdateForContinuous");
                }
        }
        }
        public void SetAssociatedIndexForFrequencyVariable()
        {
            for (int dataIndex = 0; dataIndex < dataManager.data.Count; dataIndex++)
            {
                if (dataManager.data[dataIndex].mode.Equals(modeSelect.Text) &&
                    dataManager.data[dataIndex].polarization.ToString("N2").Equals(polarSelect.Text) &&
                    dataManager.data[dataIndex].vertical.ToString("N2").Equals(verticalSelect.Text) &&
                    dataManager.data[dataIndex].horizontal.ToString("N2").Equals(horizontalSelect.Text) &&
                    dataManager.data[dataIndex].depth.ToString("N2").Equals(depthSelect.Text) &&
                    dataManager.data[dataIndex].azimuth.ToString("N2").Equals(azimuthSelect.Text) &&
                    dataManager.data[dataIndex].elevation.ToString("N2").Equals(elevationSelect.Text) &&
                    dataManager.data[dataIndex].sourcePower.ToString("N3").Equals(powerSelect.Text))
                {
                    indexSelect.SelectedItem = dataIndex.ToString();
                }
            }
        }
        #endregion


    }
}
