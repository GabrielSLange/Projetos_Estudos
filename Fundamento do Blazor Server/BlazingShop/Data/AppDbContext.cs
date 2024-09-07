using BlazingShop.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions _options) : base(_options) { }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
