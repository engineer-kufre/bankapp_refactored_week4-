using DemoBankLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DemoBankLibraryTests
{
    [TestFixture]
    public class CurrentTests
    {
        [Test]
        public void InitialDepositBelowAThousandTest()
        {
            //Arrange, Act and Assert
            Assert.Throws<InvalidOperationException>(() => new CurrentAccount(50));
        }

        [Test]
        public void NegativeOrZeroDepositTest()
        {
            //Arrange
            CurrentAccount account = new CurrentAccount(5000);

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(-50, DateTime.Now, "Save"));
        }

        [Test]
        public void DepositWorksRightTest()
        {
            //Arrange
            CurrentAccount account = new CurrentAccount(5000);
            decimal expected = 5400;

            //Act
            account.Deposit(250, DateTime.Now, "Save");
            account.Deposit(150, DateTime.Now, "Save");
            decimal actual = account.Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsufficientBalanceTest()
        {
            //Arrange
            CurrentAccount account = new CurrentAccount(5000);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(6000, DateTime.Now, "Save"));
        }

        [Test]
        public void NegativeorZeroWithdrawalTest()
        {
            //Arrange
            CurrentAccount account = new CurrentAccount(5000);

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(0, DateTime.Now, "Save"));
        }

        [Test]
        public void WithdrawalWorksRightTest()
        {
            //Arrange
            CurrentAccount account = new CurrentAccount(5000);
            decimal expected = 5350;

            //Act
            account.Withdraw(250, DateTime.Now, "Buy a bag");
            account.Deposit(750, DateTime.Now, "Salary");
            account.Withdraw(150, DateTime.Now, "Bus Trip");
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
            CurrentAccount account1 = new CurrentAccount(5000);
            customer1.allCurrentAccounts.Add(account1);

            fullName = "Bradley Wiggins";
            email = "brad@wiggs.com";
            password = "bradwiggs";
            Customer customer2 = new Customer(fullName, password, email);
            customerProfiles.Add(customer2);
            SavingsAccount account2 = new SavingsAccount(300);
            customer2.allSavingsAccounts.Add(account2);

            int[] expected = { 2500, 2800 };

            //Act
            account1.Transfer(2500, account2.AccountNumber.ToString(), DateTime.Now, "Transfer to 0056445802", customerProfiles);
            decimal[] actual = new decimal[2];
            actual[0] = account1.Balance;
            actual[1] = account2.Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}