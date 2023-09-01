using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATR
{
    public class DataManager
    {
        #region Classes
        MainForm mainForm;
        #endregion

        #region Data Parameters
        public List<Point> data;
        #endregion

        #region File IO
        public string dataFolder = "Data";
        public string dataFile = "data.dat";
        #endregion

        #region Flags
        bool ready = false;
        bool fileIOready = false;
        #endregion

        public DataManager(MainForm mainForm)
        {
            this.mainForm = mainForm;
            data = new List<Point>();
            ready = true;
            fileIOready = true;
        }

        public void CheckDataFolder()
        {
            string folderpath = mainForm.basePath + @"\" + dataFolder + @"\";
            // Test if path exists
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
                mainForm.WriteToOutput(string.Format("Data folder created: {0}", dataFolder));
            }
        }

        public void CheckDataFile()
        {
            string folderpath = mainForm.basePath + @"\" + dataFolder + @"\";
            string filepath = mainForm.basePath + @"\" + dataFolder + @"\" + dataFile;
            // Test if path exists
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
                mainForm.WriteToOutput(string.Format("Data folder created: {0}", dataFolder));
            }
            // Test if file exists
            if (!File.Exists(filepath))
            {
                mainForm.WriteToOutput(string.Format("Data file created: {0}", dataFile));
                WriteData();
            }
        }

        public void WriteData()
        {
            // Overwrite meta file (if exists) with new meta file containg program parameters
            string filepath = mainForm.basePath + @"\" + dataFolder + @"\" + dataFile;
            using (StreamWriter sw = File.CreateText(filepath))
            {
                for (int i = 0; i < data.Count; i++)
                {
                    sw.WriteLine("{0:N2} {1:N2} {2:N2} {3:N2} {4:N2} {5:N2} {6:N3} {7} {8}",
                                    data[i].polarization,
                                    data[i].vertical,
                                    data[i].horizontal,
                                    data[i].depth,
                                    data[i].azimuth,
                                    data[i].elevation,
                                    data[i].sourcePower,
                                    data[i].pointAvgQuantity,
                                    data[i].mode);
                    sw.WriteLine(string.Join(" ", data[i].frequency.Select(p => p.ToString()).ToArray()));
                    sw.WriteLine(string.Join(" ", data[i].real.Select(p => p.ToString()).ToArray()));
                    sw.WriteLine(string.Join(" ", data[i].imag.Select(p => p.ToString()).ToArray()));
                    sw.WriteLine(string.Join(" ", data[i].mag.Select(p => p.ToString()).ToArray()));
                    sw.WriteLine(string.Join(" ", data[i].phase.Select(p => p.ToString()).ToArray()));
                }
            }
            mainForm.WriteToOutput(string.Format("Wrote to data file: {0}", dataFile));
        }

        public void ReadData()
        {
            try
            {
                string filepath = mainForm.basePath + @"\" + dataFolder + @"\" + dataFile;
                using (StreamReader sr = File.OpenText(filepath))
                {
                    float polarization = 0;
                    float vertical = 0;
                    float horizontal = 0;
                    float depth = 0;
                    float azimuth = 0;
                    float elevation = 0;

                    string mode = " ";
                    double sourcePower = 0;
                    int pointAvgQuantity = 0;

                    double[] frequency = { 0 };
                    double[] real = { 0 };
                    double[] imag = { 0 };
                    double[] mag = { 0 };
                    double[] phase = { 0 };

                    int count = 0;
                    int index = 0;
                    string s;
                    while((s = sr.ReadLine()) != null)
                    {
                        index = count % 6;
                        if (index == 0)
                        {
                            string[] values = s.Split();
                            polarization = (float)System.Convert.ToDouble(values[0]);
                            vertical = (float)System.Convert.ToDouble(values[1]);
                            horizontal = (float)System.Convert.ToDouble(values[2]);
                            depth = (float)System.Convert.ToDouble(values[3]);
                            azimuth = (float)System.Convert.ToDouble(values[4]);
                            elevation = (float)System.Convert.ToDouble(values[5]);
                            sourcePower = System.Convert.ToDouble(values[6]);
                            pointAvgQuantity = System.Convert.ToInt32(values[7]);
                            mode = values[8];
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
                            imag = Array.ConvertAll(values, double.Parse);
                        }
                        if (index == 4)
                        {
                            string[] values = s.Split();
                            mag = Array.ConvertAll(values, double.Parse);
                        }
                        if (index == 5)
                        {
                            string[] values = s.Split();
                            phase = Array.ConvertAll(values, double.Parse);
                            AddPoint(new Point(
                                             polarization,
                                             vertical,
                                             horizontal,
                                             depth,
                                             azimuth,
                                             elevation,
                                             mode,
                                             sourcePower,
                                             pointAvgQuantity,
                                             frequency,
                                             real,
                                             imag,
                                             mag,
                                             phase
                                    ));
                        }
                        count++;
                    }
                }
                mainForm.WriteToOutput(string.Format("Read data in file: {0}", dataFile));
            }
            catch
            {
                mainForm.WriteToOutput(string.Format("Failed to read data file: {0}", dataFile));
            }
        }

        public void SaveData(string folder, string file)
        {
            if (fileIOready == true)
            {
                fileIOready = false;
                dataFolder = folder;
                dataFile = file;
                CheckDataFolder();
                WriteData(); // this writes over existing document OR writes new document if none exists yet
                fileIOready = true;
                mainForm.WriteToOutput(string.Format("Data saved to: {0}\\{1}", folder, file));
            }
            else
            {
                mainForm.WriteToOutput("Cannot save data at the moment");
            }
        }

        public void LoadData(string folder, string file)
        {
            if (fileIOready == true)
            {
                fileIOready = false;
                dataFolder = folder;
                dataFile = file;
                CheckDataFile();
                ClearDataset();
                ReadData();
                fileIOready = true;
                mainForm.WriteToOutput(string.Format("Data loaded from: {0}\\{1}", folder, file));
                mainForm.UpdateForContinuous(data.Count - 1);
            }
            else
            {
                mainForm.WriteToOutput("Cannot load data at the moment");
            }
        }

        public void AddPoint(Point point)
        {
            if (ready == true)
            {
                ready = false;
                data.Add(point);
                ready = true;
                mainForm.AppendDataSelection(data.Count - 1);
                if (fileIOready == true)
                {
                    mainForm.UpdateForContinuous(data.Count - 1);
                }
                mainForm.WriteToOutput(string.Format("Added Point to Dataset. Set length: {0}", data.Count));
            }
            else
            {
                mainForm.WriteToOutput("Not ready to append to dataset");
            }
        }

        public void RemoveLastPoint()
        {
            if (data.Count > 0)
            {
                if (ready == true)
                {
                    ready = false;
                    data.RemoveAt(data.Count - 1);
                    ready = true;
                    mainForm.RepopulateEntireDataSelection();
                    if (fileIOready == true)
                    {
                        mainForm.UpdateForContinuous(data.Count - 1);
                    }
                    mainForm.WriteToOutput(string.Format("Removed point at index {0}", data.Count));
                }
                else
                {
                    mainForm.WriteToOutput("Not ready to remove points");
                }
            }
        }

        public void ClearDataset()
        {
            if (ready == true)
            {
                ready = false;
                data.Clear();
                mainForm.ClearDataSelection();
                ready = true;
                mainForm.WriteToOutput(string.Format("Dataset Cleared. Set length: {0}", data.Count));
            }
            else
            {
                mainForm.WriteToOutput("Not ready to clear dataset");
            }
        }
    }
}
