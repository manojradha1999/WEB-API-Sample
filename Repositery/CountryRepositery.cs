using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using WorldAPI.Data;
using WorldAPI.Model;
using WorldAPI.Repositery.IRepositery;

namespace WorldAPI.Repositery
{
    public class CountryRepositery : ICountryRepositery
    {
        private readonly ApplicationDbContext _dbContext;
        public CountryRepositery( ApplicationDbContext dbContext) { 

            _dbContext = dbContext;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(Country country)
        {
             await _dbContext.countries.AddAsync(country);
             await Save();

        }

        public async Task Delete(Country country)
        {
            _dbContext.countries.Remove(country);
            await Save();
        }

        public async Task<Country> Get(int id)
        {
            Country country = await _dbContext.countries.FindAsync(id);
            return country;

        }

        public async Task<List<Country>> GetAll()
        {
            List< Country > countries = await _dbContext.countries.ToListAsync();
            return countries;
        }

        public async Task Update(Country country)
        {
            _dbContext.countries.Update(country);
            await Save();
        }
    }
}
