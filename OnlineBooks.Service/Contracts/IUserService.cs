using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<OnlineUserModel>> GetUsers(); 
        OnlineUserModel GetUserByEmail(string email);
        Task<bool> CreateUser(OnlineUserModel request);
        Task<bool> UpdateUser(OnlineUserModel request);
        Task<bool> DeleteUser(Guid userId);
    }
}
