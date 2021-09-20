using AutoMapper;
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
   public class OnlineUserTypeDataAccess: IOnlineUserTypeDataAccess
    {
        private readonly OnlineBooksContext _onlineBooksContext;
        private readonly IMapper _mapper;

        public OnlineUserTypeDataAccess(OnlineBooksContext onlineBooksContext)
        {
            _onlineBooksContext = onlineBooksContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public async Task<bool> CreateOnlineUserType(OnlineUserTypeModel request)
        {
            var onlineUserTypeDto = _mapper.Map<OnlineUserTypeModel, OnlineUserType>(request);
            _onlineBooksContext.OnlineUserTypes.Add(onlineUserTypeDto);
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }

        public async Task<bool> DeleteOnlineUserType(Guid onlineUserTypeId)
        {
            OnlineUserType onlineUserTypeDto = _onlineBooksContext.OnlineUserTypes.FirstOrDefault(x => x.OnlineUserTypeId == onlineUserTypeId);
            if (onlineUserTypeDto is null)
                return false;
            onlineUserTypeDto.IsDeleted = true;
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }
         
        public async Task<IEnumerable<OnlineUserTypeModel>> GetOnlineUserTypes()
        {
            var onlineUserTypes = new List<OnlineUserTypeModel>();
            var usersDto = _onlineBooksContext.OnlineUserTypes.Where(x => x.IsDeleted == false).ToList();
            for (int i = 0; i < usersDto.Count; i++)
            {
                var user = _mapper.Map<OnlineUserType, OnlineUserTypeModel>(usersDto[i]);
                onlineUserTypes.Add(user);
            }
            return onlineUserTypes;
        }

        public async Task<bool> UpdateOnlineUserType(OnlineUserTypeModel request)
        {
            OnlineUserType userDto = _onlineBooksContext.OnlineUserTypes.FirstOrDefault(x => x.OnlineUserTypeId == request.OnlineUserTypeId);
            _mapper.Map<OnlineUserTypeModel, OnlineUserType>(request, userDto);
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }
    }
}
