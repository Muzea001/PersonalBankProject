using BankApp.Interface;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.DAL
{
    public class LoanRepository : GenericRepo<Loan>, ILoan
    {

        private readonly BankDbContext _bankDbContext;
        private readonly DbSet<Loan> _dbSet;

        public LoanRepository(BankDbContext bankDbContext) : base(bankDbContext)
        {
            _bankDbContext = bankDbContext;
            _dbSet = bankDbContext.Set<Loan>();
        }

        public decimal CalculateMonthlyPayment(int id)
        {

            if(id == 0)
            {
                return 0;
            }
            Loan loan = getElementById(id);
            decimal rentPercentage  = loan.RentPercentage;
            decimal totalAmount = loan.totalAmount;
            DateTime currentDate = DateTime.Now;
            int sumOfMonths = ((loan.DeadLine.Year - currentDate.Year) * 12) + loan.DeadLine.Month - currentDate.Month;
            decimal monthlyPayment = (totalAmount / sumOfMonths)*rentPercentage;

            return monthlyPayment;
        }

        public int getPaymentCount(int id)
        {
            Loan loan = getElementById(id);
            if(loan == null)
            {
                return -1;
            }
            int paymentCount = (int)(getTotalAmountPostRent(id) / CalculateMonthlyPayment(id));
            return paymentCount;
        }

        public decimal getTotalAmountPostRent(int id)
        {
            if(id == 0)
            {
                return -1;
            }   
            Loan loan = getElementById(id);
            decimal totalAmount = loan.totalAmount;
            DateTime currentDate = DateTime.Now;
            int sumOfMonths = ((loan.DeadLine.Year - currentDate.Year) * 12) + loan.DeadLine.Month - currentDate.Month;
            decimal sumOfYears = (sumOfMonths) / 12;
            decimal totalAmountPostRent = totalAmount + (totalAmount * loan.RentPercentage / 100 * sumOfYears);
            return totalAmountPostRent;
        }

        public int PaymentsLeft(int id)
        {
            Loan loan = getElementById(id);
            if (loan == null)
            {
                return 0;
            }
            int paymentsLeft = getPaymentCount(id)-loan.associatedPayments.Count();
            return paymentsLeft;
        }
    }
}
