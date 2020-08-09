using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBankLibrary
{
    public static class AuthenticationClass
    {
        //customer signup method
        public static bool CustomerSignup(string fullName, string email, string password)
        {
            bool isSignedUp = false;

            Customer customer = new Customer(fullName, password, email);
            Bank.customerProfiles.Add(customer);
            if (customer != null)
            {
                isSignedUp = true;
            }
            return isSignedUp;
        }

        //method for authenticating login details
        public static Customer LoginAuth(string logInEmail, string logInPassword)
        {
            Customer customer = null;
            foreach (var item in Bank.customerProfiles)
            {
                if (item.Email == logInEmail && item.Password == logInPassword)
                {
                    customer = item;
                }
            }
            return customer;
        }
    }
}
