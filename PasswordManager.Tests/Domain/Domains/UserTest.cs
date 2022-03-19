using FluentAssertions;
using Xunit;

namespace PasswordManager.Tests.Domain.Domains
{
    public class UserTest
    {
        [Fact]
        public void Constructor_ShouldConstructPropertyProperly()
        {
            string userName = "TestUserName";
            string password = "TestPassword";

            var result = new UserTestBuilder().Build();
            result.UserName.Should().Be(userName);
            result.Password.Should().Be(password);
        }

        [Fact]
        public void AddProperty_ShouldAddNewPropertyToUser_WhenPropertyPassed()
        { 
            var userResult = new UserTestBuilder().Build();
            var propertyResult = new PropertyTestBuilder().Build();

            userResult.AddProperty(propertyResult);

            userResult.Properties.Should().ContainEquivalentOf(propertyResult);
        }
    }
}
