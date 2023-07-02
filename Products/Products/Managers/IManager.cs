namespace Products.Managers
{
    interface IManager<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        bool Add(T item);
        bool DeleteByID(int id);
        bool Update(T item);
    }
}
