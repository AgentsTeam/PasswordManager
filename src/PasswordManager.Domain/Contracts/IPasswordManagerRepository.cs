﻿using PasswordManager.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Contracts
{
    public interface IPasswordManagerRepository
    {
        User GetUser(string userName);
        Task<User> AddUserAsync(User user);

        Property GetProperty(int id);
        Task<Property> AddPropertyAsync(Property property);
    }
}
