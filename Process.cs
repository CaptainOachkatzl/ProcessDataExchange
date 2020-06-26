namespace Assignment
{
    class Process
    {
        Consumer m_consumer;
        Producer m_producer;

        public string MessagePrefix {get;set;} = "Process: ";

        public Process(string processName, ConsumerNetworkModule consumerNetworkModule, ProducerNetworkModule producerNetworkModule)
        {
            m_consumer = new Consumer(consumerNetworkModule);
            m_producer = new Producer(producerNetworkModule);

            m_consumer.MessagePrefix = processName + ": ";
            m_producer.MessagePrefix = processName + ": ";
        }

        public void StartReceiving()
        {
            m_consumer.Start();
        }

        public void StartSending()
        {
            m_producer.Start();
        }
    }
}