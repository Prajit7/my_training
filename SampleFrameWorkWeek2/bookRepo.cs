using System;//Default APIs
using Entities;//For the Entity class
using Repository;//Repo class
using SampleConApp; //Utilities

namespace Entities
{
    class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public int BookStock { get; set; } = 10;

        public void ShallowCopy(Book copy)
        {
            this.BookId = copy.BookId;
            this.BookStock = copy.BookStock;
            this.BookTitle = copy.BookTitle;
            this.Price = copy.Price;
            this.Publisher = copy.Publisher;
            this.Author = copy.Author;
        }

        public Book DeepCopy(Book copy)
        {
            Book book = new Book();
            book.ShallowCopy(copy);
            return book;
        }
    }
}
//datatype [] identifier = new datatype[size]
namespace Repository
{
    class BookRepository
    {
        private Book[] _books = null;
        private readonly int _size = 0;
        public BookRepository(int size)
        {
            _size = size;
            _books = new Book[_size];
        }

        public int AddNewBook(Book book)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] == null)
                {
                    _books[i] = book.DeepCopy(book);
                    return 1;//To exit
                }
            }
            return _size;
        }

        public void UpdateBook(Book book)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] != null && _books[i].BookId == book.BookId)
                {
                    _books[i].ShallowCopy(book);
                    return;//To exit
                }
            }
            throw new Exception("No book found to update");
        }

        public void RemoveBook(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_books[i] != null && _books[i].BookId == id)
                {
                    _books[i] = null;
                    return;//To exit
                }
            }
            throw new Exception("No book found to remove");
        }

        public Book[] FindByAuthor(string author)
        {
            int count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.Author.Contains(author))
                {
                    count += 1;
                }
            }
            Book[] books = new Book[count];
            count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.Author.Contains(author))
                {
                    books[count] = book.DeepCopy(book);
                    count += 1;
                }
                throw new Exception("No Book Found");
            }
            return books;
        }

        public Book[] FindByTitle(string title)
        {
            int count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.BookTitle.Contains(title))
                {
                    count += 1;
                }
            }
            Book[] books = new Book[count];
            count = 0;
            foreach (Book book in _books)
            {
                if (book != null && book.BookTitle.Contains(title))
                {
                    books[count] = book.DeepCopy(book);
                    count += 1;
                }
                throw new Exception("No Book Found");
            }
            return books;
        }
    }
}

namespace UILayer
{
    enum Options
    {
        Add = 1, Remove=5, Author=3, Title=4, Update=2
    }
    class UIComponent
    {
        public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~BOOK STORE MANAGER SOFTWARE~~~~~~~~~~~~~~~~~~~\nTO ADD NEW BOOK------------------------>PRESS 1\nTO UPDATE EXISTING BOOK---------------->PRESS 2\nTO FIND BOOK BY AUTHOR----------------->PRESS 3\nTO FIND BOOK BY TITLE------------------>PRESS 4\nTO DELETE BOOK------------------------->PRESS 5\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";

        private static BookRepository repo;

        public static void Run()
        {
            int size = Utilities.GetNumber("Enter the no of Books U need for the Store");
            repo = new BookRepository(size);
            bool processing = true;
            do
            {
                Options option = (Options)Utilities.GetNumber(menu);
                processing = processMenu(option);
            } while (processing);
            Console.WriteLine("Thanks for Using our Application!!!");
        }

        private static bool processMenu(Options option)
        {
            switch (option)
            {
                case Options.Add:
                    AddBookHelper();
                   
                    break;
                case Options.Remove:
                    RemoveBookHelper();
                    break;
                case Options.Author:
                    FindByAuthor();
                    break;
                case Options.Title:
                    FindByTitle();
                    break;
                case Options.Update:
                    UpdatedBook();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void UpdatedBook()
        {
            int bookId = Utilities.GetNumber("Enter the book Id");
            string bookName = Utilities.Prompt("Enter the new name");
            string bookAuthor = Utilities.Prompt("Enter the name of the Author");
            double bookPrice = Utilities.GetNumber("Enter the Price of the book");
            string bookPublisher = Utilities.Prompt("Enter the Publisher name");
            int bookStocks = Utilities.GetNumber("Enter the stocks");
            Book book = new Book {BookId=bookId, BookTitle = bookName, BookStock = bookStocks, Author = bookAuthor, Price = bookPrice, Publisher = bookPublisher };
            repo.UpdateBook(book);


        }

        private static void FindByTitle()
        {

            //Book book = new Book();
            //string Title = Utilities.Prompt("Enter the Title Name");
            //book.BookTitle = Title;
            //repo.FindByTitle(Title);
            string title = Utilities.Prompt("Enter the Title Name");
            try
            {
               
                Book[] titleName = repo.FindByTitle(title);

                foreach (Book item in titleName)
                {
                    Console.WriteLine($"The book id is {item.BookId} and name is {item.BookTitle} and price is {item.Price}");
                }

              
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           

        }

        private static void FindByAuthor()
        {

            //Book book = new Book();
            //string Author = Utilities.Prompt("Enter the Author Name");
            //book.Author = Author;
            //repo.FindByTitle(Author);
            //Utilities.Prompt("Press Enter to clear the Screen");
            //Console.Clear();
            try
            {
                string author = Utilities.Prompt("Enter the Author Name");
                Book[] auth = repo.FindByAuthor(author);

                foreach (Book item in auth)
                {
                    Console.WriteLine($"The book id is {item.BookId} and name is {item.BookTitle} and price is {item.Price}");
                }
            
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           


        }

        private static void RemoveBookHelper()
        {
            int bookId = Utilities.GetNumber("Enter the ID of the Book you want to remove");
            repo.RemoveBook(bookId);
            Console.WriteLine("Removed");

        }
        private static void AddBookHelper()
        {
            int bookId = Utilities.GetNumber("Enter the Book Id");
            string bookName = Utilities.Prompt("Enter the name of the Book");
            string bookAuthor = Utilities.Prompt("Enter the name of the Author");
            double bookPrice = Utilities.GetNumber("Enter the Price of the book");
            string bookPublisher = Utilities.Prompt("Enter the Publisher name");
            int bookStocks = Utilities.GetNumber("Enter the stocks");

            Book book = new Book { BookId = bookId, BookTitle = bookName, BookStock = bookStocks, Author = bookAuthor, Price = bookPrice, Publisher = bookPublisher };
            repo.AddNewBook(book);
            Console.WriteLine("Book Added");



        }
    }
}

namespace TestingApp
{
    using Repository;
    using SampleConApp;
    using System;


    class bookRepo
    {
        static void Main(string[] args)
        {
            UILayer.UIComponent.Run();
        }
    }
}
