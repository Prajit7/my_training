using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleConApp;

namespace SampleFrameWork.Practical
{
    class BillFinal
    {
        private static int i = 0;
        public int BillNo { get; set; } = ++i;
        public DateTime BillDate = DateTime.Now;

        public int BillHolder { get; set; }

        public int BillAmt { get; set; }

        
       
    }

    class Item:BillFinal
    {
       
        SortedList<int, string> Particulars = new SortedList<int, string>();
        public int Id { get; set; }
        public int Unitprice { get; set; }
        public int Quantity { get; set; }

        public void SetParticular()
        {
            Particulars.Add(1,"Apple");
            Particulars.Add(2,"Mango");
            Particulars.Add(3,"Banana");
            Particulars.Add(4,"Kiwi");
            Particulars.Add(5,"Custard Apple");
            

        }
        public void Display()
        {
            foreach (var item in Particulars)
            {

                Console.WriteLine($"For {item.Key} press {item.Value}");
            }

        }

       
        SortedList<string, int> TotalSelected = new SortedList<string, int>();
        List<int> TotalAmt = new List<int>();

        public void SetPrice(int id, int ItemQuantity)
        {
            Stack<double> amount = new Stack<double>();
            Console.WriteLine("Selected Items");
            foreach (var item in Particulars)
            {
                if (item.Key == id)
                {
                    Console.WriteLine(item.Value + "-" + ItemQuantity);
                    TotalSelected.Add(item.Value, ItemQuantity);
                    switch (id)
                    {
                        case 1:
                            TotalAmt.Add(120 * ItemQuantity);
                           
                           
                            break;
                        case 2:
                            TotalAmt.Add(140 * ItemQuantity);
                            

                            break;
                        case 3:
                            TotalAmt.Add(160 * ItemQuantity);
                           
                            break;
                        default:
                            
                            Console.WriteLine("Not a Valid Option");
                            break;
                    }
                  
                    foreach (var Amt in TotalAmt)
                    {
                        Console.WriteLine(Amt);
                        
                    }
    
                }

            }


        }
        public void displayBill()
        {
            foreach (var item in TotalSelected)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($" {BillNo} on {BillDate} with total amount of {TotalAmt.Sum()}");

        }


        //public void totalBill()
        //{

        //    foreach (var item in TotalSelected)
        //    {
        //        Console.WriteLine(item);
        //    }
          

        //}


    }

    class Bill
    {
        static void Main(string[] args)
        {
            Example:
            Item SelectedItem = new Item();
            BillFinal billFinal = new BillFinal();


            SelectedItem.SetParticular();
            string CustName = Utilities.Prompt("Enter your Name");
            Console.WriteLine("This is our Menu");
        Demo:
            SelectedItem.Display();


            int ItemId = Utilities.GetNumber("Enter Id");
            int ItemQuantity = Utilities.GetNumber("Enter Quantity");

            SelectedItem.SetPrice(ItemId, ItemQuantity);
            int choice = Utilities.GetNumber("Enter 1 to continue");
            if (choice == 1) goto Demo;
            //SelectedItem.totalBill();
            Console.Clear();
            SelectedItem.displayBill();
            goto Example;
           // SelectedItem.totalBillAmount();








        }
    }

}
