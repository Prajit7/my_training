using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleADOWeek3
{


    class TransactionDemo
    {
        static readonly string strConnection = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

        private static void addEmployee(string name, string address, int salary, string deptName)
        {
            SqlTransaction transaction = null;
            SqlConnection con = new SqlConnection(strConnection);
            string cmdGetDeptId = $"Select dbo.GetDept('{deptName}') as DeptId";
            string cmdInsertDept = "InsertDept";
            int depId = 0;
            try
            {
                con.Open();
                transaction = con.BeginTransaction();
                //1
                SqlCommand cmd1 = new SqlCommand(cmdGetDeptId, con, transaction);
                depId = (int)cmd1.ExecuteScalar();

                if (depId == 0)
                {
                    SqlCommand cmd2 = new SqlCommand(cmdInsertDept, con, transaction);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@deptName", deptName);
                    cmd2.Parameters.AddWithValue("@deptId", depId);
                    cmd2.Parameters[1].Direction = ParameterDirection.Output;
                    cmd2.ExecuteNonQuery();
                    depId = (int)cmd2.Parameters[1].Value;
                }
                SqlCommand cmd3 = new SqlCommand("InsertEmployee", con, transaction);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.AddWithValue("@empName", name);
                cmd3.Parameters.AddWithValue("@empAddress", address);
                cmd3.Parameters.AddWithValue("@empSalary", salary);
                cmd3.Parameters.AddWithValue("@deptId", depId);
                cmd3.Parameters.AddWithValue("@empId", 0);
                cmd3.Parameters.AddWithValue("@mgrId", 1004);
                cmd3.Parameters[4].Direction = ParameterDirection.Output;
                cmd3.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("The Employee has been added to the database with an ID generated as " + cmd3.Parameters[4].Value);


            }
            catch (Exception ex)
            {

                if (transaction != null)
                    transaction.Rollback();
                throw ex;

            }
        }



        class TranscationExample
        {

            static void Main(string[] args)
            {
                string name = Utilities.Prompt("Enter your name");
                string address = Utilities.Prompt("Enter the address");
                int salary = Utilities.GetNumber("Enter the address");
                string dept = Utilities.Prompt("Enter the Department name");

                addEmployee(name,address,salary,dept);


            }
        }
    }
}
