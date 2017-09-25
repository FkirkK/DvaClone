using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DvaDataImporter;
using NUnit.Framework;

namespace DvaTesting
{
    [TestFixture]
    class DataImporterTest
    {
        [Test]
        public void ShouldImportFilesAtPathCorrectly()
        {
            //Arrange
            DataImporter di = new DataImporter();

            //Act
            Dictionary<string, string> importedData = di.ImportData("../../../../TestFiles/");

            //Assert
            Assert.AreEqual("This is a test document.", importedData["test1"]);
            Assert.AreEqual("This is also a test document.", importedData["test2"]);
        }

        [Test]
        public void ShouldImportAllReviewsCorrectly()
        {
            // Arrange
            DataImporter di = new DataImporter();

            // Act
            var reviews = di.ImportReviews("../../../../op_spam_v1.4");

            //Assert
            Assert.AreEqual(400, reviews.Count(x => x.IsPositive && x.IsTruthful));
            Assert.AreEqual(400, reviews.Count(x => !x.IsPositive && x.IsTruthful));
            Assert.AreEqual(400, reviews.Count(x => x.IsPositive && !x.IsTruthful));
            Assert.AreEqual(400, reviews.Count(x => !x.IsPositive && !x.IsTruthful));
            Assert.True(reviews.TrueForAll(x => !string.IsNullOrEmpty(x.Content)));
            Assert.True(reviews.TrueForAll(x => !string.IsNullOrEmpty(x.Title)));

        }
    }
}
