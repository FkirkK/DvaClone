using DvaCore.Models;
using DvaPythonRunner;

namespace DvaCore
{
    public class AnalysisRunner : IAnalysisRunner
    {
        /// <summary>
        /// Constructor for the AnalysisRunner class
        /// </summary>
        /// <param name="pr">Pythonrunner which calls the relevant scripts.</param>
        public AnalysisRunner(IPythonRunner pr)
        {
            _internalPythonRunner = pr;
        }
        
        private readonly IPythonRunner _internalPythonRunner;

        public LinearSvmResult RunLinearSvm()
        {
            var result = _internalPythonRunner.LinearSvm();
            
            return new LinearSvmResult(result);
        }
    }
}