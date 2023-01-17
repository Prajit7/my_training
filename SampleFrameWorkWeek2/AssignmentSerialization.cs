using DataLayer;
using SampleConApp;
using SampleFrameWorkWeek2.practical;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleFrameWorkWeek2
{

    class AssignmentSerialization 
    {
        static void Main(string[] args)
        {
            p:
            int choice = Utilities.GetNumber("Press 1 to Add Data,2 for View Data");
            if (choice == 1) AddCst(); 
            else if (choice == 2) CustomerDeser();
            else if (choice == 3) DeleteCst();
            goto p;


        }

        private static void DeleteCst()
        {
            int id = Utilities.GetNumber("Enter the ID you want to remove");
            List<Customer> newCst = CustomerDeser();
            for (int i = 0; i < newCst.Count; i++)
            {
                if(newCst[i].CustomerId == id)
                {
                    newCst.Remove(newCst[i]);
                }
            }
            FileStream fs = new FileStream("Cust.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            formatter.Serialize(fs, newCst);
           
            fs.Close();







        }

        private static List<Customer> CustomerDeser()
        {
            //Customer cst = null;
            List<Customer> cst = null;
            FileStream fs = new FileStream("Cust.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer deSer = new XmlSerializer(typeof(List<Customer>));
            cst = deSer.Deserialize(fs) as List<Customer>;
            ViewData(cst);

            return cst;
        }

        private static void ViewData(List<Customer> cst)
        {
            foreach (var item in cst)
            {
                Console.WriteLine(item.ToString());
            }
        }



        //private static void CustSerialization(Customer det)
        //{

        //    FileStream fs = new FileStream("Cust.xml", FileMode.Create, FileAccess.Write);
        //    XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
        //    formatter.Serialize(fs, det);
        //    fs.Close();

        //}

        static List<Customer> cst = new List<Customer>();


        private static void AddCst()
        {
            Customer customer = new Customer();

            customer.CustomerId = Utilities.GetNumber("Enter the ID");
            customer.CustomerName = Utilities.Prompt("Enter Name");
            customer.CustomerAddress = Utilities.Prompt("Enter Address");
            customer.BillAmount = Utilities.GetNumber("Enter Bill");
            cst.Add(customer);
            //CustSerialization(customer);
            FileStream fs = new FileStream("Cust.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            formatter.Serialize(fs, cst);
            fs.Close();


        }


    }
}
