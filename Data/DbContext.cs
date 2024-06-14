using Microsoft.EntityFrameworkCore;

namespace dpc.InternetSalesAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ECommerce> ECommerces { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<CustomerItem> CustomerItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerItemConfiguration());
        }

    }
}