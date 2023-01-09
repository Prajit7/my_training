using System;
using System.Collections;

namespace SampleFrameWorkWeek2
{
    class Ex01
    {
        static void Main(string[] args)
        {
            arraylistex();
        }

        private static void arraylistex()
        {
            ArrayList lst = new ArrayList();
            lst.Add("Prajit");
            lst.Add("Shri");
            lst.Add("Ashwin");

            Console.WriteLine("The total no. of names "+lst.Count);

            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
            lst.Remove("Shri");
            lst.Insert(1, "Shri");
            lst.Insert(2, "Shrinidhi");

            Console.WriteLine("After inserting");
            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }



        }
    }
}
