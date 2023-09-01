using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Annotations;
using OxyPlot.WindowsForms;
using System.Windows.Forms;

namespace CSUATR
{
    public class Plotter
    {
        #region Classes
        MainForm mainForm;
        DataManager dataManager;
        PlotModel plot;
        #endregion

        #region Axes
        LinearAxis axisX;
        LinearAxis axisY;
        LinearAxis axisScatterBottom;
        LinearAxis axisScatterLeft;
        LinearAxis axisScatterRight;
        LinearAxis axisScatterTop;
        AngleAxis axisAngle;
        MagnitudeAxis axisRadius;
        #endregion

        #region Series
        LineSeries realData;
        LineSeries imaginaryData;
        LineSeries magnitudeData;
        LineSeries phaseData;

        ScatterSeries realImagData;
        ScatterSeries magPhaseData;
        #endregion

        #region Flags
        bool ready = false; // meant to keep multiple threads from editing the same dataset
        #endregion

        #region Constants
        double MEGAHERTZ = 1000000;
        #endregion

        #region GUI Parameters
        public String[] indepVariables = {
            "Polarization",
            "Vertical",
            "Horizontal",
            "Depth",
            "Azimuth",
            "Elevation",
            "Source Power",
            "Frequency"
        };
        public string currentTextIndex = "None";
        public string currentTextPolar = "None";
        public string currentTextVertical = "None";
        public string currentTextHorizontal = "None";
        public string currentTextDepth = "None";
        public string currentTextAzimuth = "None";
        public string currentTextElevation = "None";

        public string currentTextPower = "None";
        public string currentTextFrequency = "None";
        public string currentTextVariable = "None";

        public string currentTextMode = "None";

        public int currentDataIndexCount = 0;
        #endregion

        public Plotter(MainForm mainForm, DataManager dataManager, PlotModel plot)
        {
            this.mainForm = mainForm;
            this.dataManager = dataManager;
            this.plot = plot;
            SetupPlot();
            SetupSeries();
            ready = true;
            UpdatePlot();
        }

        #region Setup
        private void SetupPlot()
        {
            plot.Background = OxyColor.FromRgb(255, 255, 255);
            //plot.Padding = new OxyThickness(5, 10, 15, 0);
            //plot.PlotMargins = new OxyThickness(35, 10, 15, 50);
        }
        private void SetupSeries()
        {
            // Series
            realData = new LineSeries();
            imaginaryData = new LineSeries();
            magnitudeData = new LineSeries();
            phaseData = new LineSeries();
            realImagData = new ScatterSeries();
            magPhaseData = new ScatterSeries();
            realData.Title = "Real (V)";
            imaginaryData.Title = "Imaginary (V)";
            magnitudeData.Title = "Magnitude (dB)";
            phaseData.Title = "Phase (degrees)";
            realImagData.Title = "Real and Imaginary";
            magPhaseData.Title = "Magnitude and Phase";
            plot.Series.Add(realData);
            plot.Series.Add(imaginaryData);
            plot.Series.Add(magnitudeData);
            plot.Series.Add(phaseData);
            plot.Series.Add(realImagData);
            plot.Series.Add(magPhaseData);
        }
        #endregion

