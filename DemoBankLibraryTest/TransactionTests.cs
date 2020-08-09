using DemoBankLibrary;
using NUnit.Framework;
using System;

namespace DemoBankLibraryTests
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void TransactionTest()
        {
            //Arrange
            Transaction deposit = null;
            decimal amount = 5000;
            DateTime date = DateTime.Now;
            string note = "Demo Transaction";

            //Act
            deposit = new Transaction(amount, date, note);

            //Assert
            Assert.IsNotNull(deposit);
        }
    }
}