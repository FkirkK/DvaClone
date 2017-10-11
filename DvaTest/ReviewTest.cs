using System;
using System.Collections.Generic;
using System.Text;
using DvaCore.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DvaTest
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
