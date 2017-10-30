using DvaCore;
using DvaCore.Models;

namespace DvaAnalysis
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

        public IResult RunLinearSvmBigramPlus()
        {
            string analysisReturnString = _internalPythonRunner.LinearSvmBigramPlus();
            IResult judgedResult = _judge.judgeResults(new LinearSvmResult(analysisReturnString));
            
            return judgedResult;
        }

        public IResult RunLinearSvmUnigram()
        {
            string analysisReturnString = _internalPythonRunner.LinearSvmUnigram();
            IResult judgedResult = _judge.judgeResults(new LinearSvmResult(analysisReturnString));

            return judgedResult;
        }

        public IResult RunLinearSvmBigram()
        {
            string analysisReturnString = _internalPythonRunner.LinearSvmBigram();
            IResult judgedResult = _judge.judgeResults(new LinearSvmResult(analysisReturnString));

            return judgedResult;
        }

        public IResult RunLinearSvmTrigram()
        {
            string analysisReturnString = _internalPythonRunner.LinearSvmTrigram();
            IResult judgedResult = _judge.judgeResults(new LinearSvmResult(analysisReturnString));

            return judgedResult;
        }

        public IResult RunLinearSvmTrigramPlus()
        {
            string analysisReturnString = _internalPythonRunner.LinearSvmTrigramPlus();
            IResult judgedResult = _judge.judgeResults(new LinearSvmResult(analysisReturnString));

            return judgedResult;
        }
    }
}