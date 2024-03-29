﻿using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.DataAccess.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Implementations
{
    public class UnsubscribeDataAccess: IUnsubscribeDataAccess
    {
        private readonly OnlineBooksContext _onlineBooksContext;
        public UnsubscribeDataAccess(OnlineBooksContext onlineBooksContext)
        {
            _onlineBooksContext = onlineBooksContext;
        }

        public async Task<bool> UnsubscribeUser(Guid userId, Guid SubscriptionId, Guid bookId)
        {
            var unSubDto = _onlineBooksContext.Unsubscribes.FirstOrDefault(x => x.IsDeleted == false && 
            x.UserId == userId && 
            x.SubscriptionId == SubscriptionId &&
            x.BookId == bookId);
            if (unSubDto is null)
                return false;
            unSubDto.IsDeleted = true;
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }
    }
}
