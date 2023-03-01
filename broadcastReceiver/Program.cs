using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace broadcastReceiver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket socketBroadcastReceiver = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPEndPoint socketBroadcastReceiverEP = new IPEndPoint(IPAddress.Any, 23000);
            byte[] receivedBuffer = new byte[512];

            try
            {

                while (true)
                {
                    socketBroadcastReceiver.Bind(socketBroadcastReceiverEP);
                    int nCountReceived = socketBroadcastReceiver.Receive(receivedBuffer);
                    Console.WriteLine("no of received bytes count is " + nCountReceived);
                    Array.Clear(receivedBuffer,0, receivedBuffer.Length);
                }
            }
            catch (Exception Excp)
            {
                Console.WriteLine(Excp.ToString());
            }
        }
    }
}
