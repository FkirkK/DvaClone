using DvaAnalysis.Models;
using System;
using System.Collections.Generic;
using DvaAnalysis.Committees;

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

        public IResult RunAnalysis(AnalysisConfiguration config, ICommittee committee)
        {
            string analysisReturnString = RunConfiguration(config);

            if (analysisReturnString == null)
                throw new Exception("The analysis result was null");

            IResult result = committee.ClassifyResult(new ClassifierResult(analysisReturnString));
            return result;
        }

        public IResult RunAnalysis(List<AnalysisConfiguration> configs, ICommittee committee)
        {
            List<IResult> resultList = new List<IResult>();
            foreach (var config in configs)
            {
                string analysisReturnString = RunConfiguration(config);

                if (analysisReturnString == null)
                    throw new Exception("The analysis result was null");

                resultList.Add(new ClassifierResult(analysisReturnString));
            }
            

            IResult result = committee.ClassifyResults(resultList);
            return result;
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