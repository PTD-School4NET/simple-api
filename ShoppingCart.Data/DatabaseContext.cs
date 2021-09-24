using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShoppingCart.Common.Database;
using ShoppingCart.Data.SeedData;
using ShoppingCart.Models;

namespace ShoppingCart.Data
{
    public class DatabaseContext : DbContext
    {
        private DatabaseSettings _databaseSettings { get; set; }
        public DbSet<Product> Product { get; set; }

        public DatabaseContext(IOptions<DatabaseSettings> dbOptions)
        {
            this._databaseSettings = dbOptions.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._databaseSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Description).IsRequired().HasMaxLength(5000);
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Product>().Property(x => x.Image).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.CreatedAt).IsRequired();
            modelBuilder.Entity<Product>().HasData(ProductSeedData.GetInitialProducts());
        }
    }
}
