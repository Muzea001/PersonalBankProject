using System.Xml.Linq;

namespace BankApp.Models
{
    public class Bank
    {

        public int BankId { get; set; }
        public string BankName {  get; set; }

        public decimal SumOfHoldings { get; set; }

        public decimal SumOfDebt { get; set; }

        public List<User> Users { get; set; }

        public List<Account> Accounts { get; set; }

        public List<Loan> Loans { get; set; }

        public override string ToString()
        {
            return $"Id: {BankId}, Name: {BankName}, Sum of money: {SumOfHoldings}, Sum of debt = {SumOfDebt}";
        }
    }
}

