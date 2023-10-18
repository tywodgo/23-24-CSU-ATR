using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATRv2
{
    public class EventManager
    {
        #region Form Communication
        private MainForm mainForm;
        private Terminal terminal;
        private Positioner positioner;
        private Instrument instrument;
        #endregion

        #region Parameters
        private List<Function> eventQueue;
        private ListBox eventQueueStrings;

        private List<long> currentEventIDs;
        public List<Function> currentEvents;
        private List<string> currentEventStrings;
        private Label currentEventString;

        private long latestEventID = 0;
        #endregion

        public EventManager(
            MainForm mainForm,
            Terminal terminal,
            Positioner positioner,
            Instrument instrument,
            ListBox eventQueueStrings,
            Label currentEventString)
        {
            this.mainForm = mainForm;
            this.terminal = terminal;
            this.positioner = positioner;
            this.instrument = instrument;

            eventQueue = new List<Function>();
            this.eventQueueStrings = eventQueueStrings;

            currentEventIDs = new List<long>();
            currentEvents = new List<Function>();
            currentEventStrings = new List<string>();
            this.currentEventString = currentEventString;
        }

        #region Add Event
        // Append Range
        public void AppendEventRange(List<Function> events)
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _AppendEventRange(events); })); }
            else { _AppendEventRange(events); }
        }
        private void _AppendEventRange(List<Function> events)
        {
            int index = eventQueueStrings.SelectedIndex;
            eventQueue.AddRange(events);
            foreach (Function e in events)
            {
                eventQueueStrings.Items.Add(EventToString(e));
            }
            eventQueueStrings.SetSelected(eventQueueStrings.Items.Count - 1, true);

            UpdateTimeRemaining();
            UpdateEventsRemaining();

            if (currentEvents.Count == 0 && mainForm.continuous.Checked == true) { Execute(); }
        }
        // Add
        public void AddEvent(Function e)
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _AddEvent(e); })); }
            else { _AddEvent(e); }
        }
        private void _AddEvent(Function e)
        {
            if (mainForm.addMode.Text.Equals("Insert")) { InsertEvent(e); }
            else if (mainForm.addMode.Text.Equals("Push")) { PushEvent(e); }
            else { AppendEvent(e); }
        }
        // Append
        public void AppendEvent(Function e)
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _AppendEvent(e); })); }
            else { _AppendEvent(e); }
        }
        private void _AppendEvent(Function e)
        {
            eventQueue.Add(e);
            eventQueueStrings.Items.Add(EventToString(e));
            eventQueueStrings.SetSelected(eventQueueStrings.Items.Count - 1, true);

            UpdateTimeRemaining();
            UpdateEventsRemaining();

            if (currentEvents.Count == 0 && mainForm.continuous.Checked == true) { Execute(); }
        }
        // Insert
        public void InsertEvent(Function e)
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _InsertEvent(e); })); }
            else { _InsertEvent(e); }
        }
        private void _InsertEvent(Function e)
        {
            int index = eventQueueStrings.SelectedIndex;
            if (index < 0) { index = 0; }
            eventQueue.Insert(index, e);
            eventQueueStrings.Items.Insert(index, EventToString(e));
            if (index + 1 < eventQueueStrings.Items.Count)
            {
                eventQueueStrings.SetSelected(index + 1, true);
            }
            else
            {
                eventQueueStrings.SetSelected(index, true);
            }

            UpdateTimeRemaining();
            UpdateEventsRemaining();

            if (currentEvents.Count == 0 && mainForm.continuous.Checked == true) { Execute(); }
        }
        // Push
        public void PushEvent(Function e)
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _PushEvent(e); })); }
            else { _PushEvent(e); }
        }
        private void _PushEvent(Function e)
        {
            eventQueue.Insert(0, e);
            eventQueueStrings.Items.Insert(0, EventToString(e));
            eventQueueStrings.SetSelected(0, true);

            UpdateTimeRemaining();
            UpdateEventsRemaining();

            if (currentEvents.Count == 0 && mainForm.continuous.Checked == true) { Execute(); }
        }
        #endregion

        #region Execution
        public void Finish(long eventID, bool succeeded)
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _Finish(eventID, succeeded); })); }
            else { _Finish(eventID, succeeded); }
        }
        public void _Finish(long eventID, bool succeeded)
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
                            terminal.Write(string.Format("{0} Failed. Event pushed to queue", currentEventStrings[i]), 2);
                        }
                        currentEventIDs.RemoveAt(i);
                        currentEvents.RemoveAt(i);
                        currentEventStrings.RemoveAt(i);
                        if (currentEvents.Count > 0) { currentEventString.Text = currentEventStrings.Last(); }
                        else { currentEventString.Text = "None"; }

                        if (currentEvents.Count == 0 && mainForm.continuous.Checked == true) { Execute(); }
                    }
                    catch
                    {
                        terminal.Write("Failed to properly finish", 3);
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
                    // negative ids are reserved
                    if (latestEventID < 0) { latestEventID = 0; } // in case id overshoots long bounds (and wraps around)
                    else { latestEventID++; }
                    eventQueue.First().AddCallback(new Callback(Finish, latestEventID));
                    currentEventIDs.Add(latestEventID);
                    currentEvents.Add(eventQueue.First()); // add top to current execution
                    currentEventStrings.Add((string)eventQueueStrings.Items[0]);
                    currentEventString.Text = currentEventStrings.Last();

                    int index = eventQueueStrings.SelectedIndex;
                    eventQueue.RemoveAt(0);
                    eventQueueStrings.Items.RemoveAt(0);
                    if (index >= 1) { eventQueueStrings.SetSelected(index - 1, true); }

                    UpdateTimeRemaining();
                    UpdateEventsRemaining();

                    currentEvents.Last().Call();
                }
                catch
                {
                    terminal.Write("Failed to properly execute next event", 3);
                    return;
                }
            }
            else
            {
                if (mainForm.continuous.Checked == false)
                {
                    terminal.Write("Nothing in queue to execute", 2);
                }
            }
        }
        public void Stop()
        {
            try
            {
                if (currentEvents.Count > 0)
                {
                    Function f = currentEvents.Last();
                    string name = f.function.Method.Name;
                    if (name.Equals("MoveToPosition") ||
                        name.Equals("MoveByAmount") ||
                        name.Equals("Calibrate") ||
                        name.Equals("MoveToHome"))
                    {
                        positioner.Stop(); // TODO: test that this actually stops the motors
                    }
                    else if (name.Equals("WaitMotor") || name.Equals("WaitTime"))
                    {
                        positioner.AbortWait();
                    }
                    else if (name.Equals("Measure"))
                    {
                        instrument.Abort();
                    }
                    f.callback.Call(false);
                }
            }
            catch
            {
                terminal.Write("Failed to stop event", 3);
            }
        }
        #endregion

        #region Remove
        public void ClearQueue()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _ClearQueue(); })); }
            else { _ClearQueue(); }
        }
        public void _ClearQueue()
        {
            try
            {
                eventQueue.Clear();
                eventQueueStrings.Items.Clear();
                UpdateTimeRemaining();
                UpdateEventsRemaining();
            }
            catch
            {
                terminal.Write("Failed to properly clear queue", 3);
            }
        }
        public void Remove()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _Remove(); })); }
            else { _Remove(); }
        }
        public void _Remove()
        {
            try
            {
                int index = eventQueueStrings.SelectedIndex;
                if (index < 0) { index = 0; }
                eventQueue.RemoveAt(index);
                eventQueueStrings.Items.RemoveAt(index);
                if (index >= 1) { eventQueueStrings.SetSelected(index - 1, true); }

                UpdateTimeRemaining();
                UpdateEventsRemaining();
            }
            catch
            {
                terminal.Write("Failed to properly remove event", 3);
            }
        }
        #endregion

        #region Assistant Methods
        private double EstimateTimeRemaining()
        {
            // seriously, a very very rough estimate
            try
            {
                double time = 0; // seconds
                foreach (Function e in eventQueue)
                {
                    string name = e.function.Method.Name;
                    if (name.Equals("Connect")) { time += 1.0; }
                    else if (name.Equals("MoveToPosition") || name.Equals("MoveByAmount"))
                    {
                        if ((char)e.args[0] == 'H') { time += 3.0; }
                        else if ((char)e.args[0] == 'V') { time += 1.0; }
                        else if ((char)e.args[0] == 'D') { time += 10.0; }
                        else if ((char)e.args[0] == 'A') { time += 2.0; }
                        else if ((char)e.args[0] == 'E') { time += 1.0; }
                        else if ((char)e.args[0] == 'P') { time += 2.0; }
                    }
                    else if (name.Equals("Calibrate")) { time += 120.0; }
                    else if (name.Equals("MoveToHome")) { time += 60.0; }
                    else if (name.Equals("WaitMotor"))
                    {
                        if ((char)e.args[0] == 'H') { time += (positioner.waitTimeHorizontal / 1000); }
                        else if ((char)e.args[0] == 'V') { time += (positioner.waitTimeVertical / 1000); }
                        else if ((char)e.args[0] == 'D') { time += (positioner.waitTimeDepth / 1000); }
                        else if ((char)e.args[0] == 'A') { time += (positioner.waitTimeAzimuth / 1000); }
                        else if ((char)e.args[0] == 'E') { time += (positioner.waitTimeElevation / 1000); }
                        else if ((char)e.args[0] == 'P') { time += (positioner.waitTimePolarization / 1000); }
                    }
                    else if (name.Equals("WaitTime")) { time += (double)e.args[0]; }
                    else if (name.Equals("Measure")) { time += (1 + 0.007 * instrument.sweepPoints); }
                }
                double minutes = time / 60.0;
                return minutes;
            }
            catch
            {
                terminal.Write("Failed to calculate time", 3);
                return 0;
            }
        }
        private string EventToString(Function e)
        {
            string eventString = e.function.Method.Name + "(";
            if (e.args.Length > 0)
            {
                for (int i = 0; i < e.args.Length - 1; i++)
                {
                    eventString += e.args[i].ToString() + ", ";
                }
                eventString += e.args[e.args.Length - 1].ToString();
            }
            eventString += ")";
            return eventString;
        }
        #endregion




        #region GUI Updates
        // Time Remaining
        public void UpdateTimeRemaining()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateTimeRemaining(); })); }
            else { _UpdateTimeRemaining(); }
        }
        private void _UpdateTimeRemaining() { mainForm.statusTimeRemaining.Text = EstimateTimeRemaining().ToString("N2"); }
        // Events Remaining
        public void UpdateEventsRemaining()
        {
            if (mainForm.InvokeRequired) { mainForm.Invoke(new MethodInvoker(delegate { _UpdateEventsRemaining(); })); }
            else { _UpdateEventsRemaining(); }
        }
        private void _UpdateEventsRemaining() { mainForm.statusEventsRemaining.Text = eventQueue.Count.ToString(); }
        #endregion
    }
}
