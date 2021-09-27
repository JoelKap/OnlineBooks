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
    public class SubscriptionController : ControllerBase
    {
        private ISubscriptionService _subscriptionService;
        public SubscriptionController(ISubscriptionService subcriptionServie)
        {
            _subscriptionService = subcriptionServie;
        }

        [HttpGet("{userId}/")]
        public async Task<IActionResult> GetUserSubscriptions(Guid userId)
        {
            return Ok(await _subscriptionService.GetUserSubscriptions(userId));
        }

        [HttpPost()]
        public async Task<IActionResult> CreateSubscription([FromBody] SubscriptionModel request)
        {
            return Ok(await _subscriptionService.CreateSubscription(request));
        }


        [HttpDelete("{subscriptionId}/")]
        public async Task<IActionResult> DeleteSubscription(Guid subscriptionId)
            {
            return Ok(await _subscriptionService.DeleteSubscription(subscriptionId));
        }
    }
}
