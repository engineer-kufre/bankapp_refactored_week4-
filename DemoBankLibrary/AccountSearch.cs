using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBankLibrary
{
    public class AccountSearch
    {
        public static void ReturnBalance(Customer activeCustomer)
        {
            bool accountFound = false;

            while (accountFound == false)
            {
                Console.WriteLine($"Here are your accounts, {activeCustomer.CustomerName}:");
                foreach (var item in activeCustomer.allSavingsAccounts)
                {
                    Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
                }

                foreach (var item in activeCustomer.allCurrentAccounts)
                {
                    Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
                }

                Console.Write("Select account for this transaction by entering its account number: ");
                string choiceAccount = Console.ReadLine();

                for (int i = 0; i < activeCustomer.allSavingsAccounts.Count; i++)
                {
                    if (activeCustomer.allSavingsAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        Console.WriteLine($"Your balance is {activeCustomer.allSavingsAccounts[i].Balance}");
                    }
                }

                for (int i = 0; i < activeCustomer.allCurrentAccounts.Count; i++)
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

        public static void Deposits(Customer activeCustomer)
        {
            bool accountFound = false;

            SavingsAccount savingsDepositAccount = null;
            CurrentAccount currentDepositAccount = null;

            while (accountFound == false)
            {
                Console.WriteLine($"Here are your accounts, {activeCustomer.CustomerName}:");
                foreach (var item in activeCustomer.allSavingsAccounts)
                {
                    Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
                }

                foreach (var item in activeCustomer.allCurrentAccounts)
                {
                    Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
                }

                Console.Write("Select account for this transaction by entering its account number: ");
                string choiceAccount = Console.ReadLine();

                for (int i = 0; i < activeCustomer.allSavingsAccounts.Count; i++)
                {
                    if (activeCustomer.allSavingsAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        savingsDepositAccount = activeCustomer.allSavingsAccounts[i];
                    }
                }

                for (int i = 0; i < activeCustomer.allCurrentAccounts.Count; i++)
                {
                    if (activeCustomer.allCurrentAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        currentDepositAccount = activeCustomer.allCurrentAccounts[i];
                    }
                }

                if (accountFound == false)
                {
                    Console.WriteLine("Account entered does not exist!");
                }
            }

            Console.Write("Enter deposit amount: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter deposit note: ");
            string depositNote = Console.ReadLine();
            DateTime depositDate = DateTime.Now;

            if (savingsDepositAccount != null)
            {
                try
                {
                    savingsDepositAccount.Deposit(depositAmount, depositDate, depositNote);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (currentDepositAccount != null)
            {
                try
                {
                    currentDepositAccount.Deposit(depositAmount, depositDate, depositNote);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Withdraws(Customer activeCustomer)
        {
            bool accountFound = false;

            SavingsAccount savingsWithdrawalAccount = null;
            CurrentAccount currentWithdrawalAccount = null;

            while (accountFound == false)
            {
                Console.WriteLine($"Here are your accounts, {activeCustomer.CustomerName}:");

                foreach (var item in activeCustomer.allSavingsAccounts)
                {
                    Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
                }

                foreach (var item in activeCustomer.allCurrentAccounts)
                {
                    Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
                }

                Console.Write("Select account for this transaction by entering its account number: ");
                string choiceAccount = Console.ReadLine();

                for (int i = 0; i < activeCustomer.allSavingsAccounts.Count; i++)
                {
                    if (activeCustomer.allSavingsAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        savingsWithdrawalAccount = activeCustomer.allSavingsAccounts[i];
                    }
                }

                for (int i = 0; i < activeCustomer.allCurrentAccounts.Count; i++)
                {
                    if (activeCustomer.allCurrentAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        currentWithdrawalAccount = activeCustomer.allCurrentAccounts[i];
                    }
                }

                if (accountFound == false)
                {
                    Console.WriteLine("Account entered does not exist!");
                }
            }

            Console.Write("Enter withdrawal amount: ");
            decimal withdrawalAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter withdrawal note: ");
            string withdrawalNote = Console.ReadLine();
            DateTime withdrawalDate = DateTime.Now;

            if (savingsWithdrawalAccount != null)
            {
                try
                {
                    savingsWithdrawalAccount.Withdraw(withdrawalAmount, withdrawalDate, withdrawalNote);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (currentWithdrawalAccount != null)
            {
                try
                {
                    currentWithdrawalAccount.Withdraw(withdrawalAmount, withdrawalDate, withdrawalNote);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Transfer(Customer activeCustomer)
        {
            bool accountFound = false;

            SavingsAccount savingsWithdrawalAccount = null;
            CurrentAccount currentWithdrawalAccount = null;

            while (accountFound == false)
            {
                Console.WriteLine($"Here are your accounts, {activeCustomer.CustomerName}:");

                foreach (var item in activeCustomer.allSavingsAccounts)
                {
                    Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
                }

                foreach (var item in activeCustomer.allCurrentAccounts)
                {
                    Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
                }

                Console.Write("Select account for this transaction by entering its account number: ");
                string choiceAccount = Console.ReadLine();

                for (int i = 0; i < activeCustomer.allSavingsAccounts.Count; i++)
                {
                    if (activeCustomer.allSavingsAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        savingsWithdrawalAccount = activeCustomer.allSavingsAccounts[i];
                    }
                }

                for (int i = 0; i < activeCustomer.allCurrentAccounts.Count; i++)
                {
                    if (activeCustomer.allCurrentAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        currentWithdrawalAccount = activeCustomer.allCurrentAccounts[i];
                    }
                }

                if (accountFound == false)
                {
                    Console.WriteLine("Account entered does not exist!");
                }
            }
            Console.Write("Enter transfer amount: ");
            decimal transferAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter recipient account number: ");
            string recipientAccount = Console.ReadLine();
            Console.Write("Enter transfer note: ");
            string transferNote = Console.ReadLine();
            DateTime transferDate = DateTime.Now;
            List<Customer> customersList = Bank.customerProfiles;

            if (savingsWithdrawalAccount != null)
            {
                try
                {
                    savingsWithdrawalAccount.Transfer(transferAmount, recipientAccount, transferDate, transferNote, customersList);
                    Console.WriteLine("Transaction successfull!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (currentWithdrawalAccount != null)
            {
                try
                {
                    currentWithdrawalAccount.Transfer(transferAmount, recipientAccount, transferDate, transferNote, customersList);
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
            bool accountFound = false;

            SavingsAccount savingsAccount = null;
            CurrentAccount currentAccount = null;

            while (accountFound == false)
            {
                Console.WriteLine($"Here are your accounts, {activeCustomer.CustomerName}:");

                foreach (var item in activeCustomer.allSavingsAccounts)
                {
                    Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
                }

                foreach (var item in activeCustomer.allCurrentAccounts)
                {
                    Console.WriteLine($"=> {item.AccountNumber} ({item.AccountType})");
                }

                Console.Write("Select account to view statement: ");
                string choiceAccount = Console.ReadLine();

                for (int i = 0; i < activeCustomer.allSavingsAccounts.Count; i++)
                {
                    if (activeCustomer.allSavingsAccounts[i].AccountNumber == choiceAccount)
                    {
                        accountFound = true;
                        savingsAccount = activeCustomer.allSavingsAccounts[i];
                    }
                }

                for (int i = 0; i < activeCustomer.allCurrentAccounts.Count; i++)
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

                if (savingsAccount != null)
                {
                    savingsAccount.PrintAccountStatement(activeCustomer, savingsAccount);
                }

                if (currentAccount != null)
                {
                    currentAccount.PrintAccountStatement(activeCustomer, currentAccount);
                }
            }
        }
    }
}
