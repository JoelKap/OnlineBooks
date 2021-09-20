using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.Model;
using OnlineBooks.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Implementation
{
    public class SubscriptionService: ISubscriptionService
    {
        private ISubscriptionDataAccess _subscriptionDataService;
        public SubscriptionService(ISubscriptionDataAccess subscriptionDataService)
        {
            _subscriptionDataService = subscriptionDataService;
        }

        public async Task<bool> CreateSubscription(SubscriptionModel request)
        {
            return await _subscriptionDataService.CreateSubscription(request);
        }

        public async Task<bool> DeleteSubscription(Guid subscriptionId)
        {
            return await _subscriptionDataService.DeleteSubscription(subscriptionId);
        }

        public Task<IEnumerable<OnlineUserModel>> GetUserSubscriptions(Guid userId, string email)
        {
            return _subscriptionDataService.GetUserSubscriptions(userId, email);
        }
    }
}
