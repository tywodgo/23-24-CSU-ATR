using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUATRv3
{
    public class FileManager
    {
        MainForm mainForm;
        Terminal terminal;
        public string basePath;
        public string folder;
        public string file;
        public char delimiter;

        public FileManager(MainForm mainForm, Terminal terminal, string folder, string file, char delimiter)
        {
            this.mainForm = mainForm;
            this.terminal = terminal;
            basePath = Directory.GetCurrentDirectory();
            this.folder = folder;
            this.file = file;
            this.delimiter = delimiter;
        }

        public void ChangeFolder(string folder)
        {
            this.folder = folder;
            mainForm.WriteMeta();
        }

        public void ChangeFile(string file)
        {
            this.file = file;
            mainForm.WriteMeta();
        }

        public bool Check()
        {
            string folderpath = basePath + @"\" + folder + @"\";
            string filepath = basePath + @"\" + folder + @"\" + file;
            try
            {
                // Test if path exists
                if (!Directory.Exists(folderpath))
                {
                    terminal.Write(string.Format("Folder '{0}' does not exist", folder));
                    return false;
                }
                // Test if file exists
                else if (!File.Exists(filepath))
                {
                    terminal.Write(string.Format("File '{0}' does not exist", file));
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                terminal.Write(string.Format("Failed to check: {0}\\{1}", folder, file));
                return false;
            }
        }

        public List<string[]> Read()
        {
            // list items will assume the form in a file like:
            //{itemName}{delimeter}{space}{variableValue}
            // Example:
            //Polarization Angle: 270
            List<string[]> lines = new List<string[]>();
            try
            {
                // check if directory exists, if not don't read
                if (Check() == true)
                {
                    // read file
                    string filepath = basePath + @"\" + folder + @"\" + file;
                    using (StreamReader sr = File.OpenText(filepath))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            // get both identifier and value separated by delimiter
                            string[] line = s.Split(new[] { delimiter }, 2);
                            line[1] = line[1].Replace(" ", "");
                            lines.Add(line);
                        }
                    }
                    terminal.Write(string.Format("Read: {0}\\{1}", folder, file));
                }
            }
            catch
            {
                terminal.Write(string.Format("Failed to read: {0}\\{1}", folder, file));
            }
            return lines;
        }

        public void Write(List<object[]> lines)
        {
            string folderpath = basePath + @"\" + folder + @"\";
            string filepath = basePath + @"\" + folder + @"\" + file;
            try
            {
                // Make sure folder exists, if not, create one
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                    terminal.Write(string.Format("Folder created: {0}", folder));
                }
                // write to file
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    for (int i = 0; i < lines.Count; i++)
                    {
                        // write identifier, delimiter, space, and then value
                        sw.WriteLine(string.Format("{0}{1} {2}", lines[i][0], delimiter, lines[i][1]));
                    }
                }
                terminal.Write(string.Format("Wrote: {0}\\{1}", folder, file));
            }
            catch
            {
                terminal.Write(string.Format("Failed to write: {0}\\{1}", folder, file));
            }

        }
    }
}
