using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount myAccount = new BankAccount(50000, (TypeOfAccount)1);

            Console.WriteLine($"My Account: {myAccount.AccountNumber} {myAccount.Balance} {myAccount.TypeOfAccount}");
        }
    }
}
