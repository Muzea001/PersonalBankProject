namespace BankApp.Interface
{
    public interface IRepository<T> where T : class
   
    {
        T getElementById(int id);

        T getElementByStringId(string id);

        IEnumerable<T> getAll();

        void add(T record);

        void delete(int id);

        void update(T record);

        void save();
       

    }
}
