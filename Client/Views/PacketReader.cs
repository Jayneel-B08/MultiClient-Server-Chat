using Client.Connection;
using System.ComponentModel;
using System.Text;

namespace Client.Views
{
    internal class PacketReader
    {
        public PacketReader(byte[] packet)
        {
            string[] Parts = Encoding.UTF8.GetString(packet, 0, packet.Length).Split('|');
            
            switch (Parts[0])
            {
                case "CONNECT":
                    ViewModel.SetID(Parts[1]);
                    ViewModel.AppendText($"Connected\nUserID: {Parts[1]}");
                    ClientConnection.ClientId = Parts[1];
                    break;
                case "MSG":
                    ReadMSG(Parts);
                    //ViewModel.AppendText($"{Encoding.UTF8.GetString(packet)}");
                    break;

                case "INFO":
                    ReadINFO(Parts);
                    break;
            }
        }
        private void ReadMSG(string[] Parts)
        {
            string msg = Parts[3];
            string sender = Parts[1];
            string text = $"[{sender}]: {msg}";
            ViewModel.AppendText(text);
        }

        private void ReadINFO(string[] Parts)
        {
            switch (Parts[2].Replace("\0", ""))
            {
                case "JOIN":
                    ViewModel.AppendText($"[{Parts[1]}] Joined");
                    break;
                case "LEFT":
                    ViewModel.AppendText($"[{Parts[1]}] Left");
                    break;
                default:
                    ViewModel.AppendText(Parts[2]);
                    break;
            }
        }
    }
}
