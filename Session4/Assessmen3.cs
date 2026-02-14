using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Text;
using System.Transactions;
using System.Xml.Linq;

namespace ConsoleApp1.Session4
{
    public class Assessment3
    {
        //You will build a console application that simulates a simple ATM
        //system.The program allows users to create accounts, deposit and
        //withdraw money, check balance, and view transaction history.
        //displays a menu-driven ATM interface:
        //1.Create a new account
        //2.Log in using your account number
        //3.Check balance
        //4.Deposit money
        //5.Withdraw money
        //6.View transaction history
        //7.Exit

        //Displays the main ATM menu with all options a user can choose
        //from(create account, login, exit, etc.).
        //Allows the user to create a new bank account.
        //Generates a random account number
        //Collects user name and 4-digit PIN
        //Initializes balance and transaction history
        //Logs in the user by asking for account number and PIN
        //Displays the menu that a logged-in user sees (check balance,
        //deposit, withdraw, view transactions, logout).
        //Allows the user to Add money to the user’s account.
        //Allows the user to withdraw money from the account.

        //Displays all previous transactions for the logged-in account.
        //Includes date, transaction type, amount, and resulting balance


        public List<Account> Accounts = new List<Account>();
        Account LoggedInAccount = null;

        public Assessment3()
        {
            ShowMainMenu();
        }

        public void ShowCreateAccountMenu()
        {
            string PIN;

            LoggedInAccount = null;


            Console.WriteLine("Enter account name or EXIT :");
            string Name = Console.ReadLine();

            if (Name.ToLower() == "exit")
            {
                ShowMainMenu();
            }

            while (true)
            {
                Console.WriteLine("Choose 4 digits PIN:");

                if (AskAndParsePIN(out PIN))
                {
                    break;
                }
            }

            var newAccount = new Account() { Name = Name, Id = (Accounts.Count() + 1).ToString(), Balance = 0, PIN = PIN };
            Accounts.Add(newAccount);
            Console.WriteLine(Environment.NewLine + $"Account {newAccount.Id} created succesfully." + Environment.NewLine);
            ShowMainMenu();
        }

        bool AskAndParsePIN(out string result)
        {

            string line = Console.ReadLine();
            if (line.Length == 4)
            {
                bool parsedInt = int.TryParse(line, out int number);
                if (parsedInt && number > 0 && number < 10000)
                {
                    result = line;
                    return true;
                }
            }

            Console.WriteLine("Invalid input");
            result = string.Empty;
            return false;
        }

        public void ShowMainMenu()
        {
            LoggedInAccount = null;

            Console.WriteLine("Enter process number to continue");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("1.Create a new account");
            Console.WriteLine("2.Log in");
            Console.WriteLine("3.Exit");
            Console.WriteLine(Environment.NewLine);

            int mainMenuSelection = ParseMainMenuSelection();

            if (mainMenuSelection == 1)
                ShowCreateAccountMenu();
            else if (mainMenuSelection == 2)
                ShowLogIn();
            else if (mainMenuSelection == 3)
                Environment.Exit(0);
        }

