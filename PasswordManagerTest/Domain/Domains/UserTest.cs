using PasswordManager.Domain.Domains;
using System;
using Xunit;

namespace PasswordManagerTest.Domain.Domains
{
    public class UserTest
    {
        [Fact]
        public void Constructor_ShouldConstructPropertyProperly()
        {
            string userName = "TestUserName";
            string password = "TestPassword";

            var result = new User(userName, password);
            Assert.Equal(userName, result.UserName);
            Assert.Equal(password, result.Password);
        }
    }
}
