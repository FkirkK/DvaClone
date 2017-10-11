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
        public void RunLinearSvmReturnsSvmResult()
        {
            
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IAnalysisRunner ar = new AnalysisRunner(pr);

            //Act
            var linearSvmResult = ar.RunLinearSvm();

            //Assert 
            Assert.AreEqual(linearSvmResult.RatedDocuments.Count, 1600); // Where 1600 is the number of files read
        }
    }
}