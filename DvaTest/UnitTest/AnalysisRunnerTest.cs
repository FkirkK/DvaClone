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
            var linearSvmResult = (LinearSvmResult)ar.RunLinearSvm();

            //Assert 
            Assert.AreEqual(linearSvmResult.RatedDocuments.Count, 1600); // Where 1600 is the number of files read
        }
    }
}