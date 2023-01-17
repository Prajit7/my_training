using SampleADOWeek3;
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
    class Patient
    {
        public int patientId { get; set; }
        public string patientName { get; set; }
        public string patientAddress { get; set; }
        public string bloodGrp { get; set; }
        public int providerId { get; set; }
    }
    class Providers
    {
        public int providerId { get; set; }
        public string providerName { get; set; }
        public string treatmentName { get; set; }
    }
    interface IDataAccessComponent
    {
        void AddNewPatient(Patient pat);
        void UpdatePatient(Patient pat);
        void DeletePatient(int id);
        void AddProviders(Providers pd);
        List<Providers> GetAllProvider();

    }
    class DataComponent : IDataAccessComponent
    {
        private string strCon = string.Empty;
        const string STRINSERT = "Insert into PATIENT values(@patName,@patAddress,@bldGrp,@prdId)";
        const string STRUPDATE = "Update PATIENT Set PATIENTNAME=@patName,PATIENTADDRESS=patAdd,BLOODGROUP=bldGrp,PROVIDERID=@prdId WHERE PATIENTID = @patId";
        const string STRPROVIDER = "Insert into PROVIDERS values(@prdName,@prdTrt)";
       
        const string STRDELETE = "DELETE FROM PATIENT WHERE PATIENTID = @patId";

        const string STRALLPROVIDERS = "SELECT * FROM PROVIDERS";


        private void NonQueryExecute(string query, SqlParameter[] parameters, CommandType type)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = type;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        private DataTable GetRecords(string query, SqlParameter[] parameters, CommandType type = CommandType.Text)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = type;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable("Records");
                table.Load(reader);
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataComponent(string connectionString)
        {
            strCon = connectionString;
        }


        public void AddNewPatient(Patient pat)
        {
            List<SqlParameter> paramater = new List<SqlParameter>();
            paramater.Add(new SqlParameter("@patName", pat.patientName));
            paramater.Add(new SqlParameter("@patAddress", pat.patientAddress));
            paramater.Add(new SqlParameter("@bldGrp", pat.bloodGrp));
            paramater.Add(new SqlParameter("prdId", pat.providerId));
            try
            {
                NonQueryExecute(STRINSERT, paramater.ToArray(), CommandType.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void AddProviders(Providers pd)
        {
            List<SqlParameter> paramater = new List<SqlParameter>();
            paramater.Add(new SqlParameter("@prdName", pd.providerName));
            paramater.Add(new SqlParameter("@prdTrt", pd.treatmentName));
           

            try
            {
                NonQueryExecute(STRPROVIDER, paramater.ToArray(), CommandType.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                }
            }

        public void DeletePatient(int id)
        {
            List<SqlParameter> sqlP = new List<SqlParameter>();
            sqlP.Add(new SqlParameter("@patId", id));

            try
            {
                NonQueryExecute(STRDELETE, sqlP.ToArray(), CommandType.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdatePatient(Patient pat)
        {
            List<SqlParameter> paramater = new List<SqlParameter>();
            paramater.Add(new SqlParameter("@patName", pat.patientName));
            paramater.Add(new SqlParameter("@patAddress", pat.patientAddress));
            paramater.Add(new SqlParameter("@bldGrp", pat.bloodGrp));
            paramater.Add(new SqlParameter("prdId", pat.providerId));
            

            try
            {
                NonQueryExecute(STRUPDATE, paramater.ToArray(), CommandType.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Providers> GetAllProvider()
        {
            var table = GetRecords(STRALLPROVIDERS, null);
            List<Providers> provider = new List<Providers>();
            foreach (DataRow row in table.Rows)
            {
                Providers prd = new Providers
                {
                    providerId = Convert.ToInt32(row[0]),
                    providerName = row[1].ToString(),
                    treatmentName = row[2].ToString()
                };
                provider.Add(prd);
            }
            return provider;
        }
    }
    class UIManager
    {
        static IDataAccessComponent component = null;
        static string connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
       
        internal static void DisplayMenu()
        {
            component = new DataComponent(connectionString);
            bool processing = true;
            string menu = "Press 1 to Add Patient \nPress 2 to Add Providers \nPress 3 to Remove Patient\nPress Other Key to Exit";
            do
            {
                int choice = Utilities.GetNumber(menu);
                processing = processMenu(choice);
            } while (processing);
        }
        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddPatient();
                    break;
                case 2:
                    AddProviders();
                    break;
                case 3:
                    Removepatient();
                    break;
                case 4:
                    UpdatePatient();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void UpdatePatient()
        {
            int patId = Utilities.GetNumber("Enter the Patient Id you want to update");
            string pName = Utilities.Prompt("Enter the Patient Name");
            string pAdd = Utilities.Prompt("Enter the Address");
            string pBlood = Utilities.Prompt("Enter the Blood Group");
            var data = component.GetAllProvider();
            foreach (var pt in data)
                Console.WriteLine($"Press {pt.providerId} for {pt.providerName} used to treat {pt.treatmentName}");
            int pId = Utilities.GetNumber("Enter the Provider Id");




            component.UpdatePatient(new Patient
            {
                patientId = patId,
                patientName = pName,
                patientAddress = pAdd,
                bloodGrp = pBlood,
                providerId = pId

            });
        }

        private static void Removepatient()
        {
            int pID = Utilities.GetNumber("Enter the Patient Id you want to delete");
            component.DeletePatient(pID);

        }

        private static void AddProviders()
        {
            var data = component.GetAllProvider();
            foreach (var pt in data)
                Console.WriteLine($"Press {pt.providerId} for {pt.providerName} used to treat {pt.treatmentName}");
            component.AddProviders(new Providers
            {
                providerName = Utilities.Prompt("Enter the Provider Name"),
                treatmentName = Utilities.Prompt("Enter the treatmentName"),

            });
        }

        private static void AddPatient()
        {
            string pName = Utilities.Prompt("Enter the Patient Name");
            string pAdd = Utilities.Prompt("Enter the Address");
            string pBlood = Utilities.Prompt("Enter the Blood Group");
            var data = component.GetAllProvider();
            foreach (var pt in data)
                Console.WriteLine($"Press {pt.providerId} for {pt.providerName} used to treat {pt.treatmentName}");
            int pId = Utilities.GetNumber("Enter the Provider Id");
           
            


            component.AddNewPatient(new Patient
            {
                patientName =pName ,
                patientAddress = pAdd,
                bloodGrp =pBlood,
                providerId = pId
               
            });

        }
    }
    


    class E2EPatient
    {
       
        static void Main(string[] args)

        {
            UIManager.DisplayMenu();

       

        }
    }
}

