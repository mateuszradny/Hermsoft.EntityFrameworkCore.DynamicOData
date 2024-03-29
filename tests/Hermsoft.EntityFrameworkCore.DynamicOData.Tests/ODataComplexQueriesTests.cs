using FluentAssertions;
using Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales;
using System.Net.Http.Json;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests
{
    public class ODataComplexQueriesTests : BaseIntegrationTest
    {
        public ODataComplexQueriesTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Get_QueryWithSelect_ReturnsOnlySelectedFields()
        {
            var response = await HttpClient.GetAsync($"/sales/{nameof(Order)}?$select={nameof(Order.TotalPrice)}");
            response.Should().BeSuccessful();

            var usersResult = await response.Content.ReadFromJsonAsync<ODataResult<Order>>();
            usersResult!.value.Select(x => x.Id).Should().AllBeEquivalentTo(0);
            usersResult!.value.Select(x => x.UserId).Should().AllBeEquivalentTo(Guid.Empty);
            usersResult!.value.Select(x => x.OderedOn).Should().AllBeEquivalentTo((DateTimeOffset)default);
        }

        [Fact]
        public async Task Get_QueryWithExpand_ReturnsCollectionWithExpandedEntities()
        {
            var response = await HttpClient.GetAsync($"/sales/{nameof(Order)}?$expand={nameof(Order.User)}");
            response.Should().BeSuccessful();

            var usersResult = await response.Content.ReadFromJsonAsync<ODataResult<Order>>();
            usersResult!.value.Select(x => x.User).Should().NotContainNulls();
        }

        [Fact]
        public async Task Get_QueryWithFilter_ReturnsMatchedEntities()
        {
            var response = await HttpClient.GetAsync($"/sales/{nameof(Order)}?$filter={nameof(Order.TotalPrice)} gt 1");
            response.Should().BeSuccessful();

            var usersResult = await response.Content.ReadFromJsonAsync<ODataResult<Order>>();
            usersResult!.value.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task Get_QueryWithOrderBy_ReturnsSortedEntities()
        {
            var response = await HttpClient.GetAsync($"/sales/{nameof(Order)}?$orderby={nameof(Order.TotalPrice)}");
            response.Should().BeSuccessful();

            var usersResult = await response.Content.ReadFromJsonAsync<ODataResult<Order>>();
            usersResult!.value.Select(x => x.TotalPrice).Should().BeInAscendingOrder();
        }

        [Fact]
        public async Task Get_QueryWithGroupBy_ReturnsGroupedEntities()
        {
            var response = await HttpClient.GetAsync($"/sales/{nameof(Order)}?$apply=groupby(({nameof(Order.UserId)}), aggregate({nameof(Order.TotalPrice)} with sum as total))");
            response.Should().BeSuccessful();

            var usersResult = await response.Content.ReadFromJsonAsync<ODataResult<Order>>();
            usersResult!.value.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task Get_ComplexQuery_ReturnsValidResult()
        {
            var response = await HttpClient.GetAsync($"/sales/{nameof(Order)}?$select={nameof(Order.TotalPrice)}&$filter={nameof(Order.UserId)} ne null&$orderby={nameof(Order.TotalPrice)} desc&$expand={nameof(Order.User)}");
            response.Should().BeSuccessful();
        }
    }
}