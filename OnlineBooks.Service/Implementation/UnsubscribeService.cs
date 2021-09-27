using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.Service.Contracts;
using System;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Implementation
{
    public class UnsubscribeService: IUnsubscribeService
    {
        private IUnsubscribeDataAccess _unsubscribeDataAccess;
        public UnsubscribeService(IUnsubscribeDataAccess unsubscribeDataAccess)
        {
            _unsubscribeDataAccess = unsubscribeDataAccess; 
        }

        public Task<bool> UnsubscribeUser(Guid userId, Guid SubscriptionId, Guid bookId)
        {
            return _unsubscribeDataAccess.UnsubscribeUser(userId, SubscriptionId, bookId);
        }
    }
}
 