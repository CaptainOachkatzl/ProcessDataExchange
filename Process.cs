namespace Assignment
{
    class Process
    {
        Consumer m_consumer;
        Producer m_producer;

        public string ProcessName { get; private set; } = "Process";

        public Process(string processName, ConsumerNetworkModule consumerNetworkModule, ProducerNetworkModule producerNetworkModule)
        {
            m_consumer = new Consumer(consumerNetworkModule);
            m_producer = new Producer(producerNetworkModule);

            m_consumer.ConsumerName = processName;
            m_producer.ProducerName = processName;
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