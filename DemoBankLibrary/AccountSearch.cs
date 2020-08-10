using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBankLibrary
{
    public class AccountSearch
    {
        //method receives an account number from the user, searches amongst his accounts and displays account balance if a match is found
        public static void ReturnBalance(Customer activeCustomer)
        {
            bool accountFound = false;

            while (accountFound == false)
            {
                DisplayUserAccounts(activeCustomer);

                Console.Write("Select account for this transaction by entering its account number: ");
                string choiceAccount = Console.ReadLine();

                for (int i = 0; i < activeCustomer.allSavingsAccounts.Count; i++)  //search savings accounts
                {
                    if (activeCustomer.allSavingsAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        Console.WriteLine($"Your balance is {activeCustomer.allSavingsAccounts[i].Balance}");
                    }
                }

                for (int i = 0; i < activeCustomer.allCurrentAccounts.Count; i++) //search current accounts
                {
                    if (activeCustomer.allCurrentAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        Console.WriteLine($"Your balance is {activeCustomer.allCurrentAccounts[i].Balance}");
                    }
                }

                if (accountFound == false)
                {
                    Console.WriteLine("Account entered does not exist!");
                }
            }
        }

        //method to search for customer account details match before deposit is made
        public static void Deposits(Customer activeCustomer)
        {
            SavingsAccount savingsAccount;
            CurrentAccount currentAccount;

            //receives account details and confirms validity
            ConfirmAccount(activeCustomer, out savingsAccount, out currentAccount);

            Console.Write("Enter deposit amount: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter deposit note: ");
            string depositNote = Console.ReadLine();
            DateTime depositDate = DateTime.Now;

            if (savingsAccount != null) //match found
            {
                try
                {
                    savingsAccount.Deposit(depositAmount, depositDate, depositNote);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (currentAccount != null) //match found
            {
                try
                {
                    currentAccount.Deposit(depositAmount, depositDate, depositNote);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //method to search for customer account details match before withdrawal is made
        public static void Withdraws(Customer activeCustomer)
        {
            SavingsAccount savingsAccount;
            CurrentAccount currentAccount;

            //receives account details and confirms validity
            ConfirmAccount(activeCustomer, out savingsAccount, out currentAccount);

            Console.Write("Enter withdrawal amount: ");
            decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter withdrawal note: ");
            string withdrawalNote = Console.ReadLine();
            DateTime withdrawalDate = DateTime.Now;

            if (savingsAccount != null) //match found
            {
                try
                {
                    savingsAccount.Withdraw(withdrawalAmount, withdrawalDate, withdrawalNote);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (currentAccount != null) //match found
            {
                try
                {
                    currentAccount.Withdraw(withdrawalAmount, withdrawalDate, withdrawalNote);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //method to search for customer and target account details match before transfer is made
        public static void Transfer(Customer activeCustomer)
        {
            SavingsAccount savingsAccount;
            CurrentAccount currentAccount;

            //receives account details and confirms validity
            ConfirmAccount(activeCustomer, out savingsAccount, out currentAccount);

            Console.Write("Enter transfer amount: ");
            decimal transferAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter recipient account number: ");
            string recipientAccount = Console.ReadLine();
            Console.Write("Enter transfer note: ");
            string transferNote = Console.ReadLine();
            DateTime transferDate = DateTime.Now;
            List<Customer> customersList = Bank.customerProfiles;

            if (savingsAccount != null) //match found
            {
                try
                {
                    savingsAccount.Transfer(transferAmount, recipientAccount, transferDate, transferNote, customersList);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (currentAccount != null) //match found
            {
                try
                {
                    currentAccount.Transfer(transferAmount, recipientAccount, transferDate, transferNote, customersList);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Statement(Customer activeCustomer)
        {
            SavingsAccount savingsAccount;
            CurrentAccount currentAccount;

            //receives account details and confirms validity
            ConfirmAccount(activeCustomer, out savingsAccount, out currentAccount);

            if (savingsAccount != null)
            {
                savingsAccount.PrintAccountStatement(activeCustomer, savingsAccount);
            }

            if (currentAccount != null)
            {
                currentAccount.PrintAccountStatement(activeCustomer, currentAccount);
            }
        }

        //displays user's savings and current accounts
        private static void DisplayUserAccounts(Customer activeCustomer)
        {
            Console.WriteLine($"Here are your accounts, {activeCustomer.CustomerName}:");
            foreach (var item in activeCustomer.allSavingsAccounts) //displays user's savings accounts
            {
                Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
            }

            foreach (var item in activeCustomer.allCurrentAccounts) //displays user's current accounts
            {
                Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
            }
        }

        //displays accounts, receives user account number and searches to confirm that account exists
        private static void ConfirmAccount(Customer activeCustomer, out SavingsAccount savingsAccount, out CurrentAccount currentAccount)
        {
            bool accountFound = false;

            savingsAccount = null;
            currentAccount = null;
            while (accountFound == false)
            {
                DisplayUserAccounts(activeCustomer);

                Console.Write("Select account an by entering its account number: ");
                string choiceAccount = Console.ReadLine();

                for (int i = 0; i < activeCustomer.allSavingsAccounts.Count; i++)  //search savings accounts
                {
                    if (activeCustomer.allSavingsAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        savingsAccount = activeCustomer.allSavingsAccounts[i];
                    }
                }

                for (int i = 0; i < activeCustomer.allCurrentAccounts.Count; i++)  //search current accounts
                {
                    if (activeCustomer.allCurrentAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        currentAccount = activeCustomer.allCurrentAccounts[i];
                    }
                }

                if (accountFound == false)
                {
                    Console.WriteLine("Account entered does not exist!");
                }
            }
        }
    }
}
