using System;
using System.Collections.Generic;
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
            List<string> importedData = di.ImportData("../../../../TestFiles/");

            //Assert
            Assert.AreEqual("This is a test document.", importedData[0]);
            Assert.AreEqual("This is also a test document.", importedData[1]);
        }
    }
}
