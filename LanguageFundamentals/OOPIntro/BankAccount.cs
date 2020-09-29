using System;
using System.Collections.Generic;

namespace OOPIntro
{
    // Define the class within the namespace
    public class BankAccount
    {
        //=============== Attributes up top ================//
        // Public Attributes
        public string FirstName;
        public string LastName;
        public string EmailAddress;
        public DateTime Birthday; 
        public List<decimal> Transactions;

        public decimal Balance
        {
            get
            {
                decimal bal = 0;
                foreach(decimal transaction in Transactions)
                {
                    bal += transaction;
                }
                return bal;
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public int Age
        {
            get
            {
                int age = (int)((DateTime.Now - Birthday).Days / 365.25);

                return age;
            }
        }

        public string CCN
        {
            get
            {
                string ccn = CreditCardNumber.ToString();

                return $"***{ccn.Substring(ccn.Length-4)}";
            }
            set
            {
                CreditCardNumber = Int32.Parse(value);
            }
        }

        // Private Attributes
        private int SocialSecurityNumber;
        private long CreditCardNumber;
        //==================================================//

        //================= Constructor(s) =================//
        public BankAccount()
        {
            FirstName = "John";
            LastName = "Doe";
            EmailAddress = "jdoe@gmail.com";
            Birthday = new DateTime(1980, 1,1);
            SocialSecurityNumber = 123456789;
            CreditCardNumber = 1234123456785678;
            Transactions = new List<decimal>();
        }

        public BankAccount(string FirstName, string lName, string email, DateTime bday)
        {
            this.FirstName = FirstName;
            LastName = lName;
            EmailAddress = email;
            Birthday = bday;
            SocialSecurityNumber = 0;
            RandomCCN();
            Transactions = new List<decimal>();
        }

        public BankAccount(string fName, string lName, string email, DateTime bday, int ssn, long ccn)
        {
            FirstName = fName;
            LastName = lName;
            EmailAddress = email;
            Birthday = bday;
            SocialSecurityNumber = ssn;
            CreditCardNumber = ccn;
            Transactions = new List<decimal>();
        }
        //==================================================//

        //==================== Methods =====================//
        // Create a new randomly generated credit card number
        public void RandomCCN()
        {
            string cc = "";
            Random rand = new Random();
            for(int i = 0; i < 16; i++)
            {
                cc += rand.Next(0,10).ToString();
            }

            CreditCardNumber = Int64.Parse(cc);
        }

        // Make a deposit into my account
        public void Deposit(decimal amount)
        {
            if(amount < 0)
            {
                System.Console.WriteLine("You cannot deposit a negative amount of dollars");
            } 
            else 
            {
                Transactions.Add(amount);
            }
        }

        // Make a withdrawal from my account
        public void Withdraw(decimal amount)
        {
            if(amount < 0)
            {
                System.Console.WriteLine("You cannot withdraw a negative amount of dollars");
            } 
            else 
            {
                Transactions.Add(amount*-1);
                if(Balance < 0)
                {
                    System.Console.WriteLine("Overdraft fee incurred.");
                    Transactions.Add(-35);
                }
            }
        }

        // Transfer money from this account to another
        public void Transfer(decimal amount, BankAccount account)
        {
            // Withdraw the amount given from THIS account
            Withdraw(amount);
            // and then deposit it into the account given as a parameter
            account.Deposit(amount);
        }
        //==================================================//
    }
}