using BankApp.Interface;
using BankApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BankApp.DAL
{
    public class UserRepository : GenericRepo<User>, IUser
    {

        private readonly BankDbContext _bankDbContext;
        private readonly DbSet<User> _dbSet;
        private readonly IRepository<Bank> _bankService;
       

        public UserRepository(BankDbContext bankDbContext, IRepository<Bank> bankService) : base(bankDbContext)
        {
            _bankDbContext = bankDbContext;
            _dbSet = bankDbContext.Set<User>();
            _bankService = bankService;
        }

        public bool ChangeMemebershipStatus(bool status, int id)
        {
            var user = getElementById(id);
            if (user != null)
            {
                return false;
            }
            user.Member = status;
            return true;
        
        
        }

        public bool SwapBank(int id, int newBankId)
        {
            var user = getElementById(id);
            if (user != null) { return false; }
            user.BankId = id;
            Bank newBank = _bankService.getElementById(newBankId);
            if (newBank != null)
            {
                return false;
            }
            user.Bank = newBank;
            user.BankId = newBankId;
            return true;
        }
    }
}
