using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Contracts
{
    public interface IOnlineUserTypeDataAccess
    {
        Task<IEnumerable<OnlineUserTypeModel>> GetOnlineUserTypes();
        Task<bool> CreateOnlineUserType(OnlineUserTypeModel request);
        Task<bool> UpdateOnlineUserType(OnlineUserTypeModel request);
        Task<bool> DeleteOnlineUserType(Guid onlineUserTypeId);
    } 
}
 