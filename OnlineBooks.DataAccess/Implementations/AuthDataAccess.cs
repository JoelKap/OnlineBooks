using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.DataAccess.DTO;
using OnlineBooks.Model;
using System.Linq;

namespace OnlineBooks.DataAccess.Implementations
{
    public class AuthDataAccess : IAuthDataAccess
    {
        private readonly OnlineBooksContext _onlineBooksContext;
        private readonly IMapper _mapper;
        public AuthDataAccess(OnlineBooksContext onlineBooksContext)
        {
            _onlineBooksContext = onlineBooksContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public OnlineUserModel GetUser(string email, string password)
        {
            var userDto = _onlineBooksContext.OnlineUsers
                        .Include(x => x.OnlineUserType)
                        .Where(x => x.IsDeleted == false && x.Email == email && x.Password == password).FirstOrDefault();
            var user = _mapper.Map<OnlineUser, OnlineUserModel>((OnlineUser)userDto);

            user.UserType.OnlineUserTypeName = _onlineBooksContext.OnlineUserTypes.FirstOrDefault(x => x.OnlineUserTypeId == user.OnlineUserTypeId).OnlineUserTypeName;

            return user;
        }
    }
}
