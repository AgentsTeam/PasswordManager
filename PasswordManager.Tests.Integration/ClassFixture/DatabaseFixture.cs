using Microsoft.EntityFrameworkCore;
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
                .UseNpgsql("Host=192.168.21.129;Database=passwordmanager;Username=postgres;Password=1qa@WS3ed123")
                .Options;
            Repository = new PasswordManagerRepository(option);
            _scop = new TransactionScope();
        }

        public void Dispose()
        {
            Repository.DisposeAsync();
            _scop.Dispose();
        }
    }
}
