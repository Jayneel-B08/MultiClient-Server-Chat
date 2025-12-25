using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views
{
    internal class ViewModel
    {
        private static Client _form { get; set; } = new Client();
        public ViewModel(Client form)
        {
            _form = form;
        }
        public static void AppendText(string text)
        {
            _form.Screen.AppendText(text);
            _form.Screen.Text += "\n";
        }

        public static void SetID(string ID)
        {
            _form.Text = ID;
        }
    }
}
