using SampleFrameWorkWeek2.practical;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SampleADOWeek3
{
    class assignment
    {
        static string STRCONNECTION = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        static SqlConnection con = new SqlConnection(STRCONNECTION);
        static void Main(string[] args)
        {

            //insertRecord();
            //deleteUsingConnected();
            //EmpDeptJoin();
            readCSV();

        }

        private static void readCSV()
        {
            const string fileName = "D:/Prajit_3328/dot net/CompleteDotnetTraining/SampleFrameWorkWeek2/Customer.csv";
            List<Customer> cst = new List<Customer>();
            var allLines = File.ReadAllLines(fileName);
            foreach (var lines in allLines)
            {
                //Split
                var split = lines.Split(',');
                Customer customer = new Customer();
                customer.CustomerId = int.Parse(split[0]);
                customer.CustomerName = split[1];
                customer.CustomerAddress = split[2];
                customer.BillAmount = int.Parse(split[3]);
                cst.Add(customer);
            }
            foreach (var item in cst)
            {
                Console.WriteLine($"{item.CustomerName} from {item.CustomerAddress}");
            }


        }

        private static void EmpDeptJoin()
        {
            string query = "SELECT empname, department.DeptName FROM Department INNER JOIN employee ON department.DEPTID = Employee.DEPTID";
            SqlCommand sqlCommand = new SqlCommand(query, con);

            try
            {
                con.Open();
               var reader=  sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmpName"]} - {reader["deptname"]}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private static void deleteUsingConnected()
        {

            int id = Utilities.GetNumber("Enter the ID you want to delete");
            string query = $"delete from employee where empid = {id}";

            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private static void insertRecord()
        {
            string name = Utilities.Prompt("Enter the name");
            string address = Utilities.Prompt("Enter the address");
            int salary = Utilities.GetNumber("Enter the salary");
            int deptid = Utilities.GetNumber("Enter the deptID");
            int mgrid = Utilities.GetNumber("Enter the MgrId");
            string query = $"insert into employee values ('{name}','{address}','{salary}','{deptid}','{mgrid}')" ;
            
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}