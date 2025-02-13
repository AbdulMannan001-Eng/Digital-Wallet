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
        Console.WriteLine("Registration successful!");
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
        Console.WriteLine($"Deposited ${amount}. New Balance: ${user.Balance}");
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
        Console.WriteLine($"Withdrew ${amount}. New Balance: ${user.Balance}");
        return true;
    }

    public bool TransferFunds(User sender, User receiver, decimal amount)
    {
        
        if (amount > sender.Balance)
        {
            Console.WriteLine("Insufficient funds!"); 
            return false;
        }
        
        sender.Balance -= amount;
        receiver.Balance += amount;
        sender.TransactionHistory.Add(new Transaction("Transfer", amount, $"Transferred to {receiver.Username}"));
        receiver.TransactionHistory.Add(new Transaction("Transfer", amount, $"Received from {sender.Username}"));
        Console.WriteLine("Transfer successful!");
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