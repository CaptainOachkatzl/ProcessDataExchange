using System;
using XSLibrary.MultithreadingPatterns.Actor;

namespace Assignment
{
    class DataMessage
    {

    }

    class Consumer : Actor<DataMessage>
    {
        public Consumer(ConsumerNetworkModule networkModule)
        {
            networkModule.MessageReceived += (object sender, DataMessage message) => { HandleMessage(message); };
        }

        override protected void HandleMessage(DataMessage message)
        {
            Console.WriteLine("Consumer: Received message.");
        }
    }
}