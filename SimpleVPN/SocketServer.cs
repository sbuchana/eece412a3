using System;
using System.Windows.Forms;

namespace SimpleVPN
{
    public class SocketServer : SocketCommunication
    {
        public String IPAddress { get; set; }
        public int Port { get; set; }
        public NetConnection Socket { get; set; }
        public Form1 Form { get; set; }

        private byte[] handshake;
        private int SessionKey;

        public SocketServer(String IPAddress, int Port)
        {
            this.IPAddress = IPAddress;
            this.Port = Port;
            Socket = new NetConnection();
            handshake = new byte[4];
        }

        public void Connect()
        {
            try
            {
                var ip = System.Net.IPAddress.Parse(IPAddress);
                Socket.OnConnect += netconnection_OnConnect;
                Socket.OnDataReceived += netconnection_OnDataReceived;
                Socket.OnDisconnect += netconnection_OnDisconnect;
                Socket.Start(ip, Port);
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
            int outSize = 0;
            var sharedkey = Utilities.GetBytes(Form.TextBox_SharedSecretKey);
            var recoveredbytes = Utilities.Decrypt(data, data.Length, outSize, sharedkey);
            if (recoveredbytes[0] == Utilities.GetBytes("~")[0])
            {
                for (var i = 0; i < handshake.Length; i++)
                {
                    handshake[i] = recoveredbytes[i];
                }

                var Authentication = new dh(handshake[1], handshake[2]);
                var gMod = Authentication.generatePartialKey();
                Authentication.generateSessionKey(gMod);
                SessionKey = Authentication.key;
            }
            else
            {
                var text = Utilities.GetString(recoveredbytes);
                Form.TextBox_Received = text;
            }
        }

        public void netconnection_OnDisconnect(object sender, NetConnection connection)
        {
            Form.Label_Status = "Status: Disconnected";
        }
    }
}
