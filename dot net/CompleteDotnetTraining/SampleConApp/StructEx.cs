using System;


namespace SampleConApp
{
    struct Employee1
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }

        public string GetDetails()
        {
            return $"The employee id {EmpId} with name {EmpName} from {EmpAddress} with Salary of Rs. {EmpSalary}";
        }

    }
    class StructEx
    {
        static void Main(string[] args)
        {
            Employee1 emp = new Employee1 { EmpId = 3328, EmpAddress = "Gokak", EmpName = "Prajit", EmpSalary = 45000 };
            Console.WriteLine(emp.GetDetails());
        }
    }
}
