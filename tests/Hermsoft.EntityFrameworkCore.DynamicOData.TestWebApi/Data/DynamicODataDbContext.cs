using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data
{
    public class DynamicODataDbContext : DbContext
    {
        public DynamicODataDbContext(DbContextOptions options) : base(options)
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DynamicODataDbContext).Assembly);
        }
    }
}