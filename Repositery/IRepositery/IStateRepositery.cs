using WorldAPI.Model;

namespace WorldAPI.Repositery.IRepositery
{
    public interface IStateRepositery
    {
        Task<List<State>> GetAll();
        Task<State> Get(int id);
        Task Create(State entity);
        Task Update(State entity);
        Task Delete(State entity);
        Task Save();
    }
}
