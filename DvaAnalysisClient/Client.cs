using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace DvaAnalysisClient
{
    public class Client
    {
        private IPAddress _ip = null;
        private IPEndPoint _endPoint = null;
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] buffer = new byte[1024000];

        public Client(string ip, int port)
        {
            if (! IPAddress.TryParse(ip, out _ip))
                throw new FormatException("Invalid ip: " + ip);

            if (port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
                throw new ArgumentOutOfRangeException("Invalid port: " + port);
            
            _endPoint = new IPEndPoint(_ip, port);

            LoopConnect();
        }


        public Client() : this("127.0.0.1", 13337)
        {
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
            try
            {
                socket.Connect(_endPoint);
            }
            catch (SocketException e)
            {
                throw new UnableToConnectException("Unable to connect to server.", e);
            }
        }
    }
}
