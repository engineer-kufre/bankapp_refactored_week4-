using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBankLibrary
{
    public class Bank
    {
        public static List<Customer> customerProfiles = new List<Customer>();

        //method to create accounts
        public static void CreateAccount(Customer activeCustomer)
        {
            bool accepted = false;
            string accountChoice = "";

            while (accepted == false) //checks for wrong selection entry
            {
                Console.Write("Enter \"S\" to create a savings account or \"C\" for a current account: ");
                accountChoice = Console.ReadLine();

                if (accountChoice.ToUpper() == "S")
                {
                    Console.Write("Enter initial balance (MUST be at least $100): ");
                    accepted = true;
                }
                else if (accountChoice.ToUpper() == "C")
                {
                    Console.Write("Enter initial balance (MUST be at least $1000): ");
                    accepted = true;
                }
                else
                {
                    Console.WriteLine("Wrong selection. Try again!");
                }
            }

            decimal initial = decimal.Parse(Console.ReadLine());
            if (accountChoice.ToUpper() == "S") //user wishes to open a savings account
            {
                try
                {
                    SavingsAccount account = new SavingsAccount(initial);
                    activeCustomer.allSavingsAccounts.Add(account);
                    Console.WriteLine("Account successfully created!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (accountChoice.ToUpper() == "C") //user wishes to open a current account
            {
                try
                {
                    CurrentAccount account = new CurrentAccount(initial);
                    activeCustomer.allCurrentAccounts.Add(account);
                    Console.WriteLine("Account successfully created!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
