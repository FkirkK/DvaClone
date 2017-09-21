using System;

namespace DvaDataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            DataImporter di = new DataImporter();
            var data = di.ImportData("../TestFiles/");
        }
    }
}
