using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SimpleVPN
{
    public class SocketClient : SocketCommunication
    {
        public String IPAddress { get; set; }
        public int Port { get; set; }

        public SocketClient(String IPAddress, int Port)
        {
            this.IPAddress = IPAddress;
            this.Port = Port;
        }

        public void Connect()
        {
            try {
                var client = new TcpClient(IPAddress, Port);
                var stream = client.GetStream();

                //Close Stream and Client
                stream.Close();
                client.Close();
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
    }
}
