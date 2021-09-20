using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.Model;
using OnlineBooks.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Implementation
{
    public class UserService : IUserService
    {

        private IUserDataAccess _userDataAccess;

        public UserService(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task<IEnumerable<OnlineUserModel>> GetUsers()
        {
            return await _userDataAccess.GetUsers();
        }
         
        public OnlineUserModel GetUserByEmail(string email)
        {
            return _userDataAccess.GetUserByEmail(email);
        }

        public async Task<bool> CreateUser(OnlineUserModel request)
        {
            return await _userDataAccess.CreateUser(request);

        }

        public async Task<bool> UpdateUser(OnlineUserModel request)
        {
            return await _userDataAccess.UpdateUser(request);
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            return await _userDataAccess.DeleteUser(userId);
        }
    }
}
