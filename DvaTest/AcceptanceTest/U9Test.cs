using System;
using System.Collections.Generic;
using System.Text;
using DvaAnalysis;
using DvaCore;
using DvaCore.Models;
using NUnit.Framework;

namespace DvaTest.AcceptanceTest
{
    [TestFixture]
    class U9Test
    {
        /* 1
         * This is an acceptance test for running Unigram with a Linear svc classifier
         */
        [Test]
        public void RunUnigramWithLinearSVCReturnsCorrectResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert
            Assert.AreEqual(0.840, linearSvmResult.OverallPrecision, 0.001);
        }

        /* 2
         * This is an acceptance test for running Unigram with a DecisionTree classifier
         */
        [Test]
        public void RunUnigramWithDecisionTreeClassifierReturnsCorrectResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.DecisionTree, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert
            Assert.AreEqual(0.669, linearSvmResult.OverallPrecision, 0.001);
        }

        /* 3
         * This is an acceptance test for running Unigram with a SVCLinear classifier
         */
        [Test]
        public void RunUnigramWithSVCLinearReturnsCorrectResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.SVCLinear, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert
            Assert.AreEqual(0.838, linearSvmResult.OverallPrecision, 0.001);
        }

        /* 4
         * This is an acceptance test for running Unigram with a SVCPolynomial classifier
         */
        [Test]
        public void RunUnigramWithSVCPolynomialReturnsCorrectResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.SVCPolynomial, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert
            Assert.AreEqual(0.501, linearSvmResult.OverallPrecision, 0.001);
        }

        /* 5
         * This is an acceptance test for running Unigram with a SVCRbf classifier
         */
        [Test]
        public void RunUnigramWithSVCRbfReturnsCorrectResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.SVCRbf, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert
            Assert.AreEqual(0.754, linearSvmResult.OverallPrecision, 0.001);
        }

        /* 6
         * This is an acceptance test for running Unigram with a SVCSigmoid classifier
         */
        [Test]
        public void RunUnigramWithSVCSigmoidReturnsCorrectResult()
        {
            //Arrange
            IPythonRunner pr = new PythonRunner();
            IJudge j = new Judge();
            IAnalysisRunner ar = new AnalysisRunner(pr, j);
            PythonConfiguration config = new PythonConfiguration(Classification.SVCSigmoid, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (LinearSvmResult)ar.RunAnalysis(config);

            //Assert
            Assert.AreEqual(0.757, linearSvmResult.OverallPrecision, 0.001);
        }
    }
}
