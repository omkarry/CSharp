using System;
using System.Text.RegularExpressions;

namespace ConsoleApp2.BankModels
{
    public class BankCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string MailId { get; set; }
        public string MaritalStatus { get; set; }
        public string PhoneNumber { get; set; }
        public int NumOfChildren { get; set; }
        public int Age { get; set; }

        public string haveChildren;

        public bool isMarried = false;
        public string[] childrenNames = new string[20];

        public void GetDetails()
        {
            do
            {
                Console.WriteLine("\nEnter your First Name: ");
                FirstName = Console.ReadLine();
                if (!Regex.IsMatch(FirstName, @"[a-zA-Z]"))
                {
                    Console.WriteLine("\nEnter your first name Correctly...");
                }
                else
                    break;
            } while (true);

            do
            {
                Console.WriteLine("\nEnter your Last Name: ");
                LastName = Console.ReadLine();
                if (!Regex.IsMatch(LastName, @"[a-zA-Z]"))
                {
                    Console.WriteLine("\nEnter your first name Correctly...");
                }
                else
                    break;
            } while (true);

            do
            {
                Console.WriteLine("\nSelect your Gender: (Male/Female/Other)");
                Gender = Console.ReadLine();
                if (!(Gender.ToUpper() == "MALE" || Gender.ToUpper() == "FEMALE" || Gender.ToUpper() == "OTHER"))
                {
                    Console.WriteLine("\nSelect Gender from the options...");
                }
                else
                    break;
            } while (true);

            do
            {
                Console.WriteLine("\nEnter your Age: ");
                Age = Convert.ToInt32(Console.ReadLine());
                if (Age < 18 || Age > 80)
                {
                    Console.WriteLine("\nEnter Age Between 18-80 ");
                }
                else
                    break;
            } while (true);

            do
            {
                Console.WriteLine("\nEnter your Email Id: ");
                MailId = Console.ReadLine();
                if (!Regex.IsMatch(MailId, @"^[a-zA-Z0-9+_.-]+@(.+)+.com$"))
                {
                    Console.WriteLine("Enter a valid email");
                }
                else
                    break;
            } while (true);

            do
            {
                Console.WriteLine("\nEnter your 10 digits Phone Number: ");
                PhoneNumber = Console.ReadLine();
                if (!Regex.IsMatch(PhoneNumber, @"^[0-9]{10}$"))
                {
                    Console.WriteLine("\nEnter a valid phone number");
                }
                else
                    break;
            } while (true);

            do
            {
                Console.WriteLine("\nMarital Status: (Married/Unmarried/Divorcee)");
                MaritalStatus = Console.ReadLine();
                if (MaritalStatus.ToUpper() == "MARRIED" || MaritalStatus.ToUpper() == "DIVORCEE")
                {
                    isMarried = true;
                    Console.WriteLine("\nDo you have children?(Yes/No) ");
                    haveChildren = Console.ReadLine();
                    if (haveChildren == "Y" || haveChildren == "YES")
                    {
                        Console.WriteLine("\nHow many ? ");
                        NumOfChildren = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter Children names: ");

                        for (int i = 0; i < NumOfChildren; i++)
                        {
                            do
                            {
                                childrenNames[i] = Console.ReadLine();
                                if (!Regex.IsMatch(childrenNames[i], @"^[A-Za-z]"))
                                {
                                    Console.WriteLine("\nEnter Name Correctly");
                                }
                                else
                                    break;
                            } while (true);
                        }
                    }
                }
                else
                {
                    if (!(MaritalStatus.ToUpper() == "UNMARRIED"))
                    {
                        Console.WriteLine("\nSelect marital status from option");
                    }
                    else
                        break;
                }
            } while (true);
        }

        public void ShowPersonalDetails()
        {
            Console.WriteLine("\n--* Presonal Details *--");
            Console.WriteLine($"\t* Account Holder Name: {FirstName} {LastName}");
            Console.WriteLine($"\t* Gender: {Gender}");
            Console.WriteLine($"\t* Email Id: {MailId}");
            Console.WriteLine($"\t* Phone Number: {PhoneNumber}");
            if (isMarried == true)
            {
                Console.WriteLine($"\t* Marital Status: {MaritalStatus}");
                if (haveChildren.ToUpper() == "YES" || haveChildren.ToUpper() == "Y")
                {
                    Console.WriteLine("\t* Children Names: ");
                    foreach (string child in childrenNames)
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
}
