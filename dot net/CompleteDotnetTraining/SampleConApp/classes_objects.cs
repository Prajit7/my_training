using System;
using System.IO;

namespace SampleConApp
{
    class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public double Balance { get; private set; } = 5000;

        public void Credit(int amount) => Balance += amount;
        public void Debit(int amount)
        {
            if (amount > Balance) throw new Exception("Insufficient Balance");
            Balance -= amount;
        }
    }
    class AccountManager
    {
        private Account[] _account = null;
        private int _size = 0;
        public AccountManager(int size)
        {
            _size = size;
            _account = new Account[_size];
        }
        public void AddNewAccount(Account acc)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_account[i] == null)
                {
                    _account[i] = new Account { AccountId = acc.AccountId, Name = acc.Name };
                    _account[i].Credit((int)acc.Balance);
                    return;
                }

            }
        }
        public void UpdateAccountDetails(Account acc)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_account[i] != null && _account[i].AccountId == acc.AccountId)
                {
                    _account[i].Name = acc.Name;
                    return;
                }

            }
            throw new Exception("Account not found to Update");
        }

        public void DeleteAccount(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_account[i] != null && _account[i].AccountId == id)
                {
                    _account[i] = null;
                    return;
                }
            }
            throw new Exception("No Account found to Delete");
        }
        public Account FindAccount(int id)
        {
            foreach (Account acc in _account)
            {
                if (acc != null && acc.AccountId == id)
                {
                    return acc;
                }
            }
            throw new Exception("No Account Found");
        }

    }
    class Employee
    {
        int id;
        string Name, Address;
        double Salary;

        public int Empid
        {
            get { return id; }
            set { id = value; }


        }
        public string EmpName
        {
            get { return Name; }
            set { Name = value; }
        }
        public string EmpAddress
        {
            get { return Address; }
            set { Address = value; }
        }
        public double EmpSalary
        {
            get => Salary;
            set => Salary = value;
        }

    }
    class UIManger
    {
        public static AccountManager mgr = null;
        internal static void DisplayMenu(string file)
        {
            int size = Utilities.GetNumber("Enter the Size");
            mgr = new AccountManager(size);
            bool processing = true;
            string menu = File.ReadAllText(file);
            do
            {
                int choice = Utilities.GetNumber(menu);
                processing = processMenu(choice);
            } while (processing);
            Console.WriteLine("Thanks for using our application");

        }
        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                   addingAccountHelper();
                    break;
                case 2:
                   updatingAccountHelper();
                    break;
                case 3:
                  findingAccountHelper();
                    break;
                case 4:
                    
                default:
                    return false;
            }
            return true;//break vs. goto vs. return vs. throw.
        }

        private static void findingAccountHelper()
        {
            int id = Utilities.GetNumber("Enter the ID of the Account to Find");
            try
            {
                Account acc = mgr.FindAccount(id);
                Console.WriteLine("The Details of the Account are as follows:");
                string content = $"The Name: {acc.Name}\nThe Balance : {acc.Balance}\nThe Account No: {acc.AccountId}\n";
                Console.WriteLine(content);
                Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void updatingAccountHelper()
        {
            int id = Utilities.GetNumber("Enter the ID of the Account to Update");
            string name = Utilities.Prompt("Enter the  New Name of the Customer");
            Account acc = new Account { AccountId = id, Name = name };
            mgr.UpdateAccountDetails(acc);
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();

        }

        private static void addingAccountHelper()
        {
            int id = Utilities.GetNumber("Enter the ID of the Account");
            string name = Utilities.Prompt("Enter the Name of the Customer");
            Account acc = new Account { AccountId = id, Name = name };
            mgr.AddNewAccount(acc);
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();

        }
    }
    class classes_objects
    {
        static void Main(string[] args)
        {
            UIManger.DisplayMenu(args[0]);
            //    Employee empObj = new Employee { EmpAddress = "Gokak", Empid = 3328, EmpName = "Prajit", EmpSalary = 45000 };
            //    Console.WriteLine($"The employee name is {empObj.EmpName} from {empObj.EmpAddress} has salary of {empObj.EmpSalary}");

            //    Account acc = new Account { AccountId = 121, Name = "Shri" };
            //    Console.WriteLine("The Balance "+acc.Balance);
            //    acc.Credit(1000);
            //    Console.WriteLine("The Balance " + acc.Balance);

            //    try
            //    {
            //        acc.Debit(40000);
            //    }
            //    catch (Exception ex)
            //    {

            //        Console.WriteLine(ex.Message);
            //    }
            //    int count = Utilities.GetNumber("Enter the number of Account");
            //    AccountManager mgr = new AccountManager(count);
            //    try
            //    {
            //        mgr.FindAccount(121);
            //    }
            //    catch (Exception ex)
            //    {

            //        Console.WriteLine(ex.Message);
            //    }
            //}
        }
    }
}
