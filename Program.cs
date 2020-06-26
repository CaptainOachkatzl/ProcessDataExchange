using System;
using System.Net;
using System.Threading;
using XSLibrary.Cryptography.ConnectionCryptos;
using XSLibrary.MultithreadingPatterns.Actor;
using XSLibrary.Network.Acceptors;
using XSLibrary.Network.Connections;
using XSLibrary.Network.Connectors;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 31415;

            ConsumerNetworkModule consumerNetworkModule = new ConsumerNetworkModule();

            Consumer consumer = new Consumer(consumerNetworkModule);
            consumer.Start();

            SecureAcceptor acceptor = new SecureAcceptor(new TCPAcceptor(port, 10));
            acceptor.Crypto = CryptoType.EC25519;
            acceptor.SecureConnectionEstablished += consumerNetworkModule.OnProducerConnected;
            acceptor.Run();

            SecureConnector connector = new SecureConnector();
            connector.Crypto = CryptoType.EC25519;

            while(true)
            {
                TCPPacketConnection consumerConnection;
                connector.Connect(new IPEndPoint(IPAddress.Loopback, port), out consumerConnection);
                Thread.Sleep(2000);
            }
        }
    }
}
