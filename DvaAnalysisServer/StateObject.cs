using System.Net.Sockets;

namespace DvaAnalysisServer
{
    internal class StateObject
    {
        public Socket Socket { get; }
        public byte[] Buffer { get; }

        public StateObject(Socket socket)
        {
            Socket = socket;
            Buffer = new byte[1024000];
        }
    }
}