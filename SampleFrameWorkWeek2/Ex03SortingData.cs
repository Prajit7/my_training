using SampleFrameWorkWeek2.practical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2
{
    class Ex03SortingData
    {
        static void Main(string[] args)
        {
            //sortingExampleString();
            //sortingExampleCustomer();
            sortingBasedOnCriteria();

        }

        private static void sortingBasedOnCriteria()
        {

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer
            {
                CustomerId = 1,
                CustomerName = "Prajit",
                BillAmount = 500,
                CustomerAddress = "Murdeshwar"
            });

            customers.Add(new Customer
            {
                CustomerId = 2,
                CustomerName = "Ashwin",
                BillAmount = 300,
                CustomerAddress = "bangalore"
            });

            customers.Add(new Customer
            {
                CustomerId = 3,
                CustomerName = "Shrihari",
                BillAmount = 250,
                CustomerAddress = "Gokak"
            });

            customers.Add(new Customer
            {
                CustomerId = 4,
                CustomerName = "Ram",
                BillAmount = 100,
                CustomerAddress = "Kumta"
            });

            Console.WriteLine("Enter the Criteria");
            Array values = Enum.GetValues(typeof(Criteria));
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
            Criteria selected = (Criteria)Enum.Parse(typeof(Criteria), Console.ReadLine().ToUpper());
            customers.Sort(new CustomerComparer(selected));
            foreach (var item in customers)
            {
                Console.WriteLine(item);

            }
        }

        private static void sortingExampleCustomer()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer
            {
                CustomerId = 1,
                CustomerName = "Prajit",
                BillAmount = 500,
                CustomerAddress = "Murdeshwar"
            });

            customers.Add(new Customer
            {
                CustomerId = 2,
                CustomerName = "Ashwin",
                BillAmount = 300,
                CustomerAddress = "bangalore"
            });

            customers.Add(new Customer
            {
                CustomerId = 3,
                CustomerName = "Shrihari",
                BillAmount = 250,
                CustomerAddress = "Gokak"
            });

            customers.Add(new Customer
            {
                CustomerId = 4,
                CustomerName = "Ram",
                BillAmount = 100,
                CustomerAddress = "Kumta"
            });

            customers.Sort();
            foreach (var cst in customers)
                Console.WriteLine(cst);


        }

        private static void sortingExampleString()
        {
            string[] old = { "kiwi", "butterFruit" };
            List<string> fruits = new List<string>(old);
            fruits.Add("Apple");
            fruits.Add("mango");
            fruits.Add("Banana");
            fruits.Sort();
            foreach (var item in fruits)
            {
                Console.WriteLine(item);
            }

        }
    }
}
