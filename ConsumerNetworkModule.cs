using XSLibrary.Cryptography.ConnectionCryptos;
using XSLibrary.Network.Acceptors;
using XSLibrary.Network.Connections;

namespace Assignment
{
    class ConsumerNetworkModule
    {
        public delegate void MessageReceivedHandler(object sender, ConsumerMessage message);
        public event MessageReceivedHandler MessageReceived;

        public ConsumerNetworkModule(int port)
        {           
            SecureAcceptor acceptor = new SecureAcceptor(new TCPAcceptor(port, 10));
            acceptor.Crypto = CryptoType.EC25519;
            acceptor.SecureConnectionEstablished += OnProducerConnected;
            acceptor.Run();
        }

        internal void OnProducerConnected(object sender, TCPPacketConnection connection)
        {
            MessageReceived.Invoke(this, new ConsumerMessage());
            connection.Disconnect();
        }
    }
}
