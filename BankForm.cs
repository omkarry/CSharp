using System;
using System.Text.RegularExpressions;

namespace BankForm
{
    public class BankCustomer
    {
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Gender{get; set;}
        public string MailId{get; set;}
        public string MaritalStatus{get; set;}
        public string PhoneNumber{get; set;}
        public int NumOfChildren{get; set;}
        public int Age{get; set;}

        public string haveChildren;

        public bool isMarried = false;
        public string[] childrenNames = new string[20];

        public void GetDetails()
        {
            do{
                Console.WriteLine("\nEnter your First Name: ");
                FirstName = Console.ReadLine();
                if(!(Regex.IsMatch(FirstName, @"[a-zA-Z]")))
                {
                    Console.WriteLine("\nEnter your first name Correctly...");    
                }
                else
                    break;
            }while(1);
            
            do
            {
                Console.WriteLine("\nEnter your Last Name: ");
                LastName = Console.ReadLine();
                if(!(Regex.IsMatch(LastName, @"[a-zA-Z]")))
                {
                    Console.WriteLine("\nEnter your first name Correctly...");     
                }
                else
                    break;
            }while(1);

            do
            {
                Console.WriteLine("\nSelect your Gender: (Male/Female/Other)");
                Gender = Console.ReadLine();
                if(!((Gender.ToUpper() == "MALE") || (Gender.ToUpper() == "FEMALE") || (Gender.ToUpper() == "OTHER")))
                {
                    Console.WriteLine("\nSelect Gender from the options...");
                }
                else
                    break;
            }while(1);

            do
            {
                Console.WriteLine("\nEnter your Age: ");
                Age = Convert.ToInt32(Console.ReadLine());
                if(Age<18 || Age>80)
                {
                    Console.WriteLine("\nEnter Age Between 18-80 ");
                }
                else
                    break;
            }while(1);
            
            do
            {
                Console.WriteLine("Enter your Email Id: ");
                email = Console.ReadLine();
                if(!(Regex.IsMatch(email,@"^[a-zA-Z0-9+_.-]+@(.+)+.com$")))
                {
                    Console.WriteLine("Enter a valid email");
                }
            }while(1);

            do
            {
                Console.WriteLine("\nEnter your 10 digits Phone Number: ");
                PhoneNumber = Console.ReadLine();
                if(!(Regex.IsMatch(PhoneNumber,@"^[0-9]{10}$")))
                {
                    Console.WriteLine("\nEnter a valid phone number");
                }
                else
                    break;
            }while(1);
            
            do
            {
                Console.WriteLine("\nMarital Status: (Married/Unmarried/Divorcee)");
                MaritalStatus = Console.ReadLine();
                if(MaritalStatus.ToUpper() == "MARRIED" || MaritalStatus.ToUpper() == "DIVORCEE")
                {
                    isMarried = true;
                    Console.WriteLine("\nDo you have children?(Yes/No) ");
                    haveChildren = Console.ReadLine();
                    if (haveChildren == "Y" || haveChildren == "YES")
                    {
                        Console.WriteLine("\nHow many ? ");
                        NumOfChildren = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter Children names: ");
                        
                        for(int i=0;i<NumOfChildren;i++)
                        {
                            do
                            {
                                childrenNames[i] = Console.ReadLine();
                                if (!(Regex.IsMatch(childrenNames[i],@"^[A-Za-z]")))
                                {
                                    Console.WriteLine("\nEnter Name Correctly");
                                }
                                else
                                    break;
                            }while(1);
                        }
                    }
                }
                else
                {
                    if(!(MaritalStatus.ToUpper() == "UNMARRIED"))
                    {
                        Console.WriteLine("\nSelect marital status from option");
                    }
                    else
                        break;
                }
            }while(1);
        }

