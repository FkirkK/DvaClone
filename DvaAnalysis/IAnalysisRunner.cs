using DvaCore;
using DvaCore.Models;
using System.Collections.Generic;

namespace DvaAnalysis
{
    public interface IAnalysisRunner
    {
        IResult RunAnalysis(AnalysisConfiguration config, IJudge judge);
        IResult RunAnalysis(List<AnalysisConfiguration> configs, IJudge judge);
    }
}