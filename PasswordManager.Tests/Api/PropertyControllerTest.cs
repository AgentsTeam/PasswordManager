using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PasswordManager.Api.Controllers;
using PasswordManager.Domain.Contracts;
using Xunit;

namespace PasswordManager.Tests.Unit.Api
{
    public class PropertyControllerTest
    {
        private readonly PropertyController _controller;
        
        public PropertyControllerTest()
        {
            var service = Substitute.For<IPropertyService>();
            _controller = new PropertyController(service);
        }

        [Fact]
        public void Get_ShouldReturnAProperty()
        {
            var property = _controller.Get(1);

            property.Should().BeOfType<OkObjectResult>();
        }
    }
}
