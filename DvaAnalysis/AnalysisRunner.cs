using DvaCore;
using DvaCore.Models;
using System;
using System.Collections.Generic;

namespace DvaAnalysis
{
    public class AnalysisRunner : IAnalysisRunner
    {
        /// <summary>
        /// Constructor for the AnalysisRunner class
        /// </summary>
        public AnalysisRunner()
        {
            
        }

        public IResult RunAnalysis(AnalysisConfiguration config, IJudge judge)
        {
            string analysisReturnString = RunConfiguration(config);

            if (analysisReturnString == null)
                throw new Exception("The analysis result was null");

            
            IResult judgedResult = judge.JudgeResult(new ClassifierResult(analysisReturnString));
            return judgedResult;
        }

        public IResult RunAnalysis(List<AnalysisConfiguration> configs, IJudge judge)
        {
            List<IResult> resultList = new List<IResult>();
            foreach (var config in configs)
            {
                string analysisReturnString = RunConfiguration(config);

                if (analysisReturnString == null)
                    throw new Exception("The analysis result was null");

                resultList.Add(new ClassifierResult(analysisReturnString));
            }
            

            IResult judgedResult = judge.JudgeResults(resultList);
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
            return new PythonRunner().RunAnalysis((PythonConfiguration)config);
        }
    }
}