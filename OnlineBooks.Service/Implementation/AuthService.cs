using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.Model;
using OnlineBooks.Service.Contracts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineBooks.Service.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IAuthDataAccess _authDataAccess;
        private IConfiguration _config;
        public AuthService(IAuthDataAccess authDal, IConfiguration config)
        {
            _authDataAccess = authDal;
            _config = config;
        }

        public OnlineUserModel GetUser(string email, string password)
        {
            return _authDataAccess.GetUser(email, password);
        }
         
        public LoginResponseModel GetUserLoginResponse(OnlineUserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JwtConfig:secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.Name, user.Email.ToString()),
                     new Claim(ClaimTypes.Name, user.UserId.ToString()),
                     new Claim(ClaimTypes.Name, user.FirstName.ToString()),
                     new Claim(ClaimTypes.Name, user.LastName.ToString())
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "Online Books",
                Audience = "Online Books Test"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseModel response = new LoginResponseModel()
            {
                Token = tokenHandler.WriteToken(token),
                OnlineUserTypeId = user.OnlineUserTypeId,
                OnlineUserTypeName = user.UserType.OnlineUserTypeName
            };

            return response;
        }
    }
}
