using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBankLibrary
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Id { get; }
        private static int id = 1;

        public Customer()
        {

        }

        public Customer(string name, string password, string email)
        {
            CustomerName = name;
            Password = password;
            Email = email;
            Id = id.ToString();
            id++;
        }

        public List<SavingsAccount> allSavingsAccounts = new List<SavingsAccount>();
        public List<CurrentAccount> allCurrentAccounts = new List<CurrentAccount>();
    }
}
