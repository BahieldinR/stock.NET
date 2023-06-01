using Microsoft.EntityFrameworkCore;

namespace Stock_System.Model
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}