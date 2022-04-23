using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Domains;

namespace PasswordManager.Persistence
{
    public class PasswordManagerContext : DbContext
    {
        public PasswordManagerContext(DbContextOptions<PasswordManagerContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
