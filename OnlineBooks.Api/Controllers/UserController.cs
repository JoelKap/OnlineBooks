using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Model;
using OnlineBooks.Service.Contracts;
using System;
using System.Threading.Tasks;

namespace OnlineBooks.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            return Ok( _userService.GetUserByEmail(email));
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> CreateUser([FromBody] OnlineUserModel request)
        {
            return Ok(await _userService.CreateUser(request));
        }


        [HttpPut()]
        public async Task<IActionResult> UpdateUser([FromBody] OnlineUserModel request)
        {
            return Ok(await _userService.UpdateUser(request));
        }
         
        [HttpDelete()]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            return Ok(await _userService.DeleteUser(userId));
        }
    }
}
