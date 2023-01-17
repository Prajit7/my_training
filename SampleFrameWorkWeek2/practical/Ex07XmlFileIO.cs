using SampleFrameWorkWeek2.practical;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace SampleFrameWorkWeek2
{
    class Ex07XmlFileIO
    {
        static Customer[] getAllCustomer(string filename)
        {
            List<Customer> allCustomer = new List<Customer>();
            var allLines = File.ReadAllLines(filename);
            foreach (var item in allLines)
            {
                var split = item.Split(',');
                Customer cst = new Customer();
                cst.CustomerId = int.Parse(split[0]);
                cst.CustomerName = split[1];
                cst.CustomerAddress = split[2];
                cst.BillAmount = int.Parse(split[3]);
                allCustomer.Add(cst);

            }

            return allCustomer.ToArray();
        }
       static void writeToXML(Customer[] data,string fileName)
        {
            DataTable table = new DataTable("Customer");
            table.Columns.Add("CustomerId", typeof(int));
            table.Columns.Add("Customername", typeof(string));
            table.Columns.Add("CustomerAdsress", typeof(string));
            table.Columns.Add("BillAmount", typeof(int));

            foreach (var cst in data)
            {
                DataRow row = table.NewRow();
                row[0] = cst.CustomerId;
                row[1] = cst.CustomerName;
                row[2] = cst.CustomerAddress;
                row[3] = cst.BillAmount;

                table.Rows.Add(row);
            }
            table.AcceptChanges();
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            //ds.WriteXml(fileName);
            Console.WriteLine(ds.GetXml()); ;


        }
        static void Main(string[] args)
        {
            var data = getAllCustomer("../../Customer.csv");
            writeToXML(data, "../../Customer.xml");
           
        }
    }
}