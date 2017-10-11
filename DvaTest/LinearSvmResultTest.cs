using DvaCore.Models;
using NUnit.Framework;

namespace DvaTest
{
    [TestFixture]
    public class LinearSvmResultParserTest
    {

        [Test]
        public void ParseStringNoDocs()
        {
            // Arrange
            var input = "0.0, 1.0, 3.0, 2.0, 4.0, 5.5, 7.0, 0.0, 10.0";

            // Act
            var result = new LinearSvmResult(input);

            // Assert
            Assert.AreEqual(result.OverallPrecision, 0.0);
            Assert.AreEqual(result.OverallBest, 1.0);
            Assert.AreEqual(result.OverallWorst, 3.0);
            Assert.AreEqual(result.FalsePositives, 2.0);
            Assert.AreEqual(result.FalsePositivesBest, 4.0);
            Assert.AreEqual(result.FalsePositivesWorst, 5.5);
            Assert.AreEqual(result.FalseNegatives, 7.0);
            Assert.AreEqual(result.FalseNegativesBest, 0.0);
            Assert.AreEqual(result.FalseNegativesWorst, 10.0);

            Assert.AreEqual(result.RatedDocuments.Count, 0);
        }
        
        [Test]
        public void ParseStringTenDocs()
        {
            // Arrange
            var input = "0.0, 1.0, 3.0, 2.0, 4.0, 5.5, 7.0, 0.0, 10.0, " +
                        "doc1, 1, 1, doc2, 0, 1, doc3, 1, 1, doc4, 1, 1, " +
                        "doc5, 1, 0, doc6, 1, 1, doc7, 0, 0, doc8, 0, 0, " +
                        "doc9, 1, 0, doc10, 0, 1";

            // Act
            var result = new LinearSvmResult(input);

            // Assert
            Assert.AreEqual(result.RatedDocuments.Count, 10);

            // React
            var documents = result.RatedDocuments;

            // Reassert
            Assert.AreEqual(new RatedDocument("doc1", true, true), documents[0]);
            Assert.AreEqual(new RatedDocument("doc2", false, true), documents[1]);
            Assert.AreEqual(new RatedDocument("doc3", true, true), documents[2]);
            Assert.AreEqual(new RatedDocument("doc4", true, true), documents[3]);
            Assert.AreEqual(new RatedDocument("doc5", true, false), documents[4]);
            Assert.AreEqual(new RatedDocument("doc6", true, true), documents[5]);
            Assert.AreEqual(new RatedDocument("doc7", false, false), documents[6]);
            Assert.AreEqual(new RatedDocument("doc8", false, false), documents[7]);
            Assert.AreEqual(new RatedDocument("doc9", true, false), documents[8]);
            Assert.AreEqual(new RatedDocument("doc10", false, true), documents[9]);
        }
        
        
        [Test]
        public void EqualityFlase()
        {
            // Arrange
            var input = "0.0, 1.0, 3.0, 2.0, 4.0, 5.5, 7.0, 0.0, 10.0, " +
                        "doc1, 1, 1, doc2, 0, 1, doc3, 1, 1, doc4, 1, 1, " +
                        "doc5, 1, 0, doc6, 1, 1, doc7, 0, 0";

            // Act
            var result = new LinearSvmResult(input);
            var result2 = new LinearSvmResult(input + ", doc8, 0, 1");

            // Assert
            Assert.AreNotEqual(result, result2);
        }
        
        [Test]
        public void EqualityTrue()
        {
            // Arrange
            var input = "0.0, 1.0, 3.0, 2.0, 4.0, 5.5, 7.0, 0.0, 10.0, " +
                        "doc1,Equals 1, 1, doc2, 0, 1, doc3, 1, 1, doc4, 1, 1, " +
                        "doc5, 1, 0, doc6, 1, 1, doc7, 0, 0";

            // Act
            var result = new LinearSvmResult(input + ", doc8, 0, 1");
            var result2 = new LinearSvmResult(input + ", doc8, 0, 1");

            // Assert
            Assert.AreEqual(result, result2);
        }
    }
}