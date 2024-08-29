namespace BankApp.Models
{
    public class AccountTransaction
    {
        public AccountTransaction(int accountId, int transactionId)
        {
            AccountId = accountId;
            TransactionId = transactionId;
            
        }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}
