using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Seeders
{
    public class TestDbContext : DynamicODataDbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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