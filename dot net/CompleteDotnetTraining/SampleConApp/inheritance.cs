using System;


namespace SampleConApp
{
    class BankAccount
    {
        public int AccountNumber { get; set; }
        public string name { get; set; }
        public int AccountBalance { get; protected set; } = 5000;
    }

    class SbAccount : BankAccount
    {
        public void Credit(int amount) => AccountBalance += amount;
        public void Debit(int amount) => AccountBalance -= amount;
    }
    class RdAccount : BankAccount
    {
        int amount = 5000;
        public void MakePayment()
        {
            Console.WriteLine($"The payment of {amount} is done");
            AccountBalance += amount;
        } 
    }
    class inheritance
    {
        static void Main(string[] args)
        {
            SbAccount acc = new SbAccount { AccountNumber = 123, name = "Praj" };
            acc.Credit(28000);
            Console.WriteLine($"The Balance is after Credit {acc.AccountBalance}");
            acc.Debit(2000);
            Console.WriteLine($"The Balance is after Debit {acc.AccountBalance}");

            RdAccount rdAcc = new RdAccount { AccountNumber = 112, name = "Shri" };
            rdAcc.MakePayment();
        }
    }
}
