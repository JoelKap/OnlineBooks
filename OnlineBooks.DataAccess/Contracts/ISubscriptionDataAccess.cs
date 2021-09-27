using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Contracts
{
    public interface ISubscriptionDataAccess
    {
        Task<OnlineUserModel> GetUserSubscriptions(Guid userId);
        Task<bool> CreateSubscription(SubscriptionModel request);
        Task<bool> DeleteSubscription(Guid subscriptionId);
    }
}
 