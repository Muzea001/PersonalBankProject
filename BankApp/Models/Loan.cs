namespace BankApp.Models
{
    public class Loan
    {

        public int LoanId {  get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public decimal RentPercentage { get; set; }

        public decimal totalAmount { get; set; }
        public DateTime DeadLine {  get; set; }

        public List<Downpayment> associatedPayments { get; set; }


    }
}
