using System;

namespace SampleConApp
{
    class Ex1Sample
    {
        static void Main()
        {
            Console.WriteLine("C# code by Praj");

            Console.WriteLine("Enter the name");
            string name =  Console.ReadLine();

            Console.WriteLine("Enter the address");
            string add = Console.ReadLine();

            Console.WriteLine("Enter the salary");
            string sal = Console.ReadLine();

            Console.WriteLine("Enter the age");
            //double age =Convert.ToInt64(Console.ReadLine());
           // if (age > 18)
            //{
           //     Console.WriteLine("Can Ride bike");
           // }
           

            Console.WriteLine("The name is " + name + "\nThe Address is " + add + "\nThe salary is " + sal);

            Console.WriteLine($"The name is {name} from {add} and salary is {sal}");
        }
    }
}
