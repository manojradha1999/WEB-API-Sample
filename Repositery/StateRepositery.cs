using Microsoft.EntityFrameworkCore;
using WorldAPI.Data;
using WorldAPI.Model;
using WorldAPI.Repositery.IRepositery;

namespace WorldAPI.Repositery
{
    public class StateRepositery: IStateRepositery
    {
        private readonly ApplicationDbContext _dbContext;
        public StateRepositery(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(State entity)
        {
            await _dbContext.states.AddAsync(entity);
            await Save();

        }

        public async Task Delete(State entity)
        {
            _dbContext.states.Remove(entity);
            await Save();
        }

        public async Task<State> Get(int id)
        {
            State state = await _dbContext.states.FindAsync(id);
            return state;

        }

        public async Task<List<State>> GetAll()
        {
            List<State> states = await _dbContext.states.ToListAsync();
            return states;
        }

        public async Task Update(State entity)
        {
            _dbContext.states.Update(entity);
            await Save();
        }
    }
}
