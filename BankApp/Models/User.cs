namespace BankApp.Models
{
    public class User
    {
        
        public int UserId { get; set; }

        public string UserName { get; set; }

        public bool Member {  get; set; }

        
        public Account UserAccount { get; set; }

        public int BankId { get; set; }
        public Bank Bank { get; set; }


    }
}
