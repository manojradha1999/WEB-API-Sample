using WorldAPI.Model;

namespace WorldAPI.Repositery.IRepositery
{
    public interface IGenericRepositery<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T entity);
        Task Delete(T entity);
        Task Save();
    }
}
