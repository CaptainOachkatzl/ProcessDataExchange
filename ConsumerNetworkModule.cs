using System;
using XSLibrary.Network.Connections;

namespace Assignment
{
    class ConsumerNetworkModule
    {
        public delegate void MessageReceivedHandler(object sender, ConsumerMessage message);
        public event MessageReceivedHandler MessageReceived;

        internal void OnProducerConnected(object sender, TCPPacketConnection connection)
        {
            Console.WriteLine("Producer connected.");
            MessageReceived.Invoke(this, new ConsumerMessage());
            connection.Disconnect();
        }
    }
}
