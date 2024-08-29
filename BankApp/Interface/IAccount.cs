using BankApp.Models;

namespace BankApp.Interface
{
    public interface IAccount
    {

        Transaction Deposit(int fromId, int toId, decimal amount);

        Transaction Withdraw(int id, decimal amount);

        decimal LoanSum(int id);

        decimal Balance (int accountId);

        Transaction DownPayment(int accountId, int LoanId);

        Loan RequestLoan(int id, decimal amount, string loanType);

    }
}
