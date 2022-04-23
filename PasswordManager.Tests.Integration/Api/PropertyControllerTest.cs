using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using Xunit;

namespace PasswordManager.Tests.Integration.Api
{
    public class PropertyControllerTest
    {

        private readonly RESTFulApiFactoryClient _restfulClient;

        public PropertyControllerTest()
        {
            //var appFactory = new WebApplicationFactory<Program>();
            //var httpClient = appFactory.CreateClient();
            //_restfulClient = new RESTFulApiFactoryClient(httpClient);
        }

        [Fact]
        public async void Get_ShouldReturnThePropertWithId()
        {
            var response = await _restfulClient.GetContentAsync<OkObjectResult>("/api/Property");

            response.Should().BeOfType<OkObjectResult>();
            response.StatusCode.Should().Be(200);
            response.Value.Should().NotBeNull();
            response.Value.Should().BeOfType(typeof(JsonResult));
        }
    }
}
