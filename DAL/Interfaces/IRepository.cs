namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        T Get(object entity);
    }
}
