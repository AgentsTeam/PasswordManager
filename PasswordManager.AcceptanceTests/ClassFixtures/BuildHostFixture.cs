using PasswordManager.AcceptanceTests.CoreHost;
using PasswordManager.AcceptanceTests.HostInformations;
using PasswordManager.AcceptanceTests.NetCoreHosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.AcceptanceTests.ClassFixtures
{
    public class BuildHostFixture : IDisposable
    {
        private readonly IStartableHost _host = new DotNetCoreHost(new DotNetCoreHostOptions()
        {
            CsProjectPath = HostConstants.CsProjectPath,
            Port = HostConstants.Port
        });

        public BuildHostFixture()
        {
            _host.Start();
        }

        public void Dispose()
        {
            _host.Stop();
        }
    }
}
