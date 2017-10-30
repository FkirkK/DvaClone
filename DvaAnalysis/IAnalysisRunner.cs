using DvaCore.Models;

namespace DvaAnalysis
{
    public interface IAnalysisRunner
    {
        IResult RunAnalysis(AnalysisConfiguration config);
    }
}