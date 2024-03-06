namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
    {
        protected HttpClient HttpClient { get; private set; }

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            HttpClient = factory.CreateDefaultClient();
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}