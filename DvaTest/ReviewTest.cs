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
            
            //Assert:
            Assert.AreEqual("Hello this should be equal.", review.ToString());
        }
        
    }
}
