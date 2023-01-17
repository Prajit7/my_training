using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2.practical
{
    class HashsetCollection
    {
        HashSet<Customer> customers = new HashSet<Customer>();
         
        public void AddCustomer(Customer cst)
        {
            customers.Add(cst);
        }
        public HashSet<Customer> AllCustomer => customers;
    }
}
