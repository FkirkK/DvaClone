using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DvaPythonRunner;

namespace DvaTest
{
    [TestFixture]
    class PythonRunnerTest
    {
        [TestCase(1,2,3)]
        [TestCase(4, 8, 12)]
        [TestCase(5, 10, 15)]
        [TestCase(100, 200, 300)]
        public void DoesPythonReturnCorrectResult(int input1, int input2, int exceptedResult)
        {

            //Arrange
            PythonRunner pr = new PythonRunner();

            //Act
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            int result = int.Parse((string)pr.RunScript("../../../../TestFiles/python.py", input1, input2));

            //Assert
            Assert.AreEqual(result,exceptedResult);
        }

    }
}
