using Microsoft.EntityFrameworkCore;
using StoreDatabase.Entities;

namespace StoreDatabase.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product //1
                {
                    ProductID = 1,
                    ProductName = "Cheese Pizza",
                    ProductPrice = 9.99f
                },
                new Product //2
                {
                    ProductID = 2,
                    ProductName = "Veggie Pizza",
                    ProductPrice = 10.99f
                }, new Product  //3
                {
                    ProductID = 3,
                    ProductName = "Peperonni Pizza",
                    ProductPrice = 12.99f
                }, new Product  //4
                {
                    ProductID = 4,
                    ProductName = "Supreme Pizza",
                    ProductPrice = 13.99f
                }, new Product  //5
                {
                    ProductID = 5,
                    ProductName = "Bread Sticks",
                    ProductPrice = 1.99f
                }, new Product  //6
                {
                    ProductID = 6,
                    ProductName = "Soft Drink",
                    ProductPrice = 1.99f
                });
        }
    }
}

