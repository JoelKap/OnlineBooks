using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Contracts
{
    public interface IOnlineUserTypeService
    {
        Task<IEnumerable<OnlineUserTypeModel>> GetOnlineUserTypes();
        Task<bool> CreateOnlineUserType(OnlineUserTypeModel request);
        Task<bool> UpdateOnlineUserType(OnlineUserTypeModel request);
        Task<bool> DeleteOnlineUserType(Guid onlineUserTypeId);
    }
}
