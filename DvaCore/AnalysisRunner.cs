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
            var result = _internalPythonRunner.LinearSvm();
            
            return new LinearSvmResult(result);
        }
    }
}