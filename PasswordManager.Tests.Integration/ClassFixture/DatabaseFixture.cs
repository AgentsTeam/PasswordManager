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
        public PasswordManagerRepository Repository;
        public TransactionScope _scop;
        
        public DatabaseFixture()
        {
            var option = new DbContextOptionsBuilder<PasswordManagerRepository>()
                .UseNpgsql("Host=srv2.sakkogroup.ir:2345;Database=passwordmanager;Username=postgres;Password=1qa@WS3ed123")
                .Options;
            Repository = new PasswordManagerRepository(option);
            _scop = new TransactionScope();

            var user1 = new User("Foad", "Pashah", "foad.2000matrix@gmail.com","foad", "123456", DateTime.UtcNow);
            var user2 = new User("Masoud", "Moghadam", "Masoud.test@gmail.com", "Masoud", "123456", DateTime.UtcNow);

            Repository.AddRange(new[] { user1, user2 });
            Repository.SaveChanges();

            var property1 = new Property("GooglePass", "Password Of google", "123456789", user1.Id);

            
            Repository.Add(property1);
            Repository.SaveChanges();
            
        }

        public void Dispose()
        {
            Repository.DisposeAsync();
            _scop.Dispose();
        }
    }
}
