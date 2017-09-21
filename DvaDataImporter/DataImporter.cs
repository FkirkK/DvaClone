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
        public List<string> ImportData(string path)
        {
            List<string> textFromFiles = new List<string>();

            var txtFiles = Directory.EnumerateFiles(path, "*.txt");

            foreach (string file in txtFiles)
            {
                var text = File.ReadAllText(file);
                textFromFiles.Add(text);
            }

            return textFromFiles;
        }
    }
}
