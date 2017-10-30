﻿using DvaAnalysis;
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