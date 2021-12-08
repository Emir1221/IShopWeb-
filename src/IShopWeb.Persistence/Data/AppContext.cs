using IShopWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IShopWeb.Persistence.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