        #region Update
        // update plot
        public void UpdatePlot()
        {
            if (ready == true)
            {
                ready = false;
                mainForm.WriteToOutput("Updating Plot");
                TestForChangesInGUIParameters();
                Plot();
                ready = true;
            }
            else
            {
                mainForm.WriteToOutput("Not ready to update plot");
            }
        }
        private void TestForChangesInGUIParameters()
        {
            // test for changes in gui parameters
            if (!currentTextIndex.Equals(mainForm.indexSelect.Text) ||
                !currentTextMode.Equals(mainForm.modeSelect.Text) ||
                !currentTextPolar.Equals(mainForm.polarSelect.Text) ||
                !currentTextVertical.Equals(mainForm.verticalSelect.Text) ||
                !currentTextHorizontal.Equals(mainForm.horizontalSelect.Text) ||
                !currentTextDepth.Equals(mainForm.depthSelect.Text) ||
                !currentTextAzimuth.Equals(mainForm.azimuthSelect.Text) ||
                !currentTextElevation.Equals(mainForm.elevationSelect.Text) ||
                !currentTextPower.Equals(mainForm.powerSelect.Text) ||
                !currentTextFrequency.Equals(mainForm.frequencySelect.Text) ||
                !currentTextVariable.Equals(mainForm.indepVariable.Text) ||
                currentDataIndexCount != dataManager.data.Count
            )
            {
                // if there are changes, update the parameters and repopulate arrays
                currentTextIndex = mainForm.indexSelect.Text;
                currentTextMode = mainForm.modeSelect.Text;
                currentTextPolar = mainForm.polarSelect.Text;
                currentTextVertical = mainForm.verticalSelect.Text;
                currentTextHorizontal = mainForm.horizontalSelect.Text;
                currentTextDepth = mainForm.depthSelect.Text;
                currentTextAzimuth = mainForm.azimuthSelect.Text;
                currentTextElevation = mainForm.elevationSelect.Text;
                currentTextPower = mainForm.powerSelect.Text;
                currentTextFrequency = mainForm.frequencySelect.Text;
                currentTextVariable = mainForm.indepVariable.Text;
                currentDataIndexCount = dataManager.data.Count;
                // re-populate arrays based on selection
                PopulateSeries();
            }
        }
        private void PopulateSeries()
        {
            realData.Points.Clear();
            imaginaryData.Points.Clear();
            magnitudeData.Points.Clear();
            phaseData.Points.Clear();
            realImagData.Points.Clear();
            magPhaseData.Points.Clear();
            if (currentTextVariable.Equals("Polarization"))
            {
                PopulateSeries_Polarization();
            }
            else if (currentTextVariable.Equals("Vertical"))
            {
                PopulateSeries_Vertical();
            }
            else if (currentTextVariable.Equals("Horizontal"))
            {
                PopulateSeries_Horizontal();
            }
            else if (currentTextVariable.Equals("Depth"))
            {
                PopulateSeries_Depth();
            }
            else if (currentTextVariable.Equals("Azimuth"))
            {
                PopulateSeries_Azimuth();
            }
            else if (currentTextVariable.Equals("Elevation"))
            {
                PopulateSeries_Elevation();
            }
            else if (currentTextVariable.Equals("Source Power"))
            {
                PopulateSeries_SourcePower();
            }
            else if (currentTextVariable.Equals("Frequency"))
            {
                PopulateSeries_Frequency();
            }
        }
        private void PopulateSeries_Polarization()
        {
            try
            {
                for (int i = 0; i < dataManager.data.Count; i++)
                {
                    if (dataManager.data[i].mode.Equals(currentTextMode) &&
                        //dataManager.data[i].polarization.ToString("N2").Equals(currentTextPolar) &&
                        dataManager.data[i].vertical.ToString("N2").Equals(currentTextVertical) &&
                        dataManager.data[i].horizontal.ToString("N2").Equals(currentTextHorizontal) &&
                        dataManager.data[i].depth.ToString("N2").Equals(currentTextDepth) &&
                        dataManager.data[i].azimuth.ToString("N2").Equals(currentTextAzimuth) &&
                        dataManager.data[i].elevation.ToString("N2").Equals(currentTextElevation) &&
                        dataManager.data[i].sourcePower.ToString("N3").Equals(currentTextPower))
                    {
                        for (int j = 0; j < dataManager.data[i].frequency.Count(); j++)
                        {
                            if ((dataManager.data[i].frequency[j] / MEGAHERTZ).ToString("N3").Equals(currentTextFrequency))
                            {
                                realData.Points.Add(new DataPoint(dataManager.data[i].real[j], dataManager.data[i].polarization));
                                imaginaryData.Points.Add(new DataPoint(dataManager.data[i].imag[j], dataManager.data[i].polarization));
                                magnitudeData.Points.Add(new DataPoint(dataManager.data[i].mag[j], dataManager.data[i].polarization));
                                phaseData.Points.Add(new DataPoint(dataManager.data[i].phase[j], dataManager.data[i].polarization));
                                realImagData.Points.Add(new ScatterPoint(dataManager.data[i].real[j], dataManager.data[i].imag[j]));
                                magPhaseData.Points.Add(new ScatterPoint(dataManager.data[i].phase[j], dataManager.data[i].mag[j]));
                                break;
                            }
                        }
                    }
                }
                realData.Points.OrderBy(p => p.Y);
                imaginaryData.Points.OrderBy(p => p.Y);
                magnitudeData.Points.OrderBy(p => p.Y);
                phaseData.Points.OrderBy(p => p.Y);
            }
            catch
            {
                mainForm.WriteToOutput("Failed to populate polarization series");
            }
        }
        private void PopulateSeries_Vertical()
        {
            try
            {
                for (int i = 0; i < dataManager.data.Count; i++)
                {
                    if (dataManager.data[i].mode.Equals(currentTextMode) &&
                        dataManager.data[i].polarization.ToString("N2").Equals(currentTextPolar) &&
                        //dataManager.data[i].vertical.ToString("N2").Equals(currentTextVertical) &&
                        dataManager.data[i].horizontal.ToString("N2").Equals(currentTextHorizontal) &&
                        dataManager.data[i].depth.ToString("N2").Equals(currentTextDepth) &&
                        dataManager.data[i].azimuth.ToString("N2").Equals(currentTextAzimuth) &&
                        dataManager.data[i].elevation.ToString("N2").Equals(currentTextElevation) &&
                        dataManager.data[i].sourcePower.ToString("N3").Equals(currentTextPower))
                    {
                        for (int j = 0; j < dataManager.data[i].frequency.Count(); j++)
                        {
                            if ((dataManager.data[i].frequency[j] / MEGAHERTZ).ToString("N3").Equals(currentTextFrequency))
                            {
                                realData.Points.Add(new DataPoint(dataManager.data[i].vertical, dataManager.data[i].real[j]));
                                imaginaryData.Points.Add(new DataPoint(dataManager.data[i].vertical, dataManager.data[i].imag[j]));
                                magnitudeData.Points.Add(new DataPoint(dataManager.data[i].vertical, dataManager.data[i].mag[j]));
                                phaseData.Points.Add(new DataPoint(dataManager.data[i].vertical, dataManager.data[i].phase[j]));
                                realImagData.Points.Add(new ScatterPoint(dataManager.data[i].real[j], dataManager.data[i].imag[j]));
                                magPhaseData.Points.Add(new ScatterPoint(dataManager.data[i].phase[j], dataManager.data[i].mag[j]));
                                break;
                            }
                        }
                    }
                }
                realData.Points.OrderBy(p => p.X);
                imaginaryData.Points.OrderBy(p => p.X);
                magnitudeData.Points.OrderBy(p => p.X);
                phaseData.Points.OrderBy(p => p.X);
            }
            catch
            {
                mainForm.WriteToOutput("Failed to populate vertical series");
            }
        }
        private void PopulateSeries_Horizontal()
        {
            try
            {
                for (int i = 0; i < dataManager.data.Count; i++)
                {
                    if (dataManager.data[i].mode.Equals(currentTextMode) &&
                        dataManager.data[i].polarization.ToString("N2").Equals(currentTextPolar) &&
                        dataManager.data[i].vertical.ToString("N2").Equals(currentTextVertical) &&
                        //dataManager.data[i].horizontal.ToString("N2").Equals(currentTextHorizontal) &&
                        dataManager.data[i].depth.ToString("N2").Equals(currentTextDepth) &&
                        dataManager.data[i].azimuth.ToString("N2").Equals(currentTextAzimuth) &&
                        dataManager.data[i].elevation.ToString("N2").Equals(currentTextElevation) &&
                        dataManager.data[i].sourcePower.ToString("N3").Equals(currentTextPower))
                    {
                        for (int j = 0; j < dataManager.data[i].frequency.Count(); j++)
                        {
                            if ((dataManager.data[i].frequency[j] / MEGAHERTZ).ToString("N3").Equals(currentTextFrequency))
                            {
                                realData.Points.Add(new DataPoint(dataManager.data[i].horizontal, dataManager.data[i].real[j]));
                                imaginaryData.Points.Add(new DataPoint(dataManager.data[i].horizontal, dataManager.data[i].imag[j]));
                                magnitudeData.Points.Add(new DataPoint(dataManager.data[i].horizontal, dataManager.data[i].mag[j]));
                                phaseData.Points.Add(new DataPoint(dataManager.data[i].horizontal, dataManager.data[i].phase[j]));
                                realImagData.Points.Add(new ScatterPoint(dataManager.data[i].real[j], dataManager.data[i].imag[j]));
                                magPhaseData.Points.Add(new ScatterPoint(dataManager.data[i].phase[j], dataManager.data[i].mag[j]));
                                break;
                            }
                        }
                    }
                }
                realData.Points.OrderBy(p => p.X);
                imaginaryData.Points.OrderBy(p => p.X);
                magnitudeData.Points.OrderBy(p => p.X);
                phaseData.Points.OrderBy(p => p.X);
            }
            catch
            {
                mainForm.WriteToOutput("Failed to populate horizontal series");
            }
        }
        private void PopulateSeries_Depth()
        {
            try
            {
                for (int i = 0; i < dataManager.data.Count; i++)
                {
                    if (dataManager.data[i].mode.Equals(currentTextMode) &&
                        dataManager.data[i].polarization.ToString("N2").Equals(currentTextPolar) &&
                        dataManager.data[i].vertical.ToString("N2").Equals(currentTextVertical) &&
                        dataManager.data[i].horizontal.ToString("N2").Equals(currentTextHorizontal) &&
                        //dataManager.data[i].depth.ToString("N2").Equals(currentTextDepth) &&
                        dataManager.data[i].azimuth.ToString("N2").Equals(currentTextAzimuth) &&
                        dataManager.data[i].elevation.ToString("N2").Equals(currentTextElevation) &&
                        dataManager.data[i].sourcePower.ToString("N3").Equals(currentTextPower))
                    {
                        for (int j = 0; j < dataManager.data[i].frequency.Count(); j++)
                        {
                            if ((dataManager.data[i].frequency[j] / MEGAHERTZ).ToString("N3").Equals(currentTextFrequency))
                            {
                                realData.Points.Add(new DataPoint(dataManager.data[i].depth, dataManager.data[i].real[j]));
                                imaginaryData.Points.Add(new DataPoint(dataManager.data[i].depth, dataManager.data[i].imag[j]));
                                magnitudeData.Points.Add(new DataPoint(dataManager.data[i].depth, dataManager.data[i].mag[j]));
                                phaseData.Points.Add(new DataPoint(dataManager.data[i].depth, dataManager.data[i].phase[j]));
                                realImagData.Points.Add(new ScatterPoint(dataManager.data[i].real[j], dataManager.data[i].imag[j]));
                                magPhaseData.Points.Add(new ScatterPoint(dataManager.data[i].phase[j], dataManager.data[i].mag[j]));
                                break;
                            }
                        }
                    }
                }
                realData.Points.OrderBy(p => p.X);
                imaginaryData.Points.OrderBy(p => p.X);
                magnitudeData.Points.OrderBy(p => p.X);
                phaseData.Points.OrderBy(p => p.X);
            }
            catch
            {
                mainForm.WriteToOutput("Failed to populate depth series");
            }
        }
        private void PopulateSeries_Azimuth()
        {
            try
            {
                for (int i = 0; i < dataManager.data.Count; i++)
                {
                    if (dataManager.data[i].mode.Equals(currentTextMode) &&
                        dataManager.data[i].polarization.ToString("N2").Equals(currentTextPolar) &&
                        dataManager.data[i].vertical.ToString("N2").Equals(currentTextVertical) &&
                        dataManager.data[i].horizontal.ToString("N2").Equals(currentTextHorizontal) &&
                        dataManager.data[i].depth.ToString("N2").Equals(currentTextDepth) &&
                        //dataManager.data[i].azimuth.ToString("N2").Equals(currentTextAzimuth) &&
                        dataManager.data[i].elevation.ToString("N2").Equals(currentTextElevation) &&
                        dataManager.data[i].sourcePower.ToString("N3").Equals(currentTextPower))
                    {
                        for (int j = 0; j < dataManager.data[i].frequency.Count(); j++)
                        {
                            if ((dataManager.data[i].frequency[j] / MEGAHERTZ).ToString("N3").Equals(currentTextFrequency))
                            {
                                realData.Points.Add(new DataPoint(dataManager.data[i].real[j], dataManager.data[i].azimuth));
                                imaginaryData.Points.Add(new DataPoint(dataManager.data[i].imag[j], dataManager.data[i].azimuth));
                                magnitudeData.Points.Add(new DataPoint(dataManager.data[i].mag[j], dataManager.data[i].azimuth));
                                phaseData.Points.Add(new DataPoint(dataManager.data[i].phase[j], dataManager.data[i].azimuth));
                                realImagData.Points.Add(new ScatterPoint(dataManager.data[i].real[j], dataManager.data[i].imag[j]));
                                magPhaseData.Points.Add(new ScatterPoint(dataManager.data[i].phase[j], dataManager.data[i].mag[j]));
                                break;
                            }
                        }
                    }
                }
                realData.Points.OrderBy(p => p.Y);
                imaginaryData.Points.OrderBy(p => p.Y);
                magnitudeData.Points.OrderBy(p => p.Y);
                phaseData.Points.OrderBy(p => p.Y);
            }
            catch
            {
                mainForm.WriteToOutput("Failed to populate azimuth series");
            }

        }
        private void PopulateSeries_Elevation()
        {
            try
            {
                for (int i = 0; i < dataManager.data.Count; i++)
                {
                    if (dataManager.data[i].mode.Equals(currentTextMode) &&
                        dataManager.data[i].polarization.ToString("N2").Equals(currentTextPolar) &&
                        dataManager.data[i].vertical.ToString("N2").Equals(currentTextVertical) &&
                        dataManager.data[i].horizontal.ToString("N2").Equals(currentTextHorizontal) &&
                        dataManager.data[i].depth.ToString("N2").Equals(currentTextDepth) &&
                        dataManager.data[i].azimuth.ToString("N2").Equals(currentTextAzimuth) &&
                        //dataManager.data[i].elevation.ToString("N2").Equals(currentTextElevation) &&
                        dataManager.data[i].sourcePower.ToString("N3").Equals(currentTextPower))
                    {
                        for (int j = 0; j < dataManager.data[i].frequency.Count(); j++)
                        {
                            if ((dataManager.data[i].frequency[j] / MEGAHERTZ).ToString("N3").Equals(currentTextFrequency))
                            {
                                realData.Points.Add(new DataPoint(dataManager.data[i].real[j], dataManager.data[i].elevation));
                                imaginaryData.Points.Add(new DataPoint(dataManager.data[i].imag[j], dataManager.data[i].elevation));
                                magnitudeData.Points.Add(new DataPoint(dataManager.data[i].mag[j], dataManager.data[i].elevation));
                                phaseData.Points.Add(new DataPoint(dataManager.data[i].phase[j], dataManager.data[i].elevation));
                                realImagData.Points.Add(new ScatterPoint(dataManager.data[i].real[j], dataManager.data[i].imag[j]));
                                magPhaseData.Points.Add(new ScatterPoint(dataManager.data[i].phase[j], dataManager.data[i].mag[j]));
                                break;
                            }
                        }
                    }
                }
                realData.Points.OrderBy(p => p.Y);
                imaginaryData.Points.OrderBy(p => p.Y);
                magnitudeData.Points.OrderBy(p => p.Y);
                phaseData.Points.OrderBy(p => p.Y);
            }
            catch
            {
                mainForm.WriteToOutput("Failed to populate elevation series");
            }
        }
        private void PopulateSeries_SourcePower()
        {
            try
            {
                for (int i = 0; i < dataManager.data.Count; i++)
                {
                    if (dataManager.data[i].mode.Equals(currentTextMode) &&
                        dataManager.data[i].polarization.ToString("N2").Equals(currentTextPolar) &&
                        dataManager.data[i].vertical.ToString("N2").Equals(currentTextVertical) &&
                        dataManager.data[i].horizontal.ToString("N2").Equals(currentTextHorizontal) &&
                        dataManager.data[i].depth.ToString("N2").Equals(currentTextDepth) &&
                        dataManager.data[i].azimuth.ToString("N2").Equals(currentTextAzimuth) &&
                        //dataManager.data[i].sourcePower.ToString("N3").Equals(currentTextPower) &&
                        dataManager.data[i].elevation.ToString("N2").Equals(currentTextElevation))
                    {
                        for (int j = 0; j < dataManager.data[i].frequency.Count(); j++)
                        {
                            if ((dataManager.data[i].frequency[j] / MEGAHERTZ).ToString("N3").Equals(currentTextFrequency))
                            {
                                realData.Points.Add(new DataPoint(dataManager.data[i].sourcePower, dataManager.data[i].real[j]));
                                imaginaryData.Points.Add(new DataPoint(dataManager.data[i].sourcePower, dataManager.data[i].imag[j]));
                                magnitudeData.Points.Add(new DataPoint(dataManager.data[i].sourcePower, dataManager.data[i].mag[j]));
                                phaseData.Points.Add(new DataPoint(dataManager.data[i].sourcePower, dataManager.data[i].phase[j]));
                                realImagData.Points.Add(new ScatterPoint(dataManager.data[i].real[j], dataManager.data[i].imag[j]));
                                magPhaseData.Points.Add(new ScatterPoint(dataManager.data[i].phase[j], dataManager.data[i].mag[j]));
                                break;
                            }
                        }
                    }
                }
                realData.Points.OrderBy(p => p.X);
                imaginaryData.Points.OrderBy(p => p.X);
                magnitudeData.Points.OrderBy(p => p.X);
                phaseData.Points.OrderBy(p => p.X);
            }
            catch
            {
                mainForm.WriteToOutput("Failed to populate source power series");
            }
        }
        private void PopulateSeries_Frequency()
        {
            try
            {
                int i = System.Convert.ToInt32(currentTextIndex);
                for (int j = 0; j < dataManager.data[i].frequency.Count(); j++)
                {
                    realData.Points.Add(new DataPoint((dataManager.data[i].frequency[j] / MEGAHERTZ), dataManager.data[i].real[j]));
                    imaginaryData.Points.Add(new DataPoint((dataManager.data[i].frequency[j] / MEGAHERTZ), dataManager.data[i].imag[j]));
                    magnitudeData.Points.Add(new DataPoint((dataManager.data[i].frequency[j] / MEGAHERTZ), dataManager.data[i].mag[j]));
                    phaseData.Points.Add(new DataPoint((dataManager.data[i].frequency[j] / MEGAHERTZ), dataManager.data[i].phase[j]));
                    realImagData.Points.Add(new ScatterPoint(dataManager.data[i].real[j], dataManager.data[i].imag[j]));
                    magPhaseData.Points.Add(new ScatterPoint(dataManager.data[i].phase[j], dataManager.data[i].mag[j]));
                }
                realData.Points.OrderBy(p => p.X);
                imaginaryData.Points.OrderBy(p => p.X);
                magnitudeData.Points.OrderBy(p => p.X);
                phaseData.Points.OrderBy(p => p.X);
            }
            catch
            {
                mainForm.WriteToOutput("Failed to populate frequency series for index");
            }
            //for (int i = 0; i < dataManager.data.Count; i++)
            //{
            //    if (dataManager.data[i].mode.Equals(currentTextMode) &&
            //        dataManager.data[i].polarization.ToString("N2").Equals(currentTextPolar) &&
            //        dataManager.data[i].vertical.ToString("N2").Equals(currentTextVertical) &&
            //        dataManager.data[i].horizontal.ToString("N2").Equals(currentTextHorizontal) &&
            //        dataManager.data[i].depth.ToString("N2").Equals(currentTextDepth) &&
            //        dataManager.data[i].azimuth.ToString("N2").Equals(currentTextAzimuth) &&
            //        dataManager.data[i].elevation.ToString("N2").Equals(currentTextElevation) &&
            //        dataManager.data[i].sourcePower.ToString("N3").Equals(currentTextPower))
            //    {
            //        for (int j = 0; j < dataManager.data[i].frequency.Count(); j++)
            //        {
            //            realData.Points.Add(new DataPoint((dataManager.data[i].frequency[j] / MEGAHERTZ), dataManager.data[i].real[j]));
            //            imaginaryData.Points.Add(new DataPoint((dataManager.data[i].frequency[j] / MEGAHERTZ), dataManager.data[i].imag[j]));
            //            magnitudeData.Points.Add(new DataPoint((dataManager.data[i].frequency[j] / MEGAHERTZ), dataManager.data[i].mag[j]));
            //            phaseData.Points.Add(new DataPoint((dataManager.data[i].frequency[j] / MEGAHERTZ), dataManager.data[i].phase[j]));
            //            realImagData.Points.Add(new ScatterPoint(dataManager.data[i].real[j], dataManager.data[i].imag[j]));
            //            magPhaseData.Points.Add(new ScatterPoint(dataManager.data[i].mag[j], dataManager.data[i].phase[j]));
            //        }
            //    }
            //}
        }
        #endregion

