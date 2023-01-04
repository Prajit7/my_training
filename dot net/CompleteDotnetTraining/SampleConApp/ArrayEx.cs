using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class ArrayEx
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many names you want to store in Array");

            int len = Convert.ToInt32( Console.ReadLine());
            string[] names = new string[len];

            Console.WriteLine("Enter the names");
            for (int i = 0; i < len; i++)
            {
                names[i] = Console.ReadLine();
            }
            //string[] names = { "Prajit", "Shrihari", "Ashwin", "Hemanth", "Anagha" };

            //Console.WriteLine("The size:"+ names.Length);
            //Console.WriteLine("The dimensions:"+ names.Rank);
            //Console.WriteLine("The Length of !st dim :"+ names.GetLength(0));

            //Iterate
            foreach (string name in names)
            {
                Console.WriteLine(name);
               
            }


            //------------------------Multi-Dim Array-------------------

            int[,] data = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            for (int i = 0; i < data.GetLength(0); i++)
            {
                string row = "";
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    row += data[i, j] + " ";
                }
                Console.WriteLine(row.TrimEnd());
                Console.WriteLine();
            }

        }
    }
}
