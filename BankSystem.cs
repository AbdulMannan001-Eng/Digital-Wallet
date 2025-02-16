using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BankSystem : IBankOperations
{
    private List<User> Users = new List<User>();

    public bool RegisterUser(string username, string password, string accountNumber)
    {
        
        if (Users.Exists(u => u.AccountNumber == accountNumber))
        {
            Console.WriteLine("Account number already exists!");
            return false;
        }
        
      
        Users.Add(new User { Username = username, Password = password, AccountNumber = accountNumber });
        Console.WriteLine("You've successfully Created An Account!");
        return true;
    }

    public User AuthenticateUser(string username, string password)
    {
        return Users.Find(u => u.Username == username && u.Password == password)!;
    }

    public void DepositFunds(User user, decimal amount)
    {
        user.Balance += amount;
        user.TransactionHistory.Add(new Transaction("Deposit", amount, "Deposited funds"));
        Console.WriteLine($"\nDeposited ${amount}. New Balance: ${user.Balance}");
    }

    public bool WithdrawFunds(User user, decimal amount)
    {
        
        if (amount > user.Balance)
        {
            Console.WriteLine("Insufficient funds!");
            return false;
        }

        user.Balance -= amount;
        user.TransactionHistory.Add(new Transaction("Withdrawal", amount, "Withdraw funds"));
        Console.WriteLine($"\nWithdrew ${amount}. New Balance: ${user.Balance}");
        return true;
    }
    public void ViewTransactionHistory(User user)
    {
        Console.WriteLine("\nTransaction History:");
        if (user.TransactionHistory.Count == 0)
        {
            Console.WriteLine("No transactions found.");
            return;
        }

        foreach (var transaction in user.TransactionHistory)
        {
            Console.WriteLine($"{transaction.Date} - {transaction.Type}: ${transaction.Amount} - {transaction.Description}");
        }
    }

    public void DisplayUserDetails(User user)
    {
        Console.WriteLine($"\nUser Details:\nUsername: {user.Username}\nAccount Number: {user.AccountNumber}\nBalance: ${user.Balance}");
    }
}