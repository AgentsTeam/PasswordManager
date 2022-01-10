using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Common.Helpers;
using PasswordManager.Common.Models;
using PasswordManager.Domain.Commands;
using PasswordManager.Domain.Contracts;
using PasswordManager.Domain.Domains;

namespace PasswordManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSetting _jwtSetting;
        private readonly IPasswordManagerRepository _repository;
        public AccountController(JwtSetting jwtSetting, IPasswordManagerRepository repository)
        {
            _jwtSetting = jwtSetting;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterCommand command)
        {
            var user = new User(command.UserName,command.Password)
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email
            };
            user = await _repository.AddUser(user);
            if (user != null)
            {
                return Ok();
            }
            return BadRequest("Cannot create a user");
        }

        [HttpPost]
        public IActionResult Login(UserLoginCommand command)
        {
            try
            {
                var user = _repository.GetUser(command.UserName);
                if (user != null)
                {
                    if (user.Password == command.Password)
                    {
                        var token = JwtHelper.GetTokenkey(new JwtToken()
                        {
                            Email = user.Email,
                            GuidId = Guid.NewGuid(),
                            UserName = user.UserName,
                            Id = user.Id,
                        }, _jwtSetting);

                        return Ok(token);
                    }
                }
                return NotFound($"User/Password Incorrect");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get List of UserAccounts
        /// </summary>
        /// <returns>List Of UserAccounts</returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetList()
        {
            return Ok();
        }
    }
}
