namespace BankApp.Models
{
    public class Transaction
    {

        public int TransactionId { get; set; }

        public List<AccountTransaction> AccountTransactions { get; set; }

        public DateTime TransactionDate { get; set; }

        public bool isDeposit { get; set; }

        public decimal TransactionAmount { get; set; }

        public bool? isLoan { get; set; }

        public bool IsProcessed { get; set; }

        public int? DownpaymentId { get; set; }  
        public Downpayment Downpayment { get; set; }
    }
}
