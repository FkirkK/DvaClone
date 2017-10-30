using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DvaAnalysisClient
{
    public class Client
    {
        private string _ip;
        private int _port;
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] buffer = new byte[10240];

        public Client(string ip, int port)
        {
            _ip = ip;
            _port = port;
            LoopConnect();
        }

        public string SendMessageAndWaitForRespons(string message)
        {
            socket.Send(Encoding.ASCII.GetBytes(message));
            int received = socket.Receive(buffer);
            byte[] response = new byte[received];
            Array.Copy(buffer, response, received);

            return Encoding.ASCII.GetString(response);
        }

        private void LoopConnect()
        {
            while (!socket.Connected)
            {
                try
                {
                    socket.Connect(new IPEndPoint(IPAddress.Loopback, _port));
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
