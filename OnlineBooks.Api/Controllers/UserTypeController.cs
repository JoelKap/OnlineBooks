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
    public class UserTypeController : ControllerBase
    { 
        private IOnlineUserTypeService _userTypeService;
        public UserTypeController(IOnlineUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetUserTypes()
        {
            return Ok(await _userTypeService.GetOnlineUserTypes());
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUserType([FromBody] OnlineUserTypeModel request)
        {
            return Ok(await _userTypeService.CreateOnlineUserType(request));
        }


        [HttpPut()]
        public async Task<IActionResult> UpdateUserType([FromBody] OnlineUserTypeModel request)
        {
            return Ok(await _userTypeService.UpdateOnlineUserType(request));
        }

        [HttpDelete()] 
        public async Task<IActionResult> DeleteUserType(Guid onlineUserTypeId)
        {
            return Ok(await _userTypeService.DeleteOnlineUserType(onlineUserTypeId));
        }
    }
}
