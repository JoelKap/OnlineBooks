using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Contracts
{
    public interface ISubscriptionDataAccess
    {
        Task<IEnumerable<OnlineUserModel>> GetUserSubscriptions(Guid userId, string? email);
        Task<bool> CreateSubscription(SubscriptionModel request);
        Task<bool> DeleteSubscription(Guid subscriptionId);
    }
}
 