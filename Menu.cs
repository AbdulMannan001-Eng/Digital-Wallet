using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;


using System.Windows;
public class Menu
{
    private BankSystem bank = new BankSystem();
    private User loggedInUser = null!;

    public void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("WelCome To MGQS International Bank");
            Console.WriteLine("Enter 1. To Create An Account");
            Console.WriteLine("Enter 2. To Login");
            Console.WriteLine("Enter 3. To Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()!;
            switch (choice)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    LoginUser();
                    break;
                case "3":
                    Console.WriteLine("Exiting.........\nThanks For Banking With Us!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void RegisterUser()
    {
        Console.Write("Enter Your username: ");
        string username = Console.ReadLine()!;

        string password = "";
        Console.WriteLine("Enter Your 4-Digit PIN");
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter && password.Length == 4)
                break;
            if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password[..^1];
                Console.Write("\b \b");
            }
            else if (char.IsDigit(key.KeyChar) && password.Length < 4)
            {
                password += key.KeyChar;
                Console.Write("✳");
            }
        }
        Console.WriteLine();

            if (password.Length != 4)
            {
                Console.WriteLine("PIN must be a 4-digit number. Try again.");
                return;
            }

        Console.WriteLine("\nEnter phone number: ");
        string phoneNumber = Console.ReadLine()!;
        string accountNumber = phoneNumber.Substring(1);

        bool success = bank.RegisterUser(username, password, accountNumber);
        if (success)
        {
            Console.WriteLine($"This is your MGQS International Bank account Number: {accountNumber}");
        }
        PressAnyKeyToContinue();
    }

    private void LoginUser()
    {
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;

            string password = "";
            Console.Write("Enter password: ");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter && password.Length == 4)
                    break;
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
                else if (char.IsDigit(key.KeyChar) && password.Length < 4)
                {
                    password += key.KeyChar;
                    Console.Write("✳");
                }
            }

            Console.WriteLine();

            if (password.Length != 4)
            {
                Console.WriteLine("PIN must be a 4-digit number. Try again.");
                return;
            }

            loggedInUser = bank.AuthenticateUser(username, password);
            if (loggedInUser != null)
            {
                Console.WriteLine($"Welcome back to MGQS International Bank, {loggedInUser.Username}!");
                ShowUserMenu();
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }
             PressAnyKeyToContinue();
        }
    }
 


    private void ShowUserMenu()
    {
        while (loggedInUser != null)
        {
            Console.WriteLine("\nUser Menu");
            Console.WriteLine("Enter 1. To Deposit Funds");
            Console.WriteLine("Enter 2. To Withdraw Funds");
            Console.WriteLine("Enter 3. To View Transaction History");
            Console.WriteLine("Enter 4. To View Account Details");
            Console.WriteLine("Enter 5. To Logout");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()!;
            switch (choice)
            {
                case "1":
                    DepositFunds();
                    break;
                case "2":
                    WithdrawFunds();
                    break;
                
                case "3":
                    bank.ViewTransactionHistory(loggedInUser);
                    break;
                case "4":
                    bank.DisplayUserDetails(loggedInUser);
                    break;
                case "5":
                    loggedInUser = null!;
                    Console.WriteLine("Logged out successfully.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    Console.Clear();
                    break;
            }
        }
    }
    private static void PressAnyKeyToContinue()
    {
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void DepositFunds()
    {
        Console.Write("Enter amount to deposit: ");
        decimal amount = decimal.Parse(Console.ReadLine()!);
        string password = "";
        Console.WriteLine("Enter Your PIN");
        while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter && password.Length == 4)
                    break;
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
                else if (char.IsDigit(key.KeyChar) && password.Length < 4)
                {
                    password += key.KeyChar;
                    Console.Write("✳");
                }
            }
        bank.DepositFunds(loggedInUser, amount);
         PressAnyKeyToContinue();
    }

    private void WithdrawFunds()
    {
        Console.Write("Enter amount to withdraw: ");
        decimal amount = decimal.Parse(Console.ReadLine()!);
        string password = "";
        Console.WriteLine("Enter your PIN");
        while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter && password.Length == 4)
                    break;
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
                else if (char.IsDigit(key.KeyChar) && password.Length < 4)
                {
                    password += key.KeyChar;
                    Console.Write("✳");
                }
            }
        bank.WithdrawFunds(loggedInUser, amount);
         PressAnyKeyToContinue();
    }
}
