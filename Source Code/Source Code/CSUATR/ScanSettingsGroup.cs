using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSUATR
{
    partial class MainForm
    {
        #region GUI Parameters
        // lowerLimitPolar
        // lowerLimitVertical
        // lowerLimitHorizontal
        // lowerLimitDepth
        // lowerLimitAzimuth
        // lowerLimitElevation

        // upperLimitPolar
        // upperLimitVertical
        // upperLimitHorizontal
        // upperLimitDepth
        // upperLimitAzimuth
        // upperLimitElevation

        // resolutionPolar
        // resolutionVertical
        // resolutionHorizontal
        // resolutionDepth
        // resolutionAzimuth
        // resolutionElevation

        // lowerLimitFrequency
        // upperLimitFrequency
        // scanSweepPoints

        // scanSourcePower
        // scanAvgPoints
        // scanType
        #endregion

        #region Status Parameters
        // Program Set Parameters (GUI)
        // scanEstimatedTime
        // progressBar
        // progressPercent
        #endregion

        #region Flags
        public bool unlockedPolar = false;
        public bool unlockedVertical = false;
        public bool unlockedHorizontal = false;
        public bool unlockedDepth = false;
        public bool unlockedAzimuth = false;
        public bool unlockedElevation = false;
        #endregion

        #region Active Functions
        // Functional Buttons
        private void buttonScanReSet_Click(object sender, EventArgs e)
        {
            ReadSettings_ScanSettings();
        }

        private void buttonScanStart_Click(object sender, EventArgs e)
        {
            if (scanner.inProgress == false)
            {
                scanner.Start();
            }
            else if (scanner.paused == false)
            {
                scanner.Pause();
            }
            else
            {
                scanner.Resume();
            }
        }

        private void buttonScanCancel_Click(object sender, EventArgs e)
        {
            if (scanner.inProgress == true)
            {
                scanner.Cancel();
            }
        }
        #endregion

        #region Passive Functions
        // Unlock Buttons
        private void buttonLockPolar_Click(object sender, EventArgs e)
        {
            if (unlockedPolar == true)
            {
                unlockedPolar = false;
                buttonLockPolar.Text = "Locked";
            }
            else
            {
                unlockedPolar = true;
                buttonLockPolar.Text = "Unlocked";
            }
            UpdateEnabledButtons_ScanSettings();
        }
        private void buttonLockVertical_Click(object sender, EventArgs e)
        {
            if (unlockedVertical == true)
            {
                unlockedVertical = false;
                buttonLockVertical.Text = "Locked";
            }
            else
            {
                unlockedVertical = true;
                buttonLockVertical.Text = "Unlocked";
            }
            UpdateEnabledButtons_ScanSettings();
        }
        private void buttonLockHorizontal_Click(object sender, EventArgs e)
        {
            if (unlockedHorizontal == true)
            {
                unlockedHorizontal = false;
                buttonLockHorizontal.Text = "Locked";
            }
            else
            {
                unlockedHorizontal = true;
                buttonLockHorizontal.Text = "Unlocked";
            }
            UpdateEnabledButtons_ScanSettings();
        }
        private void buttonLockDepth_Click(object sender, EventArgs e)
        {
            if (unlockedDepth == true)
            {
                unlockedDepth = false;
                buttonLockDepth.Text = "Locked";
            }
            else
            {
                unlockedDepth = true;
                buttonLockDepth.Text = "Unlocked";
            }
            UpdateEnabledButtons_ScanSettings();
        }
        private void buttonLockAzimuth_Click(object sender, EventArgs e)
        {
            if (unlockedAzimuth == true)
            {
                unlockedAzimuth = false;
                buttonLockAzimuth.Text = "Locked";
            }
            else
            {
                unlockedAzimuth = true;
                buttonLockAzimuth.Text = "Unlocked";
            }
            UpdateEnabledButtons_ScanSettings();
        }
        private void buttonLockElevation_Click(object sender, EventArgs e)
        {
            if (unlockedElevation == true)
            {
                unlockedElevation = false;
                buttonLockElevation.Text = "Locked";
            }
            else
            {
                unlockedElevation = true;
                buttonLockElevation.Text = "Unlocked";
            }
            UpdateEnabledButtons_ScanSettings();
        }
        #endregion

        public void UpdateEnabledButtons_ScanSettings()
        {
            if (arduino.connected == false || networkAnalyzer.connected == false)
            {
                buttonScanStart.Enabled = false;
                buttonScanCancel.Enabled = false;

                buttonLockPolar.Enabled = true;
                buttonLockVertical.Enabled = true;
                buttonLockHorizontal.Enabled = true;
                buttonLockDepth.Enabled = true;
                buttonLockAzimuth.Enabled = true;
                buttonLockElevation.Enabled = true;

                lowerLimitFrequency.Enabled = true;
                upperLimitFrequency.Enabled = true;
                scanSweepPoints.Enabled = true;

                scanSourcePower.Enabled = true;
                scanAvgPoints.Enabled = true;

                scanType.Enabled = true;

                if (unlockedPolar == true) { lowerLimitPolar.Enabled = true; upperLimitPolar.Enabled = true; resolutionPolar.Enabled = true; }
                else { lowerLimitPolar.Enabled = false; upperLimitPolar.Enabled = false; resolutionPolar.Enabled = false; }

                if (unlockedVertical == true) { lowerLimitVertical.Enabled = true; upperLimitVertical.Enabled = true; resolutionVertical.Enabled = true; }
                else { lowerLimitVertical.Enabled = false; upperLimitVertical.Enabled = false; resolutionVertical.Enabled = false; }

                if (unlockedHorizontal == true) { lowerLimitHorizontal.Enabled = true; upperLimitHorizontal.Enabled = true; resolutionHorizontal.Enabled = true; }
                else { lowerLimitHorizontal.Enabled = false; upperLimitHorizontal.Enabled = false; resolutionHorizontal.Enabled = false; }

                if (unlockedDepth == true) { lowerLimitDepth.Enabled = true; upperLimitDepth.Enabled = true; resolutionDepth.Enabled = true; }
                else { lowerLimitDepth.Enabled = false; upperLimitDepth.Enabled = false; resolutionDepth.Enabled = false; }

                if (unlockedAzimuth == true) { lowerLimitAzimuth.Enabled = true; upperLimitAzimuth.Enabled = true; resolutionAzimuth.Enabled = true; }
                else { lowerLimitAzimuth.Enabled = false; upperLimitAzimuth.Enabled = false; resolutionAzimuth.Enabled = false; }

                if (unlockedElevation == true) { lowerLimitElevation.Enabled = true; upperLimitElevation.Enabled = true; resolutionElevation.Enabled = true; }
                else { lowerLimitElevation.Enabled = false; upperLimitElevation.Enabled = false; resolutionElevation.Enabled = false; }
            }
            else
            {
                if (scanner.inProgress == false)
                {
                    buttonScanStart.Text = "Start";
                    buttonScanCancel.Enabled = false;

                    if (networkAnalyzer.ready == false || positioner.inMotion == true)
                    {
                        buttonScanStart.Enabled = false;
                    }
                    else
                    {
                        buttonScanStart.Enabled = true;
                    }

                    buttonLockPolar.Enabled = true;
                    buttonLockVertical.Enabled = true;
                    buttonLockHorizontal.Enabled = true;
                    buttonLockDepth.Enabled = true;
                    buttonLockAzimuth.Enabled = true;
                    buttonLockElevation.Enabled = true;

                    lowerLimitFrequency.Enabled = true;
                    upperLimitFrequency.Enabled = true;
                    scanSweepPoints.Enabled = true;

                    scanSourcePower.Enabled = true;
                    scanAvgPoints.Enabled = true;

                    scanType.Enabled = true;

                    if (unlockedPolar == true) { lowerLimitPolar.Enabled = true; upperLimitPolar.Enabled = true; resolutionPolar.Enabled = true; }
                    else { lowerLimitPolar.Enabled = false; upperLimitPolar.Enabled = false; resolutionPolar.Enabled = false; }

                    if (unlockedVertical == true) { lowerLimitVertical.Enabled = true; upperLimitVertical.Enabled = true; resolutionVertical.Enabled = true; }
                    else { lowerLimitVertical.Enabled = false; upperLimitVertical.Enabled = false; resolutionVertical.Enabled = false; }

                    if (unlockedHorizontal == true) { lowerLimitHorizontal.Enabled = true; upperLimitHorizontal.Enabled = true; resolutionHorizontal.Enabled = true; }
                    else { lowerLimitHorizontal.Enabled = false; upperLimitHorizontal.Enabled = false; resolutionHorizontal.Enabled = false; }

                    if (unlockedDepth == true) { lowerLimitDepth.Enabled = true; upperLimitDepth.Enabled = true; resolutionDepth.Enabled = true; }
                    else { lowerLimitDepth.Enabled = false; upperLimitDepth.Enabled = false; resolutionDepth.Enabled = false; }

                    if (unlockedAzimuth == true) { lowerLimitAzimuth.Enabled = true; upperLimitAzimuth.Enabled = true; resolutionAzimuth.Enabled = true; }
                    else { lowerLimitAzimuth.Enabled = false; upperLimitAzimuth.Enabled = false; resolutionAzimuth.Enabled = false; }

                    if (unlockedElevation == true) { lowerLimitElevation.Enabled = true; upperLimitElevation.Enabled = true; resolutionElevation.Enabled = true; }
                    else { lowerLimitElevation.Enabled = false; upperLimitElevation.Enabled = false; resolutionElevation.Enabled = false; }
                }
                else
                {
                    buttonScanStart.Enabled = true;
                    buttonScanCancel.Enabled = true;

                    if (scanner.paused == false)
                    {
                        buttonScanStart.Text = "Pause";
                    }
                    else
                    {
                        buttonScanStart.Text = "Resume";
                    }

                    buttonLockPolar.Enabled = false;
                    buttonLockVertical.Enabled = false;
                    buttonLockHorizontal.Enabled = false;
                    buttonLockDepth.Enabled = false;
                    buttonLockAzimuth.Enabled = false;
                    buttonLockElevation.Enabled = false;

                    lowerLimitPolar.Enabled = false;
                    lowerLimitVertical.Enabled = false;
                    lowerLimitHorizontal.Enabled = false;
                    lowerLimitDepth.Enabled = false;
                    lowerLimitAzimuth.Enabled = false;
                    lowerLimitElevation.Enabled = false;

                    upperLimitPolar.Enabled = false;
                    upperLimitVertical.Enabled = false;
                    upperLimitHorizontal.Enabled = false;
                    upperLimitDepth.Enabled = false;
                    upperLimitAzimuth.Enabled = false;
                    upperLimitElevation.Enabled = false;

                    resolutionPolar.Enabled = false;
                    resolutionVertical.Enabled = false;
                    resolutionHorizontal.Enabled = false;
                    resolutionDepth.Enabled = false;
                    resolutionAzimuth.Enabled = false;
                    resolutionElevation.Enabled = false;

                    lowerLimitFrequency.Enabled = false;
                    upperLimitFrequency.Enabled = false;
                    scanSweepPoints.Enabled = false;

                    scanSourcePower.Enabled = false;
                    scanAvgPoints.Enabled = false;

                    scanType.Enabled = false;
                }
            }
        }

        public void UpdateStatus_ScanEstimatedTime()
        {
            if (scanner != null)
            {
                scanEstimatedTime.Text = scanner.estimatedTime.ToString("N2");
            }
            else
            {
                scanEstimatedTime.Text = "NULL";
            }
        }

        public void UpdateStatus_ScanProgress()
        {
            int progress = scanner.progress;
            if (progress > 100) { progress = 100; }
            if (progress < 0) { progress = 0; }
            progressBar.Value = progress;
            progressPercent.Text = progress.ToString("N0") + '%';
        }

        public void PopulateItems_ScanType()
        {
            scanType.Items.Clear();
            scanType.Items.AddRange(scanner.scanTypes);
        }
    }
}
