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
        // moveToPolar
        // moveToVertical
        // moveToHorizontal
        // moveToDepth
        // moveToAzimuth
        // moveToElevation

        // moveByPolar
        // moveByVertical
        // moveByHorizontal
        // moveByDepth
        // moveByAzimuth
        // moveByElevation
        #endregion

        #region Status Parameters
        // statusPositionPolar
        // statusPositionVertical
        // statusPositionHorizontal
        // statusPositionAzimuthal
        // statusPositionElevation
        #endregion

        #region Flags
        public bool engagedPolar = false;
        public bool engagedVertical = false;
        public bool engagedHorizontal = false;
        public bool engagedDepth = false;
        public bool engagedAzimuth = false;
        public bool engagedElevation = false;
        #endregion

        #region Active Functions
        // Reload Settings
        private void buttonMoveReSet_Click(object sender, EventArgs e)
        {
            ReadSettings_Positioning();
        }
        // Stop
        private void buttonMoveStop_Click(object sender, EventArgs e)
        {
            positioner.Stop();
        }
        // Home
        private void buttonHome_Click(object sender, EventArgs e)
        {
            positioner.MoveToHome();
            // Reset all values to reflect the "home" position
        }
        // Move To
        private void buttonMoveTo_Click(object sender, EventArgs e)
        {
            if (engagedPolar == true) { positioner.MoveToPosition('P', (float)moveToPolar.Value); }
            if (engagedAzimuth == true) { positioner.MoveToPosition('A', (float)moveToAzimuth.Value); }
            if (engagedElevation == true) { positioner.MoveToPosition('E', (float)moveToElevation.Value); }
            if (engagedHorizontal == true) { positioner.MoveToPosition('H', (float)moveToHorizontal.Value); }
            if (engagedVertical == true) { positioner.MoveToPosition('V', (float)moveToVertical.Value); }
            if (engagedDepth == true) { positioner.MoveToPosition('D', (float)moveToDepth.Value); }
        }
        // Move By
        private void buttonMoveBy_Click(object sender, EventArgs e)
        {
            if (engagedPolar == true) { positioner.MoveByAmount('P', (float)moveByPolar.Value); }
            if (engagedAzimuth == true) { positioner.MoveByAmount('A', (float)moveByAzimuth.Value); }
            if (engagedElevation == true) { positioner.MoveByAmount('E', (float)moveByElevation.Value); }
            if (engagedHorizontal == true) { positioner.MoveByAmount('H', (float)moveByHorizontal.Value); }
            if (engagedVertical == true) { positioner.MoveByAmount('V', (float)moveByVertical.Value); }
            if (engagedDepth == true) { positioner.MoveByAmount('D', (float)moveByDepth.Value); }
        }
        #endregion

        #region Passive Functions
        // Engage
        private void buttonEngagePolar_Click(object sender, EventArgs e)
        {
            if (engagedPolar == true)
            {
                engagedPolar = false;
                buttonEngagePolar.Text = "Unengaged";
            }
            else
            {
                engagedPolar = true;
                buttonEngagePolar.Text = "Engaged";
            }
            UpdateEnabledButtons_Positioning();
        }
        private void buttonEngageVertical_Click(object sender, EventArgs e)
        {
            if (engagedVertical == true)
            {
                engagedVertical = false;
                buttonEngageVertical.Text = "Unengaged";
            }
            else
            {
                engagedVertical = true;
                buttonEngageVertical.Text = "Engaged";
            }
            UpdateEnabledButtons_Positioning();
        }
        private void buttonEngageHorizontal_Click(object sender, EventArgs e)
        {
            if (engagedHorizontal == true)
            {
                engagedHorizontal = false;
                buttonEngageHorizontal.Text = "Unengaged";
            }
            else
            {
                engagedHorizontal = true;
                buttonEngageHorizontal.Text = "Engaged";
            }
            UpdateEnabledButtons_Positioning();
        }
        private void buttonEngageDepth_Click(object sender, EventArgs e)
        {
            if (engagedDepth == true)
            {
                engagedDepth = false;
                buttonEngageDepth.Text = "Unengaged";
            }
            else
            {
                engagedDepth = true;
                buttonEngageDepth.Text = "Engaged";
            }
            UpdateEnabledButtons_Positioning();
        }
        private void buttonEngageAzimuth_Click(object sender, EventArgs e)
        {
            if (engagedAzimuth == true)
            {
                engagedAzimuth = false;
                buttonEngageAzimuth.Text = "Unengaged";
            }
            else
            {
                engagedAzimuth = true;
                buttonEngageAzimuth.Text = "Engaged";
            }
            UpdateEnabledButtons_Positioning();
        }
        private void buttonEngageElevation_Click(object sender, EventArgs e)
        {
            if (engagedElevation == true)
            {
                engagedElevation = false;
                buttonEngageElevation.Text = "Unengaged";
            }
            else
            {
                engagedElevation = true;
                buttonEngageElevation.Text = "Engaged";
            }
            UpdateEnabledButtons_Positioning();
        }
        #endregion

        public void UpdateEnabledButtons_Positioning()
        {
            if ((scanner.inProgress == true && scanner.paused == false) || arduino.connected == false)
            {
                buttonMoveTo.Enabled = false;
                buttonMoveBy.Enabled = false;
                buttonMoveStop.Enabled = false;
                buttonHome.Enabled = false;

                buttonEngagePolar.Enabled = true;
                buttonEngageVertical.Enabled = true;
                buttonEngageHorizontal.Enabled = true;
                buttonEngageDepth.Enabled = true;
                buttonEngageAzimuth.Enabled = true;
                buttonEngageElevation.Enabled = true;

                if (engagedPolar == true) { moveToPolar.Enabled = true; moveByPolar.Enabled = true; }
                else { moveToPolar.Enabled = false; moveByPolar.Enabled = false; }

                if (engagedVertical == true) { moveToVertical.Enabled = true; moveByVertical.Enabled = true; }
                else { moveToVertical.Enabled = false; moveByVertical.Enabled = false; }

                if (engagedHorizontal == true) { moveToHorizontal.Enabled = true; moveByHorizontal.Enabled = true; }
                else { moveToHorizontal.Enabled = false; moveByHorizontal.Enabled = false; }

                if (engagedDepth == true) { moveToDepth.Enabled = true; moveByDepth.Enabled = true; }
                else { moveToDepth.Enabled = false; moveByDepth.Enabled = false; }

                if (engagedAzimuth == true) { moveToAzimuth.Enabled = true; moveByAzimuth.Enabled = true; }
                else { moveToAzimuth.Enabled = false; moveByAzimuth.Enabled = false; }

                if (engagedElevation == true) { moveToElevation.Enabled = true; moveByElevation.Enabled = true; }
                else { moveToElevation.Enabled = false; moveByElevation.Enabled = false; }
            }
            else
            {
                if (positioner.inMotion == true)
                {
                    buttonMoveTo.Enabled = false;
                    buttonMoveBy.Enabled = false;
                    buttonMoveStop.Enabled = true;
                    buttonHome.Enabled = false;

                    buttonEngagePolar.Enabled = false;
                    buttonEngageVertical.Enabled = false;
                    buttonEngageHorizontal.Enabled = false;
                    buttonEngageDepth.Enabled = false;
                    buttonEngageAzimuth.Enabled = false;
                    buttonEngageElevation.Enabled = false;

                    moveToPolar.Enabled = false;
                    moveToVertical.Enabled = false;
                    moveToHorizontal.Enabled = false;
                    moveToDepth.Enabled = false;
                    moveToAzimuth.Enabled = false;
                    moveToElevation.Enabled = false;

                    moveByPolar.Enabled = false;
                    moveByVertical.Enabled = false;
                    moveByHorizontal.Enabled = false;
                    moveByDepth.Enabled = false;
                    moveByAzimuth.Enabled = false;
                    moveByElevation.Enabled = false;
                }
                else
                {
                    buttonMoveTo.Enabled = true;
                    buttonMoveBy.Enabled = true;
                    buttonMoveStop.Enabled = false;
                    buttonHome.Enabled = true;

                    buttonEngagePolar.Enabled = true;
                    buttonEngageVertical.Enabled = true;
                    buttonEngageHorizontal.Enabled = true;
                    buttonEngageDepth.Enabled = true;
                    buttonEngageAzimuth.Enabled = true;
                    buttonEngageElevation.Enabled = true;

                    if (engagedPolar == true) { moveToPolar.Enabled = true; moveByPolar.Enabled = true; }
                    else { moveToPolar.Enabled = false; moveByPolar.Enabled = false; }

                    if (engagedVertical == true) { moveToVertical.Enabled = true; moveByVertical.Enabled = true; }
                    else { moveToVertical.Enabled = false; moveByVertical.Enabled = false; }

                    if (engagedHorizontal == true) { moveToHorizontal.Enabled = true; moveByHorizontal.Enabled = true; }
                    else { moveToHorizontal.Enabled = false; moveByHorizontal.Enabled = false; }

                    if (engagedDepth == true) { moveToDepth.Enabled = true; moveByDepth.Enabled = true; }
                    else { moveToDepth.Enabled = false; moveByDepth.Enabled = false; }

                    if (engagedAzimuth == true) { moveToAzimuth.Enabled = true; moveByAzimuth.Enabled = true; }
                    else { moveToAzimuth.Enabled = false; moveByAzimuth.Enabled = false; }

                    if (engagedElevation == true) { moveToElevation.Enabled = true; moveByElevation.Enabled = true; }
                    else { moveToElevation.Enabled = false; moveByElevation.Enabled = false; }
                }
            }
        }

        public void UpdateStatus_Positioning()
        {
            statusPositionPolar.Text = positioner.currentPositionPolar.ToString("N2");
            statusPositionVertical.Text = positioner.currentPositionVertical.ToString("N2");
            statusPositionHorizontal.Text = positioner.currentPositionHorizontal.ToString("N2");
            statusPositionDepth.Text = positioner.currentPositionDepth.ToString("N2");
            statusPositionAzimuth.Text = positioner.currentPositionAzimuth.ToString("N2");
            statusPositionElevation.Text = positioner.currentPositionElevation.ToString("N2");
        }
    }
}
