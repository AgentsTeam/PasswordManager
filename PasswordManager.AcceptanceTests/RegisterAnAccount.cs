using PasswordManager.AcceptanceTests.Steps;
using PasswordManager.Domain.Commands;
using TestStack.BDDfy;
using Xunit;

namespace PasswordManager.AcceptanceTests
{
    public class RegisterAnAccount
    {
        StepsOfRegisterAnAccount steps = new StepsOfRegisterAnAccount();

        UserRegisterCommand user = new UserRegisterCommand()
        { 
            FirstName = "Neo",
            LastName = "Matrix",
            Email = "Neo_Matrix@gmail.com",
            Password = "!@#123",
            UserName = "NeoMatrix"
        };

        [Fact]
        public void CreateAnewAccount()
        {
            this.Given(_ => steps.IWantToCreateAnAccountAsUser(user) , "Given I want to create Neo Matrix account as User")
                .When(_ => steps.IPressRegisterButton())
                .Then(_ => steps.MyAccountShouldBeCreatedinUsers(user), "Then Neo Matrix Account should be created in Users")
                .BDDfy();
        }

    }
}
