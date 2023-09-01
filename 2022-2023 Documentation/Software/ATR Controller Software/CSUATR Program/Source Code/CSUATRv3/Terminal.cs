﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class Terminal
    {
        ListBox terminal;

        #region Parameters
        private int maxLines = 500;
        private string direction = "Down";
        #endregion

        public Terminal(ListBox terminal)
        {
            this.terminal = terminal;
        }

        #region Functions
        public void SetDirection(string dir)
        {
            if (dir.Equals("Up") || dir.Equals("Down"))
            {
                direction = dir;
            }
            else
            {
                Write("Error: Invalid output direction");
            }
        }

        public void Clear()
        {
            terminal.Items.Clear();
        }

        public void Write(string output)
        {
            if (direction.Equals("Up"))
            {
                if (terminal.InvokeRequired) { terminal.Invoke(new MethodInvoker(delegate { WriteUp(output); })); }
                else { WriteUp(output); }
            }
            else
            {
                if (terminal.InvokeRequired) { terminal.Invoke(new MethodInvoker(delegate { WriteDown(output); })); }
                else { WriteDown(output); }
            }
        }

        private void WriteDown(string output)
        {
            // keep only a few lines in the log
            while (terminal.Items.Count > maxLines) { terminal.Items.RemoveAt(0); }
            // add this line at the bottom of the log
            int index = terminal.Items.Count;
            terminal.Items.Insert(index, output);
            // Move the current index to the last item added
            terminal.TopIndex = terminal.Items.Count - 1;
        }

        private void WriteUp(string output)
        {
            // add this line at the top of the log
            terminal.Items.Insert(0, output);
            // keep only a few lines in the log
            while (terminal.Items.Count > maxLines) { terminal.Items.RemoveAt(terminal.Items.Count - 1); }
        }
        #endregion

    }
}
