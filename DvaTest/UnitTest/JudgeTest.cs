using DvaCore;
using DvaCore.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvaTest.UnitTest
{
    [TestFixture]
    public class JudgeTest
    {
        [Test]
        public void CheckIfSameObjectIsReturnedDummyJudge()
        {
            //Arrange
            IResult expectedResult = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0");
            IResult actualResult;
            IJudge judge = new Judge();

            //Act
            actualResult = judge.JudgeResult(new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0") );

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfSameObjectIsReturnedMajorityJudge()
        {
            //Arrange
            IResult expectedResult = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0");
            IResult actualResult;
            IJudge judge = new MajorityJudge();

            //Act
            actualResult = judge.JudgeResult(new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0"));

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfSingleResultIsReturnedMajorityJudge()
        {
            //Arrange
            IResult expectedResult = new ClassifierResult("1.0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1");
            IResult actualResult;
            IResult input1 = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1");
            IResult input2 = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0");
            IResult input3 = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1");
            IJudge judge = new MajorityJudge();

            //Act
            actualResult = judge.JudgeResults(new List<IResult>() { input1, input2, input3 });

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfSameObjectIsReturnedWeightedJudge()
        {
            //Arrange
            IResult expectedResult = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0");
            IResult actualResult;
            IJudge judge = new WeightedJudge(new List<double>() {1.0});

            //Act
            actualResult = judge.JudgeResult(new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0"));

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("1.0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1", 3.0, 2.0)]
        [TestCase("0.0, 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1 , 0", 2.0, 3.0)]
        [TestCase("0.0, 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1 , 0", 5.0, 5.0)]
        public void CheckIfExpectedObjectIsReturnedWeightedJudge(string inputString, double weight1, double weight2)
        {
            // Arrange
            IResult expectedResult = new ClassifierResult(inputString);
            IResult actualResult;
            IResult input1 = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1");
            IResult input2 = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0");

            IJudge judge = new WeightedJudge(new List<double>() {weight1, weight2});

            //Act
            actualResult = judge.JudgeResults(new List<IResult>() { input1, input2 });

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfExpectedObjectIsReturnedWeightedJudgeAdvanced()
        {
            // Arrange
            IResult expectedResult = new ClassifierResult("0.0, 0 , 0 , 0 , 0 , 0 , 1 , 0 , 0 , 0 , 1 , 0");
            IResult actualResult;
            IResult input1 = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1");
            IResult input2 = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0");
            IResult input3 = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0");
            IResult input4 = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 1");
            IResult input5 = new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 1 , 0");

            IJudge judge = new WeightedJudge(new List<double>() { 2.0, 3.0, 5.0, 1.5, 2.5 });

            //Act
            actualResult = judge.JudgeResults(new List<IResult>() { input1, input2, input3, input4, input5 });

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
