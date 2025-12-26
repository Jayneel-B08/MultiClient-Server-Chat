using System.Net;
using System.Net.Sockets;

namespace ServerSide
{
    internal class Server
    {
        static void Main(string[] args)
        {
            Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Connection ServerConnection = new(ServerSocket, IPAddress.Loopback, 8080);
                new Thread(() => ServerConnection.Start()).Start(); 
            }
            finally
            {
                Connection.ShutDown();
            }
            
        }

        private static void CurrentDomain_ProcessExit(object? sender, EventArgs e)
        {
            Connection.ShutDown();
            //throw new NotImplementedException();
        }
    }
}