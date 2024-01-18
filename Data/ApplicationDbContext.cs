using Microsoft.EntityFrameworkCore;
using WorldAPI.Model;

namespace WorldAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Country> countries { get; set; }

        public DbSet<State> states { get; set; }
    }
}
