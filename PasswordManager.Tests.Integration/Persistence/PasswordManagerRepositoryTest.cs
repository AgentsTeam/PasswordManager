using FluentAssertions;
using PasswordManager.Persistence;
using PasswordManager.Tests.Integration.ClassFixture;
using System;
using Xunit;
using PasswordManager.Tests.Unit.Domain.Domains.Builders;
using System.Transactions;

namespace PasswordManager.Tests.Integration.Persistence
{
    public class PasswordManagerRepositoryTest : IClassFixture<DatabaseFixture>
    {
        private readonly PasswordManagerRepository _repository;
        private readonly UserTestBuilder _userBuilder;
        private readonly PropertyTestBuilder _propertyTestBuilder;
        public PasswordManagerRepositoryTest(DatabaseFixture database)
        {
            _repository = new PasswordManagerRepository(database.Context);
            _userBuilder = new UserTestBuilder();
            _propertyTestBuilder = new PropertyTestBuilder();
        }

        [Fact]
        public void GetUserAsync_ShouldReturnUserWithName()
        {
            var users = _repository.GetUserAsync("foadTest").Result;

            users.Should().NotBeNull();
            users.UserName.Should().Be("foadTest");
        }

        [Fact]
        public void GetUserAsync_ShouldReturnUserWithId()
        {
            using (var scop = new TransactionScope())
            {
                var newUser = _userBuilder.BuildNewUser();
                var UserAdded = _repository.AddUserAsync(newUser).Result;

                var users = _repository.GetUserAsync(UserAdded.Id).Result;

                users.Should().BeEquivalentTo(newUser); 
            }
        }

        [Fact]
        public void AddUserAsync_shouldAddTheUserToDataBase()
        {
            using (var scope = new TransactionScope())
            {
                var newUser = _userBuilder.WithFirstName("TestAdduser").WithLastName("Test").BuildNewUser();

                var userAdded = _repository.AddUserAsync(newUser).Result;

                var users = _repository.GetUserAsync("TestUserName").Result;

                userAdded.Should().Be(users); 
            }
        }

        [Fact]
        public void AddUserAsync_shouldReturnTheUserThatProvided()
        {
            using (var scop = new TransactionScope())
            {
                var newUser = _userBuilder.WithFirstName("TestAdduser2").WithLastName("Test2").BuildNewUser();

                var userAdded = _repository.AddUserAsync(newUser).Result;

                userAdded.Should().BeEquivalentTo(newUser); 
            }
        }

        [Fact]
        public void UpdateUserAsync_ShouldUpdateUserProperly()
        {
            using (var scop = new TransactionScope())
            {
                var user = _userBuilder.WithUserName("alex").WithFirstName("Alex").WithLastName("Morgan").WithPassword("654321")
                        .WithEmail("alex.morgan@gmail.com").WithCreateDate(DateTime.UtcNow).BuildNewUser();
                var userAdded = _repository.AddUserAsync(user).Result;
                userAdded.UserName = "alfred Morgan";
                userAdded.Password = "987654";
                userAdded.FirstName = "Alfred";
                userAdded.LastName = "Morgan";
                userAdded.Email = "Morgan_Alfred@outlook.com";

                var userUpdated = _repository.UpdateUserAsync(userAdded).Result;
                var expectedUser = _repository.GetUserAsync(userAdded.Id).Result;

                userUpdated.Should().BeEquivalentTo(expectedUser); 
            }
        }

        [Fact]
        public void DeleteUserAsync_ShouldDeleteExistingUser()
        {
            var user = _userBuilder.BuildNewUser();
            var userCreated = _repository.AddUserAsync(user).Result;

            _repository.DeleteUserAsync(userCreated.Id).Wait();

            var expectedNullUser = _repository.GetUserAsync(userCreated.Id).Result;

            expectedNullUser.Should().BeNull();
        }

        [Fact]
        public void AddPropertyAsync_ShouldReturnThePropertyThatProvided()
        {
            using (var scop = new TransactionScope())
            {
                var user = _userBuilder.WithUserName("DavidTest").WithFirstName("fnTest").WithLastName("lnTest").BuildNewUser();
                var userAdded = _repository.AddUserAsync(user).Result;
                var newProperty = _propertyTestBuilder.WithUserId(userAdded.Id).Build();

                var propertyAdded = _repository.AddPropertyAsync(newProperty).Result;

                propertyAdded.Should().BeEquivalentTo(newProperty); 
            }
        }

        [Fact]
        public void GetPropertyAsync_ShouldReturnProperty()
        {
            using (var scop = new TransactionScope())
            {
                var user = _userBuilder.WithUserName("DavidTest").WithFirstName("fnTest").WithLastName("lnTest").BuildNewUser();
                var userAdded = _repository.AddUserAsync(user).Result;
                var newProperty = _propertyTestBuilder.WithUserId(userAdded.Id).Build();

                var propertyAdded = _repository.AddPropertyAsync(newProperty).Result;
                var property = _repository.GetPropertyAsync(propertyAdded.Id).Result;

                property.User.Should().Be(userAdded); 
            }
        }
    }
}
