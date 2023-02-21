using ConsoleApp2.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace ConsoleApp2.BankModels
{
    internal class BankAccount
    {
        private string panNumber, bankAccountNumber;
        public string addNominee, nomineeName, nomineeRelation, isAddressSame, permanentAddress,
            correspondenceAddress;
        public int nomineeAge;
        public decimal balance, dailyDepositLimit, dailyWithdrawLimit;

        public BankAccount()
        {
            balance = 0;
            dailyDepositLimit = 100000;
            dailyWithdrawLimit = 50000;
        }

        Random rd = new Random();

        public void CreateAccount()
        {
            bankAccountNumber = rd.Next(1000000, 9999999).ToString();
            bankAccountNumber = "00000" + bankAccountNumber;

            do
            {
                Console.WriteLine("\nEnter your Pan number:");
                panNumber = Console.ReadLine();

                if (!Regex.IsMatch(panNumber, @"^[A-Z]{5}[0-9]{4}[A-Z]{1}$"))
                {
                    Console.WriteLine("\nEnter Pan number Correctly");
                }
                else
                    break;
            } while (true);

            Console.WriteLine("\nAre your permanent and correspondence address same?(Yes/No) ");
            isAddressSame = Console.ReadLine();
            if (isAddressSame.ToUpper() == "Y" || isAddressSame.ToUpper() == "YES")
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
                    if (!Regex.IsMatch(nomineeName, @"[a-zA-Z]"))
                    {
                        Console.WriteLine("\nCannot be number");
                    }
                    else
                        break;
                } while (true);

                do
                {
                    Console.WriteLine("\nNominee Age: ");
                    nomineeAge = int.Parse(Console.ReadLine());
                    if (nomineeAge < 18 || nomineeAge > 80)
                    {
                        Console.WriteLine("Enter nominee Age between 18-80 ");
                    }
                    else
                        break;
                } while (true);

                do
                {
                    Console.WriteLine("\nRelation with nominee: ");
                    nomineeRelation = Console.ReadLine();
                    if (!Regex.IsMatch(nomineeRelation, @"[A-Za-z]"))
                    {
                        Console.WriteLine("\nEnter relation with nominee correctly ");
                    }
                } while (true);
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
            if (isAddressSame.ToUpper() == "YES" || isAddressSame.ToUpper() == "Y")
            {
                Console.WriteLine($"\t* Permanent Address: {permanentAddress}");

            }
            else
            {
                Console.WriteLine($"\t* Permanent Address: {permanentAddress}");
                Console.WriteLine($"\t* Correspondence Address: {correspondenceAddress}");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine("\nBalance: {0}", balance);
        }

        public void Deposit()
        {
            try
            {
                if (dailyDepositLimit == 0)
                {
                    throw new DailyLimitExceedException("\nDaily deposit limit is over");
                }
                Console.WriteLine("\nEnter amount to deposit: ");
                decimal depositAmount = decimal.Parse(Console.ReadLine());
                if (depositAmount <= 0)
                {
                    Console.WriteLine("\nDeposit amount cannot be less than or equal to 0");
                }
                else
                {
                    if (dailyDepositLimit - depositAmount >= 0)
                    {
                        Console.WriteLine("\nRs.{0} Deposited successfully...\n", depositAmount);
                        balance += depositAmount;
                        dailyDepositLimit -= depositAmount;
                        Console.WriteLine("\nDo you want to check balance?(yes/no)");
                        string wantToCheckBalance = Console.ReadLine();
                        if (wantToCheckBalance.ToLower().Equals("yes") || wantToCheckBalance.ToLower().Equals("y"))
                            CheckBalance();
                    }
                    else
                        throw new DailyLimitExceedException("\nDaily deposit limit is Rs. 100,000 only...");
                }
            }
            catch (DailyLimitExceedException DLEE)
            {
                Console.WriteLine(DLEE.Message);
                Console.WriteLine("\nRemaining limit to deposit amount: {0}", dailyDepositLimit);
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }

        public void Withdraw()
        {
            try
            {
                if (dailyWithdrawLimit == 0)
                {
                    throw new DailyLimitExceedException("Daily withdarw limit is over");
                }
                Console.WriteLine("\nEnter amount to withdraw: ");
                decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                if (withdrawAmount < 0)
                {
                    Console.WriteLine("\nWithdraw amount cannot be less than zero");
                }
                else
                {
                    if (dailyWithdrawLimit - withdrawAmount >= 0 && balance >= withdrawAmount)
                    {
                        balance -= withdrawAmount;
                        dailyWithdrawLimit -= withdrawAmount;
                        Console.WriteLine("Withdrawl of Rs. {0} successful..", withdrawAmount);
                        Console.WriteLine("\nDo you want to check balance?(yes/no)");
                        string wantToCheckBalance = Console.ReadLine();
                        if (wantToCheckBalance.ToLower().Equals("yes") || wantToCheckBalance.ToLower().Equals("y"))
                            CheckBalance();
                    }
                    else if (balance - withdrawAmount < 0)
                        throw new DailyLimitExceedException("Insufficient Amount to withdraw");
                    else
                        throw new DailyLimitExceedException("Daily withdraw limit is Rs. 50,000 only...");
                }
            }
            catch (DailyLimitExceedException DLEE)
            {
                Console.WriteLine(DLEE.Message);
                Console.WriteLine("\nRemaining limit to withdraw amount: {0}", dailyWithdrawLimit);
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }
}
