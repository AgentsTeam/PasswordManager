using Xunit;
using PasswordManager.Service;
using System;

namespace PasswordManager.Tests.Service
{
    public class UserServiceTest
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
