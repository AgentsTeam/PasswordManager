using FluentAssertions;
using PasswordManager.Persistence;
using PasswordManager.Tests.Unit._ClassFixures;
using PasswordManager.Tests.Unit.Domain.Domains.Builders;
using System.Threading.Tasks;
using Xunit;

namespace PasswordManager.Tests.Unit.Persistence
{
    public class PasswordManagerRepositoryTest : IClassFixture<RepositoryFixture>
    {
        private readonly PasswordManagerRepository _repository;
        public PasswordManagerRepositoryTest(RepositoryFixture repository)
        {
            this._repository = repository.Repository;
        }

        [Fact]
        public async Task AddUser_ShouldAddNewUserToUsers()
        {
            var newUser = new UserTestBuilder().BuildNewUser();
            await _repository.AddUserAsync(newUser);

            _repository.Users.Should().Contain(newUser);
        }

    }
}
