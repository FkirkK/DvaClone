using DvaAnalysis;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvaTest.UnitTest
{
    [TestFixture]
    class ClassificationExtensionTest
    {
        //Arrange
        [TestCase(Classification.AdaBoost, "AdaBoost with decision trees")]
        [TestCase(Classification.Bagging, "Bagging with decision trees")]
        [TestCase(Classification.DecisionTree, "Decision tree")]
        [TestCase(Classification.LinearSVC, "Linear SVC")]
        [TestCase(Classification.MultiLayerPerceptron, "Multilayer perceptron")]
        [TestCase(Classification.NaiveBayes, "Naive bayes")]
        [TestCase(Classification.NearestNeighbors, "Nearest neighbors")]
        [TestCase(Classification.SVCLinear, "SVC linear kernel")]
        [TestCase(Classification.SVCPolynomial, "SVC polynomial kernel")]
        [TestCase(Classification.SVCRbf, "SVC rbf kernel")]
        [TestCase(Classification.SVCSigmoid, "SVC sigmoid kernel")]
        public void CheckIfCorrectPrettify(Classification c, string expectedOutput)
        {
            //Act & assert
            Assert.AreEqual(expectedOutput, c.Prettify());
        }

        [Test]
        public void CheckIfNewCLassifierHasBeenIntroducedWithNoPrettifyMethod()
        {
            //Arrange
            var listOfClassifications = Enum.GetValues(typeof(Classification));

            //Act & assert
            foreach (var classification in listOfClassifications)
            {
                Assert.AreNotEqual("No pretty string for classifier", ((Classification)classification).Prettify());
            }
        }

        //Arrange
        [TestCase(Classification.AdaBoost, "AdaBoost with decision trees")]
        [TestCase(Classification.Bagging, "Bagging with decision trees")]
        [TestCase(Classification.DecisionTree, "Decision tree")]
        [TestCase(Classification.LinearSVC, "Linear SVC")]
        [TestCase(Classification.MultiLayerPerceptron, "Multilayer perceptron")]
        [TestCase(Classification.NaiveBayes, "Naive bayes")]
        [TestCase(Classification.NearestNeighbors, "Nearest neighbors")]
        [TestCase(Classification.SVCLinear, "SVC linear kernel")]
        [TestCase(Classification.SVCPolynomial, "SVC polynomial kernel")]
        [TestCase(Classification.SVCRbf, "SVC rbf kernel")]
        [TestCase(Classification.SVCSigmoid, "SVC sigmoid kernel")]
        public void CheckIfCorrectDeprettify(Classification expectedClassificer, string input)
        {
            //Act & assert
            Assert.AreEqual(expectedClassificer, ClassificationExtension.Deprettify(input));
        }

        [Test]
        public void CheckIfNewCLassifierHasBeenIntroducedWithNoDeprettifyMethod()
        {
            //Arrange
            var listOfClassifications = Enum.GetValues(typeof(Classification));

            //Act & assert
            foreach (var classification in listOfClassifications)
            {
                try
                {
                    ClassificationExtension.Deprettify(((Classification)classification).Prettify());
                }
                catch (ArgumentException)
                {
                    Assert.Fail("A Classification enum has no prettify or deprettify method");
                }
            }
        }
    }
}
