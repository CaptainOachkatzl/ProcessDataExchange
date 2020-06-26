using System;
using System.Threading;

namespace Assignment
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
                Console.WriteLine("{0} - Sending message.", ProducerName);
                m_networkModule.SendMessage(ProduceMessage());
                Thread.Sleep(8000);
            }
        }

        DataMessage ProduceMessage()
        {
            DataMessage message = new DataMessage();
            message.MessageBody = string.Format("Data sent by {0}", ProducerName);
            return message;
        }
    }
}