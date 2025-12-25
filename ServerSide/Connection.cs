using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerSide
{
    internal class Connection
    {
        private Socket ServerSocket;
        public static Dictionary<string, Socket> Clients = new Dictionary<string, Socket>();
        private static IPAddress IP = IPAddress.Loopback;
        private static int port;
        private string ClientID { get; set; } = "";
        public Connection(Socket Socket, IPAddress IpAddress, int Port)
        {
            this.ServerSocket = Socket;
            IP = IpAddress;
            port = Port;
        }

        public void Start()
        {
            ServerSocket.Bind(new IPEndPoint(IP, port));
            ServerSocket.Listen(0);
            Console.WriteLine($"Server is running on {IP}:{port}.");
            Console.WriteLine("Waiting for Connection...");
            StartListening();
        }

        private async void StartListening()
        {
            try
            {
                while (true)
                {
                    Socket ClientSocket = await ServerSocket.AcceptAsync();
                    ClientID = GenerateUserId();
                    Clients.Add(ClientID, ClientSocket);
                    Console.WriteLine($"[{ClientID}] Has Connected.");
                    new Thread(() => ReciveData(ClientID, ClientSocket)).Start();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        private async void ReciveData(string ClientID, Socket ClientSocket)
        {
            ClientSocket.Send(Encoding.UTF8.GetBytes($"CONNECT|{ClientID}"));
            BroadCastINFO(ClientID, "JOIN");
            try
            {
                while (true)
                {
                    byte[] ReceivingData = new byte[4096];
                    int ReceivedData = await ClientSocket.ReceiveAsync(ReceivingData);
                    if (ReceivedData == 0) break;
                    new PacketHandler(ReceivingData);
                }
                Clients.Remove(ClientID);
                ClientSocket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message.ToString()} - Fail to Receive Data");
            }
        }

        public static void BroadCastMSG(string ClientID, string Message)
        {
            foreach (string ID in Clients.Keys)
            {
                if (ID != ClientID)
                {
                    Clients[ID].Send(PacketHandler.WriteBroadCastMSG(ClientID, Message));
                }
            }
        }
        public static void BroadCastINFO(string userID, string Message)
        {
            foreach (string ID in Clients.Keys)
            {
                if (ID != userID)
                {
                    Clients[ID].Send(PacketHandler.WriteINFOPacket(userID, Message));
                }
            }
        }

        private string GenerateUserId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            char[] ID = new char[5];
            do
            {
                for (int i = 0; i < ID.Length; i++)
                {
                    ID[i] = chars[rnd.Next(chars.Length)];
                }
                if (Clients.ContainsKey(ID.ToString()))
                {
                    ID = new char[ID.Length + 1];
                }
            } while (Clients.ContainsKey(ID.ToString()));
            return new string(ID);
        }
    }
}
