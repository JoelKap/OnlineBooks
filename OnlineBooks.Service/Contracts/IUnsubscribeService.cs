using System;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Contracts
{
    public interface IUnsubscribeService
    {
        Task<bool> UnsubscribeUser(Guid userId, Guid SubscriptionId);
    }
}
