using OnlineBooks.Model;

namespace OnlineBooks.DataAccess.Contracts
{
    public interface IAuthDataAccess
    {
        OnlineUserModel GetUser(string email, string password);
    }
}
