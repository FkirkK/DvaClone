using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DvaDataImporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DvaTest
{
    [TestClass]
    class DataImporterTest
    {
        [TestMethod]
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

        [TestMethod]
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
            Assert.IsTrue(reviews.TrueForAll(x => !string.IsNullOrEmpty(x.Content)));
            Assert.IsTrue(reviews.TrueForAll(x => !string.IsNullOrEmpty(x.Title)));

        }

        [TestMethod]
        public void testtest()
        {
            Assert.IsTrue(true);
        }
    }
}
