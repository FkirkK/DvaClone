using System.Collections.Generic;
using DvaCore.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DvaTest.UnitTest
{
    [TestFixture]
    public class JSONTest
    {
        private List<RatedDocument> documentList;
        private LinearSvmResult svmResult;
        private string serializedDocList = "[{\"labeledclassifier\":true,\"ourclassifier\":true,\"name\":\"doc1\"},{\"labeledclassifier\":false,\"ourclassifier\":true,\"name\":\"doc2\"},{\"labeledclassifier\":true,\"ourclassifier\":false,\"name\":\"doc3\"},{\"labeledclassifier\":false,\"ourclassifier\":false,\"name\":\"doc4\"},{\"labeledclassifier\":true,\"ourclassifier\":true,\"name\":\"doc5\"}]";
        private string serilizedSvmResult = "{\"overallprecision\":0.0,\"overallbestfold\":1,\"overallworstfold\":3,\"falsepositives\":2.0,\"falsepositivesbestfold\":4,\"falsepositivesworstfold\":5,\"falsenegatives\":7.0,\"falsenegativesbestfold\":0,\"falsenegativesworstfold\":10,\"rateddocuments\":[{\"labeledclassifier\":true,\"ourclassifier\":true,\"name\":\"doc1\"},{\"labeledclassifier\":false,\"ourclassifier\":true,\"name\":\"doc2\"},{\"labeledclassifier\":true,\"ourclassifier\":true,\"name\":\"doc3\"},{\"labeledclassifier\":true,\"ourclassifier\":true,\"name\":\"doc4\"},{\"labeledclassifier\":true,\"ourclassifier\":false,\"name\":\"doc5\"},{\"labeledclassifier\":true,\"ourclassifier\":true,\"name\":\"doc6\"},{\"labeledclassifier\":false,\"ourclassifier\":false,\"name\":\"doc7\"},{\"labeledclassifier\":false,\"ourclassifier\":false,\"name\":\"doc8\"},{\"labeledclassifier\":true,\"ourclassifier\":false,\"name\":\"doc9\"},{\"labeledclassifier\":false,\"ourclassifier\":true,\"name\":\"doc10\"}]}";
        
        
        [SetUp]
        public void SetUp()
        {
            documentList = new List<RatedDocument>
            {
                new RatedDocument("doc1", true, true),
                new RatedDocument("doc2", false, true),
                new RatedDocument("doc3", true, false),
                new RatedDocument("doc4", false, false),
                new RatedDocument("doc5", true, true)
            };
            
            svmResult = new LinearSvmResult("0.0, 1, 3, 2.0, 4, 5, 7.0, 0, 10, " +
                                            "doc1, 1, 1, doc2, 0, 1, doc3, 1, 1, doc4, 1, 1, " +
                                            "doc5, 1, 0, doc6, 1, 1, doc7, 0, 0, doc8, 0, 0, " +
                                            "doc9, 1, 0, doc10, 0, 1");
            
        }
        
        
        [Test]
        public void CanSerialize()
        {
            //Arrange
            var input = documentList;

            //Act
            var output = JsonConvert.SerializeObject(input);
            
            //Assert
            Assert.AreEqual(serializedDocList, output.ToLower());
        }
        
        [Test]
        public void CanDeserialize()
        {
            //Arrange
            string serializedInput = serializedDocList;
                
            //Act
            var output = JsonConvert.DeserializeObject<List<RatedDocument>>(serializedInput);
            
            //Assert
            Assert.AreEqual(documentList, output);
        }
        
        [Test]
        public void CanSerializeSvmResult()
        {
            //Arrange
            var input = svmResult;

            //Act
            var output = JsonConvert.SerializeObject(input);
            
            //Assert
            Assert.AreEqual(serilizedSvmResult, output.ToLower());
        }
        
        [Test]
        public void CanDeserializeSvmResult()
        {
            //Arrange
            string serializedInput = serilizedSvmResult;
                
            //Act
            var output = JsonConvert.DeserializeObject<LinearSvmResult>(serializedInput);
            
            //Assert
            Assert.AreEqual(svmResult, output);
        }
    }
}
