using System;
using System.Threading;

namespace Assignment
{
    class Producer
    {
        ProducerNetworkModule m_networkModule;

        public string MessagePrefix = "Producer: ";

        public Producer(ProducerNetworkModule networkModule)
        {
            m_networkModule = networkModule;
        }

        public void Start()
        {            
            while(true)
            {
                Console.WriteLine("{0}Sending message.", MessagePrefix);
                m_networkModule.SendMessage(new DataMessage());
                Thread.Sleep(8000);
            }
        }
    }
}