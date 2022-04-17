using FluentAssertions;
using PasswordManager.Persistence;
using PasswordManager.Tests.Integration.ClassFixture;
using System;
using System.Threading.Tasks;
using Xunit;
using PasswordManager.Tests.Unit.Domain.Domains.Builders;

namespace PasswordManager.Tests.Integration.Persistence
{
    public class PasswordManagerRepositoryTest : IClassFixture<DatabaseFixture>
    {
        private readonly PasswordManagerRepository _repository;
        private readonly UserTestBuilder _userBuilder;
        public PasswordManagerRepositoryTest(DatabaseFixture database)
        {
            _repository = database.Repository;
            _userBuilder = new UserTestBuilder();
        }

        [Fact]
        public async Task GetUserAsync_ShouldReturnUsers()
        {
            var users = await _repository.GetUserAsync("");

            users.Should().NotBeNull();
        }

        [Fact]
        public async Task AddUserAsync_shouldAddTheUserToDataBase()
        {
            var newUser = _userBuilder.Build();

            var userAdded = await _repository.AddUserAsync(newUser);

            userAdded.Should().NotBeNull();
        }
    }
}
