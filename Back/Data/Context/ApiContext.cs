using BlueModasShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlueModasShop.Data.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=bluemodasshop;User ID=SA;Password=Kiltun@1025");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Cart> Carts { get; set; }

    }
}
