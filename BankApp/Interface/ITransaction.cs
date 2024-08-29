namespace BankApp.Interface
{
    public interface ITransaction
    {

        bool ChangeTransactionStatus(int id, bool newStatus);

        
    }
}
