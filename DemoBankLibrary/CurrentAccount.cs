using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DemoBankLibrary
{
    public class CurrentAccount : BankAccount
    {
        public string AccountType = "Current";
        private int depositCount = 0;

        public CurrentAccount(decimal initialBalance)
        {
            Deposit(initialBalance, DateTime.Now, "Initial Deposit");
        }

        public void Deposit(decimal amount, DateTime date, string note)
        {
            if (depositCount == 0 && amount < 1000)
            {
                throw new InvalidOperationException("Initial deposit must be above $1000");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Your deposit amount must be more than $0");
            }

            note = Regex.Replace(note, @"(to)", "from");

            Transaction deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
            deposit.userBalance = Balance;
            depositCount++;
        }

        public void Withdraw(decimal amount, DateTime date, string note)
        {
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("You have insufficient funds for this withdrawal.");
            }
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Your withdrawal amount must be more than $0");
            }

            Transaction withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
            withdrawal.userBalance = Balance;
        }

        public void Transfer(decimal amount, string targetAccount, DateTime date, string note, List<Customer> customers)
        {
            bool targetFound = false;

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Your transfer amount must be more than $0");
            }

            for (int i = 0; i < customers.Count; i++)
            {
                for (int j = 0; j < customers[i].allSavingsAccounts.Count; j++)
                {
                    if (customers[i].allSavingsAccounts[j].AccountNumber == targetAccount)
                    {
                        targetFound = true;
                        customers[i].allSavingsAccounts[j].Deposit(amount, date, note);
                    }
                }
                for (int j = 0; j < customers[i].allCurrentAccounts.Count; j++)
                {
                    if (customers[i].allCurrentAccounts[j].AccountNumber == targetAccount)
                    {
                        targetFound = true;
                        customers[i].allCurrentAccounts[j].Deposit(amount, date, note);
                    }
                }
            }

            if (targetFound == false)
            {
                throw new ArgumentException(nameof(targetAccount), "Target account, not found");
            }

            Transaction withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
            withdrawal.userBalance = Balance;
        }
    }
}
