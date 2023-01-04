using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Business
    {
        public virtual void MakePayment(string payMode,double amount)
        {
            if (payMode == "CreditCard") Console.WriteLine("Payment not accepted");
            else Console.WriteLine($"The payment accepted by {payMode} for Rs. {amount}");
        }
    }
    class TechBusiness : Business
    {
        public override void MakePayment(string payMode, double amount)
        {
            if(payMode == "Cheque")
            {
                Console.WriteLine("Payment no longer accepted");
            }
            else Console.WriteLine($"The payment accepted by {payMode} for Rs. {amount}");
        }
    }
    class BusinessFactory
    {
        public static Business GetObjects(string arg)
        {
            if (arg.ToUpper() == "BUSINESS") return new Business();
            else if (arg.ToUpper() == "TECHBUSINESS") return new TechBusiness();
            else throw new Exception("Not available with us");
        }
    }
    class methodOverriding
    {
        static void Main(string[] args)
        {
            string businessType = Utilities.Prompt("Enter the type of business you want?");
            Business component = BusinessFactory.GetObjects(businessType);
            component.MakePayment("CreditCard", 50000);
            //component.MakePayment("Cheque", 50000);
        }
    }
}
