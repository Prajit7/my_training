using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class MathCalc02012023
    {
        static void Main(string[] args)
        {
            double num1, num2, oper;
            while (true)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Basic Calculator");
                Console.WriteLine("Press 1.Addition, 2.Subtraction, 3.Multiplication, 4. Division 5.Exit");
                Console.WriteLine("-----------------------------");
                oper = Convert.ToInt32(Console.ReadLine());

                if(oper==5) System.Environment.Exit(0);

                Console.WriteLine("Enter the First number");
                num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the Second number");
                num2 = Convert.ToDouble(Console.ReadLine());

                switch (oper)
                {
                    case 1:
                        Console.WriteLine("The Addition of  {0} and {1} is: {2}", num1, num2, num1 + num2);
                        break;

                    case 2:
                        Console.WriteLine("The addition of {0} and {1} is {2} ", num1, num2, num1 - num2);
                        break;
                    case 3:
                        Console.WriteLine("The addition of {0} and {1} is {2}", num1, num2, num1 * num2);
                        break;
                    case 4:
                        if (num2 == 0) Console.WriteLine("Cannot Divide by zero");
                        else Console.WriteLine("The addition of {0} and {1} is {2} ", num1, num2, num1 / num2);
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;
                }
            }
            } 

            }
        }
   

