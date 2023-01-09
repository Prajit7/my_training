using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2.practical
{
    class MainUi
    {
        static IDataComponent component = new CustomerDatabase();
        static void Main(string[] args)
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

