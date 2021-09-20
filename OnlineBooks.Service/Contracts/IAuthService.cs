using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Contracts
{
   public interface IAuthService
    { 
        OnlineUserModel GetUser(string email, string password);
        LoginResponseModel GetUserLoginResponse(OnlineUserModel user);
    }
}
