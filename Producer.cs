using System;
using System.Threading;

namespace Assignment
{
    class Producer
    {
        ProducerNetworkModule m_networkModule;

        public Producer(ProducerNetworkModule networkModule)
        {
            m_networkModule = networkModule;
        }

        public void Start()
        {            
            while(true)
            {
                Console.WriteLine("Producer: Sending message.");
                m_networkModule.SendMessage(new DataMessage());
                Thread.Sleep(2000);
            }
        }
    }
}