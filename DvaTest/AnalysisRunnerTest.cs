using DvaCore;
using DvaCore.Models;
using DvaPythonRunner;
using NUnit.Framework;

namespace DvaTest
{
    [TestFixture]
    public class AnalysisRunnerTest
    {
        [Test]
        public void RunLinearSvmReturnsCorrectLinearSvmResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IAnalysisRunner ar = new AnalysisRunner(pr);

            //Act
            var linearSvmResult = ar.RunLinearSvm();

            //Assert 
            Assert.AreEqual(linearSvmResult, new LinearSvmResult(1));
        }
    }
}