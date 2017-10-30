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
using System.Text;
using System.Threading;

namespace DvaTest.UnitTest
{
    [TestFixture]
    public class ListenerTest
    {
        private Process server;

        [SetUp]
        public void Setup()
        {
            //server = RunServer();
            Thread.Sleep(1000);
        }

        [TearDown]
        public void Teardown()
        {
            server.Kill();
            Thread.Sleep(1000);
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
            var linearSvmResult = (LinearSvmResult)ar.RunLinearSvmBigram();


            //Assert
            Assert.AreEqual(expectedOutput, linearSvmResult.OverallPrecision, 0.001);
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
            string callString = @"C:\Users\Stelle\Documents\GitHub\Dva\DvaAnalysisServer\bin\Debug\netcoreapp2.0\DvaAnalysisServer.dll";
            
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
