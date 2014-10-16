using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SimpleVPN
{
    public partial class Form1 : Form
    {
        private SocketCommunication socket;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "1310";
            textBox2.Text = "128.189.215.73";
            textBox_sharedsecretkey.Text = "Key";
            //SearchForLocalIP();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            var ipAddress = textBox2.Text;
            int port;

            try
            {
                port = Int32.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (radioButton_server.Checked)
            {
                socket = new SocketServer(ipAddress, port);
                this.Text = "SimpleVPN - Server";
            }
            else
            {
                socket = new SocketClient(ipAddress, port);
                this.Text = "SimpleVPN - Client";
            }

            socket.Form = this;
            socket.Connect();
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (socket.GetType() == typeof(SocketClient))
            {
                var client = (SocketClient)socket;
                var inputbytes = Utilities.GetBytes(textBox_sent.Text);
                client.Send(inputbytes);
            }
            else
            {
                var server = (SocketServer)socket;
                var inputbytes = Utilities.GetBytes(textBox_sent.Text);
                server.Send(inputbytes);
            }
        }

        private void radioButton_server_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_server.Checked == true)
            {
                //SearchForLocalIP();
            }
        }

        private void radioButton_client_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            //textBox2.Clear();
        }

        private void SearchForLocalIP()
        {
            textBox2.Enabled = false; //Disable the textbox for IP Address in server mode.

            string strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            foreach (IPAddress ipAddress in ipEntry.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox2.Text = ipAddress.ToString();
                    break;
                }
            }
        }

        private void button_continue_Click(object sender, EventArgs e)
        {
            var sharedkey = textBox_sharedsecretkey.Text;
            var bytes = Utilities.MD5Hash(sharedkey);
        }

        //Exposed Form Controls
        public string TextBox_Received
        {
            get { return textBox_received.Text; }
            set { textBox_received.Text = value; }
        }

        public string Label_Status
        {
            get { return label_status.Text; }
            set { label_status.Text = value; }
        }

        public string TextBox_SharedSecretKey
        {
            get { return textBox_sharedsecretkey.Text; }
            set { textBox_sharedsecretkey.Text = value; }
        }

        public string TextBox_Console
        {
            get { return textBox_Console.Text; }
            set { textBox_Console.Text = value; }
        }
    }
}
