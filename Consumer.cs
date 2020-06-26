using System;
using XSLibrary.MultithreadingPatterns.Actor;

namespace Assignment
{
    class Consumer : Actor<DataMessage>
    {
        public string MessagePrefix = "Consumer: ";

        public Consumer(ConsumerNetworkModule networkModule)
        {
            networkModule.MessageReceived += (object sender, DataMessage message) => { HandleMessage(message); };
        }

        override protected void HandleMessage(DataMessage message)
        {
            Console.WriteLine("{0}Received message.", MessagePrefix);
        }
    }
}