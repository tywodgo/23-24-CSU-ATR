using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class EventManager
    {
        #region Event Functionality
        // Controller: Connect(portName)
        // Controller: Disconnect()

        // Instrument: Connect(address)
        // Instrument: Disconnect()
        // Instrument: Setup()
        // Instrument: Measure()
        // Instrument: SetSParameter(sparam)
        // Instrument: SetSourcePower(power)
        // Instrument: SetStartFrequency(freq)
        // Instrument: SetStopFrequency(freq)
        // Instrument: SetIFBandwidth(freq)
        // Instrument: SetSweepPoints(points)
        // Instrument: SetAveragePoints(points)
        // Instrument: Wait()

        // Positioner: MoveToHome()
        // Positioner: Calibrate()
        // Positioner: MoveToPosition(motor, position)
        // Positioner: MoveByAmount(motor, amount)
        // Positioner: Wait()

        // DataManager: SaveData()
        // DataManager: LoadData()
        // DataManager: RemoveLastPoint()
        // DataManager: ClearDataset()
        #endregion

        MainForm mainForm;

        ListBox queue;
        Label status;

        Terminal terminal;
        Controller controller;
        Instrument instrument;
        Positioner positioner;
        DataManager dataManager;

        #region Parameters
        private List<object[]> eventQueue;
        private List<ulong> eventIDs;

        private List<object[]> currentEvents;
        private List<string> currentEventStrings;
        private List<ulong> currentEventIDs;

        ulong latestEventID = 0;
        #endregion



        // change these to be time estimates for each function (or build functions)
        #region Timing Parameters
        public double timeSetup = 1.0; // estimated time for calibration
        public double timeCalibrate = 1.0; // estimated time for calibration
        public double timeMove = 2.0; // estimated time per step
        public double timeMeasure = 3.0; // estimated time for calibration
        #endregion

        string[] addModes =
        {
            "Append",
            "Insert",
            "Push"
        };

        public EventManager(
            MainForm mainForm,
            ListBox queue,
            Label status,
            Terminal terminal,
            Controller controller,
            Instrument instrument,
            Positioner positioner,
            DataManager dataManager)
        {
            this.mainForm = mainForm;
            this.queue = queue;
            this.status = status;
            this.terminal = terminal;
            this.controller = controller;
            this.instrument = instrument;
            this.positioner = positioner;
            this.dataManager = dataManager;

            eventQueue = new List<object[]>();
            eventIDs = new List<ulong>();

            currentEvents = new List<object[]>();
            currentEventStrings = new List<string>();
            currentEventIDs = new List<ulong>();

            UpdateStatus();
            UpdateQueue();

            mainForm.addMode.Items.Clear();
            mainForm.addMode.Items.AddRange(addModes);
            mainForm.addMode.SelectedIndex = 0;
            mainForm.continuous.Checked = true;
            queue.SelectionMode = SelectionMode.One;
        }

        #region Add Event
        public void AppendEventRange(List<object[]> events)
        {
            int index = queue.SelectedIndex;
            foreach (object[] e in events)
            {
                if (latestEventID + 1 == 0) { latestEventID = 1; } // eventID, if overflows, should not equal zero
                else { latestEventID++; } // increment eventID

                eventQueue.Add(e);
                eventIDs.Add(latestEventID);
                queue.Items.Add(EventToString(e));
            }
            queue.SetSelected(queue.Items.Count - 1, true);

            UpdateQueue();

            if (currentEvents.Count == 0 && mainForm.continuous.Checked == true) { Execute(); }
        }

        public void AddEvent(object[] e)
        {
            if (mainForm.addMode.Text.Equals("Insert")) { InsertEvent(e); }
            else if (mainForm.addMode.Text.Equals("Push")) { PushEvent(e); }
            else { AppendEvent(e); }
        }
        private void AppendEvent(object[] e)
        {
            if (latestEventID + 1 == 0) { latestEventID = 1; } // eventID, if overflows, should not equal zero
            else { latestEventID++; } // increment eventID

            eventQueue.Add(e);
            eventIDs.Add(latestEventID);
            queue.Items.Add(EventToString(e));
            queue.SetSelected(queue.Items.Count - 1, true);

            UpdateQueue();

            if (currentEvents.Count == 0 && mainForm.continuous.Checked == true) { Execute(); }
        }
        private void InsertEvent(object[] e)
        {
            if (latestEventID + 1 == 0) { latestEventID = 1; } // eventID, if overflows, should not equal zero
            else { latestEventID++; } // increment eventID

            int index = queue.SelectedIndex;
            if (index < 0) { index = 0; }
            eventQueue.Insert(index, e);
            eventIDs.Insert(index, latestEventID);
            queue.Items.Insert(index, EventToString(e));
            if (index >= 0)
            {
                if (index + 1 < queue.Items.Count)
                {
                    queue.SetSelected(index + 1, true);
                }
                else
                {
                    queue.SetSelected(index, true);
                }
            }

            UpdateQueue();

            if (currentEvents.Count == 0 && mainForm.continuous.Checked == true) { Execute(); }
        }
        private void PushEvent(object[] e)
        {
            if (latestEventID + 1 == 0) { latestEventID = 1; } // eventID, if overflows, should not equal zero
            else { latestEventID++; } // increment eventID

            eventQueue.Insert(0, e);
            eventIDs.Insert(0, latestEventID);
            queue.Items.Insert(0, EventToString(e));
            queue.SetSelected(0, true);

            UpdateQueue();

            if (currentEvents.Count == 0 && mainForm.continuous.Checked == true) { Execute(); }
        }
        #endregion

        #region Execution
        public void FinishProcess(ulong eventID, bool succeeded)
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _FinishProcess(eventID, succeeded); })); }
            else { _FinishProcess(eventID, succeeded); }
        }
        public void _FinishProcess(ulong eventID, bool succeeded)
        {
            for (int i = 0; i < currentEventIDs.Count; i++)
            {
                if (currentEventIDs[i] == eventID)
                {
                    try
                    {
                        if (succeeded == false)
                        {
                            mainForm.continuous.Checked = false;
                            PushEvent(currentEvents[i]);
                            terminal.Write(string.Format("{0} Failed. Event pushed to queue", EventToString(currentEvents[i])));
                        }
                        currentEvents.RemoveAt(i);
                        currentEventStrings.RemoveAt(i);
                        currentEventIDs.RemoveAt(i);
                        UpdateStatus();
                        if (currentEvents.Count == 0 && mainForm.continuous.Checked == true) { Execute(); }
                    }
                    catch
                    {
                        terminal.Write(string.Format("Failed to properly finish: {0}", currentEventStrings[i]));
                    }
                }
            }
        }
        public void Execute()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _Execute(); })); }
            else { _Execute(); }
        }
        public void _Execute()
        {
            if (eventQueue.Any())
            {
                try
                {
                    currentEvents.Add(eventQueue.First()); // add top to current execution
                    currentEventIDs.Add(eventIDs.First());
                    currentEventStrings.Add(EventToString(eventQueue.First()));
                    UpdateStatus();

                    int index = queue.SelectedIndex;
                    eventQueue.RemoveAt(0); // not remove that top event from the queue
                    eventIDs.RemoveAt(0);
                    queue.Items.RemoveAt(0);
                    if (index >= 1) { queue.SetSelected(index - 1, true); }

                    UpdateQueue();
                }
                catch
                {
                    terminal.Write("Failed to properly execute next event");
                    return;
                }

                Command();
            }
            else
            {
                terminal.Write("Nothing in queue to execute");
            }
        }
        private void Command()
        {
            object[] currentEvent = currentEvents.Last();
            string currentEventString = currentEventStrings.Last();
            ulong eventID = currentEventIDs.Last();
            //try // TODO: uncomment these
            //{
            if (currentEvent[0].Equals("Controller"))
            {
                if (currentEvent[1].Equals("Connect")) { controller.Connect((string)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("Disconnect")) { controller.Disconnect(eventID); }
                else
                {
                    terminal.Write(string.Format("Unrecognized Command: {0}", currentEventString));
                    FinishProcess(eventID, true);
                }
            }
            else if (currentEvent[0].Equals("Instrument"))
            {
                if (currentEvent[1].Equals("Connect")) { instrument.Connect((string)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("Disconnect")) { instrument.Disconnect(eventID); }
                else if (currentEvent[1].Equals("Measure")) { instrument.Measure(eventID); }
                else if (currentEvent[1].Equals("SetSParameter")) { instrument.SetSParameter((string)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("SetSourcePower")) { instrument.SetSourcePower((double)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("SetStartFrequency")) { instrument.SetStartFrequency((double)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("SetStopFrequency")) { instrument.SetStopFrequency((double)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("SetIFBandwidth")) { instrument.SetIFBandwidth((double)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("SetSweepPoints")) { instrument.SetSweepPoints((int)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("SetAveragePoints")) { instrument.SetAveragePoints((int)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("Wait")) { instrument.Wait(eventID); }
                else
                {
                    terminal.Write(string.Format("Unrecognized Command: {0}", currentEventString));
                    FinishProcess(eventID, true);
                }
            }
            else if (currentEvent[0].Equals("Positioner"))
            {
                if (currentEvent[1].Equals("MoveToHome")) { positioner.MoveToHome(eventID); }
                else if (currentEvent[1].Equals("Calibrate")) { positioner.Calibrate(eventID); }
                else if (currentEvent[1].Equals("MoveToPosition")) { positioner.MoveToPosition((char)currentEvent[2], (float)currentEvent[3], eventID); }
                else if (currentEvent[1].Equals("MoveByAmount")) { positioner.MoveByAmount((char)currentEvent[2], (float)currentEvent[3], eventID); }
                else if (currentEvent[1].Equals("Wait")) { positioner.Wait((char)currentEvent[2], eventID); }
                else
                {
                    terminal.Write(string.Format("Unrecognized Command: {0}", currentEventString));
                    FinishProcess(eventID, true);
                }
            }
            else if (currentEvent[0].Equals("DataManager"))
            {
                if (currentEvent[1].Equals("SaveData")) { dataManager.SaveData(eventID); }
                else if (currentEvent[1].Equals("LoadData")) { dataManager.LoadData(eventID); }
                else if (currentEvent[1].Equals("RemovePointAtIndex")) { dataManager.RemovePointAtIndex((int)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("RemovePointAtID")) { dataManager.RemovePointAtID((ulong)currentEvent[2], eventID); }
                else if (currentEvent[1].Equals("RemoveFirstPoint")) { dataManager.RemoveFirstPoint(eventID); }
                else if (currentEvent[1].Equals("RemoveLastPoint")) { dataManager.RemoveLastPoint(eventID); }
                else if (currentEvent[1].Equals("ClearDataset")) { dataManager.ClearDataset(eventID); }
                else
                {
                    terminal.Write(string.Format("Unrecognized Command: {0}", currentEventString));
                    FinishProcess(eventID, true);
                }
            }
            else
            {
                terminal.Write(string.Format("Unrecognized Command: {0}", currentEventString));
                FinishProcess(eventID, true);
            }
            //}
            //catch
            //{
            //    terminal.Write(string.Format("Failed to execute command: {0}", currentEventString));
            //    FinishProcess(eventID, false);
            //}
        }
        #endregion

        #region Remove
        public void ClearQueue()
        {
            try
            {
                eventQueue.Clear();
                eventIDs.Clear();
                queue.Items.Clear();
            }
            catch
            {
                terminal.Write("Failed to properly clear queue");
            }
        }
        public void Remove()
        {
            try
            {
                int index = queue.SelectedIndex;
                if (index < 0) { index = 0; }
                eventQueue.RemoveAt(index);
                eventIDs.RemoveAt(index);
                queue.Items.RemoveAt(index);
                if (index >= 1) { queue.SetSelected(index - 1, true); }
            }
            catch
            {
                terminal.Write("Failed to properly remove event");
            }
        }
        #endregion

        #region Estimation
        private double EstimateTimeRemaining()
        {
            // TODO
            // in minutes
            return 1.000;
        }
        #endregion

        private string EventToString(object[] e)
        {
            string eventString = e[0].ToString() + ": " + e[1].ToString() + "(";
            for (int i = 2; i < e.Count() - 1; i++)
            {
                eventString += e[i].ToString() + ", ";
            }
            if (e.Count() > 2)
            {
                eventString += e[e.Count() - 1].ToString();
            }
            eventString += ")";
            return eventString;
        }


    }
}
