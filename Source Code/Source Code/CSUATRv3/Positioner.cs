using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CSUATRv3
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

        #region Classes
        Terminal terminal;
        Controller controller;
        Position position;
        System.Timers.Timer waitTimer;
        #endregion

        #region Event IDs
        Callback moveCallback;
        Callback waitCallback;
        #endregion

        #region Flags
        private bool inMotion = false;
        private bool forcedStop = false;
        #endregion

        #region Motor Bounds
        private double[] positionBoundsHorizontal = { -105.0f, 105.0f }; // appears to have 210cm of travel
        private double[] positionBoundsVertical = { -105.0f, 105.0f }; // appears to have 210cm of travel
        private double[] positionBoundsDepth = { -140.0f, 140.0f }; // appears to have 280cm of travel
        private double[] positionBoundsAzimuth = { -180.0f, 180.0f };
        private double[] positionBoundsElevation = { -180.0f, 180.0f };
        private double[] positionBoundsPolar = { -180.0f, 180.0f };
        #endregion

        #region Motor Wait Times (after done moving) (milliseconds)
        private int waitTimeHorizontal = 1000;
        private int waitTimeVertical = 1000;
        private int waitTimeDepth = 1000;
        private int waitTimeAzimuth = 1000;
        private int waitTimeElevation = 1000;
        private int waitTimePolar = 1000;
        #endregion

        public Positioner(Terminal terminal, Controller controller, Position position)
        {
            this.terminal = terminal;
            this.controller = controller;
            this.position = position;

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
                position.horizontal = 0.0f;
                position.vertical = 0.0f;
                position.depth = 0.0f;
                position.azimuth = 0.0f;
                position.elevation = 0.0f;
                position.polarization = 0.0f;
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
            if (motor == 'P') { amount = pos - position.polarization; }
            else if (motor == 'V') { amount = pos - position.vertical; }
            else if (motor == 'H') { amount = pos - position.horizontal; }
            else if (motor == 'D') { amount = pos - position.depth; }
            else if (motor == 'A') { amount = pos - position.azimuth; }
            else if (motor == 'E') { amount = pos - position.elevation; }
            MoveByAmount(motor, amount, callback);
        }
        public void MoveByAmount(char motor, double amount, Callback callback)
        {
            // Command the arduino to move system by a specified amount
            if (inMotion == false && controller.connected == true)
            {
                if (motor == 'H')
                {
                    double pos = position.horizontal + amount;
                    if (pos < positionBoundsHorizontal[0] || pos > positionBoundsHorizontal[1])
                    {
                        terminal.Write(string.Format("Horizontal position out of bounds: {0} cm", position));
                        callback.Call(true);
                        return;
                    }
                }
                else if (motor == 'V')
                {
                    double pos = position.vertical + amount;
                    if (pos < positionBoundsVertical[0] || pos > positionBoundsVertical[1])
                    {
                        terminal.Write(string.Format("Vertical position out of bounds: {0} cm", position));
                        callback.Call(true);
                        return;
                    }
                }
                else if (motor == 'D')
                {
                    double pos = position.depth + amount;
                    if (pos < positionBoundsDepth[0] || pos > positionBoundsDepth[1])
                    {
                        terminal.Write(string.Format("Depth position out of bounds: {0} cm", position));
                        callback.Call(true);
                        return;
                    }
                }
                else if (motor == 'A')
                {
                    double pos = position.azimuth + amount;
                    if (pos < positionBoundsAzimuth[0] || pos > positionBoundsAzimuth[1])
                    {
                        terminal.Write(string.Format("Azimuth position out of bounds: {0} degrees", position));
                        callback.Call(true);
                        return;
                    }
                }
                else if (motor == 'E')
                {
                    double pos = position.elevation + amount;
                    if (pos < positionBoundsElevation[0] || pos > positionBoundsElevation[1])
                    {
                        terminal.Write(string.Format("Elevation position out of bounds: {0} degrees", position));
                        callback.Call(true);
                        return;
                    }
                }
                else if (motor == 'P')
                {
                    double pos = position.polarization + amount;
                    if (pos < positionBoundsPolar[0] || pos > positionBoundsPolar[1])
                    {
                        terminal.Write(string.Format("Polarization position out of bounds: {0} degrees", position));
                        callback.Call(true);
                        return;
                    }
                }
                inMotion = true;
                forcedStop = false;
                moveCallback = callback;
                char status = 'A';
                char direction = 'P';
                if (amount < 0) { direction = 'N'; }
                double quantity = Math.Abs(amount);
                controller.Send(string.Format("s{0}m{1}d{2}q{3}", status, motor, direction, quantity));
            }
            else
            {
                callback.Call(false);
            }
        }

        public void Wait(char motor, Callback callback)
        {
            if (motor == 'P') { waitTimer.Interval = waitTimeHorizontal; }
            else if (motor == 'V') { waitTimer.Interval = waitTimeVertical; }
            else if (motor == 'H') { waitTimer.Interval = waitTimeDepth; }
            else if (motor == 'D') { waitTimer.Interval = waitTimeAzimuth; }
            else if (motor == 'A') { waitTimer.Interval = waitTimeElevation; }
            else if (motor == 'E') { waitTimer.Interval = waitTimePolar; }
            else { waitTimer.Interval = 1; }
            waitCallback = callback;
            waitTimer.Stop();
            waitTimer.Start();
        }
        private void OnWaitTimerEvent(object source, ElapsedEventArgs e)
        {
            waitCallback.Call(true);
        }
        #endregion

        public void Stop()
        {
            // Command the arduino to stop
            if (inMotion == true && controller.connected == true)
            {
                forcedStop = true;
                char status = 'S';
                controller.Send(string.Format("s{0}", status));
            }
        }

        public void ProcessControllerString(string input)
        {
            // Process the last incoming string
            int indexStatus = input.IndexOf('s'); // Status Response
            int indexMotor = input.IndexOf('m'); // Motor Response
            int indexDirection = input.IndexOf('d'); // Direction Response
            int indexQuantity = input.IndexOf('q'); // Quantity Response
            int indexPosition = input.IndexOf('p'); // Position Response
            if (indexMotor >= 0) // Motor
            {
                char motor = input[indexMotor + 1];
                if (indexPosition >= 0) // Position
                {
                    double pos = System.Convert.ToDouble(input.Substring(indexPosition + 1));
                    if (motor == 'P') { position.polarization = pos; }
                    else if (motor == 'V') { position.vertical = pos; }
                    else if (motor == 'H') { position.horizontal = pos; }
                    else if (motor == 'D') { position.depth = pos; }
                    else if (motor == 'A') { position.azimuth = pos; }
                    else if (motor == 'E') { position.elevation = pos; }
                }
                else if (indexDirection >= 0 && indexQuantity >= 0) // Direction and Quantity
                {
                    char direction = input[indexDirection + 1];
                    double quantity = System.Convert.ToDouble(input.Substring(indexQuantity + 1));
                    if (direction == 'N') { quantity *= -1; }
                    if (motor == 'P') { position.polarization += quantity; }
                    else if (motor == 'V') { position.vertical += quantity; }
                    else if (motor == 'H') { position.horizontal += quantity; }
                    else if (motor == 'D') { position.depth += quantity; }
                    else if (motor == 'A') { position.azimuth += quantity; }
                    else if (motor == 'E') { position.elevation += quantity; }
                }
            }
            if (indexStatus >= 0 && input[indexStatus + 1] == 'S') // Indicates motors are stopped
            {
                inMotion = false;
                if (forcedStop == true) { moveCallback.Call(false); }
                else { moveCallback.Call(true); }
            }
        }


        #region Methods
        public void Calibrate(object[] args, Callback callback)
        {
            Calibrate(callback);
        }

        #endregion
    }
}
