using DvaAnalysis.Models;
using NUnit.Framework;

namespace DvaTest.UnitTest
{
    [TestFixture]
    public class LinearSvmResultParserTest
    {

        [Test]
        public void ParseStringNoDocs()
        {
            // Arrange
            var input = "712, 112, 688, 88";

            // Act
            var result = new ClassifierResult(input);

            // Assert
            Assert.AreEqual(result.TrueTruthful, 712);
            Assert.AreEqual(result.FalseTruthful, 112);
            Assert.AreEqual(result.TrueDeceitful, 688);
            Assert.AreEqual(result.FalseDeceitful, 88);

            Assert.AreEqual(result.Accuracy, 0.875, 0.001);
            Assert.AreEqual(result.TruthfulPrecision, 0.864, 0.001);
            Assert.AreEqual(result.TruthfulRecall, 0.89, 0.001);
            Assert.AreEqual(result.DeceitfulPrecision, 0.887, 0.001);
            Assert.AreEqual(result.DeceitfulRecall, 0.86, 0.001);

            Assert.AreEqual(result.RatedDocuments.Count, 0);
        }
        
        [Test]
        public void ParseStringTenDocs()
        {
            // Arrange
            var input = "0, 0, 0, 0, " +
                        "doc1, 1, 1, doc2, 0, 1, doc3, 1, 1, doc4, 1, 1, " +
                        "doc5, 1, 0, doc6, 1, 1, doc7, 0, 0, doc8, 0, 0, " +
                        "doc9, 1, 0, doc10, 0, 1";

            // Act
            var result = new ClassifierResult(input);

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
        public void EqualityFalse()
        {
            // Arrange
            var input = "0, 0, 0, 0, " +
                        "doc1, 1, 1, doc2, 0, 1, doc3, 1, 1, doc4, 1, 1, " +
                        "doc5, 1, 0, doc6, 1, 1, doc7, 0, 0";

            // Act
            var result = new ClassifierResult(input);
            var result2 = new ClassifierResult(input + ", doc8, 0, 1");

            // Assert
            Assert.AreNotEqual(result, result2);
        }
        
        [Test]
        public void EqualityTrue()
        {
            // Arrange
            var input = "0, 0, 0, 0, " +
                        "doc1, 1, 1, doc2, 0, 1, doc3, 1, 1, doc4, 1, 1, " +
                        "doc5, 1, 0, doc6, 1, 1, doc7, 0, 0";

            // Act
            var result = new ClassifierResult(input + ", doc8, 0, 1");
            var result2 = new ClassifierResult(input + ", doc8, 0, 1");

            // Assert
            Assert.AreEqual(result, result2);
        }
    }
}