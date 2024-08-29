using BankApp.Interface;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.DAL
{
    public class TransactionRepository : GenericRepo<Transaction>, ITransaction
    {

        private readonly BankDbContext _bankDbContext;
        private readonly DbSet<Transaction> _dbSet;

        public TransactionRepository(BankDbContext bankDbContext) : base(bankDbContext)
        {
            _bankDbContext = bankDbContext;
            _dbSet = bankDbContext.Set<Transaction>();
        }

        public bool ChangeTransactionStatus(int id, bool newStatus)
        {
            Transaction transaction = getElementById(id);
            if (transaction == null)
            {
                return false;
            }
            transaction.IsProcessed = newStatus;
            return true;
        }
    }
}
