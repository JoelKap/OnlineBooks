using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Contracts
{
    public interface IUserDataAccess
    {
        Task<IEnumerable<OnlineUserModel>> GetUsers(); 
        OnlineUserModel GetUserByEmail(string email);
        Task<bool> CreateUser(OnlineUserModel request);
        Task<bool> UpdateUser(OnlineUserModel request);
        Task<bool> DeleteUser(Guid userId);
    }
}
