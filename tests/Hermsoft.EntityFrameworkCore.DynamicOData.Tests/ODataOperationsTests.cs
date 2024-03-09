using FluentAssertions;
using Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common;
using Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Seeders;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Identity;
using System.Net.Http.Json;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests
{
    public class ODataOperationsTests : BaseIntegrationTest
    {
        public ODataOperationsTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Get_Collection_ReturnsNotEmptyCollection()
        {
            var response = await HttpClient.GetAsync("/odata/Users");
            response.Should().BeSuccessful();

            var users = await response.Content.ReadFromJsonAsync<User[]>();
            users.Should().NotBeNullOrEmpty().And.HaveCount(FakeData.Users.Count);
        }

        [Fact]
        public async Task Get_SingleRecord_ReturnsSingleRecord()
        {
            var response = await HttpClient.GetAsync($"/odata/Users({FakeData.Users.First().Id})");
            response.Should().BeSuccessful();

            var user = await response.Content.ReadFromJsonAsync<User>();
            user.Should().NotBeNull().And.BeEquivalentTo(FakeData.Users.First());
        }

        [Fact]
        public async Task Post_SingleRecord_Returns2XX()
        {
            var newUser = FakeData.CreateUser();

            var response = await HttpClient.PostAsJsonAsync("/odata/Users", newUser);
            response.Should().BeSuccessful();
        }

        [Fact]
        public async Task Put_SingleRecord_Returns2XX()
        {
            var user = FakeData.Users.First();
            user.Name = "Test";
            user.Email = "test@test.pl";

            var response = await HttpClient.PutAsJsonAsync($"/odata/Users({user.Id})", user);
            response.Should().BeSuccessful();
        }

        [Fact]
        public async Task Patch_OneProperty_Returns2XX()
        {
            var response = await HttpClient.PatchAsJsonAsync($"/odata/Users({FakeData.Users.First().Id})", new { Email = "test@test.pl" });
            response.Should().BeSuccessful();
        }

        [Fact]
        public async Task Delete_SingleRecord_Returns2XX()
        {
            var response = await HttpClient.DeleteAsync($"/odata/Users({FakeData.Users.First().Id}");
            response.Should().BeSuccessful();
        }
    }
}