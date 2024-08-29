using BankApp.Interface;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;

namespace BankApp.DAL
{
    public class AccountRepository : GenericRepo<Account>, IAccount
    {

        private readonly BankDbContext _bankDbContext;
        private readonly DbSet<Account> _dbSet;
        private readonly ILoan _loanService;
        private DbSet<Account> Accounts => _bankDbContext.Set<Account>();

        public AccountRepository(BankDbContext bankDbContext, ILoan loanService) : base(bankDbContext)
        {
            _bankDbContext = bankDbContext;
            _dbSet = bankDbContext.Set<Account>();
            _loanService = loanService;
        }

        public decimal Balance(int accountId)
        {
            var account = _bankDbContext.Accounts
                .Include(a => a.AccountTransactions)
                .ThenInclude(at => at.Transaction)
                .FirstOrDefault(a => a.AccountId == accountId);

            if (account == null)
            {
                throw new ArgumentException("Account not found");
            }

            // Calculate the balance based on transactions
            decimal sumOfTransactions = 0;

            foreach (var accountTransaction in account.AccountTransactions)
            {
                var transaction = accountTransaction.Transaction;

                if (transaction.isDeposit)
                {
                    sumOfTransactions += transaction.TransactionAmount;
                }
                else
                {
                    sumOfTransactions -= transaction.TransactionAmount;
                }
            }
            account.Balance = sumOfTransactions;
            return sumOfTransactions;
        }

        public Transaction Deposit(int fromId, int toId, decimal amount)
        {
            Account AccountToDepositFrom = getElementById(fromId);
            Account AccountToDepositTo = getElementById(toId);
            Random IdGenerator = new Random();
            if (AccountToDepositTo == null || AccountToDepositFrom==null || amount ==0)
            {
                return null;
            }
            else
            {
               
                Transaction transaction = new Transaction
                {
                    AccountTransactions = new List<AccountTransaction>(),
                    TransactionDate = DateTime.Now,
                    isDeposit = true,
                    IsProcessed = false,
                    TransactionAmount = amount,
                    TransactionId = IdGenerator.Next()
                };
                AccountTransaction senderTransaction = new AccountTransaction(
                    AccountToDepositFrom.AccountId, transaction.TransactionId);

                _bankDbContext.Transactions.Add(transaction);
                _bankDbContext.accountTransactions.Add(senderTransaction);
                save();
  
                return transaction;
            }
        }

        public decimal LoanSum(int id)
        {
            decimal loanSum = 0;
            if (id == 0)
            {
                return -1;
            }
            Account account = getElementById(id);
            List<Loan> accountLoans = _bankDbContext.Loans.Where(x => x.AccountId == id).ToList();
            loanSum = accountLoans.Sum(x =>x.totalAmount);
            account.DebtSum = loanSum;
            save();
            return loanSum;
        }

        public Loan RequestLoan(int id, decimal amount, string loanType)
        {
            Random IdGenerator = new Random();
            if (amount == 0)
            {
                return null;
            }
            Account account = getElementById(id);
            if (account == null || account.AccountType == "Regular")
            {
                return null;
            }
            Loan loan = new Loan
            {

                Bank = account.user.Bank,
                BankId = account.user.BankId,
                LoanId = IdGenerator.Next(),
                Account = account,
                AccountId = account.AccountId,
                totalAmount = amount
            };
                if (loanType == "")
                {
                    loan.DeadLine = DateTime.Now.AddMonths(6);
                    loan.RentPercentage = 3;
                }
                if (loanType == "Regular")
                {
                    loan.DeadLine = DateTime.Now.AddYears(1);
                    loan.RentPercentage = 2;
                }
                else if (loanType == "Extended" && account.AccountType == "Premium")
                {
                    loan.DeadLine = DateTime.Now.AddYears(5);
                    loan.RentPercentage = 1.25m;
                }
                else if (loanType == "Extended")
                {
                    loan.DeadLine = DateTime.Now.AddYears(3);
                    loan.RentPercentage = 1.75m;
                }


            _bankDbContext.Loans.Add(loan);
            save();
             return loan;
               
            }
        

        public Transaction DownPayment(int accountId, int loanId)
        {
            Account account = getElementById(accountId);
            Loan loan = account.LoanList.FirstOrDefault(x => x.LoanId==loanId);
            Random random = new Random();
            if(account == null || loan == null)
            {
                return null;
            }

            Transaction transaction = new Transaction
            {
                DownpaymentId = 1,
                TransactionId = random.Next(),
                isLoan = true,
                TransactionAmount = _loanService.CalculateMonthlyPayment(loanId),
                IsProcessed = true,
                TransactionDate = DateTime.Now,
              
            };
            Downpayment payment = new Downpayment
            {
                TransactionId = transaction.TransactionId,
                loan = loan,
                LoanId = loanId,
                DownpaymentId = random.Next()


            };
            _bankDbContext.Transactions.Add(transaction);
            _bankDbContext.Downpayments.Add(payment);
            save();
            return transaction;
        }

        public Transaction Withdraw(int it, decimal amount)
        {
            Account AccountToWithdrawFrom = getElementById(it);
            Random IdGenerator = new Random();
            if (AccountToWithdrawFrom == null || amount == 0)
            {
                return null;
            }
            else
            {
                Transaction transaction = new Transaction
                {
                    TransactionDate = DateTime.Now,
                    isDeposit = false,
                    IsProcessed = false,
                    TransactionAmount = amount,
                    TransactionId = IdGenerator.Next()

                };
                AccountTransaction withdrawTransaction = new AccountTransaction(
                AccountToWithdrawFrom.AccountId, transaction.TransactionId);
                _bankDbContext.Transactions.Add(transaction);
                _bankDbContext.accountTransactions.Add(withdrawTransaction);
                save();
                return transaction;
            }
        }
    }

}
