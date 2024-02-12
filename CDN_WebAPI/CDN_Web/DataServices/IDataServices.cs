using CDN_Web.Models;

namespace CDN_Web.DataServices
{
    public interface IDataServices
    {
        #region User
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUser(int id);
        Task<bool> CreateUser(UserModel user);
        Task<bool> UpdateUser(UserModel user);
        Task<bool> DeleteUser(int id);
        #endregion

        #region Hobby

        Task<List<HobbyModel>> GetAllHobbies(int userId);
        Task<HobbyModel> GetHobby(int hobbyId);
        Task<bool> CreateHobby(HobbyModel hobby);
        Task<bool> UpdateHobby(HobbyModel hobby);
        Task<bool> DeleteHobby(int hobbyId);
        Task<bool> DeleteAllHobbies(int userId);
        #endregion

        #region SkillSet

        Task<List<SkillSetModel>> GetAllSkillSets(int userId);
        Task<SkillSetModel> GetSkillSet(int skillsetId);
        Task<bool> CreateSkillSet(SkillSetModel skillset);
        Task<bool> UpdateSkillSet(SkillSetModel skillset);
        Task<bool> DeleteSkillSet(int skillsetId);
        Task<bool> DeleteAllSkillSets(int userId);

        #endregion
    }
}
