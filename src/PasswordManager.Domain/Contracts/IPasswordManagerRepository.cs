using PasswordManager.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Contracts
{
    public interface IPasswordManagerRepository
    {
        Task<User> GetUserAsync(string userName);
        Task<User> AddUserAsync(User user);

        Task<Property> GetPropertyAsync(int id);
        Task<Property> AddPropertyAsync(Property property);
    }
}
