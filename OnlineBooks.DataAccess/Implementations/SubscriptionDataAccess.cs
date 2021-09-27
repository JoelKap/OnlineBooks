using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.DataAccess.DTO;
using OnlineBooks.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Implementations
{
    public class SubscriptionDataAccess : ISubscriptionDataAccess
    {
        private readonly OnlineBooksContext _onlineBooksContext;
        private readonly IMapper _mapper;
        public SubscriptionDataAccess(OnlineBooksContext onlineBooksContext)
        {
            _onlineBooksContext = onlineBooksContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public async Task<bool> CreateSubscription(SubscriptionModel request)
        {
            var exist = _onlineBooksContext.Subscriptions.Where(x => x.UserId == request.UserId && x.CatalogueId == request.CatalogueId && x.IsDeleted == false).ToList();
            if (exist.Any())
                return false;

            request.Reference = GenerateSubscriptionReference();
            var subscriptionDto = new Subscription()
            {
                CatalogueId = request.CatalogueId,
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                Reference = request.Reference,
                SubscriptionId = Guid.NewGuid(),
                UserId = request.UserId
            };

           _onlineBooksContext.Subscriptions.Add(subscriptionDto);

            for (int i = 0; i < request.Catalogue.Books.Count; i++)
            {
                var book = request.Catalogue.Books[i];
                var unsubs = new Unsubscribe();
                unsubs.IsDeleted = false;
                unsubs.CreatedAt = DateTime.Now;
                unsubs.UnsubscribeId = Guid.NewGuid();
                unsubs.SubscriptionId = subscriptionDto.SubscriptionId;
                unsubs.UserId = subscriptionDto.UserId;
                unsubs.BookId = book.BookId;
                _onlineBooksContext.Unsubscribes.Add(unsubs);
            }
            _ = _onlineBooksContext.SaveChanges();
            return true;

        }

        public async Task<bool> DeleteSubscription(Guid subscriptionId)
        {
            Subscription subscriptionDto = _onlineBooksContext.Subscriptions.FirstOrDefault(x => x.SubscriptionId == subscriptionId);
            if (subscriptionDto is null)
                return false;
            subscriptionDto.IsDeleted = true;
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }

        public async Task<OnlineUserModel> GetUserSubscriptions(Guid userId)
        {
            var user = new OnlineUserModel();
            var userSubDto = _onlineBooksContext.OnlineUsers
                .Include(x => x.Subscriptions.Where(x => x.UserId == userId && x.IsDeleted == false))
                .FirstOrDefault(x => x.IsDeleted == false && x.UserId == userId);

            user = _mapper.Map<OnlineUser, OnlineUserModel>(userSubDto);
            return user;
        }

        private string GenerateSubscriptionReference()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
