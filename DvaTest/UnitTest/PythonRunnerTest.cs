using DvaPythonRunner;
using NUnit.Framework;

namespace DvaTest.UnitTest
{
    [TestFixture]
    class PythonRunnerTest
    {
        [TestCase(1,2,3)]
        [TestCase(4, 8, 12)]
        [TestCase(5, 10, 15)]
        [TestCase(100, 200, 300)]
        public void DoesPythonRun(int input1, int input2, int exceptedResult)
        {

            //Arrange
            PythonRunner pr = new PythonRunner();

            //Act
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            int result = int.Parse(pr.RunGenericPythonScripts("../../../../TestFiles/python.py", input1, input2));

            //Assert
            Assert.AreEqual(result, exceptedResult);
        }
    }
}
