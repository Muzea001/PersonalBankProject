namespace BankApp.DTOs
{
    public class LoanDTO
    {
        public int accountId {  get; set; }
        public decimal amount { get; set; }

        public string type { get; set; }
    }
}
