using EventWebApi.Models;
using Microsoft.EntityFrameworkCore;
namespace EventWebApi.Context
{
    public class PostgreDBContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

        public PostgreDBContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ApiBD;Username=postgres;Password=11");
        }

    }
}
