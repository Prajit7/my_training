using System;


namespace SampleConApp
{
    class Array_dy02012023
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the CTS equivalent of type");
            string typeName = Console.ReadLine();

            Type type = Type.GetType(typeName, true, true);
            Array myArray = Array.CreateInstance(type, size);

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter the value of the type{type.Name}");
                string enteredValue = Console.ReadLine();
                object convertedValue = Convert.ChangeType(enteredValue, type);
                myArray.SetValue(convertedValue, i);
            }
            Console.WriteLine("All values are set");
            foreach (object item in myArray)
            {
                Console.WriteLine(item);
            }


            

        }
    }
}
