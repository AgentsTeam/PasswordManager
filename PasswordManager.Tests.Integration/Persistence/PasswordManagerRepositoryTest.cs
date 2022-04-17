﻿using FluentAssertions;
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
        public void GetUserAsync_ShouldReturnUsers()
        {
            var users = _repository.GetUserAsync("foad").Result;

            users.UserName.Should().Be("foad");
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
            var newProperty = _propertyTestBuilder.Build();

            var propertyAdded = _repository.AddPropertyAsync(newProperty).Result;

            propertyAdded.Should().BeEquivalentTo(newProperty);

        }

        


    }
}
