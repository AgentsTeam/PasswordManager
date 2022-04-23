using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Domains;
using PasswordManager.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PasswordManager.Tests.Integration.ClassFixture
{
    public class DatabaseFixture : IDisposable
    {
        private readonly TransactionScope _scop;
        public PasswordManagerContext Context;

        private User user1 = new User("FoadTest", "Pashah", "foad.2000matrix@gmail.com", "foadTest", "123456", DateTime.UtcNow);
        private User user2 = new User("MasoudTest", "Moghadam", "Masoud.test@gmail.com", "MasoudTest", "123456", DateTime.UtcNow);
        private Property property1 = new Property("GooglePassTest", "Password Of google", "123456789", Guid.NewGuid());
        public DatabaseFixture()
        {
            var option = new DbContextOptionsBuilder<PasswordManagerContext>()
                .UseNpgsql("Host=srv2.sakkogroup.ir:2345;Database=passwordmanager;Username=postgres;Password=1qa@WS3ed123")
                .Options;
            Context = new PasswordManagerContext(option);
            
            Context.AddRange(new[] { user1, user2 });
            Context.SaveChanges();

            property1.UserId = user1.Id;
            property1.User = user1;

            Context.Add(property1);
            Context.SaveChanges();
            
        }

        public void Dispose()
        {
            Context.Properties.Remove(property1);
            Context.Users.RemoveRange(new User[] { user1, user2 });
            Context.SaveChanges();
            Context.Dispose();
        }
    }
}
