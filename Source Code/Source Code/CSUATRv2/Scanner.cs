using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CSUATRv2
{
    public class Scanner
    {
        #region Form Communications
        Terminal terminal;
        MainForm mainForm;
        ScanForm scanForm;
        #endregion

        #region Classes
        EventManager eventManager;
        Controller controller;
        Positioner positioner;
        Instrument instrument;
        DataManager dataManager;
        #endregion

        #region Scanner Parameters
        private List<char> motors;
        private List<double> lowerLimit;
        private List<double> upperLimit;
        private List<double> resolution;
        private string scanType;
        private List<Function> stepActions;
        #endregion

        #region Types
        public string[] scanTypes = { "Single",
                                      "Double"};
        #endregion

        public Scanner(MainForm mainForm,
            Terminal terminal,
            EventManager eventManager,
            Controller controller,
            Positioner positioner,
            Instrument instrument,
            DataManager dataManager
            )
        {
            this.mainForm = mainForm;
            this.terminal = terminal;
            this.eventManager = eventManager;
            this.controller = controller;
            this.positioner = positioner;
            this.instrument = instrument;
            this.dataManager = dataManager;
        }

        public void Setup(ScanForm scanForm)
        {
            this.scanForm = scanForm;
            scanType = scanForm.scanType.Text;
            motors = new List<char>();
            lowerLimit = new List<double>();
            upperLimit = new List<double>();
            resolution = new List<double>();
            if (scanForm.unlockedDepth == true)
            {
                motors.Add('D');
                lowerLimit.Add((double)scanForm.lowerLimitDepth.Value);
                upperLimit.Add((double)scanForm.upperLimitDepth.Value);
                resolution.Add((double)scanForm.resolutionDepth.Value);
            }
            if (scanForm.unlockedHorizontal == true)
            {
                motors.Add('H');
                lowerLimit.Add((double)scanForm.lowerLimitHorizontal.Value);
                upperLimit.Add((double)scanForm.upperLimitHorizontal.Value);
                resolution.Add((double)scanForm.resolutionHorizontal.Value);
            }
            if (scanForm.unlockedVertical == true)
            {
                motors.Add('V');
                lowerLimit.Add((double)scanForm.lowerLimitVertical.Value);
                upperLimit.Add((double)scanForm.upperLimitVertical.Value);
                resolution.Add((double)scanForm.resolutionVertical.Value);
            }
            if (scanForm.unlockedElevation == true)
            {
                motors.Add('E');
                lowerLimit.Add((double)scanForm.lowerLimitElevation.Value);
                upperLimit.Add((double)scanForm.upperLimitElevation.Value);
                resolution.Add((double)scanForm.resolutionElevation.Value);
            }
            if (scanForm.unlockedAzimuth == true)
            {
                motors.Add('A');
                lowerLimit.Add((double)scanForm.lowerLimitAzimuth.Value);
                upperLimit.Add((double)scanForm.upperLimitAzimuth.Value);
                resolution.Add((double)scanForm.resolutionAzimuth.Value);
            }
            if (scanForm.unlockedPolar == true)
            {
                motors.Add('P');
                lowerLimit.Add((double)scanForm.lowerLimitPolar.Value);
                upperLimit.Add((double)scanForm.upperLimitPolar.Value);
                resolution.Add((double)scanForm.resolutionPolar.Value);
            }
            if (scanType.Equals("Single")) { SetupSingle(); }
            else if (scanType.Equals("Double")) { SetupDouble(); }
            else { SetupDud(); }
        }
        public void SetupSingle()
        {
            stepActions = new List<Function>();
            stepActions.Add(new Function(positioner.Calibrate, new object[] { }));
            if (motors.Count >= 1)
            {
                // move motors and measure
                char motor = motors[0];
                int inc = (int)Math.Ceiling((upperLimit[0] - lowerLimit[0]) / resolution[0]);
                double res = (upperLimit[0] - lowerLimit[0]) / inc;
                for (int step = 0; step <= inc; step++)
                {
                    double position = lowerLimit[0] + res * step;
                    stepActions.Add(new Function(positioner.MoveToPosition, new object[] { motor, position }));
                    stepActions.Add(new Function(positioner.WaitMotor, new object[] { motor }));
                    stepActions.Add(new Function(instrument.Measure, new object[] { }));
                    if (scanForm.addSave.Checked == true)
                    { stepActions.Add(new Function(dataManager.SaveData, new object[] { })); }
                }
            }
            stepActions.Add(new Function(positioner.Calibrate, new object[] { }));
        }
        public void SetupDouble()
        {
            stepActions = new List<Function>();

            stepActions.Add(new Function(positioner.Calibrate, new object[] { }));

            if (motors.Count >= 2)
            {
                char motor1 = motors[0];
                int inc1 = (int)Math.Ceiling((upperLimit[0] - lowerLimit[0]) / resolution[0]);
                double res1 = (upperLimit[0] - lowerLimit[0]) / inc1;

                char motor2 = motors[1];
                int inc2 = (int)Math.Ceiling((upperLimit[1] - lowerLimit[1]) / resolution[1]);
                double res2 = (upperLimit[1] - lowerLimit[1]) / inc2;

                for (int step1 = 0; step1 <= inc1; step1++)
                {
                    double position1 = lowerLimit[0] + res1 * step1;
                    stepActions.Add(new Function(positioner.MoveToPosition, new object[] { motor1, position1 }));

                    if (step1 % 2 == 0)
                    {
                        for (int step2 = 0; step2 <= inc2; step2++)
                        {
                            double position2 = lowerLimit[1] + res2 * step2;
                            stepActions.Add(new Function(positioner.MoveToPosition, new object[] { motor2, position2 }));
                            stepActions.Add(new Function(positioner.WaitMotor, new object[] { motor2 }));
                            stepActions.Add(new Function(instrument.Measure, new object[] { }));
                            if (scanForm.addSave.Checked == true)
                            { stepActions.Add(new Function(dataManager.SaveData, new object[] { })); }
                        }
                    }
                    else
                    {
                        for (int step2 = inc2; step2 >= 0; step2--)
                        {
                            double position2 = lowerLimit[1] + res2 * step2;
                            stepActions.Add(new Function(positioner.MoveToPosition, new object[] { motor2, position2 }));
                            stepActions.Add(new Function(positioner.WaitMotor, new object[] { motor2 }));
                            stepActions.Add(new Function(instrument.Measure, new object[] { }));
                            if (scanForm.addSave.Checked == true)
                            { stepActions.Add(new Function(dataManager.SaveData, new object[] { })); }
                        }
                    }

                }
            }
            stepActions.Add(new Function(positioner.Calibrate, new object[] { }));
        }
        public void SetupDud()
        {
            stepActions = new List<Function>();
        }

        public void AddEvents()
        {
            eventManager.AppendEventRange(stepActions);
        }

    }
}
