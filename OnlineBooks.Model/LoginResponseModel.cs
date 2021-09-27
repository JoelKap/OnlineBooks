using System;

namespace OnlineBooks.Model
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public string OnlineUserTypeName { get; set; } 
        public Guid OnlineUserTypeId { get; set; }
    }
}
 