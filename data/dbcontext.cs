using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

namespace MyMvcApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }

        // 此方法僅在未透過 DI 設定時使用
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("");
            }
        }
    }

}
