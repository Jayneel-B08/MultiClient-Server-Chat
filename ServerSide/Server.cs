using System.Net;
using System.Net.Sockets;

namespace ServerSide
{
    internal class Server
    {
        static void Main(string[] args)
        {
            Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Connection ServerConnection = new Connection(ServerSocket, IPAddress.Loopback, 8080);
            ServerConnection.Start();
            Console.ReadLine();
        }
    }
}