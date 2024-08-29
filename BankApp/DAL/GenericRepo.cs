using BankApp.Interface;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.DAL
{
    public class GenericRepo<T> : IRepository<T> where T : class
    {

        private readonly BankDbContext _bankDbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepo(BankDbContext bankDbContext)
        {
            _bankDbContext = bankDbContext;
            _dbSet = bankDbContext.Set<T>();
        }

        public void add(T record)
        {
            _dbSet.Add(record);
        }

        public void delete(int id)
        {
            var affected = getElementById(id);
            _dbSet.Remove(affected);
            save();
        }

        public IEnumerable<T> getAll()
        {
           return _dbSet.ToList();
        }

        public T getElementById(int id)
        {
            return _dbSet.Find(id);
        }

        public T getElementByStringId(string id)
        {
            return _dbSet.Find(id);
        }

        public void save()
        {
            _bankDbContext.SaveChanges();
        }

        public void update(T record)
        {
            _dbSet.Attach(record);
            _bankDbContext.Entry(record).State = EntityState.Modified;
        }
    }
}
