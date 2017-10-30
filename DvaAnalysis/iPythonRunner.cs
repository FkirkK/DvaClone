namespace DvaAnalysis
{
    public interface IPythonRunner
    {
        /// <summary>
        /// Call the linear svm script. 
        /// </summary>
        /// <returns>String with linear svm result (should be correctly formatted)</returns>
        string LinearSvmBigramPlus();
        string LinearSvmUnigram();
        string LinearSvmBigram();
        string LinearSvmTrigram();
        string LinearSvmTrigramPlus();
        string RunAnalysis(Classification classType);
    }
}