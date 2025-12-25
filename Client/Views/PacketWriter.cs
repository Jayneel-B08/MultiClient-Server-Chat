using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Views
{
    internal class PacketWriter
    {
        public static byte[] WriteMSGPacket(string Message, string userID)
        {
            if (Message != null)
            {
                string text = $"MSG|{userID}|ALL|{Message}";
                ViewModel.AppendText($"[You]: {Message}");
                return Encoding.UTF8.GetBytes(text);
            }
            return Encoding.UTF8.GetBytes("FAILED");
        }

        public static byte[] WriteINFOPacket(string Info, string userID)
        {
            string text = $"INFO|{userID}|";
            if (Info == "LEFT")
            {
                text += "LEFT";
            }
            return Encoding.UTF8.GetBytes(text);
        }
    }
}
