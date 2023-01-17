using SampleConApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2
{
    class GenericCollection
    {
        static void Main(string[] args)
        {
            //listExample();
            //hashSetExample();
            // dictionaryExample();
            //queueExample();
            // sortedExample();
            sortedDictEx();
        }

        private static void sortedDictEx()
        {
            SortedDictionary<string, long> phoneNo = new SortedDictionary<string, long>();
            phoneNo.Add("Prajit", 9480409992);
            phoneNo.Add("Ashwin", 8660476367);
            phoneNo.Add("Shrihari", 8618333482);
            phoneNo.Add("Zen", 8147007697);

            foreach (var item in phoneNo)
            {
                Console.WriteLine(item.Key);
            }
        }

        private static void sortedExample()
        {
            SortedList<string, long> contacts = new SortedList<string, long>();
            contacts.Add("Prajit", 9480409992);
            contacts.Add("Shrihari", 9148012152);
            contacts.Add("Ashwin", 8660476367);
            contacts.Add("Akshata", 8147007697);
            contacts.Add("Appi", 8618333482);

            foreach (var item in contacts)
            {
                Console.WriteLine($"{item.Key}-{item.Value}");
            }
        }

        private static void queueExample()
        {
            Queue<string> items = new Queue<string>();
            items.Enqueue("Item1");//Adds the item to the bottom of the collection. 
            items.Enqueue("Item2");
            items.Enqueue("Item3");
            items.Enqueue("Item4");
            items.Enqueue("Item5");
            items.Dequeue();//Always remove the first element in the collection. 
            foreach (var item in items) Console.WriteLine(item);
            Console.WriteLine("The total item in the queue: " + items.Count);

        }


        static Dictionary<string, string> users = new Dictionary<string, string>();

        private static void signUp()
        {
            ReTry:
            var uname = Utilities.Prompt("Enter the userName");
            var pwd = Utilities.Prompt("Enter the password");
            if (users.ContainsKey(uname))
            {
                Console.WriteLine("User Already Exists!!!");
                goto ReTry;
            }
            users.Add(uname, pwd);
        }

        private static void signIn()
        {
            ReTry:
            var uName = Utilities.Prompt("Enter the user name");
            var pwd = Utilities.Prompt("Enter the password");
            if (users.ContainsKey(uName))
            {
                if(users[uName] == pwd)
                {
                    Console.WriteLine($"Welcome {uName}");
                }
                else
                {
                    Console.WriteLine("Password is InValid");
                    goto ReTry;
                }
            }
            else
            {
                Console.WriteLine("user Does'nt Exist");
                goto ReTry;
            }
        }

        private static void dictionaryExample()
        {
            
            do
            {
                var choice = Utilities.Prompt("Enter 1 for Sigin->Login and 2 for SignUp->Reg ");
                if (choice == "1") signIn();
                else if (choice == "2")
                {
                    signUp();
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            } while (true);
        }

       

        private static void hashSetExample()
        {
            HashSet<string> setEx = new HashSet<string>();
            setEx.Add("Apple");
            setEx.Add("Mango");
            setEx.Add("Kiwi");
            foreach (var item in setEx)
            {
                Console.WriteLine(item);
            }
            setEx.Remove("Kiwi");
            foreach (var item in setEx)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(setEx.Count());
            
        }

        private static void listExample()
        {
            string[] old = { "kiwi", "butterFruit" };
            List<string> fruits = new List<string>(old);
            fruits.Add("Apple");
            fruits.Add("mango");
            fruits.Add("Banana");
            foreach (var item in fruits)
            {
                Console.WriteLine(item);
            }

            List<int> integer = new List<int>();
            integer.Add(1);
            integer.Add(2);
            integer.Insert(2, 4);
            foreach (var item in integer)
            {
                Console.WriteLine(item);
            }
        }
    }
}
