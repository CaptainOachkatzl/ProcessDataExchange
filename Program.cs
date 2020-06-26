using System;
using System.Net;
using System.Threading;

namespace ProcessDataExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            int portA = 31415;
            int portB = 31416;

            Process processA = CreateProcess("Process A", portA, portB);
            Process processB = CreateProcess("Process B", portB, portA);

            // process A starts listening to messages on Port A
            processA.StartReceiving();

            // process B starts listening to messages on Port B
            processB.StartReceiving();

            // start sending messages in separate thread
            new Thread(processA.StartSending).Start();
            Thread.Sleep(4000);  // delay producing of process B so log lines are easier to read
            new Thread(processB.StartSending).Start();

            new ManualResetEvent(false).WaitOne();     // main thread set to sleep permanently
            // program will never reach the end
        }

        static Process CreateProcess(string processName, int listeningPort, int remotePort)
        {
            ConsumerNetworkModule consumerNetworkModule = new ConsumerNetworkModule(listeningPort);
            ProducerNetworkModule producerNetworkModule = new ProducerNetworkModule(new IPEndPoint(IPAddress.Loopback, remotePort));

            return new Process(processName, consumerNetworkModule, producerNetworkModule);
        }
    }
}
