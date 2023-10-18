using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CSUATR
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
        MainForm mainForm;
        Arduino arduino;
        #endregion

        #region Flags
        public bool inMotion = false;
        #endregion

        #region Positioning Parameters
        public List<object[]> motionQueue = new List<object[]>(); // for when multiple motors are queued at the same time

        // "Home" position will be considered the "zeroed" position (AKA origin)
        // these zeros should be varified using limit switches
        public float[] positionBoundsPolar = { -180.0f, 180.0f };
        public float[] positionBoundsVertical = { -105.0f, 105.0f }; // appears to have 210cm of travel
        public float[] positionBoundsHorizontal = { -105.0f, 105.0f }; // appears to have 210cm of travel
        public float[] positionBoundsDepth = { -140.0f, 140.0f }; // appears to have 280cm of travel
        public float[] positionBoundsAzimuth = { -180.0f, 180.0f };
        public float[] positionBoundsElevation = { -180.0f, 180.0f };

        // Program Variables
        public float currentPositionPolar = 0.0f;
        public float currentPositionVertical = 0.0f;
        public float currentPositionHorizontal = 0.0f;
        public float currentPositionDepth = 0.0f;
        public float currentPositionAzimuth = 0.0f;
        public float currentPositionElevation = 0.0f;
        #endregion

        public Positioner(MainForm mainForm, Arduino arduino)
        {
            this.mainForm = mainForm;
            this.arduino = arduino;
        }

        public void Reset()
        {
            // Resets Queue and inMotion parameter, does not reset current position
            // this should only be instantiated if the arduino is diconnected
            inMotion = false;
            motionQueue.Clear();
            mainForm.UpdateEnabledButtons_Positioning();
            mainForm.UpdateEnabledButtons_ScanSettings();
        }

        public void MoveToHome()
        {
            // This function currently zeros out the position (will change later with limit switches)
            currentPositionPolar = 0.0f;
            currentPositionVertical = 0.0f;
            currentPositionHorizontal = 0.0f;
            currentPositionDepth = 0.0f;
            currentPositionAzimuth = 0.0f;
            currentPositionElevation = 0.0f;
            mainForm.UpdateStatus_Positioning();
        }

        public void MoveToPosition(char motor, float position)
        {
            // Call MoveByAmount() with parameters that will move system to specified position
            if (inMotion == true)
            {
                object[] query = { "position", motor, position };
                motionQueue.Add(query);
                return;
            }
            float amount = 0;
                 if (motor == 'P') { amount = position - currentPositionPolar; }
            else if (motor == 'V') { amount = position - currentPositionVertical; }
            else if (motor == 'H') { amount = position - currentPositionHorizontal; }
            else if (motor == 'D') { amount = position - currentPositionDepth; }
            else if (motor == 'A') { amount = position - currentPositionAzimuth; }
            else if (motor == 'E') { amount = position - currentPositionElevation; 
                //mainForm.WriteToOutput(string.Format("Position: {0}, currentPositionElevation: {1}, amount: {2}", position, currentPositionElevation, amount)); 
            }
            MoveByAmount(motor, amount);
        }
        
        public void MoveByAmount(char motor, float amount)
        {
            // Command the arduino to move system by a specified amount
            if (inMotion == true)
            {
                object[] query = { "amount", motor, amount };
                motionQueue.Add(query);
                return;
            }
            if (motor == 'P')
            {
                float position = currentPositionPolar + amount;
                if (position < positionBoundsPolar[0] || position > positionBoundsPolar[1])
                {
                    mainForm.WriteToOutput(string.Format("Polarization position out of bounds: {0} degrees", position));
                    return;
                }
            }
            else if (motor == 'V')
            {
                float position = currentPositionVertical + amount;
                if (position < positionBoundsVertical[0] || position > positionBoundsVertical[1])
                {
                    mainForm.WriteToOutput(string.Format("Vertical position out of bounds: {0} cm", position));
                    return;
                }
            }
            else if (motor == 'H')
            {
                float position = currentPositionHorizontal + amount;
                if (position < positionBoundsHorizontal[0] || position > positionBoundsHorizontal[1])
                {
                    mainForm.WriteToOutput(string.Format("Horizontal position out of bounds: {0} cm", position));
                    return;
                }
            }
            else if (motor == 'D')
            {
                float position = currentPositionDepth + amount;
                if (position < positionBoundsDepth[0] || position > positionBoundsDepth[1])
                {
                    mainForm.WriteToOutput(string.Format("Depth position out of bounds: {0} cm", position));
                    return;
                }
            }
            else if (motor == 'A')
            {
                float position = currentPositionAzimuth + amount;
                if (position < positionBoundsAzimuth[0] || position > positionBoundsAzimuth[1])
                {
                    mainForm.WriteToOutput(string.Format("Azimuth position out of bounds: {0} degrees", position));
                    return;
                }
            }
            else if (motor == 'E')
            {
                float position = currentPositionElevation + amount;
                if (position < positionBoundsElevation[0] || position > positionBoundsElevation[1])
                {
                    mainForm.WriteToOutput(string.Format("Elevation position out of bounds: {0} degrees", position));
                    return;
                }
            }
            inMotion = true;
            mainForm.UpdateEnabledButtons_Positioning();
            mainForm.UpdateEnabledButtons_ScanSettings();
            char status = 'A';
            char direction = 'P';
            if (amount < 0) { direction = 'N'; }
            float quantity = Math.Abs(amount);
            arduino.Send(string.Format("s{0}m{1}d{2}q{3}", status, motor, direction, quantity));
        }

        public void Stop()
        {
            // Command the arduino to stop
            char status = 'S';
            arduino.Send(string.Format("s{0}", status));
        }

        public void ProcessArduinoString(string input)
        {
            // Process the last incoming string
            //Console.WriteLine(string.Format("Input recived: {0}", input));

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
                    float position = (float)System.Convert.ToDecimal(input.Substring(indexPosition + 1));
                         if (motor == 'P') { currentPositionPolar = position; }
                    else if (motor == 'V') { currentPositionVertical = position; }
                    else if (motor == 'H') { currentPositionHorizontal = position; }
                    else if (motor == 'D') { currentPositionDepth = position; }
                    else if (motor == 'A') { currentPositionAzimuth = position; }
                    else if (motor == 'E') { currentPositionElevation = position; }
                    if (mainForm.InvokeRequired)
                    {
                        mainForm.Invoke(new MethodInvoker(delegate
                        {
                            mainForm.UpdateStatus_Positioning();
                        }));
                    }
                    else
                    {
                        mainForm.UpdateStatus_Positioning();
                    }
                }
                else if (indexDirection >= 0 && indexQuantity >= 0) // Direction and Quantity
                {
                    char direction = input[indexDirection + 1];
                    float quantity = (float)System.Convert.ToDecimal(input.Substring(indexQuantity + 1));
                    if (direction == 'N') { quantity *= -1; }
                         if (motor == 'P') { currentPositionPolar += quantity; }
                    else if (motor == 'V') { currentPositionVertical += quantity; }
                    else if (motor == 'H') { currentPositionHorizontal += quantity; }
                    else if (motor == 'D') { currentPositionDepth += quantity; }
                    else if (motor == 'A') { currentPositionAzimuth += quantity; }
                    else if (motor == 'E') { currentPositionElevation += quantity; }
                    if (mainForm.InvokeRequired)
                    {
                        mainForm.Invoke(new MethodInvoker(delegate
                        {
                            mainForm.UpdateStatus_Positioning();
                        }));
                    }
                    else
                    {
                        mainForm.UpdateStatus_Positioning();
                    }
                }
            }
            if (indexStatus >= 0 && input[indexStatus + 1] == 'S') // Indicates motors are stopped
            {
                inMotion = false;
                // Once motors stop, this calls those that are on the queue
                if (motionQueue.Any())
                {
                    string queueCommand = (string)motionQueue.First()[0];
                    char queueMotor = (char)motionQueue.First()[1];
                    float queueValue = (float)motionQueue.First()[2];
                    motionQueue.RemoveAt(0);
                    if (queueCommand.Equals("position")) { MoveToPosition(queueMotor, queueValue); }
                    else { MoveByAmount(queueMotor, queueValue); }
                }
                else if (mainForm.InvokeRequired)
                {
                    mainForm.Invoke(new MethodInvoker(delegate
                    {
                        mainForm.UpdateEnabledButtons_Positioning();
                        mainForm.UpdateEnabledButtons_ScanSettings();
                        mainForm.scanner.OnMotorStopEvent();
                    }));
                }
                else
                {
                    mainForm.UpdateEnabledButtons_Positioning();
                    mainForm.UpdateEnabledButtons_ScanSettings();
                    mainForm.scanner.OnMotorStopEvent();
                }
                
            }
        }

    }
}
