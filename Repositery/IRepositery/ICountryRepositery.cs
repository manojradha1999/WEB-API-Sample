using WorldAPI.Model;

namespace WorldAPI.Repositery.IRepositery
{
    public interface ICountryRepositery
    {
        Task<List<Country>> GetAll();
        Task<Country> Get(int id);
        Task Create(Country country);
        Task Update(Country country);
        Task Delete(Country country);
        Task Save();

    }
}
