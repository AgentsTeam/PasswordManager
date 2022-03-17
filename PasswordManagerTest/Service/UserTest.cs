using Xunit;
using PasswordManager.Service;
using System;

namespace PasswordManagerTest.Service
{
    public class UserTest
    {
        UserService userService = new UserService();

        [Fact]
        public void Get_ShouldReturnNullForInvalidId()
        {
            var result = userService.Get(Guid.Empty);
            Assert.Null(result);
        }

        [Fact]
        public void Get_ShouldReturnValidUserForValidId()
        { 
            var result = userService.Get(Guid.Empty);
        }
    }
}
