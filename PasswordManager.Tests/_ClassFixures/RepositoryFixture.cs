using Microsoft.EntityFrameworkCore;
using PasswordManager.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Tests.Unit._ClassFixures
{
    public class RepositoryFixture : IDisposable
    {
        public PasswordManagerRepository Repository { get; set; }

        public RepositoryFixture()
        {
            Repository = new PasswordManagerRepository(new DbContextOptions<PasswordManagerRepository>());
        }

        public void Dispose()
        {
            Repository.Dispose();
        }
    }
}
