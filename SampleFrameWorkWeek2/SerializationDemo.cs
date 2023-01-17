using SampleConApp;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace SampleFrameWorkWeek2
{
    [Serializable]
   public class Employee
    {
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int EmpID { get; set; }

        public override string ToString()
        {
            return $"{EmpName} from {EmpAddress}";
        }
    }
   
    class SerializationDemo
    {
        static void Main(string[] args)
        {
            
            int choice = Utilities.GetNumber("Press 1 for Serialization and 2 dor Deserialization\n3 for xml Serialization and 4 for Deserialization\n5 for Soap Serialization and 6 for Soap DeSerialization");
            if (choice == 1) serializeEx();
            else if (choice == 2) deSerializeEx();
            else if (choice == 3) xmlSerialize();
            else if (choice == 4) xmlDeSerialize();
            else if (choice == 5) soafSerialization();
            else if (choice == 6) soafDeSerialization();
            else Console.WriteLine("Invalid");
            
        }

        private static void soafDeSerialization()
        {
            Employee emp = null;
            FileStream fs = new FileStream("EmpSoap.xml", FileMode.Open, FileAccess.Read);
            SoapFormatter formatter = new SoapFormatter();
            emp = formatter.Deserialize(fs) as Employee;
            fs.Close();
            Console.WriteLine(emp);
        }

        private static void soafSerialization()
        {
            //Employee emp = new Employee
            //{
            //    EmpID = 141,
            //    EmpName = "Prajit",
            //    EmpAddress = "Gokak"

            //};
            Employee emp = new Employee();
            emp.EmpID = Utilities.GetNumber("Enter Emp Id");
            emp.EmpName = Utilities.Prompt("Enter name");
            emp.EmpAddress = Utilities.Prompt("Enter Address");
            

            FileStream fs = new FileStream("EmpSoap.xml", FileMode.OpenOrCreate, FileAccess.Write);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(fs, emp);
            fs.Close();
        }

        private static void xmlDeSerialize()
        {
            Employee emp = null;
            FileStream fs = new FileStream("EmpXML.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer formatter = new XmlSerializer(typeof(Employee));
            emp = formatter.Deserialize(fs) as Employee;
            fs.Close();
            Console.WriteLine(emp);
        }

        private static void xmlSerialize()
        {
            Employee emp = new Employee
            {
                EmpID = 141,
                EmpName = "Prajit",
                EmpAddress = "Gokak"

            };
            FileStream fs = new FileStream("EmpXML.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(Employee));
            formatter.Serialize(fs, emp);
            fs.Close();


        }

        private static void deSerializeEx()
        {
            Employee emp = new Employee();
            FileStream fs = new FileStream("Emp.Bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            emp = formatter.Deserialize(fs) as Employee;
            fs.Close();
            Console.WriteLine(emp);


        }

        private static void serializeEx()
        {
            Employee emp = new Employee
            {
                EmpID = 123,
                EmpName = "Prajit",
                EmpAddress = "Murdeshwar"
            };

            FileStream fs = new FileStream("Emp.Bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, emp);
            fs.Close();
        }
    }
}