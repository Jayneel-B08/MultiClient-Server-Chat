using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Client.Views;

namespace Client.Connection
{
    internal class ClientConnection
    {
        private static Socket _ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static string ClientId { get; set; } = "";
        public static async Task Connect(IPAddress IP, int port)
        {
            try
            {
                await _ClientSocket.ConnectAsync(new IPEndPoint(IP, port));
                _ = RecevingData();
            }
            catch (Exception ex)
            {
                ViewModel.AppendText(ex.Message.ToString());
            }
        }

        public static async Task RecevingData()
        {

            while (true)
            {
                byte[] ReceivingData = new byte[1024];
                int ReceivedData = await _ClientSocket.ReceiveAsync(ReceivingData, SocketFlags.None);
                if (ReceivedData == 0) break;
                new PacketReader(ReceivingData);
            }
        }

        public static async Task SendingData(string Message)
        {
            if (!String.IsNullOrEmpty(Message))
            {
                byte[] data = PacketWriter.WriteMSGPacket(Message, ClientId);
                await _ClientSocket.SendAsync(data);
            }
            else
            {
                ViewModel.AppendText("Enter Before Sending.");
            }

        }
    }
}
