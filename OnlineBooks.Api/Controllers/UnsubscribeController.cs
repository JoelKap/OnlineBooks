using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Service.Contracts;
using System;
using System.Threading.Tasks;

namespace OnlineBooks.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UnsubscribeController : ControllerBase
    {
        private IUnsubscribeService _subscribeService;

        public UnsubscribeController(IUnsubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet()]
        public async Task<IActionResult> Unsubscribe(Guid userId, Guid subscriptionId)
        {
            return Ok(await _subscribeService.UnsubscribeUser(userId, subscriptionId));
        }
    }
}
