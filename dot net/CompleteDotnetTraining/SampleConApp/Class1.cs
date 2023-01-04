using System;

namespace SampleConApp
{
    class Class1
    {
        static void Main()
        {
            Console.WriteLine($"The range of byte is {byte.MinValue} to {byte.MaxValue}");

            Console.WriteLine($"The range of int is {int.MinValue} to {int.MaxValue}");

            Console.WriteLine($"The range of long is {long.MinValue} to {long.MaxValue}");

            int i = 5;
            long l = i;
            //i = (int)(l);
            checked
            {
                //i = (int)(l);
            }
            i = Convert.ToInt32(l); //use
            Console.WriteLine(i);

        }
    }
}
