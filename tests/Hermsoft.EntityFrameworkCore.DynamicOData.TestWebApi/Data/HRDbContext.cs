using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.HR;
using Microsoft.EntityFrameworkCore;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkerSkill> WorkerSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("hr");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRDbContext).Assembly);
        }
    }
}