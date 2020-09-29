using System;

namespace OOPIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount MyAccount = new BankAccount();

            BankAccount CustomAccount = new BankAccount("Josh", "Ferreira", "shadowgames1993@gmail", new DateTime(1993, 9, 30), 723991744, 4132587619049283);

            BankAccount InfolessPerson = new BankAccount("Jane", "Doe", "janey@doe.com", new DateTime(1992, 4,6));

            CustomAccount.Deposit(9000);
            InfolessPerson.Withdraw(1000);
            CustomAccount.Transfer(1200, InfolessPerson);
        }
    }
}
