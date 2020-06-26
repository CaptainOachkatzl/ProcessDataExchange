using System.Net;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 31415;

            ConsumerNetworkModule consumerNetworkModule = new ConsumerNetworkModule(port);

            Consumer consumer = new Consumer(consumerNetworkModule);
            consumer.Start();

            ProducerNetworkModule producerNetworkModule = new ProducerNetworkModule(new IPEndPoint(IPAddress.Loopback, port));

            Producer producer = new Producer(producerNetworkModule);
            producer.Start();
        }
    }
}
