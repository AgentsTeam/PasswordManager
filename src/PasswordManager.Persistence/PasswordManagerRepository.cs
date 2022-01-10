using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Persistence
{
    public class PasswordManagerRepository : DbContext
    {
        public PasswordManagerRepository(DbContextOptions<PasswordManagerRepository> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
