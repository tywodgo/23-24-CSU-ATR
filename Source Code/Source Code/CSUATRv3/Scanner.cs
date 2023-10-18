using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class Scanner
    {
        #region Classes
        Terminal terminal;
        EventManager eventManager;
        Controller controller;
        Positioner positioner;
        Instrument instrument;
        DataManager dataManager;
        #endregion

        #region Scanner Parameters
        public List<char> motors;
        public List<double> lowerLimit;
        public List<double> upperLimit;
        public List<double> resolution;
        public string scanType;

        List<object[]> stepActions;
        #endregion

        #region Types
        public string[] scanTypes = { "Single",
                                      "Double"};
        #endregion

        public Scanner(Terminal terminal,
            EventManager eventManager,
            Controller controller,
            Positioner positioner,
            Instrument instrument,
            DataManager dataManager
            )
        {
            this.terminal = terminal;
            this.eventManager = eventManager;
            this.controller = controller;
            this.positioner = positioner;
            this.instrument = instrument;
            this.dataManager = dataManager;
        }

        public void Setup(ScanForm scanForm)
        {
            scanType = scanForm.scanType.Text;
            motors = new List<char>();
            lowerLimit = new List<double>();
            upperLimit = new List<double>();
            resolution = new List<double>();
            if (scanForm.unlockedDepth == true)
            {
                motors.Add('D');
                lowerLimit.Add(scanForm.lowerLimitDepth.Value);
                upperLimit.Add(scanForm.upperLimitDepth.Value);
                resolution.Add(scanForm.resolutionDepth.Value);
            }
            if (scanForm.unlockedHorizontal == true)
            {
                motors.Add('H');
                lowerLimit.Add(scanForm.lowerLimitHorizontal.Value);
                upperLimit.Add(scanForm.upperLimitHorizontal.Value);
                resolution.Add(scanForm.resolutionHorizontal.Value);
            }
            if (scanForm.unlockedVertical == true)
            {
                motors.Add('V');
                lowerLimit.Add(scanForm.lowerLimitVertical.Value);
                upperLimit.Add(scanForm.upperLimitVertical.Value);
                resolution.Add(scanForm.resolutionVertical.Value);
            }
            if (scanForm.unlockedElevation == true)
            {
                motors.Add('E');
                lowerLimit.Add(scanForm.lowerLimitElevation.Value);
                upperLimit.Add(scanForm.upperLimitElevation.Value);
                resolution.Add(scanForm.resolutionElevation.Value);
            }
            if (scanForm.unlockedAzimuth == true)
            {
                motors.Add('A');
                lowerLimit.Add(scanForm.lowerLimitAzimuth.Value);
                upperLimit.Add(scanForm.upperLimitAzimuth.Value);
                resolution.Add(scanForm.resolutionAzimuth.Value);
            }
            if (scanForm.unlockedPolar == true)
            {
                motors.Add('P');
                lowerLimit.Add(scanForm.lowerLimitPolar.Value);
                upperLimit.Add(scanForm.upperLimitPolar.Value);
                resolution.Add(scanForm.resolutionPolar.Value);
            }
            if (scanType.Equals("Single")) { SetupSingle(); }
            else if (scanType.Equals("Double")) { SetupDouble(); }
            else { SetupDud(); }
        }
        public void SetupSingle()
        {
            stepActions = new List<object[]>();
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
                    stepActions.Add(new object[] { "Positioner", "MoveToPosition", motor, position });
                    stepActions.Add(new object[] { "Positioner", "Wait", motor });
                    stepActions.Add(new object[] { "Instrument", "Measure" });
                }
            }
            stepActions.Add(new object[] { "Positioner", "Calibrate" });
        }
        public void SetupDouble()
        {
            stepActions = new List<object[]>();

            stepActions.Add(new object[] { "Positioner", "Calibrate" });

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
                    stepActions.Add(new object[] { "Positioner", "MoveToPosition", motor1, position1 });

                    if (step1 % 2 == 0)
                    {
                        for (int step2 = 0; step2 <= inc2; step2++)
                        {
                            double position2 = lowerLimit[1] + res2 * step2;
                            stepActions.Add(new object[] { "Positioner", "MoveToPosition", motor2, position2 });
                            stepActions.Add(new object[] { "Positioner", "Wait", motor2 });
                            stepActions.Add(new object[] { "Instrument", "Measure" });
                        }
                    }
                    else
                    {
                        for (int step2 = inc2; step2 >= 0; step2--)
                        {
                            double position2 = lowerLimit[1] + res2 * step2;
                            stepActions.Add(new object[] { "Positioner", "MoveToPosition", motor2, position2 });
                            stepActions.Add(new object[] { "Positioner", "Wait", motor2 });
                            stepActions.Add(new object[] { "Instrument", "Measure" });
                        }
                    }

                }
            }
            stepActions.Add(new object[] { "Positioner", "Calibrate" });
        }
        public void SetupDud()
        {
            stepActions = new List<object[]>();
            object[] actionEnd = { "end" };
            stepActions.Add(actionEnd);
        }

        public void AddEvents()
        {
            eventManager.AppendEventRange(stepActions);
        }

    }
}
