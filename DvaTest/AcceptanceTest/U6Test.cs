using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DvaAnalysis;
using DvaAnalysis.Committees;
using DvaAnalysis.Models;

namespace DvaTest.AcceptanceTest
{
    [TestFixture]
    class U6Test
    {        
        /* 1
         * This is an acceptance test for running unigram with a linear svc classifier
         */
        [Test]
        public void RunLinearSvmUnigramReturnsCorrectSvmResult()
        {
            //Arrange
            ICommittee j = new MajorityCommittee();
            IAnalysisRunner ar = new AnalysisRunner();
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert
            Assert.AreEqual(0.840, linearSvmResult.Accuracy, 0.001);
        }

        /* 2
        * This is an acceptance test for running bigram with a linear svc classifier
        */
        [Test]
        public void RunLinearSvmBigramReturnsCorrectSvmResult()
        {
            //Arrange
            ICommittee j = new MajorityCommittee();
            IAnalysisRunner ar = new AnalysisRunner();
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, FeatureSet.Bigram);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert
            Assert.AreEqual(0.829, linearSvmResult.Accuracy, 0.001);
        }

        /* 3
        * This is an acceptance test for running trigram with a linear svc classifier
        */
        [Test]
        public void RunLinearSvmTrigramReturnsCorrectSvmResult()
        {
            //Arrange
            ICommittee j = new MajorityCommittee();
            IAnalysisRunner ar = new AnalysisRunner();
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, FeatureSet.Trigram);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert
            Assert.AreEqual(0.783, linearSvmResult.Accuracy, 0.001);
        }

        /* 4
        * This is an acceptance test for running trigramplus with a linear svc classifier
        */
        [Test]
        public void RunLinearSvmTrigramPlusReturnsCorrectSvmResult()
        {
            //Arrange
            ICommittee j = new MajorityCommittee();
            IAnalysisRunner ar = new AnalysisRunner();
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, FeatureSet.TrigramPlus);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert
            Assert.AreEqual(0.861, linearSvmResult.Accuracy, 0.001);
        }
    }
}
