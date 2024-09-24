using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure
{
    public class InventoryDBContext : DbContext
    {

        public InventoryDBContext(DbContextOptions<InventoryDBContext> options) :base(options) { }
      
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> ordersItem { get; set; }
        public DbSet<Stock> stocks { get; set; }
        public DbSet<Supplier> suppliers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryDBContext).Assembly);
           
        } 

    }
}
