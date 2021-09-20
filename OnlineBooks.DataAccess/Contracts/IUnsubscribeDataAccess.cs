using System;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Contracts
{
    public interface IUnsubscribeDataAccess
    {
        Task<bool> UnsubscribeUser(Guid userId, Guid SubscriptionId);
    }
}
 