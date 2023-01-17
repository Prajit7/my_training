using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesLayer;

namespace SampleFrameWorkWeek2.practical
{
    class MainUi
    {
        static IDataComponent component = null;

        static MainUi()
        {
            //Console.WriteLine("Enter the Name of the Component as : List or ArrayList");
            //component = CustomerFactory.GetComponent(Console.ReadLine());

        }
        static void Main(string[] args)
        {

            //factoryTesting();
            HashsetCollection collection = new HashsetCollection();
            ///Initially it gives count as 6 irrespective of similar kind so we should first check the hashcode with id(customer.cs) then use equal method to check the similarity-->this is overiding
            collection.AddCustomer(new Customer { CustomerId = 111, CustomerName = "Praj", CustomerAddress = "Gokak", BillAmount = 1000 });
            collection.AddCustomer(new Customer { CustomerId = 111, CustomerName = "Praj", CustomerAddress = "Murdeshwar", BillAmount = 1000 });
            collection.AddCustomer(new Customer { CustomerId = 111, CustomerName = "Praj", CustomerAddress = "Gokak", BillAmount = 1000 });
            collection.AddCustomer(new Customer { CustomerId = 111, CustomerName = "Praj", CustomerAddress = "Gokak", BillAmount = 1000 });
            collection.AddCustomer(new Customer { CustomerId = 111, CustomerName = "Shri", CustomerAddress = "Gokak", BillAmount = 1000 });
            collection.AddCustomer(new Customer { CustomerId = 112, CustomerName = "Shri", CustomerAddress = "Gokak", BillAmount = 1000 });

            Console.WriteLine("The Total no of Customers: " + collection.AllCustomer.Count);



            foreach (var customer in collection.AllCustomer)
            {
                Console.WriteLine(customer);
            }
           
        }

        private static void factoryTesting()
        {
            component.AddNewCustomer(new Customer { CustomerId = 111, CustomerName = "Ramesh Adiga", CustomerAddress = "Kundapur", BillAmount = 5600 });
            component.AddNewCustomer(new Customer { CustomerId = 112, CustomerName = "Ram ", CustomerAddress = "Kundapur", BillAmount = 5600 });
            component.AddNewCustomer(new Customer { CustomerId = 113, CustomerName = "Sita ", CustomerAddress = "Kundapur", BillAmount = 5600 });

            component.UpdateCustomer(new Customer { CustomerId = 111, CustomerName = "raj", CustomerAddress = "Udupi", BillAmount = 5600 });
            //component.DeleteCustomer(111);
            var data = component.GetAllCustomers();
            foreach (Customer customer in data)
                Console.WriteLine($"The Customer ID is {customer.CustomerId} with name {customer.CustomerName} from {customer.CustomerAddress} with bill of {customer.BillAmount}");
        }
           
    }
}

