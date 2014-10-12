using System;
using System.Windows.Forms;

namespace SimpleVPN
{
    public partial class Form1 : Form
    {
        SocketCommunication socket;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            var ipAddress = textBox2.Text;
            int port;

            try {
                port = Int32.Parse(textBox1.Text);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return;
            }

            if (radioButton_server.Checked)
            {
                socket = new SocketServer(ipAddress, port);
            }
            else
            {
                socket = new SocketClient(ipAddress, port);
            }
            
            socket.Connect();
        }
    }
}
