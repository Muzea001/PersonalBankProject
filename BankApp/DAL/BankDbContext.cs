using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace BankApp.Models

{
    public class BankDbContext : DbContext
    {

        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        public DbSet<Bank> Bank { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Loan> Loans { get; set; }

        public DbSet<Downpayment> Downpayments { get; set; }

        public DbSet<AccountTransaction>  accountTransactions {  get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Bank>()
                .HasMany(u => u.Users)
                .WithOne(a => a.Bank)
                .HasForeignKey(a => a.BankId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bank>()
               .HasMany(u => u.Loans)
               .WithOne(a => a.Bank)
               .HasForeignKey(a => a.BankId)
               .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Account>()
                  .HasMany(t => t.LoanList)
                  .WithOne(a => a.Account)
                  .HasForeignKey(a => a.AccountId);

                  modelBuilder.Entity<User>()
                 .HasOne(u => u.Bank)
                 .WithMany(b => b.Users)
                 .HasForeignKey(u => u.BankId)
                 .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<User>()
               .HasOne(u => u.UserAccount)
               .WithOne(a => a.user)
               .HasForeignKey<Account>(a => a.userId);

                modelBuilder.Entity<AccountTransaction>()
                .HasKey(at => new { at.AccountId, at.TransactionId });

                modelBuilder.Entity<AccountTransaction>()
                .HasOne(at => at.Account)
                .WithMany(a => a.AccountTransactions)
                .HasForeignKey(at => at.AccountId);

                modelBuilder.Entity<AccountTransaction>()
                .HasOne(at => at.Transaction)
                .WithMany(t => t.AccountTransactions)
                .HasForeignKey(at => at.TransactionId);

                 modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Downpayment)
                .WithOne(d => d.Transaction)
                .HasForeignKey<Downpayment>(d => d.TransactionId) 
                .OnDelete(DeleteBehavior.Restrict); 

                modelBuilder.Entity<Bank>()
                .HasMany(t => t.Accounts)
                .WithOne(t => t.bank)
                .HasForeignKey(t =>t.BankId)
                .OnDelete(DeleteBehavior.Restrict);

                 modelBuilder.Entity<Account>()
                .HasOne(t => t.bank)
                .WithMany(t => t.Accounts)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Downpayment>()
                .HasOne(d => d.Transaction)
                .WithOne(t => t.Downpayment)
                .HasForeignKey<Transaction>(t => t.DownpaymentId) 
                .OnDelete(DeleteBehavior.Restrict);

                    modelBuilder.Entity<Loan>()
                    .HasMany(l => l.associatedPayments)
                    .WithOne(d => d.loan)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.Cascade);

                    modelBuilder.Entity<Downpayment>()
                   .HasOne(d => d.loan)
                   .WithMany(l => l.associatedPayments)
                   .HasForeignKey(d => d.LoanId)
                   .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bank>().HasData(
                 new Bank {
                     BankId = 1,
                     BankName = "MyBank1",
                     SumOfDebt = 0,
                     SumOfHoldings = 100000000m,
                     
                   
                 }
                 
            );

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = 1,
                    BankId = 1,
                    Member = false,
                    UserName = "Mike Smith"
                },
                 new User()
                 {
                     UserId = 2,
                     BankId = 1,
                     Member = true,
                     UserName = "John Johnson"
                 }

                );

            modelBuilder.Entity<Account>().HasData(
               new Account()
               {
                  AccountId = 1,
                  DebtSum = 0,
                  AccountType = "Regular",
                  Balance = 0,
                  userId = 1,
                  BankId = 1
               },
                new Account()
                {
                    AccountId = 2,
                    DebtSum = 0,
                    AccountType = "Savings",
                    Balance = 0,
                    userId = 2,
                    BankId =1
                }
               );

            modelBuilder.Entity<Loan>().HasData(
               new Loan()
               {
                   AccountId = 1,
                   associatedPayments = { },
                   BankId = 1,
                   DeadLine = DateTime.Now.AddMonths(24),
                   RentPercentage = 5,
                   totalAmount = 150.000m,
                   LoanId = 1,
               }
               );
                modelBuilder.Entity<Transaction>().HasData(
                        new Transaction
                        {
                            TransactionId = 1,
                            TransactionAmount = 1000,
                            TransactionDate = DateTime.Now,
                            IsProcessed = true,
                            isDeposit = true,
                            isLoan = false
                        },
                        new Transaction
                            {
                          TransactionId = 2,
                          TransactionAmount = 2000,
                          TransactionDate = DateTime.Now,
                          IsProcessed = true,
                          isDeposit = false,
                          isLoan = true,
                          DownpaymentId = 1
                            }
                    );

            modelBuilder.Entity<AccountTransaction>().HasData(
            new AccountTransaction(1,1),
            new AccountTransaction(2,1)
                      );


            modelBuilder.Entity<Downpayment>().HasData(
                

                    new Downpayment
                    {
                        LoanId = 1,
                        TransactionId = 2,
                        DownpaymentId = 1

                    }



                );


            base.OnModelCreating(modelBuilder);

        }
    }
}
