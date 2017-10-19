using DvaCore;
using DvaCore.Models;
using DvaPythonRunner;
using NUnit.Framework;

namespace DvaTest.UnitTest
{
    [TestFixture]
    public class AnalysisRunnerTest
    {
        [Test]
        public void RunLinearSvmReturnsSvmResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunLinearSvmBigramPlus();

            //Assert 
            Assert.AreEqual(linearSvmResult.RatedDocuments.Count, 1600); // Where 1600 is the number of files read
            Assert.AreEqual(linearSvmResult.OverallPrecision, 0.859, 0.001);
        }

        [Test]
        public void RunLinearSvmSelectingUnigram()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunLinearSvmUnigram();

            //Assert
            Assert.AreEqual(linearSvmResult.OverallPrecision, 0.840, 0.001);
        }
    }
}