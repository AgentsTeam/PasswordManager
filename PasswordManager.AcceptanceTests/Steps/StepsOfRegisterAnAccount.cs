using FluentAssertions;
using PasswordManager.AcceptanceTests.HostInformations;
using PasswordManager.Domain.Commands;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PasswordManager.AcceptanceTests.Steps
{
    public class StepsOfRegisterAnAccount
    {
        private HttpStatusCode _responseStatus;

        private UserRegisterCommand _userRegister;

        public void IWantToCreateAnAccountAsUser(UserRegisterCommand userRegister)
        {
            _userRegister = userRegister;
        }

        public void IPressRegisterButton()
        {
            _responseStatus = PostTheRegisterAccountAsync(_userRegister).Result;
        }

        public void MyAccountShouldBeCreatedinUsers()
        {
            _responseStatus.Should().Be(HttpStatusCode.OK);
            
        }

        private async Task<HttpStatusCode> PostTheRegisterAccountAsync(UserRegisterCommand userRegister)
        {
            var restClient = new RestClient(HostConstants.Endpoint);
            var restRequest = new RestRequest("Account/Register", Method.Post);
            restRequest.AddJsonBody(userRegister);
            var response = await restClient.PostAsync(restRequest);
            return response.StatusCode;
        }
    }
}
