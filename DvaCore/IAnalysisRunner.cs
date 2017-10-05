using DvaCore.Models;
using DvaPythonRunner;

namespace DvaCore
{
    public interface IAnalysisRunner
    {
        LinearSvmResult RunLinearSvm();
    }
}