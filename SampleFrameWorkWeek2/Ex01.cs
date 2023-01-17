using System;
using System.Collections;

namespace SampleFrameWorkWeek2
{
    class Ex01
    {
        static void Main(string[] args)
        {
            //arraylistex();
            hashTableEx();
        }

        private static void hashTableEx()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Prajit", "Murdeshwar");      //Adds
            hashtable["Ashwin"] = "Bangalore";          //Checks whether the key is present, if present then modifies.
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");

            }

            //To get values from keys
            foreach (var item in hashtable.Keys)
            {
                Console.WriteLine(hashtable[item]);
            }
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
