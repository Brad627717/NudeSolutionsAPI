using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<InsuredItem> InsuredItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InsuredItem>()
            .HasOne(_ => _.Category)
            .WithMany(a => a.InsuredItems)
            .HasForeignKey(p => p.CategoryId);
        }
    }
}
