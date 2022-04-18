using FluentAssertions;
using PasswordManager.Persistence;
using PasswordManager.Tests.Integration.ClassFixture;
using System;
using System.Threading.Tasks;
using Xunit;
using PasswordManager.Tests.Unit.Domain.Domains.Builders;
using System.Linq;

namespace PasswordManager.Tests.Integration.Persistence
{
    public class PasswordManagerRepositoryTest : IClassFixture<DatabaseFixture>
    {
        private readonly PasswordManagerRepository _repository;
        private readonly UserTestBuilder _userBuilder;
        private readonly PropertyTestBuilder _propertyTestBuilder;
        public PasswordManagerRepositoryTest(DatabaseFixture database)
        {
            _repository = database.Repository;
            _userBuilder = new UserTestBuilder();
            _propertyTestBuilder = new PropertyTestBuilder();
        }

        [Fact]
        public void GetUserAsync_ShouldReturnUserWithName()
        {
            var users = _repository.GetUserAsync("foad").Result;

            users.UserName.Should().Be("foad");
        }

        [Fact]
        public void GetUserAsync_ShouldReturnUserWithId()
        {
            var newUser = _userBuilder.BuildNewUser();
            var UserAdded = _repository.AddUserAsync(newUser).Result;
            
            var users = _repository.GetUserAsync(UserAdded.Id).Result;

            users.Should().BeEquivalentTo(newUser);
        }

        [Fact]
        public void AddUserAsync_shouldAddTheUserToDataBase()
        {
            var newUser = _userBuilder.BuildNewUser();

            var userAdded = _repository.AddUserAsync(newUser).Result;

            var users = _repository.GetUserAsync("TestUserName").Result;

            userAdded.Should().Be(users);
        }

        [Fact]
        public void AddUserAsync_shouldReturnTheUserThatProvided()
        {
            var newUser = _userBuilder.BuildNewUser();

            var userAdded = _repository.AddUserAsync(newUser).Result;

            userAdded.Should().BeEquivalentTo(newUser);
        }

        [Fact]
        public void AddPropertyAsync_ShouldReturnThePropertyThatProvided()
        {
            var newProperty = _propertyTestBuilder.WithUserId(_repository.Users.FirstOrDefault(x=>x.UserName.ToLower() == "foad").Id).Build();

            var propertyAdded = _repository.AddPropertyAsync(newProperty).Result;
            
            propertyAdded.Should().BeEquivalentTo(newProperty);
        }

        [Fact]
        public void GetPropertyAsync_ShouldReturnProperty()
        {
            var newProperty = _propertyTestBuilder.WithUserId(_repository.Users.FirstOrDefault(x => x.UserName.ToLower() == "foad").Id).Build();

            var propertyAdded = _repository.AddPropertyAsync(newProperty).Result;
            var property = _repository.GetPropertyAsync(propertyAdded.Id).Result;

            var user = _repository.GetUserAsync("foad").Result;

            property.User.Should().Be(user);
        }

        [Fact]
        public void AddPropertyAsync_ShouldAddThePropertyToDataBase()
        {
            var user = _repository.GetUserAsync("foad").Result;

            var newProperty = _propertyTestBuilder.WithUserId(user.Id).Build();

            var propertyAdded = _repository.AddPropertyAsync(newProperty).Result;

            propertyAdded.Should().BeEquivalentTo(newProperty);

        }

        [Fact]
        public void UpdateUserAsync_ShouldUpdateUserProperly()
        {
            var user = _repository.GetUserAsync("foad").Result;
            user.UserName = "Foad Pashah";
            user.Password = "654321";
            user.FirstName = "Foad";
            user.LastName = "Pashah";
            user.Email = "Pashah_foad@outlook.com";

            var userUpdated = _repository.UpdateUserAsync(user).Result;

            var expectedUser = _repository.GetUserAsync(user.Id).Result;

            userUpdated.Should().BeEquivalentTo(expectedUser);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldDeleteExistingUser()
        { 
            var user = _userBuilder.BuildNewUser();
            var userCreated = _repository.AddUserAsync(user).Result;

            await _repository.DeleteUserAsync(userCreated.Id);

            var expectedNullUser = _repository.GetUserAsync(userCreated.Id).Result;

            expectedNullUser.Should().BeNull();
        }




        


    }
}
