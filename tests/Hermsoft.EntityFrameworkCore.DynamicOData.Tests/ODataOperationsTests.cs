using Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests
{
    public class ODataOperationsTests : BaseIntegrationTest
    {
        public ODataOperationsTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Get_RequestAllUsers()
        {
            var response = await HttpClient.GetAsync("/odata/Users");
            response.EnsureSuccessStatusCode();
        }
    }
}