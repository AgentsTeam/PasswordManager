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

        

        public User GetUser(string userName)
        {
            return Users.FirstOrDefault(x => x.UserName == userName);
        }
        public async Task<User> AddUserAsync(User user)
        {
            await Users.AddAsync(user);
            await SaveChangesAsync();
            return user;
        }

        public Property GetProperty(int id)
        {
            return Properties.Find(id);
        }
        public async Task<Property> AddPropertyAsync(Property property)
        {
            await Properties.AddAsync(property);
            await SaveChangesAsync();
            return property;
        }

        
    }
}
