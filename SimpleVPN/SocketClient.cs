using System;
using System.Windows.Forms;

namespace SimpleVPN
{
    public class SocketClient : SocketCommunication
    {
        public String IPAddress { get; set; }
        public int Port { get; set; }
        public NetConnection Socket { get; set; }
        public Form1 Form { get; set; }

        public SocketClient(String IPAddress, int Port)
        {
            this.IPAddress = IPAddress;
            this.Port = Port;
            Socket = new NetConnection();
        }

        public void Connect()
        {
            try
            {
                Socket.OnConnect += netconnection_OnConnect;
                Socket.OnDataReceived += netconnection_OnDataReceived;
                Socket.OnDisconnect += netconnection_OnDisconnect;
                Socket.Connect(IPAddress, Port);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void netconnection_OnConnect(object sender, NetConnection connection)
        {
            Form.Label_Status = "Status: Connected";
        }

        public void netconnection_OnDataReceived(object sender, NetConnection connection, byte[] data)
        {
        }

        public void netconnection_OnDisconnect(object sender, NetConnection connection)
        {
            Form.Label_Status = "Status: Disconnected";
        }

        public void Send(byte[] data)
        {
            Socket.Send(data);
        }
    }
}
