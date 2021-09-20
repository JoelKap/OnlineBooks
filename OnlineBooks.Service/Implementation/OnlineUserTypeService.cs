using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.Model;
using OnlineBooks.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Implementation
{
    public class OnlineUserTypeService: IOnlineUserTypeService
    {
        private IOnlineUserTypeDataAccess _onlineUserTypeDataService;
        public OnlineUserTypeService(IOnlineUserTypeDataAccess onlineUserTypeDataService)
        {
            _onlineUserTypeDataService = onlineUserTypeDataService;
        }

        public async Task<bool> CreateOnlineUserType(OnlineUserTypeModel request)
        {
            return await _onlineUserTypeDataService.CreateOnlineUserType(request);
        }

        public async Task<bool> DeleteOnlineUserType(Guid onlineUserTypeId)
        {
            return await _onlineUserTypeDataService.DeleteOnlineUserType(onlineUserTypeId);
        }

        public Task<IEnumerable<OnlineUserTypeModel>> GetOnlineUserTypes()
        {
            return _onlineUserTypeDataService.GetOnlineUserTypes();
        }

        public async Task<bool> UpdateOnlineUserType(OnlineUserTypeModel request)
        {
            return await _onlineUserTypeDataService.UpdateOnlineUserType(request);
        }
    }
}
