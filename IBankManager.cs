using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IBankOperations
{
    bool RegisterUser(string username, string password, string accountNumber);
    User AuthenticateUser(string username, string password);
    void DepositFunds(User user, decimal amount);
    bool WithdrawFunds(User user, decimal amount);
    //bool TransferFunds(User sender, User receiver, decimal amount);
    void ViewTransactionHistory(User user);
    void DisplayUserDetails(User user);
}