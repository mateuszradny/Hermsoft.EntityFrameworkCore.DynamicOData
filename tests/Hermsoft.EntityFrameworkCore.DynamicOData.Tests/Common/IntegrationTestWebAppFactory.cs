using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi;
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
                var descriptorType = typeof(DbContextOptions<TestDbContext>);

                var descriptor = services
                    .SingleOrDefault(s => s.ServiceType == descriptorType);

                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<TestDbContext>(options =>
                    options.UseSqlServer(_dbContainer.GetConnectionString()));
            });
        }

        public Task InitializeAsync()
        {
            return _dbContainer.StartAsync();
        }

        public new Task DisposeAsync()
        {
            return _dbContainer.StopAsync();
        }
    }
}