using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Sample8.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(p => p.Id);
            modelBuilder.Entity<Company>().HasData(new Company[] { new Company(1, "Тестовая компания", "7800245852", "mail@abc.com") });

            base.OnModelCreating(modelBuilder);
        }
    }
}
