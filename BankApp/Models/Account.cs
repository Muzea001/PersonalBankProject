namespace BankApp.Models
{
    public class Account
    {

        public int AccountId {  get; set; }

        public string AccountType { get; set; }

        public decimal Balance { get; set; }

        public decimal DebtSum { get; set; }

        public List<AccountTransaction> AccountTransactions { get; set; }

        public int LoanId { get; set; }
        public List<Loan> LoanList { get; set; }

        public int BankId { get; set; }

        public Bank bank { get; set; }

        public int userId { get; set; }
        public User user { get; set; }
    }
}
