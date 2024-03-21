using FluentAssertions;
using Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests
{
    public class ODataResult<TEntity>
    {
        public TEntity[] value { get; set; }
    }

    public class ODataOperationsTests : BaseIntegrationTest
    {
        public ODataOperationsTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Get_Collection_ReturnsNotEmptyCollection()
        {
            var response = await HttpClient.GetAsync("/odata/User");
            response.Should().BeSuccessful();

            var usersResult = await response.Content.ReadFromJsonAsync<ODataResult<User>>();
            usersResult!.value.Should().NotBeNullOrEmpty().And.HaveCountGreaterThanOrEqualTo(FakeData.Users.Count);
        }

        [Fact]
        public async Task Get_SingleRecord_ReturnsSingleRecord()
        {
            var context = Provider.GetRequiredService<DynamicODataDbContext>();
            var dbUser = context.Users.First();

            var response = await HttpClient.GetAsync($"/odata/User({dbUser.Id})");
            response.Should().BeSuccessful();

            var user = await response.Content.ReadFromJsonAsync<User>();
            user.Should().NotBeNull().And.BeEquivalentTo(dbUser);
        }

        [Fact]
        public async Task Post_SingleRecord_Returns2XX()
        {
            var newUser = FakeData.CreateUser();

            var response = await HttpClient.PostAsJsonAsync("/odata/User", newUser);
            response.Should().BeSuccessful();
        }

        [Fact]
        public async Task Put_SingleRecord_Returns2XX()
        {
            var context = Provider.GetRequiredService<DynamicODataDbContext>();
            var dbUser = context.Users.First();
            dbUser.Name = "Test";
            dbUser.Email = "test@test.pl";

            var response = await HttpClient.PutAsJsonAsync($"/odata/User({dbUser.Id})", dbUser);
            response.Should().BeSuccessful();
        }

        [Fact]
        public async Task Patch_OneProperty_Returns2XX()
        {
            var context = Provider.GetRequiredService<DynamicODataDbContext>();
            var dbUser = context.Users.First();

            var response = await HttpClient.PatchAsJsonAsync($"/odata/User({dbUser.Id})", new { Email = "test@test.pl" });
            response.Should().BeSuccessful();
        }

        [Fact]
        public async Task Delete_SingleRecord_Returns2XX()
        {
            var context = Provider.GetRequiredService<DynamicODataDbContext>();
            var dbUser = context.Users.OrderBy(x => x.Id).Last();

            var response = await HttpClient.DeleteAsync($"/odata/User({dbUser.Id})");
            response.Should().BeSuccessful();

            dbUser = context.Users.FirstOrDefault(x => x.Id == dbUser.Id);
            dbUser.Should().BeNull();
        }
    }
}