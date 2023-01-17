using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2
{
    class MultiThreadingEx
    {
        static Thread thread;
        static int no = 0;
        static void threadFunc()
        {
            lock (typeof(MultiThreadingEx))
            {
                for (int i = 0; i < 10; i++)
                {
                    no += i;
                    var content = $"Thread id of {i} and count {no}";
                    Console.WriteLine(content);
                    Thread.Sleep(1000);
                }
            }
        }
        public static object ParamaterizedThreadStart { get; private set; }

        static void LargeFunWithParamaters(object data)
        {
            string fileName = data.ToString();
            var contents = File.ReadAllLines(fileName);
            foreach (var lines in contents)
            {
                Thread.Sleep(500);
                foreach (var ch in lines.ToCharArray())
                {
                    Console.Write(ch);
                    Thread.Sleep(200);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Set of records");
        }
        static void LargeFun()
        {
            Console.WriteLine("The large Function has started");
            for (int i = 0; i < 10; i++)
            {

               Thread.Sleep(1000);
                Console.WriteLine("Large Function is running");
                if (i == 5) Thread.CurrentThread.Suspend();
            }
            Console.Clear();
            Console.WriteLine("Large function completed");
        }
        static void paramaterizedThreadOperation()
        {
            ParameterizedThreadStart threadOp = new ParameterizedThreadStart(LargeFunWithParamaters);
            Thread th = new Thread(threadOp);
            th.IsBackground = true;
            th.Start("../../Sample.csv");
            th.Join();          //->1




        }
        private static void defaultThreadOperation()
        {
            ThreadStart threadStart = new ThreadStart(LargeFun);
            thread = new Thread(threadStart);
            thread.Start();
        }

        static void MultipleThreadEx()
        {
            Thread t1 = new Thread(threadFunc);
            Thread t2 = new Thread(threadFunc);
            t1.Start();
            t2.Start();
        }
         static void mainOperation()
        {
            Console.WriteLine("Main is doing its job!");      //->1
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Main is running");
            }
            Console.WriteLine("Main is completed");
            if (thread.ThreadState == ThreadState.Suspended) thread.Resume();
        }


        static void Main(string[] args)
        {
            //defaultThreadOperation();
            //paramaterizedThreadOperation();
            //mainOperation();
            MultipleThreadEx();
        }

       



    }
}
