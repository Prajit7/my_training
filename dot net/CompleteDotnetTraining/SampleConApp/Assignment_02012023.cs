using System;


namespace SampleConApp
{
    class Assignment_02012023
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of Array");

            int len = Convert.ToInt32(Console.ReadLine());
            int[] names = new int[len];

            Console.WriteLine("Enter the numbers");
            for (int i = 0; i < len; i++)
            {
                names[i] =Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < len; i++)
            {
                if (names[i] % 2 == 0)
                {
                    Console.WriteLine($"The number {names[i]} is even");
                }
                else
                {
                    Console.WriteLine($"The number {names[i]} is odd");
                }
            }
        }
    }
}
