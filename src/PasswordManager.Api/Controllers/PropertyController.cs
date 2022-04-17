using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Domain.Commands;
using PasswordManager.Domain.Contracts;
using PasswordManager.Service;

namespace PasswordManager.Api.Controllers
{
    /// <summary>
    /// User property services
    /// </summary>
    [Route("api/User/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyService _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public PropertyController(PropertyService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get property details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example :
        /// 
        ///     id : 2
        ///     
        /// </remarks>
        [Authorize]
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        /// <summary>
        /// Add a new property
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Example :
        /// 
        ///     {
        ///         "name" : "Pass1",
        ///         "value" : "1qaz@WSX3edc",
        ///         "description" : "We are using this sample propery everywhere!!!"
        ///     }
        /// </remarks>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(PropertyCommand command)
        {
            return Ok(await _service.AddAsync(command));
        }
    }
}
