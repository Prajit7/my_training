using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2
{
    class SortedDictionaryDemo
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, long> phoneNo = new SortedDictionary<string, long>();
            phoneNo.Add("Prajit", 9480409992);
            phoneNo.Add("Ashwin", 8660476367);
            phoneNo.Add("Shrihari", 8618333482);
            phoneNo.Add("Zen", 8147007697);
            

            foreach (var item in phoneNo)
            {
                Console.WriteLine(item.Key);
            }

        }
    }
}
