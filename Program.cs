using System;
using System.Net;
using System.Threading;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int portA = 31415;
            int portB = 31416;

            Process processA = CreateProcess("Process A", portA, portB);
            Process processB = CreateProcess("Process B", portB, portA);

            processA.StartReceiving();
            processB.StartReceiving();

            new Thread(processA.StartSending).Start();
            Thread.Sleep(4000);  // delay producing of process B so log lines are easier to read
            new Thread(processB.StartSending).Start();

            ManualResetEvent halt = new ManualResetEvent(false);
            halt.WaitOne();     // main thread set to sleep permanently
        }

        static Process CreateProcess(string processName, int listeningPort, int remotePort)
        {
            ConsumerNetworkModule consumerNetworkModule = new ConsumerNetworkModule(listeningPort);
            ProducerNetworkModule producerNetworkModule = new ProducerNetworkModule(new IPEndPoint(IPAddress.Loopback, remotePort));

            return new Process(processName, consumerNetworkModule, producerNetworkModule);
        }
    }
}
