﻿using DemoBankLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DemoBankLibraryTests
{
    [TestFixture]
    public class SavingsTests
    {
        [Test]
        public void InitialDepositBelowAHundredTest()
        {
            //Arrange, Act and Assert
            Assert.Throws<InvalidOperationException>(() => new SavingsAccount(20));
        }

        [Test]
        public void NegativeOrZeroDepositTest()
        {
            //Arrange
            SavingsAccount account = new SavingsAccount(500);

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(-50, DateTime.Now, "Save"));
        }

        [Test]
        public void DepositWorksRightTest()
        {
            //Arrange
            SavingsAccount account = new SavingsAccount(500);
            decimal expected = 540;

            //Act
            account.Deposit(25, DateTime.Now, "Save");
            account.Deposit(15, DateTime.Now, "Save");
            decimal actual = account.Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsufficientBalanceTest()
        {
            //Arrange
            SavingsAccount account = new SavingsAccount(500);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(6000, DateTime.Now, "Save"));
        }

        [Test]
        public void NegativeorZeroWithdrawalTest()
        {
            //Arrange
            SavingsAccount account = new SavingsAccount(500);

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(0, DateTime.Now, "Save"));
        }

        [Test]
        public void WithdrawalWorksRightTest()
        {
            //Arrange
            SavingsAccount account = new SavingsAccount(500);
            decimal expected = 535;

            //Act
            account.Withdraw(25, DateTime.Now, "Buy a bag");
            account.Deposit(75, DateTime.Now, "Salary");
            account.Withdraw(15, DateTime.Now, "Bus Trip");
            decimal actual = account.Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TransferWorksRightTest()
        {
            //Arrange
            List<Customer> customerProfiles = new List<Customer>();
            string fullName = "Adam Eve";
            string email = "adam@eve.com";
            string password = "adameve";
            Customer customer1 = new Customer(fullName, password, email);
            customerProfiles.Add(customer1);
            SavingsAccount account1 = new SavingsAccount(500);
            customer1.allSavingsAccounts.Add(account1);

            fullName = "Bradley Wiggins";
            email = "brad@wiggs.com";
            password = "bradwiggs";
            Customer customer2 = new Customer(fullName, password, email);
            customerProfiles.Add(customer2);
            SavingsAccount account2 = new SavingsAccount(300);
            customer2.allSavingsAccounts.Add(account2);

            int[] expected = { 250, 550 };

            //Act
            account1.Transfer(250, account2.AccountNumber.ToString(), DateTime.Now, "Transfer to 0056445802", customerProfiles);
            decimal[] actual = new decimal[2];
            actual[0] = account1.Balance;
            actual[1] = account2.Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}