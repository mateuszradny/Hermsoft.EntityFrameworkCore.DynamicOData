using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using Testcontainers.MsSql;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPassword("Strong_password_123!")
            .Build();

        private Respawner? _respawner;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptorType = typeof(DbContextOptions<TestDbContext>);

                var descriptor = services
                    .SingleOrDefault(s => s.ServiceType == descriptorType);

                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                var connectionString = _dbContainer.GetConnectionString();

                services.AddDbContext<TestDbContext>(options => options.UseSqlServer(connectionString));
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();

            var connectionString = _dbContainer.GetConnectionString();
            using var context = new TestDbContext(new DbContextOptionsBuilder<TestDbContext>()
                .UseSqlServer(connectionString)
                .Options);

            await context.Database.MigrateAsync();

            _respawner = await Respawner.CreateAsync(connectionString, new RespawnerOptions
            {
                TablesToIgnore = ["__EFMigrationsHistory"]
            });
        }

        public async Task ResetAsync()
        {
            var connectionString = _dbContainer.GetConnectionString();
            await _respawner.ResetAsync(connectionString);
        }

        public new Task DisposeAsync()
        {
            return _dbContainer.StopAsync();
        }
    }
}