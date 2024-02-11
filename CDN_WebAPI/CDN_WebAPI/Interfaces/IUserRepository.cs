using CDN_WebAPI.Models;

namespace CDN_WebAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<UserModel> GetAllUsers();
        UserModel? GetUser(int id);
        bool IsUserExists(int id);
        bool CreateUser(UserModel user);
        bool UpdateUser(UserModel user);
        bool DeleteUser(UserModel user);
        bool Save();

    }
}
