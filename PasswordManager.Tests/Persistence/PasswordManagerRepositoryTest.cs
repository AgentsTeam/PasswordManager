using Xunit;
using System;
using FluentAssertions;
using PasswordManager.Tests.Unit.Domain.Domains.Builders;
using PasswordManager.Persistence;
using NSubstitute;
using Microsoft.EntityFrameworkCore;

namespace PasswordManager.Tests.Unit.Persistence
{
    public class PasswordManagerRepositoryTest
    {
        private readonly UserTestBuilder _userTestBuilder;
        private readonly PasswordManagerRepository _repository;

        public PasswordManagerRepositoryTest()
        {
            var context = Substitute.For<DbContextOptions<PasswordManagerRepository>>();
            this._userTestBuilder = new UserTestBuilder();
            this._repository = new PasswordManagerRepository(context);
        }

        [Fact]
        public void GetUserAsync_ShouldReturnTheUser_WhenUserNamePassed()
        {
            var newUser = _userTestBuilder.BuildNewUser();
            var user = _repository.GetUserAsync(newUser.UserName);

            user.Should().Be(newUser);
        }
    }
}
