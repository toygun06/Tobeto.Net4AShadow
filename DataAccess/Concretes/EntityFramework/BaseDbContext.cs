using Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concretes.EntityFramework
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb; Database=Tobeto4AShadow;" +
                "Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
