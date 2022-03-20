using FluentAssertions;
using PasswordManager.Tests.Unit.Domain.Domains.Builders;
using System;
using Xunit;

namespace PasswordManager.Tests.Unit.Domain.Domains.Tests
{
    
    public class PropertyTest
    {
        private readonly PropertyTestBuilder _propertyBuilder;
        public PropertyTest()
        {
            this._propertyBuilder = new PropertyTestBuilder();
        }
        
        [Fact]
        public void Constructor_ShouldConstructPropertyProperly()
        {
            string name = "TestName";
            string description = "TestDesc";
            string value = "TestValue";
            Guid userId = Guid.NewGuid();

            var result = _propertyBuilder.WithUserId(userId).Build();
            result.Name.Should().Be(name);
            result.Description.Should().Be(description);
            result.Value.Should().Be(value);
            result.UserId.Should().Be(userId);
        }

        [Theory]
        [InlineData("", "TestDesc", "TestValue", true)]
        [InlineData("TestName", "", "TestValue", true)]
        [InlineData("TestName", "TestDesc", "", true)]
        [InlineData("TestName", "TestDesc", "TestValue", false)]
        public void Constructor_shouldReturnException_WhenInputValueIsNotProvided(string name, string description, string value, bool newGuid)
        {
            Guid userId = newGuid ? Guid.NewGuid() : Guid.Empty;
            Action result = () => _propertyBuilder
            .WithName(name).WithDescription(description).WithValue(value).WithUserId(userId).Build();
            result.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}
