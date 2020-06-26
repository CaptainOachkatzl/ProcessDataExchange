using XSLibrary.MultithreadingPatterns.Actor;

namespace Assignment
{
    class ConsumerMessage
    {

    }

    class Consumer : Actor<ConsumerMessage>
    {
        public Consumer(ConsumerNetworkModule networkModule)
        {
            networkModule.MessageReceived += (object sender, ConsumerMessage message) => { HandleMessage(message); };
        }

        override protected void HandleMessage(ConsumerMessage message)
        {
            System.Console.WriteLine("Received message.");
        }
    }
}