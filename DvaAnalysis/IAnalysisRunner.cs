using DvaCore.Models;

namespace DvaAnalysis
{
    public interface IAnalysisRunner
    {
        /// <summary>
        /// Call the LinearSvmScript and interpret the results.
        /// </summary>
        /// <returns>IResult</returns>
        IResult RunLinearSvmBigramPlus();
        IResult RunLinearSvmUnigram();
        IResult RunLinearSvmBigram();
        IResult RunLinearSvmTrigram();
        IResult RunLinearSvmTrigramPlus();
    }
}