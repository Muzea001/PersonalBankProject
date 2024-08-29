using BankApp.Models;

namespace BankApp.Interface
{
    public interface IBank 
    {

        IEnumerable<Bank> overview();
        decimal calculateCurrentSavings(int id);
        decimal sumOfallLoans(int id);

        List<Account> accountsInBank(int id);
        decimal sumOfProjectedHoldings(int id);

    }
}
