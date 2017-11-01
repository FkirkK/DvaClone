using DvaAnalysis;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvaTest.UnitTest
{
    [TestFixture]
    class PythonConfigurationTest
    {
        [TestCase(Classification.LinearSVC, FeatureSet.Bigram)]
        [TestCase(Classification.SVCLinear, FeatureSet.BigramPlus)]
        [TestCase(Classification.SVCPolynomial, FeatureSet.Trigram)]
        [TestCase(Classification.SVCRbf, FeatureSet.TrigramPlus)]
        [TestCase(Classification.SVCSigmoid, FeatureSet.Unigram)]
        [TestCase(Classification.DecisionTree, FeatureSet.Unigram)]
        public void CanSetConfiguration(Classification clas, FeatureSet bow)
        {
            //Arrange
            PythonConfiguration pc = new PythonConfiguration(clas, bow);

            //Act

            //Assert
            Assert.AreEqual(clas, pc.Classification);
            Assert.AreEqual(bow, pc.FeatureSet);
        }
    }
}
