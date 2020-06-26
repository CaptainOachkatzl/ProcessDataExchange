using System;
using System.Threading;
using XSLibrary.MultithreadingPatterns.Actor;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Consumer consumer = new Consumer();
            consumer.Start();

            while(true)
            {
                consumer.SendMessage(new ConsumerMessage());
                Thread.Sleep(2000);
            }
        }
    }
}
