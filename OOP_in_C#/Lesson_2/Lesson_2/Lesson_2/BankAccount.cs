using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_2
{
    public enum TypeOfAccount
    {
       Debet,
       Credit,
       Individual,
       Corporate
    }
    public class BankAccount
    {
        private static int _accountNumber = 0;
        private decimal _balance;
        private TypeOfAccount _typeOfAccount;
        public int AccountNumber
        {
            get { return _accountNumber; }
        }
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public TypeOfAccount TypeOfAccount
        {
            get { return _typeOfAccount; }
            set { _typeOfAccount = value; }
        }
        public BankAccount(decimal balance) : this(balance, (TypeOfAccount)0) { }
        public BankAccount(TypeOfAccount typeOfAccount) : this(20000, typeOfAccount) { }
        public BankAccount(decimal balance, TypeOfAccount typeOfAccount)
        {
            int NewAccountNumber = _accountNumber + 1;
            _accountNumber = NewAccountNumber;
            _balance = balance;
            _typeOfAccount = typeOfAccount;
        }
        public void Withdraw(decimal value)
        {
            if (value <= _balance)
            {
                _balance = _balance - value;
                Console.WriteLine($"Withdrawal {value} successfully");
            } else
            {
                Console.WriteLine("Not enough money!");
            }
        }
        public void Deposite(decimal value)
        {
            _balance = _balance + value;
            Console.WriteLine($"Deposite {value} successfully");
        }
    }
}
