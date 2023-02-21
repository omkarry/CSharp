using System;
using System.Text.RegularExpressions;

namespace ConsoleApp2.BankModels
{
    internal class CreditCard
    {
        private int cardNumber;
        public int cardLimit;
        public decimal salary;
        public string creditCardType, requestCreditCard;
        public bool cardRequestAccepted = false;

        Random rd = new Random();

        public void RequestCreditCard()
        {
            Console.WriteLine("\nDo you want Credit Card?(Yes/No) ");
            requestCreditCard = Console.ReadLine();
            if (requestCreditCard.ToUpper() == "Y" || requestCreditCard.ToUpper() == "YES")
            {
                do
                {
                    Console.WriteLine("\nEnter the salary: ");
                    salary = Convert.ToDecimal(Console.ReadLine());
                    if (salary < 0)
                    {
                        Console.WriteLine("\nSalary cannot be negative");
                    }
                    else if (salary > 0 && salary < 25000)
                    {
                        Console.WriteLine("\nYou are note eligible for credit card");
                        break;
                    }
                    else if (salary >= 25000 && salary < 50000)
                    {
                        Console.WriteLine("\nCredit Card request accepted ");
                        cardNumber = rd.Next(100000, 999999);
                        cardLimit = 30000;
                        creditCardType = "Silver";
                        cardRequestAccepted = true;
                        break;
                    }
                    else if (salary >= 50000 && salary < 100000)
                    {
                        Console.WriteLine("\nCredit Card request accepted ");
                        cardNumber = rd.Next(100000, 999999);
                        cardLimit = 75000;
                        creditCardType = "Gold";
                        cardRequestAccepted = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nCredit Card request accepted ");
                        cardNumber = rd.Next(100000, 999999);
                        cardLimit = 200000;
                        creditCardType = "Platinum";
                        cardRequestAccepted = true;
                        break;
                    }
                } while (true);
            }
        }
        public void ShowCreditCardDetails()
        {
            if (cardRequestAccepted == true)
            {
                Console.WriteLine("\n--* Credit Card Details *--");
                Console.WriteLine($"\t* Card Number(Last 6 Digits): ******{cardNumber}");
                Console.WriteLine($"\t* Card Type: {creditCardType}");
                Console.WriteLine($"\t* Card Limit: {cardLimit}");
            }
            else
                Console.WriteLine("\nYou are not eligible to apply credit card.");
        }

    }
}
