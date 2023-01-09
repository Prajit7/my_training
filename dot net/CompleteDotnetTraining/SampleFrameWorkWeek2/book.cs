using System;
using System.IO;

namespace SampleConApp
{
    class Details
    {
        public int Bookid { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public double Bookprice { get; set; }
    }
    class AccountMgr
    {
        private Details[] _books = null;
        private int _size = 0;
        public AccountMgr(int size)
        {
            _size = size;
            _books = new Details[_size];

        }
        public void AddNewBook(Details det)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] == null)
                {
                    _books[i] = new Details { Bookid = det.Bookid, BookAuthor = det.BookAuthor, BookName = det.BookName, Bookprice = det.Bookprice };
                    return;
                }
            }
        }
        public void UpdateBook(Details det)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] != null && _books[i].Bookid == det.Bookid)
                {
                    //_books[i].Bookid = det.Bookid;
                    _books[i].BookName = det.BookName;
                    _books[i].BookAuthor = det.BookAuthor;
                    _books[i].Bookprice = det.Bookprice;
                    return;
                }

            }
            throw new Exception("Not Found!");
        }
        public void DeleteBook(string BookName)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] != null && _books[i].BookName == BookName)
                {
                    _books[i] = null;
                    return;
                }

            }
            throw new Exception("Not Found!");
        }


    }


    class bookDetails
    {
        int id;
        string bName, bAuthor;
        double price;

        public int BookId
        {
            get { return id; }
            set { id = value; }
        }
        public string BookName
        {
            get { return bName; }
            set { bName = value; }
        }
        public string BookAuthor
        {
            get { return bAuthor; }
            set { bAuthor = value; }
        }
        public double BookPrice
        {
            get { return price; }
            set { price = value; }
        }
    }
    class UIManager
    {
        public static AccountMgr mgr = null;

        internal static void DisplayMenu(string file)
        {
            int size = Utilities.GetNumber("Enter the Size");
            mgr = new AccountMgr(size);
            bool processing = true;
            string menu = File.ReadAllText(file);
            do
            {
                int choice = Utilities.GetNumber(menu);
                processing = processMenu(choice);
            } while (processing);
        }
        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    addingBookHelper();
                    break;
                case 2:
                    updateHelper();
                    break;
                case 3:
                  
                    break;
                case 4:
                    
                default:
                    return false;
            }
            return true;
        }

        private static void updateHelper()
        {
            int id = Utilities.GetNumber("Enter the ID of the Book");
            string bName = Utilities.Prompt("Enter the updated name");
            string bAuthor = Utilities.Prompt("Enter the updated Author name");
            double bPrice = Utilities.GetNumber("Enter New Price");

            Details det = new Details { BookName = bName, BookAuthor = bAuthor, Bookprice = bPrice ,Bookid=id};
            mgr.UpdateBook(det);
            
           
        }

        private static void addingBookHelper()
        {
            int id = Utilities.GetNumber("Enter the Book ID");
            string name = Utilities.Prompt("Enter the Name of the Book");
            string author = Utilities.Prompt("Enter the Name of the Book Author");
            double price = Utilities.GetNumber("Enter the Book Price");

            Details acc = new Details { Bookid=id,BookName=name,BookAuthor=author,Bookprice=price};
            mgr.AddNewBook(acc);
        }
    }



        class book
        {
            static void Main(string[] args)
            {
                UIManager.DisplayMenu(args[0]);
                //bookDetails bookObj = new bookDetails { BookId = 123, BookName = "Atomic Habits", BookAuthor = "James Clear", BookPrice = 500 };
                //Console.WriteLine($"The Book name is {bookObj.BookName} from {bookObj.BookAuthor} having price of {bookObj.BookPrice}");
            }
        }
    
}

