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
        [TestCase(Classification.LinearSVC, BagOfWords.Bigram)]
        [TestCase(Classification.SVCLinear, BagOfWords.BigramPlus)]
        [TestCase(Classification.SVCPolynomial, BagOfWords.Trigram)]
        [TestCase(Classification.SVCRbf, BagOfWords.TrigramPlus)]
        [TestCase(Classification.SVCSigmoid, BagOfWords.Unigram)]
        public void CanSetConfiguration(Classification clas, BagOfWords bow)
        {
            //Arrange
            PythonConfiguration pc = new PythonConfiguration(clas, bow);

            //Act

            //Assert
            Assert.AreEqual(clas, pc.Classification);
            Assert.AreEqual(bow, pc.BagOfWords);
        }
    }
}
