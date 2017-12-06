using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using DvaAnalysis.Committees;
using DvaAnalysis.Models;

namespace DvaTest.UnitTest
{
    [TestFixture]
    public class CommitteeTest
    {
        [Test]
        public void CheckIfSameObjectIsReturnedMajorityCommittee()
        {
            //Arrange
            IResult expectedResult = new ClassifierResult("10, 20, 10, 30");
            IResult actualResult;
            ICommittee committee = new MajorityCommittee();

            //Act
            actualResult = committee.ClassifyResult(new ClassifierResult("10, 20, 10, 30") );

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfSingleCorrectResultIsReturnedMajorityCommittee()
        {
            //Arrange
            IResult expectedResult = new ClassifierResult("1, 0, 0, 0, 0, 1, 1");
            IResult actualResult;
            IResult input1 = new ClassifierResult("1, 0, 0, 0, 0, 1, 1");
            IResult input2 = new ClassifierResult("0, 0, 0, 1, 0, 1, 0");
            IResult input3 = new ClassifierResult("1, 0, 0, 0, 0, 1, 1");
            ICommittee committee = new MajorityCommittee();

            //Act
            actualResult = committee.ClassifyResults(new List<IResult>() { input1, input2, input3 });

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfSameObjectIsReturnedWeightedCommittee()
        {
            //Arrange
            IResult expectedResult = new ClassifierResult("1, 0, 0, 0, 0, 1, 1");
            IResult actualResult;
            ICommittee committee = new WeightedCommittee(new List<double>() {1.0});

            //Act
            actualResult = committee.ClassifyResult(new ClassifierResult("1, 0, 0, 0, 0, 1, 1"));

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("1, 0, 0, 0, 0, 1, 1", 3.0, 2.0)]
        [TestCase("0, 0, 0, 1, 0, 1, 0", 2.0, 3.0)]
        [TestCase("0, 0, 0, 1, 0, 1, 0", 5.0, 5.0)]
        public void CheckIfExpectedObjectIsReturnedWeightedCommittee(string inputString, double weight1, double weight2)
        {
            // Arrange
            IResult expectedResult = new ClassifierResult(inputString);
            IResult actualResult;
            IResult input1 = new ClassifierResult("1, 0, 0, 0, 0, 1, 1");
            IResult input2 = new ClassifierResult("0, 1, 0, 0, 0, 1, 0");

            ICommittee committee = new WeightedCommittee(new List<double>() {weight1, weight2});

            //Act
            actualResult = committee.ClassifyResults(new List<IResult>() { input1, input2 });

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfExpectedObjectIsReturnedWeightedCommitteeAdvanced()
        {
            // Arrange
            IResult expectedResult = new ClassifierResult("0, 0, 0, 1, 0, 1, 0");
            IResult actualResult;
            IResult input1 = new ClassifierResult("1, 0, 0, 0, 0, 1, 1");
            IResult input2 = new ClassifierResult("0, 0, 0, 1, 0, 1, 0");
            IResult input3 = new ClassifierResult("0, 0, 0, 1, 0, 1, 0");
            IResult input4 = new ClassifierResult("1, 0, 0, 0, 0, 1, 1");
            IResult input5 = new ClassifierResult("0, 0, 0, 1, 0, 1, 0");

            ICommittee committee = new WeightedCommittee(new List<double>() { 2.0, 3.0, 5.0, 1.5, 2.5 });

            //Act
            actualResult = committee.ClassifyResults(new List<IResult>() { input1, input2, input3, input4, input5 });

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
