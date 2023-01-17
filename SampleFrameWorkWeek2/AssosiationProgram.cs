using SampleConApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameWorkWeek2
{
    class Bill
    {
        private static int i = 0;
        public int BillNo { get; set; } = ++i;
        public DateTime currentDate { get; set; }
        public string BillHolder { get; set; }
        public double BillAmount { get; set; }
        

    }
    class Item
        
    {
  
        SortedList<int, string> particular = new SortedList<int, string>();
        public int id { get; set; }
        public string Particular { get; set; }
        public int unitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        

        public void item()
        {
            particular.Add(1, "Apple");
            particular.Add(2, "Mango");
            particular.Add(3, "Banana");
            particular.Add(4, "Tomato");
            particular.Add(5, "Potato");
            particular.Add(6, "Chilly");

            foreach (var item in particular)
            {
                Console.WriteLine(item.Value);
            }
        }

        
    }
    class AssosiationProgram
    {
        static void Main(string[] args)
        {
           var uname = Utilities.Prompt("Enter your name");
            Console.WriteLine("Select the item");

            Item name = new Item();
            name.item();
            var userInput = Utilities.Prompt("Enter the item");
            var quantity = Utilities.GetNumber("Enter the quantity");
            SortedList<string,int> lstItem = new SortedList<string,int>();
            lstItem.Add(userInput,quantity);

            





        }
    }
}
