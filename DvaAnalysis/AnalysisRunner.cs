using DvaCore;
using DvaCore.Models;
using System;

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

        public IResult RunAnalysis(AnalysisConfiguration config)
        {
            string analysisReturnString = RunConfiguration(config);

            if(analysisReturnString == null)
                throw new Exception("The analysis result was null");

            IResult judgedResult = _judge.judgeResults(new LinearSvmResult(analysisReturnString));
            return judgedResult;
        }

        private string RunConfiguration(AnalysisConfiguration config)
        {
            switch (config.ConfigurationType)
            {
                case ConfigurationType.PythonRunner:
                    return RunPythonRunner(config);
                default:
                    throw new ArgumentException("Unknown configuration type.");
            }
        }

        private string RunPythonRunner(AnalysisConfiguration config)
        {
            return _internalPythonRunner.RunAnalysis((PythonConfiguration)config);
        }
    }
}