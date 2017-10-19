using System;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;

namespace DvaPythonRunner
{
    public class PythonRunner : IPythonRunner
    {
        public string LinearSvmBigramPlus()
        {
            return (string)RunScript(FindScriptFolder(), "BigramPlus");
        }

        public string LinearSvmUnigram()
        {
            return (string)RunScript(FindScriptFolder(), "Unigram");
        }
        
        public string LinearSvmBigram()
        {
            return (string)RunScript(FindScriptFolder(), "Bigram");
        }

        public string LinearSvmTrigram()
        {
            return (string)RunScript(FindScriptFolder(), "Trigram");
        }

        public string LinearSvmTrigramPlus()
        {
            return (string)RunScript(FindScriptFolder(), "TrigramPlus");
        }

        private string FindScriptFolder()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var path = @"/DvaPythonScripts/OpinionSpamPackage/LinearSvm.py";
            var directoryName = Path.GetDirectoryName(currentDirectory);
            var fileName = Path.GetFileName(directoryName);

            while (fileName != "Dva")
            {
                directoryName = Path.GetDirectoryName(directoryName);
                fileName = Path.GetFileName(directoryName);
            }

            return directoryName + path;
        }

        /// <summary>
        /// Simply just runs a script in a specific path.
        /// </summary>
        /// <param name="programPath">Path for python script</param>
        /// <param name="input">Input parameters for the python script</param>
        /// <returns>String with python results</returns>
        public string RunGenericPythonScripts(string programPath, params object[] input)
        {
            return (string) RunScript(programPath, input);
        }

        // Based on example from MSDN: https://code.msdn.microsoft.com/windowsdesktop/C-and-Python-interprocess-171378ee
        private object RunScript(string programPath, params object[] input)
        {
            // full path of python interpreter
            string python = "";

            if (Environment.OSVersion.Platform == PlatformID.Unix)
                python = @"python3";
            else
                python = @"python";


            // Create new process start info 
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;

            // start python app with X arguments  
            // 1st arguments is pointer to itself
            string callString = programPath;

            foreach (var param in input)
            {
                callString += " " + param;
            }

            myProcessStartInfo.Arguments = callString;

            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;

            // start the process 
            myProcess.Start();

            // Read the standard output of the app we called.  
            // in order to avoid deadlock we will read output first 
            // and then wait for process terminate: 
            StreamReader myStreamReader = myProcess.StandardOutput;
            string myString = myStreamReader.ReadLine();

            /* if you need to read multiple lines, you might use: 
                string myString = myStreamReader.ReadToEnd() */

            // wait exit signal from the app we called and then close it. 
            myProcess.WaitForExit();
            myProcess.Close();

            return myString;
        }
    }
}
