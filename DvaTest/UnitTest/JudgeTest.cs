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
        public void CheckIfSameObjectIsReturned()
        {
            //Arrange
            IResult expectedResult = new LinearSvmResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0");
            IResult actualResult;
            IJudge judge = new Judge();

            //Act
            actualResult = judge.judgeResults(new LinearSvmResult("0, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0"));

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
