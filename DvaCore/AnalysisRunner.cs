using DvaCore.Models;
using DvaPythonRunner;

namespace DvaCore
{
    public class AnalysisRunner : IAnalysisRunner
    {
        public AnalysisRunner(IPythonRunner pr)
        {
            _internalPythonRunner = pr;
        }
        
        private IPythonRunner _internalPythonRunner;

        public LinearSvmResult RunLinearSvm()
        {
            //TODO: Make LinearSvm python script write a result to a file. This file should be interpreted here.

            return new LinearSvmResult(1);
        }
    }
}