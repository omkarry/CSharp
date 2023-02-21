using System;
using System.Text.RegularExpressions;
using ConsoleApp2.BankModels;

namespace BankForm
{
    class BankSystem
    {
        public string choice;
        public string exit = "";
        public bool hasCustomer = false;
        public static void Main()
        {
            BankSystem bankSystem = new BankSystem();
            BankCustomer customer = new BankCustomer();
            BankAccount account = new BankAccount();
            CreditCard cc = new CreditCard();

            do
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\n                Net Banking                ");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("\n2. Show Account Details");
                Console.WriteLine("\n3. Check Balance");
                Console.WriteLine("\n4. Deposit Amount");
                Console.WriteLine("\n5. Withdraw Amount");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\nEnter exit to stop..\n");
                bankSystem.choice = Console.ReadLine();

                switch (bankSystem.choice)
                {
                    case "1":
                        customer.GetDetails();
                        account.CreateAccount();
                        cc.RequestCreditCard();
                        bankSystem.hasCustomer = true;
                        break;

                    case "2":
                        if (bankSystem.hasCustomer == false)
                        {
                            Console.WriteLine("\nCreate account first");
                            break;
                        }
                        Console.WriteLine("\n\n--------------------------------------------");
                        Console.WriteLine("                 Bank Details               ");
                        Console.WriteLine("--------------------------------------------");

                        customer.ShowPersonalDetails();
                        account.ShowAccountDetails();
                        cc.ShowCreditCardDetails();
                        Console.WriteLine("--------------------------------------------");
                        break;

                    case "3":
                        if (bankSystem.hasCustomer == false)
                        {
                            Console.WriteLine("\nCreate account first");
                            break;
                        }
                        account.CheckBalance();
                        break;

                    case "4":
                        if (bankSystem.hasCustomer == false)
                        {
                            Console.WriteLine("\nCreate account first");
                            break;
                        }
                        account.Deposit();
                        break;

                    case "5":
                        if (bankSystem.hasCustomer == false)
                        {
                            Console.WriteLine("\nCreate account first");
                            break;
                        }
                        account.Withdraw();
                        break;

                    case "exit":
                        bankSystem.exit = "exit";
                        break;

                    default:
                        Console.WriteLine("\nEnter Correct Option");
                        break;
                }
            } while (bankSystem.exit.ToLower() != "exit");
        }
    }
}