using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBankLibrary
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        protected decimal balance;

        public virtual decimal Balance
        {
            get
            {
                balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int baseAccountNumber = 0056445801;

        public BankAccount()
        {
            AccountNumber = baseAccountNumber.ToString();
            baseAccountNumber++;
        }

        public void PrintAccountStatement(Customer customer, SavingsAccount choiceAccount)
        {
            Console.WriteLine("{0, -25}{1, -20}{2, -18}{3, -15}{4, -15}{5, -30}{6, -15}", "Full Name", "Account Number", "Account Type", "Amount", "Balance", "Note", "Date");
            foreach (var item in allTransactions)
            {
                Console.WriteLine("{0, -25}{1, -20}{2, -18}{3, -15}{4, -15}{5, -30}{6, -15}", customer.CustomerName, choiceAccount.AccountNumber, "Savings", item.Amount.ToString("C"), item.userBalance.ToString("C"), item.Note, item.Date.ToShortDateString());
            }
        }

        public void PrintAccountStatement(Customer customer, CurrentAccount choiceAccount)
        {
            Console.WriteLine("{0, -25}{1, -20}{2, -18}{3, -15}{4, -15}{5, -30}{6, -15}", "Full Name", "Account Number", "Account Type", "Amount", "Balance", "Note", "Date");
            foreach (var item in allTransactions)
            {
                Console.WriteLine("{0, -25}{1, -20}{2, -18}{3, -15}{4, -15}{5, -30}{6, -15}", customer.CustomerName, choiceAccount.AccountNumber, "Current", item.Amount.ToString("C"), item.userBalance.ToString("C"), item.Note, item.Date.ToShortDateString());
            }
        }

        public List<Transaction> allTransactions = new List<Transaction>();
    }
}
