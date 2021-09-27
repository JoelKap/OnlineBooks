using OnlineBooks.Model;
using System;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Contracts
{
    public interface ISubscriptionService
    {
        Task<OnlineUserModel> GetUserSubscriptions(Guid userId);
        Task<bool> CreateSubscription(SubscriptionModel request);
        Task<bool> DeleteSubscription(Guid subscriptionId);
    }
}
