using SampleConApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2.practical
{
    class QueueExample
    {
        private Queue<string> _reverseList = new Queue<string>();
        public void ViewItem(string item)
        {
            if (_reverseList.Count == 3) _reverseList.Dequeue();
            _reverseList.Enqueue(item);
            Console.ForegroundColor = ConsoleColor.Red;
            //Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(item);
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Recently viewed");

            var data = _reverseList.Reverse();
            foreach (var elements in data)
            {
                Console.WriteLine("********************");
                Console.WriteLine(elements);
                Console.WriteLine("********************");

            }

        }
    }
    class MainApp
    {

        static void Main(string[] args)
        {
            QueueExample ex = new QueueExample();
            do
            {
                var input = Utilities.Prompt("Enter the items you want to see");
                ex.ViewItem(input);
            } while (true);

        }

    }
}
    

