using System;
using System.Collections.Generic;
using System.Text;
using DvaCore.Models;
using DvaPythonRunner;
using DvaAnalysisClient;
using Newtonsoft.Json;

namespace DvaCore
{
    public class RemoteAnalysisRunner : IAnalysisRunner
    {
        private IJudge _judge;
        private string ip;
        private int port;

        public RemoteAnalysisRunner(IJudge j)
        {
            this._judge = j;
            ip = "127.0.0.1";
            port = 13337;
        }

        public IResult RunLinearSvmBigram()
        {
            Client client = new Client(ip, port);
            string resultString = client.SendMessageAndWaitForRespons(AnalysisModules.Bigram.ToString());

            var deserializedObject = JsonConvert.DeserializeObject<LinearSvmResult>(resultString);
            
            
            return _judge.judgeResults(deserializedObject);
        }

        public IResult RunLinearSvmBigramPlus()
        {
            throw new NotImplementedException();
        }

        public IResult RunLinearSvmTrigram()
        {
            throw new NotImplementedException();
        }

        public IResult RunLinearSvmTrigramPlus()
        {
            throw new NotImplementedException();
        }

        public IResult RunLinearSvmUnigram()
        {
            throw new NotImplementedException();
        }
    }
}
