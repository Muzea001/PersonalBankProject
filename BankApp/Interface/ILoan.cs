namespace BankApp.Interface
{
    public interface ILoan
    {

        decimal CalculateMonthlyPayment(int id);

        int PaymentsLeft(int id);

        decimal getTotalAmountPostRent(int id);

        int getPaymentCount(int id);


    }
}
