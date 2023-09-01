using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATR
{
    class Motors
    {
        /*
        // This class holds data on motors and their operation
        #region Parameters

        #endregion

        // String to send to microcontroller
        private string command = "";
        private double steps;
        private int stepPerRev;
        // Positioners is an enumerated set of parameters for each motor stage
        private Positioners[] stages = new Positioners[6];


        // The following store the various data for the motor stages
        #region StageData
        public enum Command { STOP, MOVE_STEP, MOVE_ANGLE, GO_STEP, GO_ANGLE, GO_POSITION, MOVE_DISTANCE, HOME, RESET, CENTER }

        // For passing data to other classes
        // struct format carried over from previous years code
        public struct StageData
        {
            public int step;
            public double angle;
            public int channel;
            public int stepsPerRevolution;
            public double position;
            public double distancePerRevolution;


            public StageData(int step, double angle, int channel, int stepsPerRevolution, double position, double distancePerRevolution)
            {
                this.step = step;
                this.angle = angle;
                this.channel = channel;
                this.stepsPerRevolution = stepsPerRevolution;
                this.position = position;
                this.distancePerRevolution = distancePerRevolution;
            }
        }

        #endregion

        // Class constructor
        public Motors()
        {
            setupStages();
        }


        /// <summary>
        /// Returns information about the specified stage (From previous team's code)
        /// (DMF) Not a very efficient way of retrieving data...
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public StageData GetStageData(Positioners.AxisType axis)
        {
            foreach (Positioners stage in stages)
            {
                if (stage.Axis == axis)
                {
                    return new StageData(stage.Step, stage.Angle, stage.Channel, stage.StepsPerRevolution, stage.Position, stage.DistancePerRevolution);
                }
            }
            return new StageData();
        }

        private void setupStages()
        {
            // The Following structure has //axistype, axisnumber, steps per revolution, distance per rev

            //X Motor Planar
            stages[0] = new Positioners(Positioners.AxisType.HORIZONTAL, 0, 120000, 11.755); //axistype, axisnumber, steps per revolution, distance per rev

            // Y Motor Planar
            stages[1] = new Positioners(Positioners.AxisType.VERTICAL, 1, 1925, 1.5); //This needs to be checked for the correct number of steps still

            // Polarization Motor Planar
            stages[2] = new Positioners(Positioners.AxisType.POLARIZATION1, 2, 1600, 0); // 200 Steps * 8 Microsteps = 1600 steps per revolution

            // Azimuth Motor Spherical
            stages[3] = new Positioners(Positioners.AxisType.AZIMUTH, 3, 115200, 0); //360/1.8 step angle = 200 steps * 72:1 gear ratio = 14400 * 8 microsteps = 115200

            // Z Linear Motor Spherical
            //TODO Rename to LinearZ
            stages[4] = new Positioners(Positioners.AxisType.ELEVATION, 4, 32000, 11.0625); // Marcus - changed steps per revolution from 32000 to 

            // Elevation Motor Spherical
            //TODO Rename to Elevation
            stages[5] = new Positioners(Positioners.AxisType.POLARIZATION2, 5, 1600, 0); //200 Steps * 8 Microsteps = 1600 steps per revolution
        }

        // The following set or retrieve position data from another class
        #region ClassDataAccess

        // Set position data from another class
        public void updatePosition(int stageNumber, int steps)
        {
            stages[stageNumber].Step = steps;
            // Check if planar motor
            if (stageNumber == 0 || stageNumber == 1 || stageNumber == 4) //Edited by Keenan
                // Set position in terms of inches
                stages[stageNumber].Position = (steps * stages[stageNumber].DistancePerRevolution) / stages[stageNumber].StepsPerRevolution;
        }

        // Retrieve step data from another class
        public int GetSteps(int stageNumber)
        {
            return stages[stageNumber].Step;
        }

        // Retrieve position data from another class
        public double GetPosition(int stageNumber)
        {
            // Check if planar motor
            if (stageNumber == 0 || stageNumber == 1 || stageNumber == 4) //Edited by Keenan
                // Position in terms of inches
                return stages[stageNumber].Position;
            else
                // Spherical/Polarization position in terms of angle
                return stages[stageNumber].Angle;
        }

        #endregion

        //The following interprets each command and send the appropriate string
        //to the Arduino
        #region MovementCommands

        // Move given number of steps
        public string MoveSteps(int stageNumber, int steps)
        {
            command = "m " + stageNumber + " " + steps.ToString();
            return command;
        }



        public string lidarDistance()  //Returns string to be sent to arduino in mainform.cs when called
        {
            command = "L";
            return command;
        }



        public string CompSteps(int stageNumber, int steps)
        {
            command = "a " + stageNumber + " " + steps.ToString();
            return command;
        }

        // Move given distance - Only applies to planar stages
        public string MoveDist(int stageNumber, double distance)
        {
            command = "m " + stageNumber + " " + ((int)Math.Floor((distance * stages[stageNumber].StepsPerRevolution) / stages[stageNumber].DistancePerRevolution)).ToString();
            return command;
        }

        // Move given angle - Only applies to spherical stages amd polarization motors
        public string MoveAngle(int stageNumber, double angle)
        {
            if (stageNumber == 0 || stageNumber == 1 || stageNumber == 4) //Edited by Keenan
            {
                MessageBox.Show("Error: Invalid command.  Movement command only valid for spherical system and polarization motors");
            }
            else
                stepPerRev = stages[stageNumber].StepsPerRevolution;
            steps = (angle / 360);
            command = "m " + stageNumber + " " + ((int)Math.Round((angle / 360) * stages[stageNumber].StepsPerRevolution)).ToString();
            return command;

        }

        // Go to given step number
        public string GoStep(int stageNumber, int steps)
        {
            command = "g " + stageNumber + " " + steps.ToString();
            return command;
        }

        // Go to given position
        public string GoPos(int stageNumber, double distance)
        {
            // Check if trying to move anything but planar stages
            if (stageNumber != 0 && stageNumber != 1 && stageNumber != 4) //Edited by Keenan
            {
                // If so, print error
                MessageBox.Show("Error: Invalid command.  Movement command only valid for planar system");
            }

            else
                command = "m " + stageNumber + " " + (int)Math.Floor(((distance - stages[stageNumber].Position) * stages[stageNumber].StepsPerRevolution) / stages[stageNumber].DistancePerRevolution);
            return command;
        }

        // Move to given coordinate
        public string GoToPos(int stageNumber, double distance)
        {
            double dist;
            if (stageNumber == 3 || stageNumber == 5) //Edited by Keenan
            {
                // Calculate angle to move
                dist = distance - stages[stageNumber].Angle; // Marcus - Should be -180 degrees
                //dist = -180; //just for continuous spherical scan
                // Convert angle to steps and send string
                command = "m " + stageNumber + " " + ((int)Math.Round((dist / 360) * stages[stageNumber].StepsPerRevolution)).ToString();
            }
            else
            {
                // Calculate distance to move
                dist = distance - stages[stageNumber].Position;
                // Convert distance to steps and send string
                command = "m " + stageNumber + " " + ((int)Math.Round((dist * stages[stageNumber].StepsPerRevolution) / stages[stageNumber].DistancePerRevolution)).ToString();
            }
            return command;
        }

        // Go to a given angle - Only applies to spherical stages amd polarization motors
        public string GoAngle(int stageNumber, int steps)
        {
            if (stageNumber == 0 || stageNumber == 1 || stageNumber == 4) //Edited by Keenan
            {
                MessageBox.Show("Error: Invalid command.  Movement command only valid for spherical system and polarization motors");
            }

            else
                command = "g " + stageNumber + " " + ((steps / 360) * stages[stageNumber].StepsPerRevolution).ToString();
            return command;
        }

        // Return all stages to origin/reset point 
        public string Home()
        {
            command = "h";
            //TODO TODO TODO Limit_Switches
            //Make sure to use limit switches to place system accurately at home (LIDAR, Optical Encoder, Light Detectors, Hard Stop Switch on Planar)

            return command;
        }

        // Center the stages
        public string Center()
        {
            command = "c";
            return command;
        }

        // Stop the currently moving stage
        public string Stop()
        {
            command = "s";
            return command;
        }

        // Reset all position values to zero
        public string Reset()
        {
            command = "r";
            return command;
        }

        public string SendPositions()
        {
            command = "p " + stages[0].Step.ToString() + " " + stages[1].Step.ToString() + " " + stages[2].Step.ToString() + " "
                + stages[3].Step.ToString() + " " + stages[4].Step.ToString() + " " + stages[5].Step.ToString();
            return command;
        }


        #endregion

    */
    }
}
