using FluentAssertions;
using Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.HR;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests
{
    public class MultipleDynamicODataConfigurationTests : BaseIntegrationTest
    {
        public MultipleDynamicODataConfigurationTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Get_FromMultipleConfigurations_Return200()
        {
            var response = await HttpClient.GetAsync($"/sales/{nameof(Order)}");
            response.Should().BeSuccessful();

            response = await HttpClient.GetAsync($"/hr/{nameof(Worker)}");
            response.Should().BeSuccessful();

            response = await HttpClient.GetAsync($"/sales/{nameof(Product)}");
            response.Should().BeSuccessful();

            response = await HttpClient.GetAsync($"/hr/{nameof(Skill)}");
            response.Should().BeSuccessful();
        }
    }
}