        public void ShowAccountOperations()
        {
            //3.Check balance
            //4.Deposit money
            //5.Withdraw money
            //6.View transaction history
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Hello, {LoggedInAccount.Name} ,Enter process number to continue");
            Console.WriteLine("1.Check Balance");
            Console.WriteLine("2.Deposit Money");
            Console.WriteLine("3.Withdraw Money");
            Console.WriteLine("4.View Transaction History");
            Console.WriteLine("5.Exit");

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "5")
                    ShowMainMenu();
                else if (line == "1")
                    ShowBalance();
                else if (line == "2")
                    ShowDepositMoney();
                else if (line == "3")
                    ShowWithdrawMoney();
                else if (line == "4")
                    ShowTransactionHistory();
            }

        }

        public void ShowBalance()
        {
            if (LoggedInAccount == null)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Current Balance is {LoggedInAccount.Balance}");
                ShowAccountOperations();
            }
        }

        public void ShowDepositMoney()
        {
            while (true)
            {
                Console.WriteLine("Enter amount or EXIT");
                string line = Console.ReadLine();
                if (line.ToLower() == "exit")
                {
                    ShowAccountOperations();
                }
                else
                {
                    if (double.TryParse(line, out double amount))
                    {
                        LoggedInAccount.Balance = LoggedInAccount.Balance + amount;
                        Console.WriteLine($"{amount} is deposited into account , current Balance is {LoggedInAccount.Balance}");
                        LoggedInAccount.Transactions.Add(new Transaction() { DateTime = DateTime.Now, Type = TransactionType.Deposit, Amount = amount });
                        ShowAccountOperations();
                    }
                }

            }
        }

        public void ShowWithdrawMoney()
        {
            while (true)
            {
                Console.WriteLine("Enter amount or EXIT");
                string line = Console.ReadLine();
                if (line.ToLower() == "exit")
                {
                    ShowAccountOperations();
                }
                else
                {
                    if (double.TryParse(line, out double amount))
                    {
                        if (LoggedInAccount.Balance >= amount)
                        {
                            LoggedInAccount.Balance = LoggedInAccount.Balance - amount;
                            Console.WriteLine($"{amount} withdrawed from account , current Balance is {LoggedInAccount.Balance}");
                            LoggedInAccount.Transactions.Add(new Transaction() { DateTime = DateTime.Now, Type = TransactionType.Withdraw, Amount = amount });
                            ShowAccountOperations();
                        }
                        else
                        {
                            Console.WriteLine("Not enough money!");
                        }
                    }
                }

            }
        }

        public void ShowTransactionHistory()
        {
            const int datetimeLength = 21;
            const int typeLength = 26;
            const int amountLength = 17;
            Console.WriteLine("====================================================================");
            Console.WriteLine("|         Date        |           Type           |       Amount    |");
            Console.WriteLine("====================================================================");
            foreach (var trans in LoggedInAccount.Transactions.OrderBy(x => x.DateTime).ToList())
                Console.WriteLine($"|{trans.DateTime,-datetimeLength}|{trans.Type.ToString(),-typeLength}|{trans.Amount,-amountLength}|");
            Console.WriteLine("====================================================================");

            ShowAccountOperations();
        }

        public void ShowLogIn()
        {
            Account? account = AskAndParseAccountNo();
            if (account == null)
            {
                ShowMainMenu();
            }
            else
            {
                if (AskAndParsePIN(account))
                {
                    LoggedInAccount = account;
                    ShowAccountOperations();
                }
                else
                {
                    ShowMainMenu();
                }
            }
        }

        public Account? AskAndParseAccountNo()
        {
            while (true)
            {
                Console.WriteLine("Enter Account No# or enter EXIT :");
                string line = Console.ReadLine();
                {
                    if (line.ToLower() == "exit")
                    {

                        return null;
                    }
                    else
                    {
                        var accountFound = Accounts.FirstOrDefault(x => x.Id == line);
                        if (accountFound == null)
                        {
                            Console.WriteLine("Account not found!");
                        }
                        else
                        {
                            return accountFound;

                        }
                    }
                }
            }
        }

        public bool AskAndParsePIN(Account account)
        {
            while (true)
            {
                Console.WriteLine("Enter PIN or enter EXIT to exit :");
                string line = Console.ReadLine();
                {
                    if (line.ToLower() == "exit")
                    {
                        return false;
                    }
                    else
                    {
                        if (account.PIN == line)
                        {
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("PIN is wrong!");

                        }
                    }
                }
            }
        }

        public int ParseMainMenuSelection()
        {
            while (true)
            {
                string line = Console.ReadLine();
                bool parsedInt = int.TryParse(line, out int number);
                if (parsedInt)
                {
                    if (number == 1 || number == 2 || number == 3)
                        return number;
                    else
                        Console.WriteLine("Invalid input");

                }
            }
        }

        public class Account
        {
            public string Id;
            public string Name;
            public string PIN;
            public double Balance = 0;
            public List<Transaction> Transactions = new List<Transaction>();
        }

        public class Transaction
        {
            public DateTime DateTime;
            public TransactionType Type;
            public double Amount;
        }

        public enum TransactionType
        {
            Deposit, Withdraw
        }
    }
}