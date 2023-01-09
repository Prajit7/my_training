using System;
using System.Collections;


using SampleFrameWorkWeek2.practical;

namespace DataLayer
{
    interface IDataComponent
    {
        void AddNewCustomer(Customer cst);
        void UpdateCustomer(Customer cst);
        Array GetAllCustomers();
        void DeleteCustomer(int id);
    }

    class CustomerDatabase : IDataComponent
    {
        private ArrayList _listOfCustomers = new ArrayList();//UR Array is replaced by ArrayList. 
        public void AddNewCustomer(Customer cst)
        {
         
            _listOfCustomers.Add(cst);
          //  Console.WriteLine("Added");

            
            
            
        }

        public void DeleteCustomer(int id)
        {
            foreach (var cst in _listOfCustomers)
            {
                if (cst is Customer)
                {
                    var unBoxed = cst as Customer;
                    if (unBoxed.CustomerId == id)
                    {
                        _listOfCustomers.Remove(unBoxed);
                        return;
                    }
                   

                }
            }
        }

        public Array GetAllCustomers()
        {
            Customer[] array = new Customer[_listOfCustomers.Count];
            for (int i = 0; i < _listOfCustomers.Count; i++)
            {
                
                array[i] = _listOfCustomers[i] as Customer;
                //Console.WriteLine($"The name is {array[i].CustomerName} and from {array[i].CustomerAddress}");
            }

            return array;



        }

        public void UpdateCustomer(Customer customer)
        {
            foreach (var cst in _listOfCustomers)
            {
                if(cst is Customer)
                {
                    var unBoxed = cst as Customer;
                    if (unBoxed.CustomerId == customer.CustomerId)
                    {
                        unBoxed.CustomerAddress = customer.CustomerAddress;
                        unBoxed.CustomerName = customer.CustomerName;
                        unBoxed.BillAmount = customer.BillAmount;
                        return;
                    }
                }
            }
        }
    }


}
