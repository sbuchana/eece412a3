using System;

namespace SimpleVPN
{
    public interface SocketCommunication
    {
        String IPAddress { get; set; }
        int Port { get; set; }
        NetConnection Socket { get; set; }
        Form1 Form { get; set; }

        void Connect();
    }
}
