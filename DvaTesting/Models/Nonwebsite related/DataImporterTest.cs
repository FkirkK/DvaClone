﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Dva.Models.Nonwebsite_related_logic;

namespace DvaTesting.Models.Nonwebsite_related
{
    [TestFixture]
    class DataImporterTest
    {
        [Test]
        public void ShouldThrowFileNotFoundException()
        {
            //Arrange
            DataImporter di = new DataImporter();

            //Act


            //Assert
            Assert.True(true);
        }
    }
}
