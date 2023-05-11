using GeekBurger.Orders.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekBurger.Orders.Repository
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
           : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<OrderChangedEvent> OrdersChangedEvents { get; set; }
    }
}
