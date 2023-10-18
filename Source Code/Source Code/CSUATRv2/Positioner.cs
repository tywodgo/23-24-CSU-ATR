using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CSUATRv2
{
    public class Positioner
    {
        #region Serial Parameters
        /* Communication Parameters */
        // Motor Parameters
        // Polarization (P)
        // Vertical     (V)
        // Horizontal   (H)
        // Depth        (D)
        // Azimuth      (A)
        // Elevation    (E)

        // Direction Parameters
        // Positive (P)
        // Negative (N)

        // Status Parameters
        // Active   (A)
        // Stopped  (S)

        // Serial IO Indicators (and functionality)
        // status    (s) (output, input, anytime)
        // motor     (m) (output, input, anytime)
        // direction (d) (output, input, anytime)
        // quantity `(q) (output, input, last)
        // position  (p) (input, last)
        #endregion

        #region Form Communications
        private MainForm mainForm;
        private Terminal terminal;
        public FileManager settings;
        #endregion

        #region Classes
        private Controller controller;
        public Position position;
        private Motors motors;
        private System.Timers.Timer waitTimer;
        #endregion

        #region Callbacks
        private Callback moveCallback;
        private Callback waitCallback;
        #endregion

        #region Flags
        private bool inMotion = false;
        private bool forcedStop = false;
        #endregion

        #region Motor Bounds
        public bool enforceBoundaries { get; set; } = true;

        public double lowerHorizontal { get; set; } = -105; // appears to have 210cm of travel
        public double lowerVertical { get; set; } = -80;
        public double lowerDepth { get; set; } = -100; // appears to have 280cm of travel
        public double lowerAzimuth { get; set; } = -180;
        public double lowerElevation { get; set; } = -180;
        public double lowerPolarization { get; set; } = -180;

        public double upperHorizontal { get; set; } = 105; // appears to have 210cm of travel
        public double upperVertical { get; set; } = 80; // can maybe increase, this value is safe
        public double upperDepth { get; set; } = 100; // appears to have 280cm of travel
        public double upperAzimuth { get; set; } = 180;
        public double upperElevation { get; set; } = 180;
        public double upperPolarization { get; set; } = 180;
        #endregion

        #region Motor Wait Times (after done moving) (milliseconds)
        public double waitTimeHorizontal = 1000;
        public double waitTimeVertical = 1000;
        public double waitTimeDepth = 1000;
        public double waitTimeAzimuth = 1000;
        public double waitTimeElevation = 1000;
        public double waitTimePolarization = 1000;
        #endregion

        public Positioner(
            MainForm mainForm,
            Terminal terminal,
            Controller controller,
            Position position,
            Motors motors,
            FileManager settings)
        {
            this.mainForm = mainForm;
            this.terminal = terminal;
            this.controller = controller;
            this.position = position;
            this.motors = motors;
            this.settings = settings;
            LoadSettings(0);

            waitTimer = new System.Timers.Timer();
            waitTimer.Elapsed += OnWaitTimerEvent;
            waitTimer.Enabled = false;
            waitTimer.AutoReset = false;
        }

        #region Event Functions
        public void MoveToHome(Callback callback)
        {
            if (inMotion == false && controller.connected == true)
            {
                // This function currently zeros out the position (will change later with limit switches)
                UpdatePosition('H', 0.0);
                UpdatePosition('V', 0.0);
                UpdatePosition('D', 0.0);
                UpdatePosition('A', 0.0);
                UpdatePosition('E', 0.0);
                UpdatePosition('P', 0.0);
                callback.Call(true);
            }
            else
            {
                callback.Call(false);
            }
        }
        public void Calibrate(Callback callback)
        {
            if (inMotion == false && controller.connected == true)
            {
                // TODO
                callback.Call(true);
            }
            else
            {
                callback.Call(false);
            }
        }
        public void MoveToPosition(char motor, double pos, Callback callback)
        {
            // Call MoveByAmount() with parameters that will move system to specified position
            double amount = 0;
            if (motor == 'H') { amount = pos - position.horizontal; }
            else if (motor == 'V') { amount = pos - position.vertical; }
            else if (motor == 'D') { amount = pos - position.depth; }
            else if (motor == 'A') { amount = pos - position.azimuth; }
            else if (motor == 'E') { amount = pos - position.elevation; }
            else if (motor == 'P') { amount = pos - position.polarization; }
            MoveByAmount(motor, amount, callback);
        }
        public void MoveByAmount(char motor, double amount, Callback callback)
        {
            // Command the arduino to move system by a specified amount
            if (inMotion == false && controller.connected == true)
            {
                // Test bounds
                if (motor == 'H')
                {
                    double pos = position.horizontal + amount;
                    if ((pos < lowerHorizontal || pos > upperHorizontal) && enforceBoundaries == true)
                    {
                        terminal.Write(string.Format("Horizontal position out of bounds: {0} cm", position), 3);
                        callback.Call(true);
                        return;
                    }
                    else
                    {
                        motors.SetStartPosition(motor, position.horizontal);
                    }
                }
                else if (motor == 'V')
                {
                    double pos = position.vertical + amount;
                    if ((pos < lowerVertical || pos > upperVertical) && enforceBoundaries == true)
                    {
                        terminal.Write(string.Format("Vertical position out of bounds: {0} cm", position), 3);
                        callback.Call(true);
                        return;
                    }
                    else
                    {
                        motors.SetStartPosition(motor, position.vertical);
                    }
                }
                else if (motor == 'D')
                {
                    double pos = position.depth + amount;
                    if ((pos < lowerDepth || pos > upperDepth) && enforceBoundaries == true)
                    {
                        terminal.Write(string.Format("Depth position out of bounds: {0} cm", position), 3);
                        callback.Call(true);
                        return;
                    }
                    else
                    {
                        motors.SetStartPosition(motor, position.depth);
                    }
                }
                else if (motor == 'A')
                {
                    double pos = position.azimuth + amount;
                    if ((pos < lowerAzimuth || pos > upperAzimuth) && enforceBoundaries == true)
                    {
                        terminal.Write(string.Format("Azimuth position out of bounds: {0} degrees", position), 3);
                        callback.Call(true);
                        return;
                    }
                    else
                    {
                        motors.SetStartPosition(motor, position.azimuth);
                    }
                }
                else if (motor == 'E')
                {
                    double pos = position.elevation + amount;
                    if ((pos < lowerElevation || pos > upperElevation) && enforceBoundaries == true)
                    {
                        terminal.Write(string.Format("Elevation position out of bounds: {0} degrees", position), 3);
                        callback.Call(true);
                        return;
                    }
                    else
                    {
                        motors.SetStartPosition(motor, position.elevation);
                    }
                }
                else if (motor == 'P')
                {
                    double pos = position.polarization + amount;
                    if ((pos < lowerPolarization || pos > upperPolarization) && enforceBoundaries == true)
                    {
                        terminal.Write(string.Format("Polarization position out of bounds: {0} degrees", position), 3);
                        callback.Call(true);
                        return;
                    }
                    else
                    {
                        motors.SetStartPosition(motor, position.polarization);
                    }
                }
                inMotion = true;
                forcedStop = false;
                moveCallback = callback;
                char status = 'A';
                char direction = 'P';
                if (amount < 0) { direction = 'N'; }
                double quantity = Math.Abs(amount);
                double alpha = motors.Alpha(motor);
                double beta = motors.Beta(motor);
                double gamma = motors.Gamma(motor);
                try
                {
                    controller.Send(string.Format("s{0}m{1}d{2}q{3}a{4}b{5}g{6}",
                        status,
                        motor,
                        direction,
                        quantity,
                        alpha,
                        beta,
                        gamma));
                }
                catch
                {
                    inMotion = false;
                    terminal.Write("Failed to send string to controller", 3);
                    callback.Call(false);
                }
            }
            else
            {
                callback.Call(false);
            }
        }
        public void WaitMotor(char motor, Callback callback)
        {
            if (motor == 'P') { waitTimer.Interval = waitTimeHorizontal; }
            else if (motor == 'V') { waitTimer.Interval = waitTimeVertical; }
            else if (motor == 'H') { waitTimer.Interval = waitTimeDepth; }
            else if (motor == 'D') { waitTimer.Interval = waitTimeAzimuth; }
            else if (motor == 'A') { waitTimer.Interval = waitTimeElevation; }
            else if (motor == 'E') { waitTimer.Interval = waitTimePolarization; }
            else { waitTimer.Interval = 1; }
            waitCallback = callback;
            waitTimer.Stop();
            waitTimer.Start();
        }
        public void WaitTime(double time, Callback callback)
        {
            waitTimer.Interval = time * 1000;
            waitCallback = callback;
            waitTimer.Stop();
            waitTimer.Start();
        }
        #endregion
        #region Call Methods
        public void MoveToHome(object[] args, Callback callback)
        {
            MoveToHome(callback);
        }
        public void Calibrate(object[] args, Callback callback)
        {
            Calibrate(callback);
        }
        public void MoveToPosition(object[] args, Callback callback)
        {
            char motor = (char)args[0];
            double pos = (double)args[1];
            MoveToPosition(motor, pos, callback);
        }
        public void MoveByAmount(object[] args, Callback callback)
        {
            char motor = (char)args[0];
            double amount = (double)args[1];
            MoveByAmount(motor, amount, callback);
        }
        public void WaitMotor(object[] args, Callback callback)
        {
            char motor = (char)args[0];
            WaitMotor(motor, callback);
        }
        public void WaitTime(object[] args, Callback callback)
        {
            double time = (double)args[0];
            WaitTime(time, callback);
        }
        #endregion

        #region Assistant Methods
        private void UpdatePosition(char motor, double pos)
        {
            if (motor == 'H') { position.horizontal = pos; }
            else if (motor == 'V') { position.vertical = pos; }
            else if (motor == 'D') { position.depth = pos; }
            else if (motor == 'A') { position.azimuth = pos; }
            else if (motor == 'E') { position.elevation = pos; }
            else if (motor == 'P') { position.polarization = pos; }
            position.SaveSettings(0);
        }
        #endregion
        #region Direct Methods
        public void Stop()
        {
            // Command the controller to stop
            if (inMotion == true && controller.connected == true)
            {
                forcedStop = true;
                char status = 'S';
                controller.Send(string.Format("s{0}", status));
            }
        }
        public void AbortWait()
        {
            waitTimer.Stop();
            waitCallback.Call(true);
        }

        public void ProcessControllerString(string input)
        {
            // Process the last incoming string
            try
            {
                Console.WriteLine(string.Format("Input String: {0}", input), 2);
                // retrieve value indices
                int indexStatus = input.IndexOf('s'); // Status Response (status)
                int indexMotor = input.IndexOf('m'); // Motor Response (motor)
                int indexDirection = input.IndexOf('d'); // Direction Response (direction)
                int indexQuantity = input.IndexOf('q'); // Quantity Response (quantity)
                int indexAlpha = input.IndexOf('a'); // Alpha Response (alpha)
                int indexBeta = input.IndexOf('b'); // Beta Response (beta)
                int indexGamma = input.IndexOf('g'); // Gamma Response (gamma)

                // retrieve values
                char status = input[indexStatus + 1];
                char motor = input[indexMotor + 1];
                char direction = input[indexDirection + 1];
                double quantity = System.Convert.ToDouble(input.Substring(indexQuantity + 1, indexAlpha - indexQuantity - 1));
                double alpha = System.Convert.ToDouble(input.Substring(indexAlpha + 1, indexBeta - indexAlpha - 1)); // not used right now
                double beta = System.Convert.ToDouble(input.Substring(indexBeta + 1, indexGamma - indexBeta - 1)); // not used right now
                double gamma = System.Convert.ToDouble(input.Substring(indexGamma + 1)); // not used right now

                // update parameters
                double position = motors.CalculatePosition(motor, direction, quantity);
                UpdatePosition(motor, position);

                if (status == 'S') // Indicates motors are stopped
                {
                    inMotion = false;
                    if (forcedStop == true) { moveCallback.Call(false); }
                    else { moveCallback.Call(true); }
                }
            }
            catch
            {
                terminal.Write("Failed to process controller string", 3);
            }

        }
        #endregion

        #region Interrupts
        private void OnWaitTimerEvent(object source, ElapsedEventArgs e)
        {
            waitCallback.Call(true);
        }
        #endregion

        #region Settings
        public void SaveSettings(int i)
        {
            List<object[]> lines = new List<object[]>();
            lines.Add(new object[] { "Horizontal Lower Bound", lowerHorizontal });
            lines.Add(new object[] { "Vertical Lower Bound", lowerVertical });
            lines.Add(new object[] { "Depth Lower Bound", lowerDepth });
            lines.Add(new object[] { "Azimuth Lower Bound", lowerAzimuth });
            lines.Add(new object[] { "Elevation Lower Bound", lowerElevation });
            lines.Add(new object[] { "Polarization Lower Bound", lowerPolarization });

            lines.Add(new object[] { "Horizontal Upper Bound", upperHorizontal });
            lines.Add(new object[] { "Vertical Upper Bound", upperVertical });
            lines.Add(new object[] { "Depth Upper Bound", upperDepth });
            lines.Add(new object[] { "Azimuth Upper Bound", upperAzimuth });
            lines.Add(new object[] { "Elevation Upper Bound", upperElevation });
            lines.Add(new object[] { "Polarization Upper Bound", upperPolarization });

            settings.Write(lines);
        }
        public void LoadSettings(int i)
        {
            List<string[]> lines = settings.Read();
            if (lines.Any())
            {
                foreach (string[] line in lines)
                {
                    if (line[0].Equals("Horizontal Lower Bound")) { lowerHorizontal = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Vertical Lower Bound")) { lowerVertical = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Depth Lower Bound")) { lowerDepth = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Azimuth Lower Bound")) { lowerAzimuth = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Elevation Lower Bound")) { lowerElevation = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Polarization Lower Bound")) { lowerPolarization = Convert.ToDouble(line[1]); }

                    else if (line[0].Equals("Horizontal Upper Bound")) { upperHorizontal = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Vertical Upper Bound")) { upperVertical = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Depth Upper Bound")) { upperDepth = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Azimuth Upper Bound")) { upperAzimuth = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Elevation Upper Bound")) { upperElevation = Convert.ToDouble(line[1]); }
                    else if (line[0].Equals("Polarization Upper Bound")) { upperPolarization = Convert.ToDouble(line[1]); }
                }
            }
            else
            {
                SaveSettings(0);
            }
        }
        #endregion
    }
}
