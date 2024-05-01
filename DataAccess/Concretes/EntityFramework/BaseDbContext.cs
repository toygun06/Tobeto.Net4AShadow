using Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concretes.EntityFramework
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb; Database=Tobeto4AShadow;" +
                "Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        //Spesifik konfigürasyonlar vermek için OnModelCreating kullanılır.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasOne(i => i.Category);
            modelBuilder.Entity<Product>().Property(i => i.Name).HasColumnName("Name").HasMaxLength(50);

            //Seed Data
            //Veritabanını oluşturduğumuzda kontrol etmek için deneme verileri
            int categoryId = 0;
            Category category = new Category(++categoryId, "Giyim");
            Category category1 = new(++categoryId, "Elektronik");

            Product product = new Product(1, "Kazak", 500, 50, 1);

            modelBuilder.Entity<Category>().HasData(category, category1);
            modelBuilder.Entity<Product>().HasData(product);

            base.OnModelCreating(modelBuilder);
        }
    }
}
