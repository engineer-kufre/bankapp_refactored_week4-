using DemoBankLibrary;
using System;

namespace Demo_Bank_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank myBank = new Bank();

            Console.WriteLine("*************************************************");
            Console.WriteLine("          WELCOME TO FREE-MONEY BANK!!!");
            Console.WriteLine("*************************************************");

            bool exitApp = false;
            Customer activeCustomer = null;

            while (activeCustomer == null && exitApp == false)
            {
                bool correctSelection = false;
                string selection = "";
                while (correctSelection == false)
                {
                    Console.WriteLine("Good day. Would like to log in or sign up as a new customer?");
                    Console.Write("Enter \"L\" to log in or \"S\" to sign up or \"X\" to exit the app: ");
                    selection = Console.ReadLine();
                    if (selection.ToUpper() == "X" || selection.ToUpper() == "S" || selection.ToUpper() == "L")
                    {
                        correctSelection = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong selection. Try again!");
                    }
                }

                correctSelection = false;

                if (selection.ToUpper() == "X")
                {
                    exitApp = true;
                }

                //SIGNUP SECTION
                if (selection.ToUpper() == "S")
                {
                    Console.Write("Please enter your Fullname: ");
                    string fullName = Console.ReadLine();
                    Console.Write("Please enter your email: ");
                    string email = Console.ReadLine();
                    Console.Write("Please enter your password: ");
                    string password = Console.ReadLine();

                    bool passwordMatch = false;
                    string passwordCheck;

                    while (passwordMatch == false)
                    {
                        Console.Write("Please reenter your password: ");
                        passwordCheck = Console.ReadLine();

                        if (password == passwordCheck)
                        {
                            passwordMatch = true;
                        }
                        else
                        {
                            Console.WriteLine("Passwords do not match!");
                        }
                    }
                    //customer signup method call
                    AuthenticationClass.CustomerSignup(fullName, email, password);
                }

                //LOGIN SECTION
                

                if (selection.ToUpper() == "L")
                {
                    //email and password validation for login
                    LoginValidation(ref activeCustomer);
                }

                while (activeCustomer != null)
                {

                    //all actions a user can take while logged in
                    CustomerLoggedInActivity(ref correctSelection, ref activeCustomer);
                }
            }
        }

        //all actions a user can take while logged in
        private static void CustomerLoggedInActivity(ref bool correctSelection, ref Customer activeCustomer)
        {
            if (activeCustomer.allSavingsAccounts.Count == 0 && activeCustomer.allCurrentAccounts.Count == 0)
            {
                Console.WriteLine("This is your first time here. You are required to create a new account.");
                Bank.CreateAccount(activeCustomer);
            }

            string choice = "";
            while (correctSelection == false)
            {
                Console.WriteLine($"What would you like to do, {activeCustomer.CustomerName}?");
                Console.WriteLine("Please select an option by entering the corresponding number:");
                Console.WriteLine("1. Create a new account.");
                Console.WriteLine("2. Make a cash deposit.");
                Console.WriteLine("3. Make a cash withdrawal.");
                Console.WriteLine("4. Make a cash transfer.");
                Console.WriteLine("5. View account balance.");
                Console.WriteLine("6. View an account statement.");
                Console.WriteLine("7. Log out.");
                Console.Write("I'd like to: ");
                choice = Console.ReadLine();
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6" || choice == "7")
                {
                    correctSelection = true;
                }
                else
                {
                    Console.WriteLine("Wrong selection. Try again!");
                }
            }

            correctSelection = false;

            if (choice == "1")
            {
                Bank.CreateAccount(activeCustomer);
            }

            if (choice == "2")
            {
                AccountSearch.Deposits(activeCustomer);
            }

            if (choice == "3")
            {
                AccountSearch.Withdraws(activeCustomer);
            }

            if (choice == "4")
            {
                AccountSearch.Transfer(activeCustomer);
            }

            if (choice == "5")
            {
                AccountSearch.ReturnBalance(activeCustomer);
            }

            if (choice == "6")
            {
                AccountSearch.Statement(activeCustomer);
            }

            if (choice == "7")
            {
                activeCustomer = null;
            }
        }

        //method for login email and password validation
        private static void LoginValidation(ref Customer activeCustomer)
        {
            while (activeCustomer == null)
            {
                Console.Write("Please enter your email: ");
                string logInEmail = Console.ReadLine();
                Console.Write("Please enter your password: ");
                string logInPassword = Console.ReadLine();

                //authenticate login details
                activeCustomer = AuthenticationClass.LoginAuth(logInEmail, logInPassword);

                if (activeCustomer == null)
                {
                    Console.WriteLine("Incorrect email or password");
                }
            }
        }
    }
}
