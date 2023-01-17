using System;
using System.Data;
using System.Data.SqlClient; 


namespace SampleADOWeek3
{
    class Utilities
    {
        internal static string Prompt(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        internal static int GetNumber(string question)
        {
            return int.Parse(Prompt(question));
        }
    }
    static class Database
    {
        const string STRCONNECTION = "Data Source=192.168.171.36;Initial Catalog=3328;Integrated Security=True";
        const string STRQUERY = "Select * from EMPLOYEE";

        public static DataTable GetAllRecords()
        {
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRQUERY, sqlCon);

            try
            {
                sqlCon.Open();
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable("EmpRecords");
                table.Load(reader);
                return table;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }


        }
    }
    class SqlConnectionDemo
    {
        const string STRCONNECTION = "Data Source=192.168.171.36;Initial Catalog=3328;Integrated Security=True";
        const string STRQUERY = "Select * from EMPLOYEE";
        const string STRFIND = "INSERT INTO EMPLOYEE VALUES(@name,@address, @salary,@dept,@mgrid)";
        

        static void Main(string[] args)
        {
            // readingData();
            //displayAstable();
            //displayDetails("Gannie Penner");

            //displayDetailsParameter("Gannie Penner");
            string name = Utilities.Prompt("Enter the name you want to add");
            string address = Utilities.Prompt("Enter the address you want to add");
            int salary = Utilities.GetNumber("Enter the salary you want to add");
            int dept = Utilities.GetNumber("Enter the dept you want to add");
            //int mgr = Utilities.GetNumber("Enter the mgrID you want to add");

            //addNewRecord(name,address,salary,dept, mgr);
            //displayAstable();

            //addNewRecordInputs();
            //displayAstable();

            addNewRecordStoredProcdure(name,address,salary,dept);


        }

        private static void addNewRecordStoredProcdure(string name,string address,int salary,int deptId)
        {
            const string STRSTORPROC = "InsertEmployee";
            int empId = 0;
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand sqlCmd = new SqlCommand(STRSTORPROC, sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@empName", name);
            sqlCmd.Parameters.AddWithValue("@empAddress", address);
            sqlCmd.Parameters.AddWithValue("@empSalary", salary);
            sqlCmd.Parameters.AddWithValue("@deptId", deptId);
            sqlCmd.Parameters.AddWithValue("@mgrId", 1004);
            sqlCmd.Parameters.AddWithValue("@empId", empId);
            
            sqlCmd.Parameters[5].Direction = ParameterDirection.Output;
            try
            {
                sqlCon.Open();
                sqlCmd.ExecuteNonQuery();
                empId = Convert.ToInt32(sqlCmd.Parameters[5].Value);
                Console.WriteLine("The empid of added is "+empId);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
        

        private static void addNewRecordInputs()
        {
            string query = $"SELECT * FROM DEPARTMENT ";
            SqlCommand cmd = new SqlCommand(query, new SqlConnection(STRCONNECTION));

           
                cmd.Connection.Open();
                SqlDataReader sql = cmd.ExecuteReader();                    //using query
                while (sql.Read())
                {
                    Console.WriteLine($"{sql[1]}");
                    //Console.WriteLine(sql["EMPADDRESS"]);
                }
            string deptName = Utilities.Prompt("Enter the dept name");
            addDept(deptName);



            }

        private static void addDept(string deptName)
        {
            string query = $"SELECT DeptId from DEPARTMENT where DeptName like '%{deptName}%'";
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            //var table = Database.GetAllRecords(); ;
           
            try
            {
                sqlCon.Open();
                SqlDataReader sql = cmd.ExecuteReader();                    //using query
                while (sql.Read())
                {
                    //Console.WriteLine($"{sql[0]}");
                    int id =Convert.ToInt32( sql[0]);
                    //Console.WriteLine(id);

                    addToEmp(id);
                    //Console.WriteLine(sql["EMPADDRESS"]);
                }

            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }




        }

        private static void addToEmp(int id)
        {
            string name = Utilities.Prompt("Enter the name you want to add");
            string address = Utilities.Prompt("Enter the address you want to add");
            int salary = 2000;   
            int mgr = Utilities.GetNumber("Enter the mgrID you want to add");
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand sqlCommand = new SqlCommand(STRFIND, sqlCon);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@address", address);
            sqlCommand.Parameters.AddWithValue("@salary", salary);
            sqlCommand.Parameters.AddWithValue("@dept", id);
            sqlCommand.Parameters.AddWithValue("@mgrid", mgr);

            try
            {
                sqlCon.Open();
                var rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }

        }

        private static void addNewRecord(string name, string address, int salary, int dept,int mgrID)
        {
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand sqlCommand = new SqlCommand(STRFIND, sqlCon);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@address", address);
            sqlCommand.Parameters.AddWithValue("@salary", salary);
            sqlCommand.Parameters.AddWithValue("@dept", dept);
            sqlCommand.Parameters.AddWithValue("@mgrid", mgrID);

            try
            {
                sqlCon.Open();
                var rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
            
        }

        private static void displayDetailsParameter(string name)
        {
            SqlCommand cmd = new SqlCommand(STRFIND, new SqlConnection(STRCONNECTION));
            try
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EMPNAME"]} from {reader[2]} has {reader[3]}");
                    //Console.WriteLine(sql["EMPADDRESS"]);
                }


            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            

        }

        private static void displayDetails(string name)
        {
            string query = $"SELECT * FROM EMPLOYEE WHERE EmpName LIKE '%{name}%'";
          
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            var table = Database.GetAllRecords(); ;
            //foreach (DataRow row in table.Rows)                   //matching using if
            //{
            //    if (row[1].ToString() == name)
            //    {
            //        Console.WriteLine($"EmpNAme: {row[1]}\nEmpAddress: {row[2]}\nEmpSalary:{row[3]:c}\n");

            //    }

            //}
            try
            {
                sqlCon.Open();
                SqlDataReader sql = cmd.ExecuteReader();                    //using query
                while (sql.Read())
                {
                    Console.WriteLine($"{sql["EMPNAME"]} from {sql[2]}");
                    //Console.WriteLine(sql["EMPADDRESS"]);
                }

            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }




        }

        private static void displayAstable()
        {
            try
            {
                var table = Database.GetAllRecords(); ;
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"EmpNAme: {row[1]}\nEmpAddress: {row[2]}\nEmpSalary:{row[3]:c}\n");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           

            
        }

        private static void readingData()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = STRCONNECTION;

            SqlCommand sqlCommand = sqlCon.CreateCommand();
            sqlCommand.CommandText = STRQUERY;

            try
            {
                sqlCon.Open();
                SqlDataReader sql = sqlCommand.ExecuteReader();
                while (sql.Read())
                {
                    Console.WriteLine($"{sql["EMPNAME"]} from {sql[2]}");
                    //Console.WriteLine(sql["EMPADDRESS"]);
                }

            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlCon.State == System.Data.ConnectionState.Open) sqlCon.Close();
            }
        }
    }
}
