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

        

        public async Task<User> GetUserAsync(string userName)
        {
            return await Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            await Users.AddAsync(user);
            await SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            Users.Update(user);
            await SaveChangesAsync();
            return user;

        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                Users.Remove(user);
                await SaveChangesAsync();
            }
        }

        public async Task<Property> GetPropertyAsync(int id)
        {
            return await Properties.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Property> AddPropertyAsync(Property property)
        {
            await Properties.AddAsync(property);
            await SaveChangesAsync();
            return property;
        }

    }
}
