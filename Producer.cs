using System;
using System.Threading;

namespace ProcessDataExchange
{
    class Producer
    {
        ProducerNetworkModule m_networkModule;

        public string ProducerName { get; set; } = "Producer";

        public Producer(ProducerNetworkModule networkModule)
        {
            m_networkModule = networkModule;
        }

        public void Start()
        {            
            while(true)
            {
                string body = string.Format("Data sent by {0}", ProducerName);
                Console.WriteLine("{0} - Sending message with body: \"{1}\"", ProducerName, body);
                m_networkModule.SendMessage(ProduceMessage(body));
                Thread.Sleep(8000);
            }
        }

        DataMessage ProduceMessage(string body)
        {
            DataMessage message = new DataMessage();
            message.MessageBody = body;
            return message;
        }
    }
}