using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DvaDataImporter
{
    public class DataImporter
    {
        public DataImporter()
        {
            
        }

        // Imports all files from folder
        public Dictionary<string, string> ImportData(string path)
        {
            Dictionary<string, string> textFromFiles = new Dictionary<string, string>();

            var txtFiles = Directory.EnumerateFiles(path, "*.txt");

            foreach (string file in txtFiles)
            {
                var text = File.ReadAllText(file);
                textFromFiles.Add(Path.GetFileNameWithoutExtension(file), text);
            }

            return textFromFiles;
        }
    }
}
