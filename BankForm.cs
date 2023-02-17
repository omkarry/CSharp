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
            }while(true);
            
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
            }while(true);

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
            }while(true);

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
            }while(true);
            
            do
            {
                Console.WriteLine("Enter your Email Id: ");
                MailId = Console.ReadLine();
                if(!(Regex.IsMatch(MailId,@"^[a-zA-Z0-9+_.-]+@(.+)+.com$")))
                {
                    Console.WriteLine("Enter a valid email");
                }
            }while(true);

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
            }while(true);
            
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
                            }while(true);
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
            }while(true);
        }

        public void ShowPersonalDetails()
        {
            Console.WriteLine("\n--* Presonal Details *--");
            Console.WriteLine($"\t* Account Holder Name: {FirstName} {LastName}");
            Console.WriteLine($"\t* Gender: {Gender}");
            Console.WriteLine($"\t* Email Id: {MailId}");
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
        private string  panNumber, bankAccountNumber;
        public string addNominee, nomineeName, nomineeRelation, isAddressSame, 
        permanentAddress, correspondenceAddress;
        public int nomineeAge;

        Random rd =new Random();

        public void CreateAccount()
        {
            bankAccountNumber = (rd.Next(1000000,9999999)).ToString();
            bankAccountNumber = "00000" + bankAccountNumber;

            do
            {
                Console.WriteLine("\nEnter your Pan number:");
                panNumber = Console.ReadLine();

                if(!(Regex.IsMatch(panNumber,@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$")))
                {
                    Console.WriteLine("\nEnter Pan number Correctly");
                }
                else
                    break;
            }while(true);
            
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
                }while(true);

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
                }while(true);

                do
                {
                    Console.WriteLine("\nRelation with nominee: ");
                    nomineeRelation = Console.ReadLine(); 
                    if(!(Regex.IsMatch(nomineeRelation, @"[A-Za-z]")))
                    {
                        Console.WriteLine("\nEnter relation with nominee correctly ");
                    }
                }while(true);
            }
            Console.WriteLine("\nAccount Created Successfully...");
        }
        public void ShowAccountDetails()
        {
            Console.WriteLine("\n\n--* Bank Account Details *--");
            Console.WriteLine($"\t* Bank Account Number: {bankAccountNumber}");
            Console.WriteLine($"\t* Pan Number: {panNumber}");
            if (addNominee.ToUpper() == "YES" || addNominee.ToUpper() == "Y")
            {
                Console.WriteLine($"\t* Nominee Name: {nomineeName}");
                Console.WriteLine($"\t* Nominee Age: {nomineeAge}");
                Console.WriteLine($"\t* Relation with nominee: {nomineeRelation}");                    
            }
            if(isAddressSame.ToUpper() == "YES" || isAddressSame.ToUpper() == "Y")
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
        public bool cardRequestAccepted = false;

        Random rd = new Random();

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
                }while(true);
            }
        }
        public void ShowCreditCardDetails()
        {
            if(cardRequestAccepted == true)
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

    class BankSystem
    {
        public string choice; 
        public string exit="";
        public bool hasCustomer = false;
        public static void Main()
        {
            BankSystem bankSystem = new BankSystem();
            BankCustomer customer = new BankCustomer();
            BankAccount account = new BankAccount();
            CreditCard cc = new CreditCard();

            do
            {
                Console.WriteLine("\n                Net Banking                ");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("\n2. Show Account Details");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\nEnter exit to stop..");
                bankSystem.choice = Console.ReadLine();

                switch(bankSystem.choice)
                {
                    case "1": customer.GetDetails();
                            account.CreateAccount();
                            cc.RequestCreditCard();
                            bankSystem.hasCustomer = true;
                    break;

                    case "2":if(bankSystem.hasCustomer == false)
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

                    case "exit": bankSystem.exit = "exit";
                    break;

                    default:    Console.WriteLine("\nEnter Correct Option");
                    break;
                }
            } while(bankSystem.exit.ToLower() != "exit");   
        }
    }
}    