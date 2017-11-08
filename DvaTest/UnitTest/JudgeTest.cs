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
            actualResult = judge.judgeResult(new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0") );

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
            actualResult = judge.judgeResult(new ClassifierResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0"));

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
            actualResult = judge.judgeResults(new List<IResult>() { input1, input2, input3 });

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
