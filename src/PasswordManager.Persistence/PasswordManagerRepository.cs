using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Contracts;
using PasswordManager.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Persistence
{
    public class PasswordManagerRepository : DbContext , IPasswordManagerRepository
    {
        public PasswordManagerRepository(DbContextOptions<PasswordManagerRepository> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }

        public async Task<User> AddUser(User user)
        {
            await Users.AddAsync(user);
            await SaveChangesAsync();
            return user;
        }

        public User GetUser(string userName)
        {
            return Users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
