using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("sales");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesDbContext).Assembly);

            FakeData.Init(10);
            modelBuilder.Entity<User>().HasData(FakeData.Users);
            modelBuilder.Entity<Role>().HasData(FakeData.Roles);
            modelBuilder.Entity<UserRole>().HasData(FakeData.UserRoles);
            modelBuilder.Entity<Order>().HasData(FakeData.Orders);
            modelBuilder.Entity<Product>().HasData(FakeData.Products);
            modelBuilder.Entity<OrderProduct>().HasData(FakeData.OrderProducts);
        }
    }
}