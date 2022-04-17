using PasswordManager.Domain.Domains;
using System;

namespace PasswordManager.Tests.Unit.Domain.Domains.Builders
{
    public class UserTestBuilder
    {
        string UserName { get; set; } = "TestUserName";
        string Password { get; set; } = "TestPassword";
        string FirstName { get; set; } = "TestFirstName";
        string LastName { get; set; } = "TestLastName";
        string Email { get; set; } = "TestEmail";
        DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public UserTestBuilder WithUserName(string userName)
        { 
            this.UserName = userName;
            return this;
        }

        public UserTestBuilder WithPassword(string password)
        { 
            this.Password = password;
            return this;
        }

        public UserTestBuilder WithFirstName(string firstName)
        {
            this.FirstName = firstName;
            return this;
        }

        public UserTestBuilder WithLastName(string lastName)
        {
            this.LastName = lastName;
            return this;
        }
        public UserTestBuilder WithEmail(string email)
        {
            this.Email = email;
            return this;
        }

        public UserTestBuilder WithCreateDate(DateTime createDate)
        {
            this.CreateDate = createDate;
            return this;
        }

        public User Build()
        {
            return new User(UserName,Password);
        }

        public User BuildNewUser()
        {
            return new User(FirstName, LastName, Email, UserName, Password, CreateDate);
        }
    }
}
