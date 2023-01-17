using SampleConApp;
using SampleFrameWorkWeek2.practical;
using System;
using System.Collections.Generic;
using System.IO;


namespace SampleFrameWork.Practical
{
    class CSVFileIo
    {
        const string fileName = "../../Customer.csv";
        static void Main(string[] args)
        {
            var choice = Utilities.Prompt("Type 'A' if you want to Enter the Data\nType 'V' to View the Data");
            if (choice.ToUpper() == "A") writingEx();
            else if (choice.ToUpper() == "V") readingEx();
            else Console.WriteLine("InValid Choice");  

        }

        private static void readingEx()
        {
            List<Customer> allCustomer = new List<Customer>();
            var allLines = File.ReadAllLines(fileName);
            foreach (var lines in allLines)
            {
                //Split
                var split = lines.Split(',');
                Customer cst = new Customer();
                cst.CustomerId =int.Parse( split[0]);
                cst.CustomerName = split[1];
                cst.CustomerAddress = split[2];
                cst.BillAmount = int.Parse(split[3]);
                allCustomer.Add(cst);
            }
            foreach (var cst in allCustomer)
            {
                Console.WriteLine(cst.CustomerName);
            }

        }

        private static void writingEx()
        {
            Customer cst = new Customer
            {
                CustomerId = Utilities.GetNumber("Enter the ID"),
                CustomerName = Utilities.Prompt("Enter the Name"),
                CustomerAddress = Utilities.Prompt("Enter the Address"),
                BillAmount = Utilities.GetNumber("Enter the Bill Amount")

            };
            File.AppendAllText(fileName, cst.ToString());
        }
    }
}