        public void ShowPersonalDetails()
        {
            Console.WriteLine("\n--* Presonal Details *--");
            Console.WriteLine($"\t* Account Holder Name: {FirstName} {LastName}");
            Console.WriteLine($"\t* Gender: {Gender}");
            Console.WriteLine($"\t* Email Id: {email}");
            Console.WriteLine($"\t* Phone Number: {PhoneNumber}");
            if (isMarried==true)
            {
                Console.WriteLine($"\t* Marital Status: {MaritalStatus}");
                if(haveChildren.ToUpper() == "YES" || haveChildren.ToUpper() == "Y")
                {
                    Console.WriteLine("\t* Children Names: ");
                    foreach(string child in childrenNames)
                    {
                        Console.WriteLine($"\t\t{child}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"\t* Marital Status: {MaritalStatus}");
            }
        }
    }

    internal class BankAccount
    {
        private string  panNumber, accountNumber, bankAccountNumber;
        public string addNominee, nomineeName, nomineeRelation, isAddressSame, permanentAddress, correspondenceAddress,;
        public int nomineeAge;

        public BankAccount()
        {}

        public void CreateAccount()
        {
            bankAccountNumber = rd.Next(1000000,9999999);
            accountNumber = "00000" + bankAccountNumber.ToString();

            do
            {
                Console.WriteLine("\nEnter your Pan number:");
                panNumber = Console.ReadLine();

                if(!(Regex.IsMatch(panNumber.ToString(),@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$")))
                {
                    Console.WriteLine("\nEnter Pan number Correctly");
                }
                else
                    break;
            }while(1);
            
            Console.WriteLine("\nAre your permanent and correspondence address same?(Yes/No) ");
            isAddressSame = Console.ReadLine();
            if(isAddressSame.ToUpper() == "Y" ||isAddressSame.ToUpper() == "YES")
            {
                Console.WriteLine("\nEnter Permanent Address: ");
                permanentAddress = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nEnter Permanent Address: ");
                permanentAddress = Console.ReadLine();
                Console.WriteLine("\nEnter Correspondence Address: ");
                correspondenceAddress = Console.ReadLine();
            }

            Console.WriteLine("\nWant to add Nominee Details? (Yes/No)");
            addNominee = Console.ReadLine();
            if (addNominee.ToUpper() == "Y" || addNominee.ToUpper() == "YES")
            {
                do
                {
                    Console.WriteLine("\nEnter Nominee Name: ");
                    nomineeName = Console.ReadLine();
                    if(!(Regex.IsMatch(nomineeName, @"[a-zA-Z]")))
                    {
                        Console.WriteLine("\nCannot be number");
                    }
                    else
                        break;
                }while(1);

                do
                {
                        Console.WriteLine("\nNominee Age: ");
                    nomineeAge = int.Parse(Console.ReadLine());
                    if(nomineeAge<18 || nomineeAge>80)
                    {
                        Console.WriteLine("Enter nominee Age between 18-80 ");
                    }
                    else
                        break;
                }while(1);

                do
                {
                    Console.WriteLine("\nRelation with nominee: ");
                    nomineeRelation = Console.ReadLine(); 
                    if(!(Regex.IsMatch(nomineeRelation, @"[A-Za-z]")))
                    {
                        Console.WriteLine("\nEnter relation with nominee correctly ");
                    }
                }while(1);
            }
            Console.WriteLine("\nAccount Created Successfully...");
        }
        void ShowAccountDetails()
        {
            Console.WriteLine("\n\n--* Bank Account Details *--");
            Console.WriteLine($"\t* Bank Account Number: {accountNumber}");
            Console.WriteLine($"\t* Pan Number: {panNumber}");
            if (addNominee.ToUpper() == "YES" || addNominee.ToUpper() == "Y")
            {
                Console.WriteLine($"\t* Nominee Name: {nomineeName}");
                Console.WriteLine($"\t* Nominee Age: {nomineeAge}");
                Console.WriteLine($"\t* Relation with nominee: {nomineeRelation}");                    
            }
            if(sameAddress.ToUpper() == "YES" || sameAddress.ToUpper() == "Y")
            {
                Console.WriteLine($"\t* Permanent Address: {permanentAddress}");

            }
            else
            {
                Console.WriteLine($"\t* Permanent Address: {permanentAddress}");
                Console.WriteLine($"\t* Correspondence Address: {correspondenceAddress}");
            }
        }
    }

    internal class CreditCard
    {
        private int cardNumber;
        public int cardLimit;
        public decimal salary;
        public string creditCardType, requestCreditCard;
        bool cardRequestAccepted = false;

        public void RequestCreditCard()
        {
            Console.WriteLine("\nDo you want Credit Card?(Yes/No) ");
            requestCreditCard = Console.ReadLine();
            if(requestCreditCard.ToUpper() == "Y" || requestCreditCard.ToUpper() == "YES")
            {
                do
                {
                    Console.WriteLine("\nEnter the salary: ");
                    salary = Convert.ToDecimal(Console.ReadLine());
                    if (salary < 0)
                    {
                        Console.WriteLine("\nSalary cannot be negative");
                    }
                    else if(salary > 0 && salary < 25000)
                    {
                        Console.WriteLine("\nYou are note eligible for credit card");
                        break;
                    }
                    else if(salary >= 25000 && salary < 50000)
                    {
                        Console.WriteLine("\nCredit Card request accepted ");
                        cardNumber = rd.Next(100000,999999);
                        cardLimit = 30000;
                        creditCardType = "Silver";
                        cardRequestAccepted = true;
                        break;
                    }
                    else if(salary >= 50000 && salary < 100000)
                    {
                        Console.WriteLine("\nCredit Card request accepted ");
                        cardNumber = rd.Next(100000,999999);
                        cardLimit = 75000;
                        creditCardType = "Gold";
                        cardRequestAccepted = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nCredit Card request accepted ");
                        cardNumber = rd.Next(100000,999999);
                        cardLimit = 200000;
                        creditCardType = "Platinum";
                        cardRequestAccepted = true;
                        break;
                    }
                }while(1);
            }
        }
        void ShowCreditCardDetails()
        {
            if(cardRequestAccepted == true)
            {
                Console.WriteLine("\n--* Credit Card Details *--");
                Console.WriteLine($"\t* Card Number(Last 6 Digits): ******{cardNumber}");
                Console.WriteLine($"\t* Card Type: {creditCardType}");
                Console.WriteLine($"\t* Card Limit: {cardLimit}");
            }
            else
                console.WriteLine("\nYou are not eligible to apply credit card.");
        }
        
    }

    class BankSystem
    {
        public static void Main(string[] args)
        {
            public int choice;
            public string exit;

            do
            {
                Console.WriteLine("\n                Net Banking                ");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("\n2. Show Account Details");
                Console.WriteLine("--------------------------------------------");
                choice = Console.ReadLine();

                switch(choice)
                {
                    case "1": BankCustomer customer = new BankCustomer();
                            customer.GetDetails();

                            BankAccount account = new BankAccount();
                            account.CreateAccount();

                            CreditCard cc = new CreditCard();
                            cc.RequestCreditCard();
                    break;

                    case "2":Console.WriteLine("\n\n--------------------------------------------");
                            Console.WriteLine("                 Bank Details               ");
                            Console.WriteLine("--------------------------------------------");

                            customer.ShowPersonalDetails();
                            account.ShowAccountDetails();
                            cc.ShowCreditCardDetails();
                            Console.WriteLine("--------------------------------------------");
                    break;

                    default:    Console.WriteLine("\nEnter Correct Option\tor");
                                Console.WriteLine("\nEnter exit to stop..");
                    break;
                }
                Console.WriteLine("Enter \"exit\" to stop");
                exit = Console.ReadLine();
            } while(exit.ToLower() != "exit");
        }
    }
}