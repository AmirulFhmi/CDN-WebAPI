using CDN_WebAPI.Models;

namespace CDN_WebAPI.Interfaces
{
    public interface IHobbyRepository
    {
        ICollection<HobbyModel> GetHobbies(int userId);
        HobbyModel? GetHobby(int hobbyId);
        bool CreateHobby(HobbyModel model);
        bool UpdateHobby(HobbyModel hobby);
        bool DeleteHobby(HobbyModel hobby);
        bool DeleteAllHobbies(int userId);
        bool Save();
    }
}
