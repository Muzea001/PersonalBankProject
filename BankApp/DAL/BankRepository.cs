using BankApp.Interface;
using BankApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BankApp.DAL
{
    
        public class BankRepository : GenericRepo<Bank>, IBank
        {
            private readonly BankDbContext _bankDbContext;
            private readonly DbSet<Bank> _dbSet;
            private readonly DbSet<Account> _accounts;
            private readonly DbSet<Loan> _loans;

            public BankRepository(BankDbContext bankDbContext) : base(bankDbContext)
            {
                _bankDbContext = bankDbContext;
                _dbSet = _bankDbContext.Set<Bank>(); 
                _accounts = _bankDbContext.Set<Account>();
                _loans = _bankDbContext.Set<Loan>();
            }

            public IEnumerable<Bank> overview()
        {
            return _dbSet.ToList(); 
            
        }


        public List<Account> accountsInBank(int id) {
        
              if (id  == 0)
            {
                return null;
            }

              var subliste = _accounts.Where(x => x.BankId==id).ToList();   
                return subliste;
        
        }
        public decimal calculateCurrentSavings(int id)
        {
            decimal sumOfAccounts;
            decimal currentSavings;
            var bank = _dbSet.FirstOrDefault(x => x.BankId == id);
            if (bank == null)
            {
                return 0;
            }
            else
            {
               var liste = accountsInBank(bank.BankId);
                sumOfAccounts = liste.Sum(x => x.Balance);
                currentSavings = sumOfAccounts - sumOfallLoans(id);
            }

            return currentSavings;
        }

        public decimal sumOfallLoans(int id)
        {
            var bank = getElementById(id);

            if (bank == null)
            {
                return 0;
            }
            double loanSuminDouble = (from loan in _loans
                               where loan.BankId == id
                               select (double)loan.totalAmount).Sum();

            decimal loanSum = (decimal)loanSuminDouble;
            return loanSum;
        }

        public decimal sumOfProjectedHoldings(int id)
        {
            var bank = getElementById(id);

            if (bank == null)
            {
                return 0;
            }

            decimal totalSumOfLoans = sumOfallLoans(id);
            decimal projectedHoldings = bank.SumOfHoldings+totalSumOfLoans;

            return projectedHoldings;
        }

        
    }
}
