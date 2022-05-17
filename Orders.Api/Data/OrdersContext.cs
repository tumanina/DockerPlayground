using Microsoft.EntityFrameworkCore;

namespace Orders.Api.Data
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}
