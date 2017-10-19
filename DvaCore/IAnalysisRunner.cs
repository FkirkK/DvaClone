using DvaCore.Models;
using DvaPythonRunner;

namespace DvaCore
{
    public interface IAnalysisRunner
    {
        /// <summary>
        /// Call the LinearSvmScript and interpret the results.
        /// </summary>
        /// <returns>IResult</returns>
        IResult RunLinearSvmBigramPlus();
        IResult RunLinearSvmUnigram();
    }
}