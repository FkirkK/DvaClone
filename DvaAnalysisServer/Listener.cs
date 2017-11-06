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
                    
                    var returnValue = temp.ToJson();
                    Console.WriteLine(returnValue);
                    return returnValue;
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
}
