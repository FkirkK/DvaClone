﻿using System;
using System.Collections.Generic;
using System.Text;
using DvaAnalysis;
using DvaAnalysis.Committees;
using DvaAnalysis.Models;
using NUnit.Framework;

namespace DvaTest.AcceptanceTest
{
    [TestFixture]
    class U9Test
    {

        public ICommittee j { get; set; }
        public IAnalysisRunner ar { get; set; }

        [SetUp]
        public void SetUp()
        {
            j = new MajorityCommittee();
            ar = new AnalysisRunner();
        }

        /* 1
         * This is an acceptance test for running Unigram with a Linear svc classifier
         */
        [Test]
        public void RunUnigramWithLinearSVCReturnsCorrectResult()
        {
            //Arrange
            PythonConfiguration config = new PythonConfiguration(Classification.LinearSVC, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert
            Assert.AreEqual(0.840, linearSvmResult.Accuracy, 0.001);
        }

        /* 2
         * This is an acceptance test for running Unigram with a DecisionTree classifier
         */
        [Test]
        public void RunUnigramWithDecisionTreeClassifierReturnsCorrectResult()
        {
            //Arrange
            PythonConfiguration config = new PythonConfiguration(Classification.DecisionTree, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert
            Assert.AreEqual(0.669, linearSvmResult.Accuracy, 0.1);
        }

        /* 3
         * This is an acceptance test for running Unigram with a SVCLinear classifier
         */
        [Test]
        public void RunUnigramWithSVCLinearReturnsCorrectResult()
        {
            //Arrange
            PythonConfiguration config = new PythonConfiguration(Classification.SVCLinear, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert
            Assert.AreEqual(0.838, linearSvmResult.Accuracy, 0.001);
        }

        /* 4
         * This is an acceptance test for running Unigram with a SVCPolynomial classifier
         */
        [Test]
        public void RunUnigramWithSVCPolynomialReturnsCorrectResult()
        {
            //Arrange
            PythonConfiguration config = new PythonConfiguration(Classification.SVCPolynomial, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert
            Assert.AreEqual(0.501, linearSvmResult.Accuracy, 0.001);
        }

        /* 5
         * This is an acceptance test for running Unigram with a SVCRbf classifier
         */
        [Test]
        public void RunUnigramWithSVCRbfReturnsCorrectResult()
        {
            //Arrange
            PythonConfiguration config = new PythonConfiguration(Classification.SVCRbf, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert
            Assert.AreEqual(0.754, linearSvmResult.Accuracy, 0.001);
        }

        /* 6
         * This is an acceptance test for running Unigram with a SVCSigmoid classifier
         */
        [Test]
        public void RunUnigramWithSVCSigmoidReturnsCorrectResult()
        {
            //Arrange
            PythonConfiguration config = new PythonConfiguration(Classification.SVCSigmoid, FeatureSet.Unigram);

            //Act
            var linearSvmResult = (ClassifierResult)ar.RunAnalysis(config, j);

            //Assert
            Assert.AreEqual(0.757, linearSvmResult.Accuracy, 0.001);
        }
    }
}
