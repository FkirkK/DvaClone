using DvaAnalysis.Models;
using System.Collections.Generic;
using DvaAnalysis.Committees;

namespace DvaAnalysis
{
    public interface IAnalysisRunner
    {
        IResult RunAnalysis(AnalysisConfiguration config, ICommittee committee);
        IResult RunAnalysis(List<AnalysisConfiguration> configs, ICommittee committee);
    }
}