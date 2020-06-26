using XSLibrary.MultithreadingPatterns.Actor;

namespace Assignment
{
    class ConsumerMessage
    {

    }

    class Consumer : Actor<ConsumerMessage>
    {
        override protected void HandleMessage(ConsumerMessage message)
        {
            System.Console.WriteLine("Received message.");
        }
    }
}