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
        // setToSourcePower
        // setToStartFrequency
        // setToStopFrequency
        // setToResFrequency
        // setToAvgPoints
        #endregion

        #region Status Parameters
        // statusSourcePower
        // statusStartFrequency
        // statusStopFrequency
        // statusResFrequency
        // statusAvgPoints
        #endregion

        #region Constants
        private double MEGAHERTZ = 1000000;
        private double GIGAHERTZ = 1000000000;
        #endregion

        #region Active Functions
        private void buttonMeasureReSet_Click(object sender, EventArgs e)
        {
            ReadSettings_Measurement();
        }
        private void buttonMeasure_Click(object sender, EventArgs e)
        {
            if (networkAnalyzer.ready == true)
            {
                networkAnalyzer.Measure();
            }
        }
        private void buttonSetTo_Click(object sender, EventArgs e)
        {
            if (networkAnalyzer.ready == true)
            {
                networkAnalyzer.SetSourcePower(setToSourcePower.Value);
                networkAnalyzer.SetStartFrequency(setToStartFrequency.Value * (decimal)MEGAHERTZ);
                networkAnalyzer.SetStopFrequency(setToStopFrequency.Value * (decimal)MEGAHERTZ);
                networkAnalyzer.SetSweepPoints((int)setToSweepPoints.Value);
                networkAnalyzer.SetPointAvgQuantity((int)setToAvgPoints.Value);
            }
        }
        #endregion

        public void UpdateEnabledButtons_Measurement()
        {
            if (scanner.inProgress == true || networkAnalyzer.connected == false)
            {
                buttonMeasure.Enabled = false;
                buttonSetTo.Enabled = false;
                setToSourcePower.Enabled = true;
                setToStartFrequency.Enabled = true;
                setToStopFrequency.Enabled = true;
                setToSweepPoints.Enabled = true;
                setToAvgPoints.Enabled = true;
            }
            else
            {
                if (networkAnalyzer.ready == false)
                {
                    buttonMeasure.Enabled = false;
                    buttonSetTo.Enabled = false;
                    setToSourcePower.Enabled = false;
                    setToStartFrequency.Enabled = false;
                    setToStopFrequency.Enabled = false;
                    setToSweepPoints.Enabled = false;
                    setToAvgPoints.Enabled = false;
                }
                else
                {
                    buttonMeasure.Enabled = true;
                    buttonSetTo.Enabled = true;
                    setToSourcePower.Enabled = true;
                    setToStartFrequency.Enabled = true;
                    setToStopFrequency.Enabled = true;
                    setToSweepPoints.Enabled = true;
                    setToAvgPoints.Enabled = true;
                }
            }
        }

        public void UpdateStatus_Measurement()
        {
            statusSourcePower.Text = networkAnalyzer.sourcePower.ToString("N3");
            statusStartFrequency.Text = (networkAnalyzer.startFrequency / (decimal)MEGAHERTZ).ToString("N3");
            statusStopFrequency.Text = (networkAnalyzer.stopFrequency / (decimal)MEGAHERTZ).ToString("N3");
            statusSweepPoints.Text = networkAnalyzer.sweepPoints.ToString("N");
            statusAvgPoints.Text = networkAnalyzer.pointAvgQuantity.ToString("N");
        }

    }
}
