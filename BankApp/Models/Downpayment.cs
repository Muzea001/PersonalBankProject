namespace BankApp.Models
{
    public class Downpayment
    {

        public int DownpaymentId { get; set; }

        public int LoanId { get; set; }

        public Loan loan { get; set; }

        public int TransactionId { get; set; }   
        public Transaction Transaction { get; set; }


        
    }
}
