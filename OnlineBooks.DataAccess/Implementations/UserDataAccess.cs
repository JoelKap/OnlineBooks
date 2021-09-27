using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.DataAccess.DTO;
using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Implementations
{
    public class UserDataAccess: IUserDataAccess
    {
        private readonly OnlineBooksContext _onlineBooksContext;
        private readonly IMapper _mapper;
        public UserDataAccess(OnlineBooksContext onlineBooksContext)
        {
            _onlineBooksContext = onlineBooksContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }
        public async Task<IEnumerable<OnlineUserModel>> GetUsers()
        {
            var users = new List<OnlineUserModel>();
            var usersDto = _onlineBooksContext.OnlineUsers.Where(x => x.IsDeleted == false).ToList();
            for (int i = 0; i < usersDto.Count; i++)
            {
                var user = _mapper.Map<OnlineUser, OnlineUserModel>(usersDto[i]);
                users.Add(user);
            }
            return users;
        }

        public OnlineUserModel GetUserByEmail(string email)
        {
            var userDto = _onlineBooksContext.OnlineUsers.Include(x => x.OnlineUserType).Where(x=> x.IsDeleted == false && x.Email == email).FirstOrDefault();
            var user = _mapper.Map<OnlineUser, OnlineUserModel>((OnlineUser)userDto);
            return user;
        }

        public async Task<bool> CreateUser(OnlineUserModel request)
        {
            request.UserId = Guid.NewGuid();
            request.OnlineUserTypeId = _onlineBooksContext.OnlineUserTypes.FirstOrDefault(x => x.IsDeleted == false && x.OnlineUserTypeName == "Internal_User").OnlineUserTypeId;
            request.IsDeleted = false;
            request.CreatedAt = DateTime.Now;
            var userDto = _mapper.Map<OnlineUserModel, OnlineUser>(request);
            _onlineBooksContext.OnlineUsers.Add(userDto);
           var response = _onlineBooksContext.SaveChanges();
            if(response == 1)
                return true;

            return false;
        }
        public async Task<bool> UpdateUser(OnlineUserModel request)
        {
            OnlineUser userDto = _onlineBooksContext.OnlineUsers.FirstOrDefault(x => x.UserId == request.UserId);
            _mapper.Map<OnlineUserModel, OnlineUser>(request, userDto);
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        } 
        public async Task<bool> DeleteUser(Guid userId)
        {
            OnlineUser userDto = _onlineBooksContext.OnlineUsers.FirstOrDefault(x => x.UserId == userId);
            if (userDto is null)
                return false;
            userDto.IsDeleted = true;
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }
    }
}
