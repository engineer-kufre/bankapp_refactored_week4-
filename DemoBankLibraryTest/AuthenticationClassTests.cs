using DemoBankLibrary;
using NUnit.Framework;

namespace DemoBankLibraryTests
{
    [TestFixture]
    public class AuthTests
    {
        [Test]
        public void RegisterTest() //tests user signup method and passes if isSignedUp equals True
        {
            //Arrange
            string fullName = "Adam Eve";
            string email = "adam@eve.com";
            string password = "adameve";
            bool expected = true;

            //Act
            bool actual = AuthenticationClass.CustomerSignup(fullName, email, password);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoginAuthenticationTest() //tests user login method and passes if customerName attribute of the new customer object matches fullName argument
        {
            //Arrange
            string fullName = "Adam Eve";
            string email = "adam@eve.com";
            string password = "adameve";
            AuthenticationClass.CustomerSignup(fullName, email, password);
            string expected = "Adam Eve";

            //Act
            Customer customer = AuthenticationClass.LoginAuth(email, password);
            string actual = customer.CustomerName;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}