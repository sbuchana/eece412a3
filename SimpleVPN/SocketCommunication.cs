using System;

namespace SimpleVPN
{
    public interface SocketCommunication
    {
        String IPAddress { get; set; }
        int Port { get; set; }

        void Connect();
    }
}
