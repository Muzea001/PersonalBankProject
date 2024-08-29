namespace BankApp.DTOs
{
    public class TransactionDTO
    {

        public int AccountId { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public decimal DebtSum { get; set; }
        public int LoanId { get; set; }
        public int BankId { get; set; }
        public int UserId { get; set; }
    }
}
