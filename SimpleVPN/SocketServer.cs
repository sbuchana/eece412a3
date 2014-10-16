﻿using System;
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
        private dh Authentication;
        private byte nonce;

        public SocketServer(String IPAddress, int Port)
        {
            this.IPAddress = IPAddress;
            this.Port = Port;
            Socket = new NetConnection();
            handshake = new byte[7];
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
            var hashedkey = new byte[16];

            if (SessionKey == 0)
            {
                hashedkey = Utilities.GetBytes(Form.TextBox_SharedSecretKey);
            }
            else
            {
                hashedkey = Utilities.MD5Hash(SessionKey.ToString());
            }

            var recoveredbytes = Utilities.Decrypt(data, data.Length, outSize, hashedkey);

            if (recoveredbytes[0] == Utilities.GetBytes("*")[0])
            {
                for (var i = 0; i < handshake.Length; i++)
                {
                    handshake[i] = recoveredbytes[i];
                }

                Authentication = new dh(handshake[1], handshake[2]);
                var gMod = Authentication.generatePartialKey();
                var direction = Utilities.GetBytes("S")[0];
                var rand = new Random();
                nonce = (byte)rand.Next();
                var othernonce = handshake[5];

                if (handshake[4] != Utilities.GetBytes("C")[0])
                {
                    MessageBox.Show("Direction is not authenticated.");
                    Form.Label_Status = "Status: Disconnected";
                    return;
                }

                handshake[0] = Utilities.GetBytes("~")[0];
                handshake[1] = (byte)handshake[1];
                handshake[2] = (byte)handshake[2];
                handshake[3] = (byte)gMod;
                handshake[4] = (byte)direction;
                handshake[5] = othernonce;
                handshake[6] = nonce;

                Send(handshake);
            }
            else if (recoveredbytes[0] == Utilities.GetBytes("~")[0])
            {
                for (var i = 0; i < handshake.Length; i++)
                {
                    handshake[i] = recoveredbytes[i];
                }

                if (handshake[4] != Utilities.GetBytes("C")[0] || handshake[6] != nonce)
                {
                    MessageBox.Show("Authentication failed.");
                    Form.Label_Status = "Status: Disconnected";
                    return;
                }

                var othergMod = handshake[3];
                Authentication.generateSessionKey(othergMod);

                SessionKey = Authentication.key;

                MessageBox.Show("SessionKey: " + SessionKey.ToString() + "\nOtherGmod=" + othergMod + "\nRoot=" + handshake[2] + "\nPrime=" + handshake[1]);
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
