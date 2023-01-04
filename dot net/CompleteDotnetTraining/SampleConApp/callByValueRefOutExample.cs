using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class MathComponent
    {
        public long AddFunction(int ival1,int ivalv2)
        {
            long result = ival1 + ivalv2;
            return result;
        }
        public void MathFunc(double v1,double v2,out double addedvalue,out double subValue,out double mulvalue,out double divValue)
        {
            addedvalue = v1 + v2;
            subValue = v1 - v2;
            mulvalue = v1 * v2;
            if (v2 != 0) divValue = v1 / v2;
            else throw new DivideByZeroException();
        }
        public void SquareBasedFunc(int inputValue,ref double squareValue,ref double sqrtValue)
        {
            squareValue = inputValue * inputValue;
            sqrtValue = Math.Sqrt(inputValue);
        }

        public long MultiplyValues(params int[] values)
        {
            long result = 1;
            foreach (int item in values)
            {
                result *= item;
            }
            return result;
        }
    }
    class callByValueRefOutExample
    {
        static void Main(string[] args)
        {
            MathComponent component = new MathComponent();
            //int iVal1 = 9;
            //double fVal = 0, sVal = 0;
            //component.SquareBasedFunc(iVal1, ref fVal, ref sVal);
            //Console.WriteLine($"The Fval :{fVal} and Sval : {sVal} ");

            //int firstVal = 2, secondVal = 10;
            //double add, sub, mul, div;
            //component.MathFunc(firstVal, secondVal, out add, out sub, out mul, out div);
            //Console.WriteLine($"The Addeed Value :{add}\nSubtracted value :{sub}\nMultiplied Value: {mul}\nDivided Value : {div}");

            long mulValueParms = component.MultiplyValues(1, 2, 3, 4);
            Console.WriteLine(mulValueParms);
        }
    }
}
