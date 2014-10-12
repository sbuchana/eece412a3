using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SimpleVPN
{
    public class SocketServer : SocketCommunication
    {
        public String IPAddress { get; set; }
        public int Port { get; set; }

        public SocketServer(String IPAddress, int Port)
        {
            this.IPAddress = IPAddress;
            this.Port = Port;
        }

        public void Connect()
        {
            try {
                var addrs = Dns.GetHostEntry(IPAddress).AddressList; //Resolve the IPAddress
                var address = addrs.First<IPAddress>();

                var listener = new TcpListener(address, Port);
                listener.Start(); 

                var socket = listener.AcceptSocket(); //Blocks application until a stream is received.
                var streamreader = new NetworkStream(socket); //Bytes are received through the streamreader.

                //Close Streamreader and Socket
                streamreader.Close();
                socket.Close();
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
    }
}
