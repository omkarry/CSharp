using System;
using System.Collections.Generic;

namespace BankSystem
{
    class BankAccount
    {
        public string AccountNumber{get; private set;}
        public decimal Balance{get; private set;}

        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount; 
        }

        public void Withdraw(decimal amount)
        {
            if(amount > Balance)
            {
                Console.WriteLine("Insufficient balance in account to withdraw..");
            }
            else
                Balance -= amount;
        }

        private void UpdateAccountNumber(string newAccountNumber)
        {
            AccountNumber = newAccountNumber;
        }
    }

    class BankCustomer
    {
        public string Name{get; set;}
        public List<BankAccount> Accounts{get; set;}

        public BankCustomer(string name)
        {
            Name = name;
            Accounts = new List<BankAccount>();
        }

        public void AddAccount(BankAccount account)
        {
            Accounts.Add(account);
        }
    }

    class Bank
    {
        private List<BankCustomer> customers = new  List<BankCustomer>();
        
        internal void AddCustomer(BankCustomer customer)
        {
            customers.Add(customer);
        }

        internal BankAccount GetBankAccount(string accountNumber)
        {
            foreach(var customer in customers)
            {
                foreach(var account in customer.Accounts)
                {
                    if(account.AccountNumber == accountNumber)
                    {
                        return account;
                    }
                }
            }
            return null;
        }
    }

    class BankSystem
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank();

            BankCustomer omkar = new BankCustomer("Omkar");
            BankAccount omkarAccount = new BankAccount("10002938");
            omkar.AddAccount(omkarAccount);
            bank.AddCustomer(omkar);

            omkarAccount.Deposit(10000);

            Console.WriteLine($"Balance of Omkar: {omkarAccount.Balance}");
            
            BankAccount account = bank.GetBankAccount("10002938");

             Console.WriteLine("Withdrawl of 2000...");
            account.Withdraw(2000);
            Console.WriteLine($"Now balance is {omkarAccount.Balance}");
        }
    }
}