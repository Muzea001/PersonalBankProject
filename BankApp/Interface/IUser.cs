namespace BankApp.Interface
{
    public interface IUser
    {

        bool SwapBank(int id, int newBankId);

        bool ChangeMemebershipStatus(bool member, int id);

    }
}
