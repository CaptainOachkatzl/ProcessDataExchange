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
                m_networkModule.SendMessage(new ConsumerMessage());
                Thread.Sleep(2000);
            }
        }
    }
}