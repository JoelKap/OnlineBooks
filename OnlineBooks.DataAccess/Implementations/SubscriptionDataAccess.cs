using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.DataAccess.DTO;
using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Implementations
{
   public class SubscriptionDataAccess: ISubscriptionDataAccess
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
            var subscriptionDto = _mapper.Map<SubscriptionModel, Subscription>(request);
            _onlineBooksContext.Subscriptions.Add(subscriptionDto);
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
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

        public async Task<IEnumerable<OnlineUserModel>> GetUserSubscriptions(Guid userId, string? email)
        {
            var users = new List<OnlineUserModel>();
            var userSubsDto = _onlineBooksContext.OnlineUsers
                .Include(x => x.IsDeleted == false && x.UserId == userId && x.Email == email)
                .Include(x => x.Subscriptions)
                .ToList();
            for (int i = 0; i < userSubsDto.Count; i++)
            {
                var user = _mapper.Map<OnlineUser, OnlineUserModel>(userSubsDto[i]);
                users.Add(user);
            }
            return users;
        }
    }
}