        #region Plot
        // plots
        private void Plot()
        {
            // decide what to plot
            realData.IsVisible = false;
            imaginaryData.IsVisible = false;
            magnitudeData.IsVisible = false;
            phaseData.IsVisible = false;
            realImagData.IsVisible = false;
            magPhaseData.IsVisible = false;
            if (mainForm.checkReal.Checked == true) { realData.IsVisible = true; }
            if (mainForm.checkImag.Checked == true) { imaginaryData.IsVisible = true; }
            if (mainForm.checkMag.Checked == true) { magnitudeData.IsVisible = true; }
            if (mainForm.checkPhase.Checked == true) { phaseData.IsVisible = true; }
            if (mainForm.checkScatRI.Checked == true) { realImagData.IsVisible = true; }
            if (mainForm.checkScatMP.Checked == true) { magPhaseData.IsVisible = true; }

            if (mainForm.checkScatMP.Checked == true || mainForm.checkScatRI.Checked == true) { PlotScatter(); }
            else if (currentTextVariable.Equals("Polarization")) { PlotPolarization(); }
            else if (currentTextVariable.Equals("Vertical")) { PlotVertical(); }
            else if (currentTextVariable.Equals("Horizontal")) { PlotHorizontal(); }
            else if (currentTextVariable.Equals("Depth")) { PlotDepth(); }
            else if (currentTextVariable.Equals("Azimuth")) { PlotAzimuth(); }
            else if (currentTextVariable.Equals("Elevation")) { PlotElevation(); }
            else if (currentTextVariable.Equals("Source Power")) { PlotSourcePower(); }
            else if (currentTextVariable.Equals("Frequency")) { PlotFrequency(); }
        }
        private void PlotPolarization()
        {
            plot.PlotAreaBorderThickness = new OxyThickness(0, 0, 0, 0);
            plot.Subtitle = "Polarization Angle (degrees)";
            plot.Axes.Clear();
            plot.PlotType = PlotType.Polar;
            axisAngle = new AngleAxis
            {
                Minimum = 0,
                Maximum = 360,
                MajorStep = 90,
            Title = "Polarization Angle (degrees)"
            };

            axisRadius = new MagnitudeAxis
            {
            };
            plot.Axes.Add(axisAngle);
            plot.Axes.Add(axisRadius);
            RefreshPlot();
        }
        private void PlotVertical()
        {
            plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
            plot.Subtitle = null;
            plot.Axes.Clear();
            plot.PlotType = PlotType.XY;
            axisX = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Vertical Position (cm)"
            };
            axisY = new LinearAxis { Position = AxisPosition.Left };
            plot.Axes.Add(axisX);
            plot.Axes.Add(axisY);
            RefreshPlot();
        }
        private void PlotHorizontal()
        {
            plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
            plot.Subtitle = null;
            plot.Axes.Clear();
            plot.PlotType = PlotType.XY;
            axisX = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Horizontal Position (cm)"
            };
            axisY = new LinearAxis { Position = AxisPosition.Left };
            plot.Axes.Add(axisX);
            plot.Axes.Add(axisY);
            RefreshPlot();
        }
        private void PlotDepth()
        {
            plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
            plot.Subtitle = null;
            plot.Axes.Clear();
            plot.PlotType = PlotType.XY;
            axisX = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Depth Position (cm)"
            };
            axisY = new LinearAxis { Position = AxisPosition.Left };
            plot.Axes.Add(axisX);
            plot.Axes.Add(axisY);
            RefreshPlot();
        }
        private void PlotAzimuth()
        {
            plot.PlotAreaBorderThickness = new OxyThickness(0, 0, 0, 0);
            plot.Subtitle = "Azimuth Angle (degrees)";
            plot.Axes.Clear();
            plot.PlotType = PlotType.Polar;
            axisAngle = new AngleAxis
            {
                Minimum = 0,
                Maximum = 360,
                MajorStep = 90,
                Title = "Azimuth Angle (degrees)"
            };
            axisRadius = new MagnitudeAxis
            {
            };
            plot.Axes.Add(axisAngle);
            plot.Axes.Add(axisRadius);
            RefreshPlot();
        }
        private void PlotElevation()
        {
            plot.PlotAreaBorderThickness = new OxyThickness(0, 0, 0, 0);
            plot.Subtitle = "Elevation Angle (degrees)";
            plot.Axes.Clear();
            plot.PlotType = PlotType.Polar;
            axisAngle = new AngleAxis
            {
                Minimum = 0,
                Maximum = 360,
                MajorStep = 90,
                Title = "Elevation Angle (degrees)"
            };
            axisRadius = new MagnitudeAxis
            {
            };
            plot.Axes.Add(axisAngle);
            plot.Axes.Add(axisRadius);
            RefreshPlot();
        }
        private void PlotSourcePower()
        {
            plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
            plot.Subtitle = null;
            plot.Axes.Clear();
            plot.PlotType = PlotType.XY;
            axisX = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Source Power (dB)"
            };
            axisY = new LinearAxis { Position = AxisPosition.Left };
            plot.Axes.Add(axisX);
            plot.Axes.Add(axisY);
            RefreshPlot();
        }
        private void PlotFrequency()
        {
            plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
            plot.Subtitle = null;
            plot.Axes.Clear();
            plot.PlotType = PlotType.XY;
            axisX = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Frequency (MHz)"
            };
            axisY = new LinearAxis { Position = AxisPosition.Left };
            plot.Axes.Add(axisX);
            plot.Axes.Add(axisY);
            RefreshPlot();
        }
        private void PlotScatter()
        {
            plot.PlotAreaBorderThickness = new OxyThickness(1, 1, 1, 1);

            plot.Subtitle = null;// currentTextVariable;
            plot.Axes.Clear();
            plot.PlotType = PlotType.XY;
            if (mainForm.checkScatMP.Checked == true)
            {
                axisScatterBottom = new LinearAxis { Position = AxisPosition.Bottom, Title = "Phase (degrees)" };
                axisScatterLeft = new LinearAxis { Position = AxisPosition.Left, Title = "Magnitude (dB)" };
                plot.Axes.Add(axisScatterBottom);
                plot.Axes.Add(axisScatterLeft);
            }
            if (mainForm.checkScatRI.Checked == true)
            {
                axisScatterTop = new LinearAxis { Position = AxisPosition.Top, Title = "Real (V)" };
                axisScatterRight = new LinearAxis { Position = AxisPosition.Right, Title = "Imaginary (V)" };
                plot.Axes.Add(axisScatterTop);
                plot.Axes.Add(axisScatterRight);
            }
            RefreshPlot();
        }
        #endregion

        #region Other
        // other functions
        public void RefreshPlot()
        {
            plot.InvalidatePlot(true); // refresh
        }
        public void AutoScalePlot()
        {
            plot.ResetAllAxes();
            RefreshPlot();
        }
        #endregion

    }
}
