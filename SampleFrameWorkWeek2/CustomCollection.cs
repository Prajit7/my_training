using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2
{
    class CutomerArray: IEnumerable
    {
        List<string> names = new List<string>();

        public void AddCustomer(string name) => names.Add(name);

        public IEnumerator GetEnumerator()
        {
           // return names.GetEnumerator();
            foreach (var item in names)
                yield return item;
            {

            }
        }

        public void RemoveCustomer(int id)
        {
            if (id > names.Count)
                throw new Exception("ID is not present");
            names.RemoveAt(id);
        }

        public string this[int index]
        {
            get
            {
                return names[index];
            }
            set
            {
                if (index < names.Count)
                    names[index] = value;

            }
        }
        public int NamesCount => names.Count;
    }
    class CustomCollection
    {
        static void Main(string[] args)
        {
            CutomerArray cstName = new CutomerArray();
            cstName.AddCustomer("Prajit");
            cstName.AddCustomer("Ashwin");
            cstName.AddCustomer("Shrihari");
            cstName.AddCustomer("Shrinidhi");

            foreach (var item in cstName)                        //line no. 16
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < cstName.NamesCount; i++)        //line no. 33
            {
                string old = cstName[i];
                cstName[i] = "Hello " + old;
                Console.WriteLine(cstName[i]);

            }

        }
    }
}
