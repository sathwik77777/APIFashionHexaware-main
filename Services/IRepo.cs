namespace FashionHexa.Services
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        bool Add(T item);
        bool Delete(int id);
        bool Update(T item);
    }
}
