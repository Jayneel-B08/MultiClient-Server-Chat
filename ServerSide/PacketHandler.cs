using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ServerSide
{
    internal class PacketHandler
    {
        public PacketHandler(byte[] Packet)
        {
            string[] parts = Encoding.UTF8.GetString(Packet).Replace("\0","").Split('|');

            if (parts.Length > 4) return;

            switch (parts[0])
            {
                case "MSG":
                    ReadMSG(parts);
                    break;

                case "INFO":
                    break;
            }
        }

        public void ReadMSG(string[] parts)
        {
            Console.WriteLine($"[{parts[1]}] to [{parts[2]}]: {parts[3]}");
            if (parts[2] == "ALL")
            {
                Connection.BroadCastMSG(parts[1], parts[3]);
            }
            else
            {
                Console.WriteLine("its not all");
            }
        }

        public void ReadINFO(string[] parts)
        {
            Console.WriteLine($"[{parts[1]}]: {parts[2]}");
        }

        public static byte[] WriteBroadCastMSG(string UserID, string Message)
        {
            if (Message != null)
            {
                string text = $"MSG|{UserID}|ALL|{Message}";
                return Encoding.UTF8.GetBytes(text);
            }
            return Encoding.UTF8.GetBytes("FAILED");
        }

        public static byte[] WriteINFOPacket(string userID,string Info)
        {
            string text = "";
            if (Info == "LEFT")
            {
                 text = $"INFO|{userID}|LEFT";
            }else if (Info == "JOIN")
            {
                text = $"INFO|{userID}|JOIN";
            }
            Console.WriteLine(text);
            return Encoding.UTF8.GetBytes(text);
        }
    }
}
