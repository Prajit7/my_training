using SampleConApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2
{
    delegate double ArithmaticOperation(double v1, double v2);

    class MathComponent
    {
        public static void PerformOperation(ArithmaticOperation oper)
        {
            var v1 = double.Parse(Utilities.Prompt("Enter the first Value"));
            var v2 = double.Parse(Utilities.Prompt("Enter the Second Value"));
            //var res = oper(v1, v2);
            Delegate[] allOperation = oper.GetInvocationList();
            foreach (Delegate item in allOperation)
            {
                Console.WriteLine(item.Method.Name);
                Console.WriteLine("The result is " + item.DynamicInvoke(v1,v2));
            }
           
        }
    }
    class DeligatesExample
    {
        static double mulFunc(double first,double second)
        {
            return first * second;
        }
        static void Main(string[] args)
        {
            //delegateEx();
           multiDelegates();
           

           

        }

        private static void multiDelegates()
        {
            //multicast Delegates
            ArithmaticOperation operation = new ArithmaticOperation(mulFunc);
            operation += new ArithmaticOperation(delegate (double v1, double v2)
            {
                return v1 - v2;

            });
            operation += new ArithmaticOperation(delegate (double v1, double v2)
            {
                return v1 + v2;

            });
             operation -= new ArithmaticOperation(delegate (double v1, double v2)
            {
                return v1 / v2;

            });         //-= Removes the last
            MathComponent.PerformOperation(operation);
        }

        private static void delegateEx()
        {
            MathComponent.PerformOperation(new ArithmaticOperation(mulFunc));//Basic version
            MathComponent.PerformOperation(delegate (double v1, double v2)
            {
                return v1 + v2;
            });//Simplified version
            MathComponent.PerformOperation((v1, v2) => v1 - v2);
        }
    }
}
