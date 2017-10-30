using DvaAnalysis;
using DvaCore;
using DvaCore.Models;
using NUnit.Framework;

namespace DvaTest.UnitTest
{
    [TestFixture]
    public class AnalysisRunnerTest
    {

        [Test]
        public void RunLinearSvmBigramPlusReturnsCorrectSvmResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, BagOfWords.BigramPlus);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert 
            Assert.AreEqual(linearSvmResult.RatedDocuments.Count, 1600); // Where 1600 is the number of files read
            Assert.AreEqual(0.859, linearSvmResult.OverallPrecision, 0.001);
        }
    }
}