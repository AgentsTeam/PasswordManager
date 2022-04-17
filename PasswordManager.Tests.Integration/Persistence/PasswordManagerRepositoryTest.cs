using FluentAssertions;
using PasswordManager.Persistence;
using PasswordManager.Tests.Integration.ClassFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PasswordManager.Tests.Integration.Persistence
{
    public class PasswordManagerRepositoryTest : IClassFixture<DatabaseFixture>
    {
        private readonly PasswordManagerRepository _repository;
        public PasswordManagerRepositoryTest(DatabaseFixture database)
        {
            _repository = database.Repository;
        }

        [Fact]
        public async Task GetUserAsync_ShouldReturnUsers()
        {
            var users = await _repository.GetUserAsync("");

            users.Should().NotBeNull();
        }
    }
}
