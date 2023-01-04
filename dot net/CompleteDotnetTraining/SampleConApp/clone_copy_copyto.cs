using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class clone_copy_copyto
    {
        public static void Main(string[] args)
        {
            string s1 = "Hello ";
            string s2 = (String)s1.Clone();
            Console.WriteLine(s1);
            Console.WriteLine(s2);

            string name = "Prajit ";
            string snameCopy = string.Copy(name);
            Console.WriteLine(name);
            Console.WriteLine(snameCopy);

            string demo = "Hello C#, How Are You?";
            char[] ch = new char[15];
            demo.CopyTo(10, ch, 0, 12);
            Console.WriteLine(ch);
        }
    }
    }
    

