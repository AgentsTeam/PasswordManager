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
    [Consumes("application/json")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly JwtSetting _jwtSetting;
        private readonly IPasswordManagerRepository _repository;
        public AccountController(JwtSetting jwtSetting, IPasswordManagerRepository repository)
        {
            _jwtSetting = jwtSetting;
            _repository = repository;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// 
        /// Example :
        /// 
        ///     {
        ///         "userName" : "masoudmghd",
        ///         "password" : "password",
        ///         "firstName" : "Masoud",
        ///         "lastName" : "Moghaddam",
        ///         "email" : "masoud.mghd@gmail.com"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterCommand command)
        {
            var user = new User(command.UserName,command.Password)
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email
            };
            user = await _repository.AddUserAsync(user);
            if (user != null)
            {
                return Ok();
            }
            return BadRequest("Cannot create a user");
        }

        /// <summary>
        /// Login with username and password
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// 
        /// Example :
        /// 
        ///     {
        ///         "userName" : "masoudmghd",
        ///         "password" : "password"
        ///     }
        /// </remarks>
        [HttpPost]
        public IActionResult Login(UserLoginCommand command)
        {
            try
            {
                var user = _repository.GetUserAsync(command.UserName).Result;
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
    }
}
