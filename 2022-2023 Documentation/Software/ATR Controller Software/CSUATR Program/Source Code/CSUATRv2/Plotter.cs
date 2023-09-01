using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATRv2
{
    public class Plotter
    {
        #region Classes
        private PlottingForm mainForm;
        private DataManager dataManager;
        private PlotModel plot;
        #endregion

        #region Axes
        private LinearAxis axisX;
        private LinearAxis axisY;
        private AngleAxis axisAngle;
        private MagnitudeAxis axisRadius;
        #endregion

        #region Series
        private LineSeries lineData;
        private ScatterSeries scatterData;
        #endregion

        #region Flags
        private bool ready;
        #endregion

        #region Constants
        double MEGAHERTZ = 1000000;
        #endregion

        #region GUI Parameters
        public string currentPlotType = "None";
        public string currentValueType = "None";
        public string currentVariable = "None";

        public string currentSParam = "None";

        //public long currentID = 0;
        //public double currentFrequency = 0;
        //public double currentPower = 0;
        //public double currentHorizontal = 0;
        //public double currentVertical = 0;
        //public double currentDepth = 0;
        //public double currentAzimuth = 0;
        //public double currentElevation = 0;
        //public double currentPolarization = 0;
        public string currentID = "None";
        public string currentFrequency = "None";
        public string currentPower = "None";
        public string currentHorizontal = "None";
        public string currentVertical = "None";
        public string currentDepth = "None";
        public string currentAzimuth = "None";
        public string currentElevation = "None";
        public string currentPolarization = "None";

        public int currentDataCount = 0;
        #endregion

        public Plotter(PlottingForm mainForm, DataManager dataManager, PlotModel plot)
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
            lineData = new LineSeries();
            scatterData = new ScatterSeries();
            plot.Series.Add(lineData);
            plot.Series.Add(scatterData);
        }
        #endregion

        #region Update
        public void UpdatePlot()
        {
            if (ready == true)
            {
                ready = false;
                //Console.WriteLine("Updating Plot");
                PopulateSeries(currentPlotType, currentValueType, currentVariable);
                UpdateDataPoints();
                Plot(currentPlotType, currentValueType, currentVariable);
                ready = true;
            }
            else
            {
                Console.WriteLine("Not ready to update plot");
            }
        }
        private void PopulateSeries(string plotType, string valueType, string variable)
        {
            try
            {
                lineData.Points.Clear();
                scatterData.Points.Clear();
                for (int i = 0; i < dataManager.data.Count; i++)
                {
                    if (
                        dataManager.data[i].sParameter.Equals(currentSParam) &&
                        (variable.Equals("Source Power")|| dataManager.data[i].sourcePower.ToString("N3") == currentPower) &&
                        (variable.Equals("Horizontal")  || dataManager.data[i].horizontal.ToString("N2") == currentHorizontal) &&
                        (variable.Equals("Vertical")    || dataManager.data[i].vertical.ToString("N2") == currentVertical) &&
                        (variable.Equals("Depth")       || dataManager.data[i].depth.ToString("N2") == currentDepth) &&
                        (variable.Equals("Azimuth")     || dataManager.data[i].azimuth.ToString("N2") == currentAzimuth) &&
                        (variable.Equals("Elevation")   || dataManager.data[i].elevation.ToString("N2") == currentElevation) &&
                        (variable.Equals("Polarization")|| dataManager.data[i].polarization.ToString("N2") == currentPolarization)
                        )
                    {
                        for (int j = 0; j < dataManager.data[i].frequency.Count(); j++)
                        {
                            if (variable.Equals("Frequency") || (dataManager.data[i].frequency[j] / MEGAHERTZ).ToString("N3") == currentFrequency)
                            {
                                if (plotType.Equals("Scatter"))
                                {
                                    double x = 0;
                                    double y = 0;
                                    if (valueType.Equals(@"Magnitude/Phase"))
                                    {
                                        x = dataManager.data[i].phase[j];
                                        y = dataManager.data[i].magnitude[j];
                                    }
                                    else if (valueType.Equals(@"Real/Imaginary"))
                                    {
                                        x = dataManager.data[i].real[j];
                                        y = dataManager.data[i].imaginary[j];
                                    }
                                    scatterData.Points.Add(new ScatterPoint(x, y));
                                }
                                else
                                {
                                    double x = 0;
                                    double y = 0;
                                    if (variable.Equals("Frequency")) { x = dataManager.data[i].frequency[j] / MEGAHERTZ; }
                                    else if (variable.Equals("Source Power")) { x = dataManager.data[i].sourcePower; }
                                    else if (variable.Equals("Horizontal")) { x = dataManager.data[i].horizontal; }
                                    else if (variable.Equals("Vertical")) { x = dataManager.data[i].vertical; }
                                    else if (variable.Equals("Depth")) { x = dataManager.data[i].depth; }
                                    else if (variable.Equals("Azimuth")) { x = dataManager.data[i].azimuth; }
                                    else if (variable.Equals("Elevation")) { x = dataManager.data[i].elevation; }
                                    else if (variable.Equals("Polarization")) { x = dataManager.data[i].polarization; }
                                    
                                    if (valueType.Equals("Amplitude")) { y = dataManager.data[i].amplitude[j]; }
                                    else if (valueType.Equals("Magnitude")) { y = dataManager.data[i].magnitude[j]; }
                                    else if (valueType.Equals("Phase")) { y = dataManager.data[i].phase[j]; }
                                    else if (valueType.Equals("Real")) { y = dataManager.data[i].real[j]; }
                                    else if (valueType.Equals("Imaginary")) { y = dataManager.data[i].imaginary[j]; }

                                    if (variable.Equals("Azimuth") ||
                                        variable.Equals("Elevation") ||
                                        variable.Equals("Polarization")
                                        ) { lineData.Points.Add(new DataPoint(y, x)); }
                                    else { lineData.Points.Add(new DataPoint(x, y)); }
                                }
                            }
                        }
                    }
                }
                if (variable.Equals("Azimuth") ||
                    variable.Equals("Elevation") ||
                    variable.Equals("Polarization")
                    ) { lineData.Points.OrderBy(p => p.Y); }
                else { lineData.Points.OrderBy(p => p.X); }
            }
            catch
            {
                Console.WriteLine(string.Format("Failed to populate {0} series", variable));
            }
        }
        private void Plot(string plotType, string valueType, string variable)
        {
            lineData.IsVisible = false;
            scatterData.IsVisible = false;

            plot.Axes.Clear();

            if (plotType.Equals("Scatter"))
            {
                if (valueType.Equals(@"Magnitude/Phase"))
                {
                    scatterData.IsVisible = true;
                    plot.Subtitle = null;
                    plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
                    plot.PlotType = PlotType.XY;
                    axisX = new LinearAxis
                    {
                        Position = AxisPosition.Bottom,
                        Title = "Phase (degrees)"
                    };
                    axisY = new LinearAxis
                    {
                        Position = AxisPosition.Left,
                        Title = "Magnitude (dB)"
                    };
                    plot.Axes.Add(axisX);
                    plot.Axes.Add(axisY);
                }
                else //if (valueType.Equals(@"Real/Imaginary"))
                {
                    scatterData.IsVisible = true;
                    plot.Subtitle = null;
                    plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
                    plot.PlotType = PlotType.XY;
                    axisX = new LinearAxis
                    {
                        Position = AxisPosition.Bottom,
                        Title = "Real (V)"
                    };
                    axisY = new LinearAxis
                    {
                        Position = AxisPosition.Left,
                        Title = "Imaginary (V)"
                    };
                    plot.Axes.Add(axisX);
                    plot.Axes.Add(axisY);
                }
            }
            else
            {
                // Define y axis and data
                if (valueType.Equals("Amplitude"))
                {
                    lineData.IsVisible = true;
                    axisY = new LinearAxis
                    {
                        Position = AxisPosition.Left,
                        Title = "Amplitude (V)"
                    };
                }
                else if (valueType.Equals("Magnitude"))
                {
                    lineData.IsVisible = true;
                    axisY = new LinearAxis
                    {
                        Position = AxisPosition.Left,
                        Title = "Magnitude (dB)"
                    };
                }
                else if (valueType.Equals("Phase"))
                {
                    lineData.IsVisible = true;
                    axisY = new LinearAxis
                    {
                        Position = AxisPosition.Left,
                        Title = "Phase (degrees)"
                    };
                }
                else if (valueType.Equals("Real"))
                {
                    lineData.IsVisible = true;
                    axisY = new LinearAxis
                    {
                        Position = AxisPosition.Left,
                        Title = "Real (V)"
                    };
                }
                else //if (valueType.Equals("Imaginary"))
                {
                    lineData.IsVisible = true;
                    axisY = new LinearAxis
                    {
                        Position = AxisPosition.Left,
                        Title = "Imaginary (V)"
                    };
                }

                // define remaining plot characteristics and add axes
                if (variable.Equals("Frequency"))
                {
                    plot.Subtitle = null;
                    plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
                    plot.PlotType = PlotType.XY;
                    axisX = new LinearAxis
                    {
                        Position = AxisPosition.Bottom,
                        Title = "Frequency (MHz)"
                    };
                    plot.Axes.Add(axisX);
                    plot.Axes.Add(axisY);
                }
                else if (variable.Equals("Source Power"))
                {
                    plot.Subtitle = null;
                    plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
                    plot.PlotType = PlotType.XY;
                    axisX = new LinearAxis
                    {
                        Position = AxisPosition.Bottom,
                        Title = "Source Power (dB)"
                    };
                    plot.Axes.Add(axisX);
                    plot.Axes.Add(axisY);
                }
                else if (variable.Equals("Horizontal"))
                {
                    plot.Subtitle = null;
                    plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
                    plot.PlotType = PlotType.XY;
                    axisX = new LinearAxis
                    {
                        Position = AxisPosition.Bottom,
                        Title = "Horizontal Position (cm)"
                    };
                    plot.Axes.Add(axisX);
                    plot.Axes.Add(axisY);
                }
                else if (variable.Equals("Vertical"))
                {
                    plot.Subtitle = null;
                    plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
                    plot.PlotType = PlotType.XY;
                    axisX = new LinearAxis
                    {
                        Position = AxisPosition.Bottom,
                        Title = "Vertical Position (cm)"
                    };
                    plot.Axes.Add(axisX);
                    plot.Axes.Add(axisY);
                }
                else if (variable.Equals("Depth"))
                {
                    plot.Subtitle = null;
                    plot.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 1);
                    plot.PlotType = PlotType.XY;
                    axisX = new LinearAxis
                    {
                        Position = AxisPosition.Bottom,
                        Title = "Depth Position (cm)"
                    };
                    plot.Axes.Add(axisX);
                    plot.Axes.Add(axisY);
                }
                else if (variable.Equals("Azimuth"))
                {
                    plot.Subtitle = "Azimuth Angle (degrees)";
                    plot.PlotAreaBorderThickness = new OxyThickness(0, 0, 0, 0);
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
                }
                else if (variable.Equals("Elevation"))
                {
                    plot.Subtitle = "Elevation Angle (degrees)";
                    plot.PlotAreaBorderThickness = new OxyThickness(0, 0, 0, 0);
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
                }
                else //if (variable.Equals("Polarization"))
                {
                    plot.Subtitle = "Polarization Angle (degrees)";
                    plot.PlotAreaBorderThickness = new OxyThickness(0, 0, 0, 0);
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
                }
            }
            RefreshPlot();
        }
        #endregion

        #region Other
        public void RefreshPlot()
        {
            plot.InvalidatePlot(true); // refresh
        }
        public void AutoScalePlot()
        {
            plot.ResetAllAxes();
            RefreshPlot();
        }

        public void UpdateDataPoints()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateDataPoints(); })); }
            else { _UpdateDataPoints(); }
        }
        private void _UpdateDataPoints()
        {
            int count = lineData.Points.Count + scatterData.Points.Count;
            mainForm.statusDataPoints.Text = count.ToString();
        }
        #endregion
    }
}
