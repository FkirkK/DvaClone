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
        /// <param name="judge">Judge which judges a result.</param>
        public AnalysisRunner(IPythonRunner pr, IJudge judge)
        {
            _internalPythonRunner = pr;
            _judge = judge;
        }
        
        private readonly IPythonRunner _internalPythonRunner;
        private readonly IJudge _judge;

        public IResult RunLinearSvm()
        {
            string analysisReturnString = _internalPythonRunner.LinearSvm();
            IResult judgedResult = _judge.judgeResults(new LinearSvmResult(analysisReturnString));
            
            return judgedResult;
        }
    }
}