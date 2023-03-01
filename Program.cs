using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPBroadcast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket socketBroadcaster= new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socketBroadcaster.EnableBroadcast = true;
            IPEndPoint socketBroadcastEP= new IPEndPoint(IPAddress.Parse("255.255.255.255"), 23000);
            byte[] broadCastbuffer = new byte[1024];

            try {

                socketBroadcaster.SendTo(broadCastbuffer, socketBroadcastEP);
                socketBroadcaster.Shutdown(SocketShutdown.Both);
                socketBroadcaster.Close();

                    }
            catch (Exception Excp) {
                Console.WriteLine(Excp.ToString());
                    }

        }
    }
}
