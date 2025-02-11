using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Transaction
{
    public string Type { get; set; }  
    public decimal Amount { get; set; } 
    public string Description { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public Transaction(string type, decimal amount, string description)
    {
        Type = type;
        Amount = amount;
        Description = description;
        Date = DateTime.Now;
    }
}