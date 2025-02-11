using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class User
{
    public string Username { get; set; } 
    public string Password { get; set; } 
    public string AccountNumber { get; set; } 
    public decimal Balance { get; set; } = 0; 
    public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>(); 
}