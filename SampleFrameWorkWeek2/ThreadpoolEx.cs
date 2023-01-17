using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2
{
    class ThreadpoolEx
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Thread Id " + Thread.CurrentThread.ManagedThreadId);
            int threadCount, maxCount;
            ThreadPool.GetMaxThreads(out threadCount, out maxCount);
            Console.WriteLine($"The Max Threads available: {threadCount}");
            ThreadPool.QueueUserWorkItem(new WaitCallback((obj) =>
            {
                Console.WriteLine("The Thread Id " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(Thread.CurrentThread.IsBackground);
                for (int i = 0; i < 10; i++)
                {
                    var content = $"Thread Id with beep # {i}";
                    Console.WriteLine(content);
                    Thread.Sleep(1000);
                }
            }));
            Console.ReadKey();


        }
    }
}
