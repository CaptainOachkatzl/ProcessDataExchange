using System.Net;
using XSLibrary.Cryptography.ConnectionCryptos;
using XSLibrary.Network.Connections;
using XSLibrary.Network.Connectors;

namespace Assignment
{
    class ProducerNetworkModule
    {
        EndPoint m_consumerEndpoint;
        SecureConnector m_connector;

        public ProducerNetworkModule(EndPoint consumerEndpoint)
        {
            m_consumerEndpoint = consumerEndpoint;
   
            m_connector = new SecureConnector();
            m_connector.Crypto = CryptoType.EC25519;
        }

        public void SendMessage(DataMessage message)
        {
            TCPPacketConnection consumerConnection;
            m_connector.Connect(m_consumerEndpoint, out consumerConnection);
        }
    }
}
