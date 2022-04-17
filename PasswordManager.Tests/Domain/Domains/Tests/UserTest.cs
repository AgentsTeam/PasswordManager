using FluentAssertions;
using PasswordManager.Tests.Unit.Domain.Domains.Builders;
using System;
using Xunit;

namespace PasswordManager.Tests.Unit.Domain.Domains.Tests
{
    public class UserTest
    {
        private readonly UserTestBuilder _userBuilder;
        private readonly PropertyTestBuilder _propertyBuilder;
        public UserTest()
        {
            this._userBuilder = new UserTestBuilder();
            this._propertyBuilder = new PropertyTestBuilder();
        }


        [Fact]
        public void Constructor_ShouldConstructUserProperly()
        {
            string userName = "TestUserName";
            string password = "TestPassword";

            var result = new UserTestBuilder().Build();
            result.UserName.Should().Be(userName);
            result.Password.Should().Be(password);
        }

        [Theory]
        [InlineData("", "TestPassword")]
        [InlineData("TestUserName", "")]
        public void Constructor_ShouldReturnException_WhenInputValueIsNotProvided(string userName, string password)
        {
            Action result = () => _userBuilder
            .WithUserName(userName).WithPassword(password).Build();
            result.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_ShouldConstructNewUserProperly()
        {
            string userName = "TestUserName";
            string password = "TestPassword";
            string firstName = "TestFirstName";
            string lastName = "TestLastName";
            string email = "TestEmail";
            DateTime createDate = DateTime.UtcNow;

            var result = _userBuilder.BuildNewUser();

            result.UserName.Should().Be(userName);
            result.Password.Should().Be(password);
            result.FirstName.Should().Be(firstName);
            result.LastName.Should().Be(lastName);
            result.Email.Should().Be(email);
            result.CreateDate.Date.Should().Be(createDate.Date);
        }

        [Theory]
        [InlineData("", "TestLastName", "TestUserName", "TestPassword", false)]
        [InlineData("TestFirstName", "", "TestUserName", "TestPassword", false)]
        [InlineData("TestFirstName", "TestLastName", "", "TestPassword", false)]
        [InlineData("TestFirstName", "TestPassword", "TestUserName", "", false)]
        [InlineData("TestFirstName", "TestPassword", "TestUserName", "TestPassword", true)]
        public void Constructor_ShouldReturnException_WhenInputValueOfNewUserIsNotProvided
            (string firstName,string lastName,string userName, string password,bool isdateNul)
        {
            DateTime createDate = !isdateNul ? DateTime.Now.Date : DateTime.MaxValue;
            Action result = () => _userBuilder
            .WithFirstName(firstName).WithLastName(lastName).WithUserName(userName).WithPassword(password)
            .WithCreateDate(createDate).BuildNewUser();

            result.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void AddProperty_ShouldAddNewPropertyToUser_WhenPropertyPassed()
        {
            var userResult = _userBuilder.Build();
            var propertyResult = _propertyBuilder.Build();

            userResult.AddProperty(propertyResult);

            userResult.Properties.Should().ContainEquivalentOf(propertyResult);
        }

        
    }
}
