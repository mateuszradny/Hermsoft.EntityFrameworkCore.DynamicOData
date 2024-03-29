using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MsSql;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPassword("Strong_password_123!")
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptorType = typeof(DbContextOptions<SalesDbContext>);
                var descriptor = services.SingleOrDefault(s => s.ServiceType == descriptorType);
                if (descriptor is not null)
                    services.Remove(descriptor);

                descriptorType = typeof(DbContextOptions<HRDbContext>);
                descriptor = services.SingleOrDefault(s => s.ServiceType == descriptorType);
                if (descriptor is not null)
                    services.Remove(descriptor);

                var connectionString = _dbContainer.GetConnectionString();

                services.AddDbContext<SalesDbContext>(options => options.UseSqlServer(connectionString));
                services.AddDbContext<HRDbContext>(options => options.UseSqlServer(connectionString));
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();

            var connectionString = _dbContainer.GetConnectionString();
            using var salesContext = new SalesDbContext(new DbContextOptionsBuilder<SalesDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            await salesContext.Database.MigrateAsync();

            using var hrContext = new HRDbContext(new DbContextOptionsBuilder<HRDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            await hrContext.Database.MigrateAsync();
        }

        public new Task DisposeAsync()
        {
            return _dbContainer.StopAsync();
        }
    }
}