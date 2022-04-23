using PasswordManager.AcceptanceTests.CoreHost;
using PasswordManager.AcceptanceTests.HostInformations;
using PasswordManager.AcceptanceTests.NetCoreHosting;
using PasswordManager.Domain.Commands;

namespace PasswordManager.AcceptanceTests.Steps
{
    public class StepsOfRegisterAnAccount
    {
        private readonly IStartableHost _host = new DotNetCoreHost(new DotNetCoreHostOptions()
        {
            CsProjectPath = HostConstants.CsProjectPath,
            Port = HostConstants.Port
        });

        public void IWantToCreateAnAccountAsUser(UserRegisterCommand userRegister)
        {
            _host.Start();
        }

        public void IPressRegisterButton()
        { 
            
        }

        public void MyAccountShouldBeCreatedinUsers(UserRegisterCommand userRegister)
        { 
            _host.Stop();
        }
    }
}
