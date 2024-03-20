using FluentAssertions;
using Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity;
using System.Net.Http.Json;
using System.Text.Json;

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

            var users = await response.Content.ReadFromJsonAsync<ODataResult<User>>(new JsonSerializerOptions
            {
                
            });
            users.value.Should().NotBeNullOrEmpty().And.HaveCountGreaterThanOrEqualTo(FakeData.Users.Count);
        }

        [Fact]
        public async Task Get_SingleRecord_ReturnsSingleRecord()
        {
            var response = await HttpClient.GetAsync($"/odata/User({FakeData.Users.First().Id})");
            response.Should().BeSuccessful();

            var user = await response.Content.ReadFromJsonAsync<User>();
            user.Should().NotBeNull().And.BeEquivalentTo(FakeData.Users.First());
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
            var user = FakeData.Users.First();
            user.Name = "Test";
            user.Email = "test@test.pl";

            var response = await HttpClient.PutAsJsonAsync($"/odata/User({user.Id})", user);
            response.Should().BeSuccessful();
        }

        [Fact]
        public async Task Patch_OneProperty_Returns2XX()
        {
            var response = await HttpClient.PatchAsJsonAsync($"/odata/User({FakeData.Users.First().Id})", new { Email = "test@test.pl" });
            response.Should().BeSuccessful();
        }

        [Fact]
        public async Task Delete_SingleRecord_Returns2XX()
        {
            var response = await HttpClient.DeleteAsync($"/odata/User({FakeData.Users.Last().Id})");
            response.Should().BeSuccessful();
        }
    }
}