using System;
using XSLibrary.MultithreadingPatterns.Actor;

namespace ProcessDataExchange
{
    class Consumer : Actor<DataMessage>
    {
        public string ConsumerName = "Consumer";

        public Consumer(ConsumerNetworkModule networkModule)
        {
            networkModule.MessageReceived += (object sender, DataMessage message) => { HandleMessage(message); };
        }

        override protected void HandleMessage(DataMessage message)
        {
            Console.WriteLine("{0} - Received message with body: \"{1}\"", ConsumerName, message.MessageBody);
        }
    }
}