using FluentAssertions;
using Hermsoft.EntityFrameworkCore.DynamicOData.Tests.Common;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.HR;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hermsoft.EntityFrameworkCore.DynamicOData.Tests
{
    public class CustomRequestHandlerServiceTests : BaseIntegrationTest
    {
        public CustomRequestHandlerServiceTests(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Delete_WithCustomRequestHandlerService_ShouldThrowException()
        {
            var response = await HttpClient.DeleteAsync($"/hr/{nameof(Worker)}(1)");
            response.Should().HaveError();
        }
    }
}
