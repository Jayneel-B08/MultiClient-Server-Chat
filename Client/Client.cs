using System.Net;
using System.Runtime.CompilerServices;
using Client.Connection;
using Client.Views;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            ViewModel view = new ViewModel(this);
            
        }

        private void ConnectBTN_Click(object sender, EventArgs e)
        {
            _ = ClientConnection.Connect(IPAddress.Loopback, 8080);
           
        }

        private void SendBTN_Click(object sender, EventArgs e)
        {
            _ = ClientConnection.SendingData(Message.Text);
            Message.Text = "";
        }
    }
}
