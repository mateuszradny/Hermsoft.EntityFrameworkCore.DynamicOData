namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable, IAsyncLifetime
    {
        protected IntegrationTestWebAppFactory Factory { get; private set; }
        protected HttpClient HttpClient { get; private set; }

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            Factory = factory;
            HttpClient = factory.CreateDefaultClient();
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }

        public async Task InitializeAsync()
        {
            await Factory.ResetAsync();
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }
}