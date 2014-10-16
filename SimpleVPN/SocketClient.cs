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

        private byte[] handshake;
        private int SessionKey;

        public SocketClient(String IPAddress, int Port)
        {
            this.IPAddress = IPAddress;
            this.Port = Port;
            Socket = new NetConnection();
            handshake = new byte[4];
            SessionKey = 0;
        }

        public void Connect()
        {
            try
            {
                Socket.OnConnect += netconnection_OnConnect;
                Socket.OnDataReceived += netconnection_OnDataReceived;
                Socket.OnDisconnect += netconnection_OnDisconnect;
                Socket.Connect(IPAddress, Port);

                var primeGen = new pGen();
                var Authentication = new dh(primeGen.prime, primeGen.root);
                var gMod = Authentication.generatePartialKey();

                handshake[0] = Utilities.GetBytes("~")[0];
                handshake[1] = (byte)primeGen.prime;
                handshake[2] = (byte)primeGen.root;
                handshake[3] = (byte)gMod;

                Send(handshake);
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
            var hashedkey = new byte[16];

            if (SessionKey == 0)
            {
                hashedkey = Utilities.GetBytes(Form.TextBox_SharedSecretKey);
            }
            else
            {
                hashedkey = Utilities.MD5Hash(SessionKey.ToString());
            }

            int outsize = 0;
            var cipher = Utilities.Encrypt(data, data.Length, outsize, hashedkey);
            Socket.Send(cipher);
        }
    }
}
