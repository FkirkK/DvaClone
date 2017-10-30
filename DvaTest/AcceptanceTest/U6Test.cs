using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DvaAnalysis;
using DvaCore;
using DvaCore.Models;

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
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, BagOfWords.Unigram);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert
            Assert.AreEqual(0.840, linearSvmResult.OverallPrecision, 0.001);
        }

        /* 2
        * This is an acceptance test for running bigram with a linear svc classifier
        */
        [Test]
        public void RunLinearSvmBigramReturnsCorrectSvmResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, BagOfWords.Bigram);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert
            Assert.AreEqual(0.828, linearSvmResult.OverallPrecision, 0.001);
        }

        /* 3
        * This is an acceptance test for running trigram with a linear svc classifier
        */
        [Test]
        public void RunLinearSvmTrigramReturnsCorrectSvmResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, BagOfWords.Trigram);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert
            Assert.AreEqual(0.782, linearSvmResult.OverallPrecision, 0.001);
        }

        /* 6
        * This is an acceptance test for running trigramplus with a linear svc classifier
        */
        [Test]
        public void RunLinearSvmTrigramPlusReturnsCorrectSvmResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, BagOfWords.TrigramPlus);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert
            Assert.AreEqual(0.861, linearSvmResult.OverallPrecision, 0.001);
        }
    }
}
