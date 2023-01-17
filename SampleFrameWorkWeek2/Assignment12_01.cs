using SampleConApp;
using SampleFrameWork.Practical;
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

    class Assignment12_01
    {
        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
        RETRY:
            var choice = Utilities.Prompt("Enter 1 to add customer\n2 to view customer\n3 To delete customer by ID\n4 to Update");

            switch (choice)
            {
                case "1":
                    AddCustomer();
                    goto RETRY;
                case "2":
                    ViewCustomer();
                    goto RETRY;
                case "3":
                    DeleteCusTByID();
                    goto RETRY;
                case "4":
                    UpdateById();
                    goto RETRY;
                default:
                    Console.WriteLine("Wrong Choice");
                    break;
            }



        }

        private static void UpdateById()
        {

            int Newid = Utilities.GetNumber("Enter Id you want to update");
            List<Customer> Newcst = Deserialize();
            for (int i = 0; i < Newcst.Count; i++)
            {
                if (Newcst[i].CustomerId == Newid)
                {
                    Newcst[i].CustomerName = Utilities.Prompt("Enter the Name");
                    Newcst[i].CustomerAddress = Utilities.Prompt("Address");
                    Newcst[i].BillAmount = Utilities.GetNumber("Amount");
                
                }

            }


            FileStream fs = new FileStream("cust_new.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            formatter.Serialize(fs, Newcst);
            fs.Close();
        }

        

        private static void DeleteCusTByID()
        {
            int Newid = Utilities.GetNumber("Enter Id");
            List<Customer> Newcst = Deserialize();
            for (int i = 0; i < Newcst.Count; i++)
            {
                if (Newcst[i].CustomerId == Newid)
                {
                    Newcst.Remove(Newcst[i]);
                }
            }


            FileStream fs = new FileStream("cust_new.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            formatter.Serialize(fs, Newcst);
            fs.Close();

            
        }


        private static List<Customer> Deserialize()
        {
            List<Customer> customers = null;
            FileStream fm = new FileStream("cust_new.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            customers = formatter.Deserialize(fm) as List<Customer>;
            fm.Close();
            return customers;
        }
        private static void ViewCustomer()
        {
            List<Customer> customers = null;
            FileStream fm = new FileStream("cust_new.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            customers = formatter.Deserialize(fm) as List<Customer>;
            fm.Close();

            
            foreach (var item in customers)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void AddCustomer()
        {
            Customer cust = new Customer();
            cust.CustomerId = Utilities.GetNumber("Enter ID ");
            cust.CustomerName =Utilities.Prompt("Enter Name");
            cust.CustomerAddress = Utilities.Prompt("Enter Address");
            cust.BillAmount = Utilities.GetNumber("Enter Bill");
            customers.Add(cust);

            FileStream fs = new FileStream("cust_new.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));
            formatter.Serialize(fs, customers);
            fs.Close();
        }
    }
}
