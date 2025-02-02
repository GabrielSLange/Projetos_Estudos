using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }

        public DbSet<Post>? Posts { get; set; }

        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=Kira1veiga!;Trusted_Connection=False; TrustServerCertificate=True;");
            options.LogTo(Console.WriteLine);
        }


    }
}