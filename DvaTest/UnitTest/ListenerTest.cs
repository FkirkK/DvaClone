using DvaAnalysisClient;
using DvaAnalysisServer;
using DvaCore;
using DvaCore.Models;
using DvaPythonRunner;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace DvaTest.UnitTest
{
    [TestFixture]
    public class ListenerTest
    {
        private Process server;

        
        /*
        [SetUp]
        public void Setup()
        {
            server = RunServer();
            Thread.Sleep(500);
        }
*/
        [TearDown]
        public void Teardown()
        {
            server.Kill();
            Thread.Sleep(500);
        }



        [TestCase("a")]
        [TestCase("127.a.0.1")]
        public void ClientHandlesInvalidIp(string ip)
        {
            Assert.Throws<FormatException>( () => new Client(ip, 1));
        }
        
        [TestCase(IPEndPoint.MinPort-1)]
        [TestCase(IPEndPoint.MaxPort+1)]
        public void ClientHandlesInvalidport(int port)
        {
            Assert.Throws<ArgumentOutOfRangeException>( () => new Client("127.0.0.1", port));
        }

        [Test]
        public void ClientCanConnectToServer()
        {
            server = RunServer();
            Thread.Sleep(500);
            
            Assert.DoesNotThrow(() => new Client());
        }
        
        [Test]
        public void ClientCannotConnectToServer()
        {
            server.Kill();
            Assert.Throws<UnableToConnectException>(() => new Client());
        }
        
        [Test]
        public void SendResponseUponInvalidServerRequest()
        {
            //Arrange
            string expectedOutput = "Invalid response";
            string actualOutput = "";
            Listener listener = new Listener();

            //Act
            Client client = new Client("127.0.0.1", 13337);
            actualOutput = client.SendMessageAndWaitForRespons("Noget som ingen menning giver");
            
            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void RunBigramAlgorithmAndSendCorrectResponseBack()
        {
            //Arrange
            double expectedOutput = 0.828;
            string actualOutput = "";
            Listener listener = new Listener();
            IJudge j = new Judge();
            IAnalysisRunner ar = new RemoteAnalysisRunner(j);

            //Act
            var linearSvmResult = ar.RunLinearSvmBigram();
            var convertedSvmResult = linearSvmResult as LinearSvmResult;
            
            
            if(convertedSvmResult == null)
                throw  new Exception("Unable to convert linearSvmResult to linearSvmResult");

            //Assert
            Assert.AreEqual(expectedOutput, convertedSvmResult.OverallPrecision, 0.001);
        }

        private static Process RunServer()
        {
            // Create new process start info 
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("dotnet");

            // make sure we can read the output from stdout 
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;

            // start python app with X arguments  
            // 1st arguments is pointer to itself
            
            //#if Debug
            string callString = @"/home/bs/code/Dva/DvaAnalysisServer/bin/Debug/netcoreapp2.0/publish/DvaAnalysisServer.dll";
            //#else
            //string callString = @"/home/bs/code/Dva/DvaAnalysisServer/bin/Debug/netcoreapp2.0/DvaAnalysisServer.dll";
            //#endif
            
            
            myProcessStartInfo.Arguments = callString;

            Process myProcess = new Process();
            // assign start information to the process 
            myProcess.StartInfo = myProcessStartInfo;

            // start the process 
            myProcess.Start();
            return myProcess;
        }
        
        
    }
}
