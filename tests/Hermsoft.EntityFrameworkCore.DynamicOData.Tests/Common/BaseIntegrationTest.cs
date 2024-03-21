using Microsoft.Extensions.DependencyInjection;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
    {
        private IServiceScope _serviceScope;

        protected IntegrationTestWebAppFactory Factory { get; private set; }
        protected HttpClient HttpClient { get; private set; }
        protected IServiceProvider Provider => _serviceScope.ServiceProvider;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            Factory = factory;
            HttpClient = factory.CreateDefaultClient();

            _serviceScope = factory.Services.CreateScope();
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
            _serviceScope?.Dispose();
        }
    }
}