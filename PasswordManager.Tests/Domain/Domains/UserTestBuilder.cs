using PasswordManager.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Tests.Domain.Domains
{
    internal class UserTestBuilder
    {
        string Username { get; set; } = "TestUserName";
        string Password { get; set; } = "TestPassword";

        public UserTestBuilder WithUserName(string userName)
        { 
            this.Username = userName;
            return this;
        }

        public UserTestBuilder WithPassword(string password)
        { 
            this.Password = password;
            return this;
        }

        public User Build()
        {
            return new User(Username,Password);
        }
    }
}
