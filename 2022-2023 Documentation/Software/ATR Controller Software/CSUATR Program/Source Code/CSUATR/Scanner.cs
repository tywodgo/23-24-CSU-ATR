using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CSUATR
{
    public class Scanner
    {
        #region Classes
        MainForm mainForm;
        Positioner positioner;
        NetworkAnalyzer networkAnalyzer;
        DataManager dataManager;
        System.Timers.Timer motorTimer;
        System.Timers.Timer instrumentTimer;
        #endregion

        #region Constants
        decimal MEGAHERTZ = 1000000;
        #endregion

        #region Flags
        public bool inProgress = false;
        public bool paused = false;
        #endregion

        #region Scanner Parameters
        string instrumentAction = " ";
        int stepIndex;

        List<object[]> stepAction;

        public double motorWaitTime = 4000; // time to wait once motor has stopped (milliseconds)
        public double instrumentWaitTime = 4000; // time to wait to try again if network analyzer is not responding (milliseconds)

        public double timeSetup = 1.0; // estimated time for calibration
        public double timeCalibrate = 1.0; // estimated time for calibration
        public double timeMove = 2.0; // estimated time per step
        public double timeMeasure = 3.0; // estimated time for calibration

        public int progress = 0;
        public double estimatedTime = 0.0;

        float[] currentPosition = new float[6];

        List<char> motors;
        List<decimal> lowerLimit;
        List<decimal> upperLimit;
        List<decimal> resolution;

        decimal startFrequency;
        decimal stopFrequency;
        int sweepPointQuantity;
        int averagePointQuantity;
        decimal sourcePower;

        string scanType;

        public string[] scanTypes = { "Single",
                                      "Double"};
        #endregion

        public Scanner(MainForm mainForm, Positioner positioner, NetworkAnalyzer networkAnalyzer, DataManager dataManager)
        {
            this.mainForm = mainForm;
            this.positioner = positioner;
            this.networkAnalyzer = networkAnalyzer;
            this.dataManager = dataManager;

            motorTimer = new System.Timers.Timer(motorWaitTime);
            motorTimer.Elapsed += OnMotorTimerEvent;
            motorTimer.Enabled = false;
            motorTimer.AutoReset = false;

            instrumentTimer = new System.Timers.Timer(instrumentWaitTime);
            instrumentTimer.Elapsed += OnInstrumentTimerEvent;
            instrumentTimer.Enabled = false;
            instrumentTimer.AutoReset = false;

        }

        public void Start()
        {
            if (inProgress == false)
            {
                inProgress = true;
                paused = false;
                mainForm.UpdateEnabledButtons_NAConnection();
                mainForm.UpdateEnabledButtons_Measurement();
                mainForm.UpdateEnabledButtons_Positioning();
                mainForm.UpdateEnabledButtons_ScanSettings();
                SetupScan();
                RunScan();
            }
            else
            {
                mainForm.WriteToOutput("Scan already in progress");
            }
        }
        public void Pause()
        {
            if (inProgress == true && paused == false)
            {
                paused = true;
                motorTimer.Stop();
                instrumentTimer.Stop();
                mainForm.UpdateEnabledButtons_NAConnection();
                mainForm.UpdateEnabledButtons_Measurement();
                mainForm.UpdateEnabledButtons_Positioning();
                mainForm.UpdateEnabledButtons_ScanSettings();
            }
            else
            {
                mainForm.WriteToOutput("Scan not in progress or already paused");
            }
        }
        public void Resume()
        {
            if (inProgress == true && paused == true)
            {
                paused = false;
                mainForm.UpdateEnabledButtons_NAConnection();
                mainForm.UpdateEnabledButtons_Measurement();
                mainForm.UpdateEnabledButtons_Positioning();
                mainForm.UpdateEnabledButtons_ScanSettings();
                RunScan();
            }
            else
            {
                mainForm.WriteToOutput("Scan not in progress or not paused");
            }
        }
        public void Cancel()
        {
            if (inProgress == true)
            {
                inProgress = false;
                paused = false;
                motorTimer.Stop();
                instrumentTimer.Stop();
                mainForm.UpdateEnabledButtons_NAConnection();
                mainForm.UpdateEnabledButtons_Measurement();
                mainForm.UpdateEnabledButtons_Positioning();
                mainForm.UpdateEnabledButtons_ScanSettings();
            }
            else
            {
                mainForm.WriteToOutput("Scan already not in progress");
            }
        }

        public void EstimateTime()
        {
            int countSetup = 0;
            int countCalibrate = 0;
            int countMove = 0;
            int countMeasure = 0;
            for (int i = stepIndex; i<stepAction.Count; i++)
            {
                if (((string)stepAction[i][0]).Equals("setup")) { countSetup++; }
                else if (((string)stepAction[i][0]).Equals("calibrate")) { countCalibrate++; }
                else if (((string)stepAction[i][0]).Equals("move")) { countMove++; }
                else if (((string)stepAction[i][0]).Equals("measure")) { countMeasure++; }
            }
            estimatedTime = timeSetup * countSetup +
                            timeCalibrate * countCalibrate +
                            timeMove * countMove +
                            timeMeasure * countMeasure;
            mainForm.UpdateStatus_ScanEstimatedTime();
        }
        public void UpdateProgress()
        {
            progress = 100 * stepIndex / stepAction.Count;
            mainForm.UpdateStatus_ScanProgress();
        }

        public void SetupScan()
        {
            ObtainCurrentPosition();
            ObtainUnlockedMotors();
            startFrequency = mainForm.lowerLimitFrequency.Value * MEGAHERTZ;
            stopFrequency = mainForm.upperLimitFrequency.Value * MEGAHERTZ;
            sweepPointQuantity = (int)mainForm.scanSweepPoints.Value;
            averagePointQuantity = (int)mainForm.scanAvgPoints.Value;
            sourcePower = mainForm.scanSourcePower.Value;
            scanType = mainForm.scanType.Text;
            if (scanType.Equals("Single")) { SetupSingle(); }
            else if (scanType.Equals("Double")) { SetupDouble(); }
            else { SetupDud(); }
        }
        public void SetupSingle()
        {
            // declare step list
            stepAction = new List<object[]>();
            object[] actionSetup = { "setup" };
            object[] actionCalibrate = { "calibrate" };
            object[] actionMeasure = { "measure" };
            object[] actionEnd = { "end" };
            // setup instrument
            stepAction.Add(actionSetup);
            // calibrate motors
            stepAction.Add(actionCalibrate);
            // if a motor is unlocked, add steps for it
            if (motors.Count >= 1)
            {
                // move motors and measure
                char motor = motors[0];
                int inc = (int)Math.Ceiling((upperLimit[0] - lowerLimit[0]) / resolution[0]);
                decimal res = (upperLimit[0] - lowerLimit[0]) / inc;
                for (int step = 0; step <= inc; step++)
                {
                    decimal position = lowerLimit[0] + res * step;
                    object[] actionMove = { "move", motor, position };
                    stepAction.Add(actionMove);
                    stepAction.Add(actionMeasure);
                }
            }
            // end scan
            //stepAction.Add(actionCalibrate); // only once limit switches are working
            stepAction.Add(actionEnd);
            // set scan step to zero and update progress
            stepIndex = 0;
            EstimateTime();
            UpdateProgress();
        }
        public void SetupDouble()
        {
            stepAction = new List<object[]>();
            object[] actionSetup = { "setup" };
            object[] actionCalibrate = { "calibrate" };
            object[] actionMeasure = { "measure" };
            object[] actionEnd = { "end" };

            stepAction.Add(actionSetup);
            stepAction.Add(actionCalibrate);

            if (motors.Count >= 2)
            {
                char motor1 = motors[0];
                int inc1 = (int)Math.Ceiling((upperLimit[0] - lowerLimit[0]) / resolution[0]);
                decimal res1 = (upperLimit[0] - lowerLimit[0]) / inc1;

                char motor2 = motors[1];
                int inc2 = (int)Math.Ceiling((upperLimit[1] - lowerLimit[1]) / resolution[1]);
                decimal res2 = (upperLimit[1] - lowerLimit[1]) / inc2;

                for (int step1 = 0; step1 <= inc1; step1++)
                {
                    decimal position1 = lowerLimit[0] + res1 * step1;
                    object[] actionMove1 = { "move", motor1, position1 };
                    stepAction.Add(actionMove1);

                    if (step1 % 2 == 0)
                    {
                        for (int step2 = 0; step2 <= inc2; step2++)
                        {
                            decimal position2 = lowerLimit[1] + res2 * step2;
                            object[] actionMove2 = { "move", motor2, position2 };
                            stepAction.Add(actionMove2);
                            stepAction.Add(actionMeasure);
                        }
                    }
                    else
                    {
                        for (int step2 = inc2; step2 >= 0; step2--)
                        {
                            decimal position2 = lowerLimit[1] + res2 * step2;
                            object[] actionMove2 = { "move", motor2, position2 };
                            stepAction.Add(actionMove2);
                            stepAction.Add(actionMeasure);
                        }
                    }

                }
            }
            //stepAction.Add(actionCalibrate); // only once limit switches are working
            stepAction.Add(actionEnd);

            stepIndex = 0;
            EstimateTime();
            UpdateProgress();
        }
        public void SetupDud()
        {
            stepAction = new List<object[]>();
            object[] actionEnd = { "end" };
            stepAction.Add(actionEnd);

            stepIndex = 0;
            EstimateTime();
            UpdateProgress();
        }

        public void ObtainCurrentPosition()
        {
            currentPosition[0] = positioner.currentPositionPolar;
            currentPosition[1] = positioner.currentPositionVertical;
            currentPosition[2] = positioner.currentPositionHorizontal;
            currentPosition[3] = positioner.currentPositionDepth;
            currentPosition[4] = positioner.currentPositionAzimuth;
            currentPosition[5] = positioner.currentPositionElevation;
        }
        public void ObtainUnlockedMotors()
        {
            motors = new List<char>();
            lowerLimit = new List<decimal>();
            upperLimit = new List<decimal>();
            resolution = new List<decimal>();
            if (mainForm.unlockedDepth == true)
            {
                motors.Add('D');
                lowerLimit.Add(mainForm.lowerLimitDepth.Value);
                upperLimit.Add(mainForm.upperLimitDepth.Value);
                resolution.Add(mainForm.resolutionDepth.Value);
            }
            if (mainForm.unlockedHorizontal == true)
            {
                motors.Add('H');
                lowerLimit.Add(mainForm.lowerLimitHorizontal.Value);
                upperLimit.Add(mainForm.upperLimitHorizontal.Value);
                resolution.Add(mainForm.resolutionHorizontal.Value);
            }
            if (mainForm.unlockedVertical == true)
            {
                motors.Add('V');
                lowerLimit.Add(mainForm.lowerLimitVertical.Value);
                upperLimit.Add(mainForm.upperLimitVertical.Value);
                resolution.Add(mainForm.resolutionVertical.Value);
            }
            if (mainForm.unlockedElevation == true)
            {
                motors.Add('E');
                lowerLimit.Add(mainForm.lowerLimitElevation.Value);
                upperLimit.Add(mainForm.upperLimitElevation.Value);
                resolution.Add(mainForm.resolutionElevation.Value);
            }
            if (mainForm.unlockedAzimuth == true)
            {
                motors.Add('A');
                lowerLimit.Add(mainForm.lowerLimitAzimuth.Value);
                upperLimit.Add(mainForm.upperLimitAzimuth.Value);
                resolution.Add(mainForm.resolutionAzimuth.Value);
            }
            if (mainForm.unlockedPolar == true)
            {
                motors.Add('P');
                lowerLimit.Add(mainForm.lowerLimitPolar.Value);
                upperLimit.Add(mainForm.upperLimitPolar.Value);
                resolution.Add(mainForm.resolutionPolar.Value);
            }
        }

        public void RunScan()
        {
            if (stepIndex < stepAction.Count)
            {
                if (((string)stepAction[stepIndex][0]).Equals("setup")) { Scan_SetupInstrument(); }
                else if (((string)stepAction[stepIndex][0]).Equals("calibrate")) { Scan_Calibrate(); }
                else if (((string)stepAction[stepIndex][0]).Equals("move")) { Scan_Move(); }
                else if (((string)stepAction[stepIndex][0]).Equals("measure")) { Scan_Measure(); }
                else if (((string)stepAction[stepIndex][0]).Equals("end")) { Scan_End(); }
            }
            else
            {
                mainForm.WriteToOutput("Scan: Step Index Exceeds Step Action Array Bounds");
                Scan_End();
            }
        }
        public void Scan_SetupInstrument()
        {
            if (inProgress == true && paused == false)
            {
                mainForm.WriteToOutput("Scan: Setting up Instrument");
                if (networkAnalyzer.SetSourcePower(sourcePower) == false)
                {
                    instrumentAction = "setup";
                    instrumentTimer.Stop();
                    instrumentTimer.Start();
                    return;
                }
                if (networkAnalyzer.SetStartFrequency(startFrequency) == false)
                {
                    instrumentAction = "setup";
                    instrumentTimer.Stop();
                    instrumentTimer.Start();
                    return;
                }
                if (networkAnalyzer.SetStopFrequency(stopFrequency) == false)
                {
                    instrumentAction = "setup";
                    instrumentTimer.Stop();
                    instrumentTimer.Start();
                    return;
                }
                if (networkAnalyzer.SetSweepPoints(sweepPointQuantity) == false)
                {
                    instrumentAction = "setup";
                    instrumentTimer.Stop();
                    instrumentTimer.Start();
                    return;
                }
                if (networkAnalyzer.SetPointAvgQuantity(averagePointQuantity) == false)
                {
                    instrumentAction = "setup";
                    instrumentTimer.Stop();
                    instrumentTimer.Start();
                    return;
                }
                stepIndex++;
                EstimateTime();
                UpdateProgress();
                RunScan();
            }
        }
        public void Scan_Calibrate()
        {
            if (inProgress == true && paused == false)
            {
                mainForm.WriteToOutput("Scan: Calibrating Motors");
                ObtainCurrentPosition();
                positioner.MoveToHome(); // this will calibrate the motors before starting the scan
                positioner.MoveToPosition('P', currentPosition[0]);
                positioner.MoveToPosition('V', currentPosition[1]);
                positioner.MoveToPosition('H', currentPosition[2]);
                positioner.MoveToPosition('D', currentPosition[3]);
                positioner.MoveToPosition('A', currentPosition[4]);
                positioner.MoveToPosition('E', currentPosition[5]);
                stepIndex++;
                EstimateTime();
                UpdateProgress();
                RunScan();
            }
        }
        public void Scan_Move()
        {
            if (inProgress == true && paused == false)
            {
                char motor = (char)stepAction[stepIndex][1];
                decimal position = (decimal)stepAction[stepIndex][2];
                mainForm.WriteToOutput(string.Format("Scan: Moving Motor {0} to position {1:N2}", motor, (float)position));
                positioner.MoveToPosition(motor, (float)position);
            }
        }
        public void Scan_Measure()
        {
            if (inProgress == true && paused == false)
            {
                mainForm.WriteToOutput("Scan: Taking Measurement");
                if (networkAnalyzer.Measure() == false)
                {
                    instrumentAction = "measure";
                    instrumentTimer.Stop();
                    instrumentTimer.Start();
                    return;
                }
            }
        }
        public void Scan_End()
        {
            if (inProgress == true && paused == false)
            {
                mainForm.WriteToOutput("Scan: Finished");
                stepIndex++;
                EstimateTime();
                UpdateProgress();
                Cancel();
            }
        }

        public void OnMotorStopEvent() // interrupt caused by positioner once motors are finally stopped
        {
            if (inProgress == true && paused == false)
            {
                stepIndex++;
                if (((string)stepAction[stepIndex][0]).Equals("measure"))
                {
                    motorTimer.Stop();
                    motorTimer.Start();
                }
                else
                {
                    if (mainForm.InvokeRequired)
                    {
                        mainForm.Invoke(new MethodInvoker(delegate
                        {
                            EstimateTime();
                            UpdateProgress();
                            RunScan();
                        }));
                    }
                    else
                    {
                        EstimateTime();
                        UpdateProgress();
                        RunScan();
                    }
                }
            }
        }
        public void OnSweepStopEvent()
        {
            if (inProgress == true && paused == false)
            {
                stepIndex++;
                if (mainForm.InvokeRequired)
                {
                    mainForm.Invoke(new MethodInvoker(delegate
                    {
                        EstimateTime();
                        UpdateProgress();
                        RunScan();
                    }));
                }
                else
                {
                    EstimateTime();
                    UpdateProgress();
                    RunScan();
                }
            }
        }
        public void OnMotorTimerEvent(object source, ElapsedEventArgs e)
        {
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new MethodInvoker(delegate
                {
                    EstimateTime();
                    UpdateProgress();
                    RunScan();
                }));
            }
            else
            {
                EstimateTime();
                UpdateProgress();
                RunScan();
            }
        }
        public void OnInstrumentTimerEvent(object source, ElapsedEventArgs e)
        {
            if (instrumentAction.Equals("setup"))
            {
                if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { Scan_SetupInstrument(); })); }
                else { Scan_SetupInstrument(); }
            }
            if (instrumentAction.Equals("measure"))
            {
                if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { Scan_Measure(); })); }
                else { Scan_Measure(); }
            }
        }

    }
}
