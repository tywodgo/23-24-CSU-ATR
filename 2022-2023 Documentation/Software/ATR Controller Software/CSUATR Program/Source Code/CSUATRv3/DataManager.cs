using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class DataManager
    {
        #region Classes
        private Terminal terminal;
        private Position position;
        private Instrument instrument;
        private Measurement measurement;
        #endregion

        #region Data Parameters
        private List<Point> data;
        private long latestID;
        #endregion

        #region Flags
        public bool ready { get; set; }
        public bool saved { get; set; }
        #endregion

        #region File IO
        public string basePath { get; set; }
        public string folder
        {
            get { return folder; }
            set { folder = value; mainForm.WriteMeta(); }
        }
        public string file
        {
            get { return file; }
            set { file = value; mainForm.WriteMeta(); }
        }
        #endregion

        public DataManager(Terminal terminal, Position position, Instrument instrument, Measurement measurement)
        {
            this.terminal = terminal;
            this.position = position;
            this.instrument = instrument;
            this.measurement = measurement;
            data = new List<Point>();
            latestID = 0;
            ready = true;
            saved = true;
            basePath = Directory.GetCurrentDirectory();
            folder = "Data";
            file = "data.txt"; //TODO: Make sure that these are recorded and initialized with the Meta File;
        }

        private bool Check()
        {
            string folderpath = basePath + @"\" + folder + @"\";
            string filepath = basePath + @"\" + folder + @"\" + file;
            try
            {
                // Test if path exists
                if (!Directory.Exists(folderpath))
                {
                    terminal.Write(string.Format("Data Folder '{0}' does not exist", folder));
                    return false;
                }
                // Test if file exists
                else if (!File.Exists(filepath))
                {
                    terminal.Write(string.Format("Data File '{0}' does not exist", file));
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                terminal.Write(string.Format("Failed to check data: {0}\\{1}", folder, file));
                return false;
            }
        }
        private void Write()
        {
            string folderpath = basePath + @"\" + folder + @"\";
            string filepath = basePath + @"\" + folder + @"\" + file;
            try
            {
                // Make sure folder exists, if not, create one
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                    terminal.Write(string.Format("Data Folder created: {0}", folder));
                }
                // write to file
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        sw.WriteLine("{0} " +
                            "{1} {2:N3} {3:N3} {4} " +
                            "{5:N2} {6:N2} {7:N2} {8:N2} {9:N2} {10:N2} ",
                            data[i].id,

                            data[i].sParameter,
                            data[i].sourcePower,
                            data[i].ifBandwidth,
                            data[i].averagePoints,

                            data[i].horizontal,
                            data[i].vertical,
                            data[i].depth,
                            data[i].azimuth,
                            data[i].elevation,
                            data[i].polarization);

                        sw.WriteLine(string.Join(" ", data[i].frequency.Select(p => p.ToString()).ToArray()));
                        sw.WriteLine(string.Join(" ", data[i].real.Select(p => p.ToString()).ToArray()));
                        sw.WriteLine(string.Join(" ", data[i].imaginary.Select(p => p.ToString()).ToArray()));
                    }
                }
                terminal.Write(string.Format("Wrote data: {0}\\{1}", folder, file));
            }
            catch
            {
                terminal.Write(string.Format("Failed to write data: {0}\\{1}", folder, file));
            }
        }
        private void Read()
        {
            try
            {
                // check if directory exists, if not don't read
                if (Check() == true)
                {
                    // read file
                    string filepath = basePath + @"\" + folder + @"\" + file;
                    using (StreamReader sr = File.OpenText(filepath))
                    {
                        long id = 0;

                        double polarization = 0;
                        double vertical = 0;
                        double horizontal = 0;
                        double depth = 0;
                        double azimuth = 0;
                        double elevation = 0;

                        string sParameter = " ";
                        double sourcePower = 0;
                        double ifBandwidth = 0;
                        int averagePoints = 0;

                        double[] frequency = { 0 };
                        double[] real = { 0 };
                        double[] imaginary = { 0 };

                        int count = 0;
                        int index = 0;
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            index = count % 4;
                            if (index == 0)
                            {
                                string[] values = s.Split();
                                id = System.Convert.ToInt64(values[0]);

                                sParameter = values[1];
                                sourcePower = System.Convert.ToDouble(values[2]);
                                ifBandwidth = System.Convert.ToDouble(values[3]);
                                averagePoints = System.Convert.ToInt32(values[4]);

                                horizontal = (float)System.Convert.ToDouble(values[5]);
                                vertical = (float)System.Convert.ToDouble(values[6]);
                                depth = (float)System.Convert.ToDouble(values[7]);
                                azimuth = (float)System.Convert.ToDouble(values[8]);
                                elevation = (float)System.Convert.ToDouble(values[9]);
                                polarization = (float)System.Convert.ToDouble(values[10]);
                            }
                            if (index == 1)
                            {
                                string[] values = s.Split();
                                frequency = Array.ConvertAll(values, double.Parse);
                            }
                            if (index == 2)
                            {
                                string[] values = s.Split();
                                real = Array.ConvertAll(values, double.Parse);
                            }
                            if (index == 3)
                            {
                                string[] values = s.Split();
                                imaginary = Array.ConvertAll(values, double.Parse);
                                AddPoint(new Point(
                                    id,

                                    horizontal,
                                    vertical,
                                    depth,
                                    azimuth,
                                    elevation,
                                    polarization,

                                    sParameter,
                                    sourcePower,
                                    ifBandwidth,
                                    averagePoints,

                                    frequency,
                                    real,
                                    imaginary
                                ));
                            }
                            count++;
                        }
                    }
                    terminal.Write(string.Format("Read data: {0}", file));
                }
            }
            catch
            {
                terminal.Write(string.Format("Failed to read data: {0}\\{1}", folder, file));
            }
        }
        private void FindLatestID()
        {
            latestID = 0;
            foreach (Point point in data)
            {
                if (point.id > latestID) { latestID = point.id; }
            }
        }

        #region Event Functions
        public void SaveData(Callback callback)
        {
            Write();
            saved = true;
            callback.Call(true);
        }
        public void LoadData(Callback callback)
        {
            ClearDataset();
            ready = false;
            Read();
            ready = true;
            saved = true;
            FindLatestID();
            //foreach (PlottingForm plottingForm in mainForm.plottingForms)
            //{
            //    if (plottingForm != null && !plottingForm.Disposing && !plottingForm.IsDisposed)
            //    {
            //        plottingForm.RepopulateAllDataSelections();
            //        plottingForm.UpdateContinuously(data.Count - 1);
            //    }
            //}
            //if (mainForm.dataForm != null && !mainForm.dataForm.Disposing && !mainForm.dataForm.IsDisposed)
            //{
            //    mainForm.dataForm.RepopulateItems();
            //}
            callback.Call(true);
        }
        public void RemovePointAtIndex(int index, Callback callback)
        {
            if (index < data.Count)
            {
                data.RemoveAt(index);
                saved = false;
                foreach (PlottingForm plottingForm in mainForm.plottingForms)
                {
                    if (plottingForm != null && !plottingForm.Disposing && !plottingForm.IsDisposed)
                    {
                        plottingForm.RepopulateAllDataSelections();
                        plottingForm.UpdateContinuously(data.Count - 1);
                    }
                }
                if (mainForm.dataForm != null && !mainForm.dataForm.Disposing && !mainForm.dataForm.IsDisposed)
                {
                    mainForm.dataForm.RemoveItem(index);
                }
                terminal.Write(string.Format("Removed point at index {0}", index));
            }
            callback.Call(true);
        }
        public void RemovePointAtID(long pointID, Callback callback)
        {
            for (int index = 0; index < data.Count; index++)
            {
                if (data[index].id == pointID)
                {
                    data.RemoveAt(index);
                    saved = false;
                    //foreach (PlottingForm plottingForm in mainForm.plottingForms)
                    //{
                    //    if (plottingForm != null && !plottingForm.Disposing && !plottingForm.IsDisposed)
                    //    {
                    //        plottingForm.RepopulateAllDataSelections();
                    //        plottingForm.UpdateContinuously(data.Count - 1);
                    //    }
                    //}
                    //if (mainForm.dataForm != null && !mainForm.dataForm.Disposing && !mainForm.dataForm.IsDisposed)
                    //{
                    //    mainForm.dataForm.RemoveItem(index);
                    //}
                    terminal.Write(string.Format("Removed point at index {0}", index));
                }
            }
            callback.Call(true);
        }
        public void RemoveFirstPoint(Callback callback)
        {
            if (data.Count > 0)
            {
                data.RemoveAt(0);
                saved = false;
                //foreach (PlottingForm plottingForm in mainForm.plottingForms)
                //{
                //    if (plottingForm != null && !plottingForm.Disposing && !plottingForm.IsDisposed)
                //    {
                //        plottingForm.RepopulateAllDataSelections();
                //        plottingForm.UpdateContinuously(data.Count - 1);
                //    }
                //}
                //if (mainForm.dataForm != null && !mainForm.dataForm.Disposing && !mainForm.dataForm.IsDisposed)
                //{
                //    mainForm.dataForm.RemoveItem(0);
                //}
                terminal.Write(string.Format("Removed point at index {0}", 0));
            }
            callback.Call(true);
        }
        public void RemoveLastPoint(Callback callback)
        {
            if (data.Count > 0)
            {
                int index = data.Count - 1;
                data.RemoveAt(index);
                saved = false;
                //foreach (PlottingForm plottingForm in mainForm.plottingForms)
                //{
                //    if (plottingForm != null && !plottingForm.Disposing && !plottingForm.IsDisposed)
                //    {
                //        plottingForm.RepopulateAllDataSelections();
                //        plottingForm.UpdateContinuously(data.Count - 1);
                //    }
                //}
                //if (mainForm.dataForm != null && !mainForm.dataForm.Disposing && !mainForm.dataForm.IsDisposed)
                //{
                //    mainForm.dataForm.RemoveItem(index);
                //}
                terminal.Write(string.Format("Removed point at index {0}", index));
            }
            callback.Call(true);
        }
        public void ClearDataset(Callback callback)
        {
            data.Clear();
            saved = false;
            //foreach (PlottingForm plottingForm in mainForm.plottingForms)
            //{
            //    if (plottingForm != null && !plottingForm.Disposing && !plottingForm.IsDisposed)
            //    {
            //        plottingForm.ClearDataSelection();
            //    }
            //}
            //if (mainForm.dataForm != null && !mainForm.dataForm.Disposing && !mainForm.dataForm.IsDisposed)
            //{
            //    mainForm.dataForm.ClearItems();
            //}
            terminal.Write(string.Format("Data cleared. Set length: {0}", data.Count));
            callback.Call(true);
        }
        #endregion

        public void AddPoint()
        {
            latestID++;
            AddPoint(new Point(
                latestID,
                position.horizontal,
                position.vertical,
                position.depth,
                position.azimuth,
                position.elevation,
                position.polarization,
                instrument.sParameter,
                instrument.sourcePower,
                instrument.ifBandwidth,
                instrument.averagePoints,
                measurement.frequency,
                measurement.real,
                measurement.imaginary
            ));
        }
        public void AddPoint(Point point)
        {
            data.Add(point);
            saved = false;
            if (ready == true)
            {
                //foreach (PlottingForm plottingForm in mainForm.plottingForms)
                //{
                //    if (plottingForm != null && !plottingForm.Disposing && !plottingForm.IsDisposed)
                //    {
                //        plottingForm.AppendDataSelection(data.Count - 1);
                //        plottingForm.UpdateContinuously(data.Count - 1);
                //    }
                //}
                //if (mainForm.dataForm != null && !mainForm.dataForm.Disposing && !mainForm.dataForm.IsDisposed)
                //{
                //    mainForm.dataForm.AppendItem(data.Count - 1);
                //}
            }
            terminal.Write(string.Format("Data point added. Set length: {0}", data.Count));
        }


    }
}
