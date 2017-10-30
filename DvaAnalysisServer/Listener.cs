using DvaCore;
using DvaCore.Models;
using DvaPythonRunner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DvaAnalysisServer
{
    public class Listener
    {
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void SetupServer()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 13337));
            serverSocket.Listen(1);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            StateObject stateObject = new StateObject(socket);
            socket.BeginReceive(stateObject.Buffer, 0, stateObject.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), stateObject);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            StateObject stateObject = (StateObject)AR.AsyncState;
            int received = stateObject.Socket.EndReceive(AR);
            byte[] buffer = new byte[received];
            Array.Copy(stateObject.Buffer, buffer, received);
            string msgReceived = Encoding.ASCII.GetString(buffer);
            Console.WriteLine(msgReceived + " request received");
            byte[] msgToSend = Encoding.ASCII.GetBytes(DetermineAndRunAnalysis(msgReceived));
            stateObject.Socket.BeginSend(msgToSend, 0, msgToSend.Length, SocketFlags.None, new AsyncCallback(SendCallback), stateObject);
        }

        private static void SendCallback(IAsyncResult AR)
        {
            StateObject stateObject = (StateObject)AR.AsyncState;
            stateObject.Socket.EndSend(AR);
        }

        private static string DetermineAndRunAnalysis(string input)
        {
            IAnalysisRunner ar = new LocalAnalysisRunner(new PythonRunner(), new Judge());
            Console.WriteLine("Running analysis");

            switch (AnalysisModulesMethods.ConvertToEnum(input))
            {
                case AnalysisModules.Bigram:
                    var temp = (LinearSvmResult)ar.RunLinearSvmBigram();
                    Console.WriteLine("Making json");

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.Converters.Add(new LinearSvmResultConverter());
                    settings.Formatting = Formatting.Indented;
                    //var stringDocs = JsonConvert.SerializeObject(temp.RatedDocuments);
                    //temp.RatedDocumentsJson = stringDocs;
                    var jsonObject = JsonConvert.SerializeObject(temp, settings);
                    //var returnValue = ar.RunLinearSvmBigram().ToJson();
                    Console.WriteLine(jsonObject);
                    return jsonObject;
                case AnalysisModules.BigramPlus:
                    break;
                case AnalysisModules.Unigram:
                    break;
                case AnalysisModules.Trigram:
                    break;
                case AnalysisModules.TrigramPlus:
                    break;
                default:
                    break;
            }
            return null;
        }
    }

    public class LinearSvmResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(LinearSvmResult));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            LinearSvmResult tempValue = (LinearSvmResult)value;
            //res.RatedDocuments = tempValue.RatedDocuments;
            //IList<RatedDocument> ratedDocs = tempValue.RatedDocuments;
            writer.WriteStartObject();
            writer.WritePropertyName("OverallPrecision");
            serializer.Serialize(writer, tempValue.OverallPrecision);

            writer.WritePropertyName("RatedDocuments");
            //foreach (RatedDocument doc in ratedDocs)
            //{
            //    serializer.Serialize(writer, doc);
            //}
            serializer.Serialize(writer, tempValue.RatedDocuments);
            writer.WriteEndObject();
        }
    }
}
