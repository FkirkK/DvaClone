using DvaAnalysis.Committees;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvaTest.UnitTest
{
    [TestFixture]
    public class CommitteeExtensionTest
    {
        //Arrange
        [TestCase(Committee.MajorityCommittee, "Majority committee")]
        [TestCase(Committee.WeightedCommittee, "Weighted committee")]
        public void CheckIfCorrectPrettyStringIsReturned(Committee c, string expectedOutput)
        {
            //Act & assert
            Assert.AreEqual(expectedOutput, c.Prettify());
        }

        [Test]
        public void CheckIfNewCommitteeHasBeenIntroducedWithNoPrettifyMethod()
        {
            //Arrange
            var listOfCommittees = Enum.GetValues(typeof(Committee));

            //Act & assert
            foreach (var committee in listOfCommittees)
            {
                Assert.AreNotEqual("No pretty string for committee", ((Committee)committee).Prettify());
            }
        }

        //Arrange
        [TestCase(Committee.MajorityCommittee, "Majority committee")]
        [TestCase(Committee.WeightedCommittee, "Weighted committee")]
        public void CheckIfCorrectDeprettifyCommittee(Committee expectedCommittee, string input)
        {
            //Act & assert
            Assert.AreEqual(expectedCommittee, CommitteeExtension.Deprettify(input));
        }

        [Test]
        public void CheckIfNewCommitteeHasBeenIntroducedWithNoDeprettifyMethod()
        {
            //Arrange
            var listOfCommittees = Enum.GetValues(typeof(Committee));

            //Act & assert
            foreach (var committee in listOfCommittees)
            {
                try
                {
                    CommitteeExtension.Deprettify(((Committee)committee).Prettify());
                }
                catch (ArgumentException)
                {
                    Assert.Fail("A Committee enum has no prettify or deprettify method");
                }
            }
        }
    }
}
