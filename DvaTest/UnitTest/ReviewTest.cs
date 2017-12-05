using System;
using DvaAnalysis.Models;
using NUnit.Framework;

namespace DvaTest.UnitTest
{
    [TestFixture]
    class ReviewTest {

        [Test]
        public void ToStringCorrectFormat()
        {
            //Arrange: 
            Review review = new Review("Hello this should be equal.", "Title", true, true);
            String returnString = "";

            //Act
            returnString = review.ToString();
            
            //Assert:
            Assert.AreEqual("Hello this should be equal.", returnString);
        }
        
    }
}
