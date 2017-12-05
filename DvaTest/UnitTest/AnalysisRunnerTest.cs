using DvaAnalysis;
using NUnit.Framework;
using System.Collections.Generic;
using DvaAnalysis.Committees;
using DvaAnalysis.Models;

namespace DvaTest.UnitTest
{
    [TestFixture]
    public class AnalysisRunnerTest
    {

        [Test]
        public void RunLinearSvmBigramPlusReturnsCorrectSvmResult()
        {
            //Arrange
            ICommittee j = new MajorityCommittee();
            IAnalysisRunner ar = new AnalysisRunner();
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, FeatureSet.BigramPlus);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert 
            Assert.AreEqual(linearSvmResult.RatedDocuments.Count, 1600); // Where 1600 is the number of files read
            Assert.AreEqual(0.859, linearSvmResult.OverallPrecision, 0.001);
        }

        [Test]
        public void Run3LinearSvmsInSequence()
        {
            //Arrange
            ICommittee j = new MajorityCommittee();
            IAnalysisRunner ar = new AnalysisRunner();
            PythonConfiguration config1 = new PythonConfiguration(Classification.LinearSVC, FeatureSet.Unigram);
            PythonConfiguration config2 = new PythonConfiguration(Classification.LinearSVC, FeatureSet.BigramPlus);
            PythonConfiguration config3 = new PythonConfiguration(Classification.LinearSVC, FeatureSet.BigramPlus);

            //Act
            var result = (ClassifierResult)ar.RunAnalysis(new List<AnalysisConfiguration>() { config1, config2, config3 }, j);

            //Assert
            Assert.AreEqual(0.859, result.OverallPrecision, 0.001);
        }


    }
}