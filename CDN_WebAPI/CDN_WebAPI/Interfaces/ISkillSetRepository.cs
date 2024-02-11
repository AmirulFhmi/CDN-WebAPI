using CDN_WebAPI.Models;

namespace CDN_WebAPI.Interfaces
{
    public interface ISkillSetRepository
    {
        ICollection<SkillSetModel> GetSkillSets(int userId);
        SkillSetModel? GetSkillSet(int skillSetId);
        bool CreateSkillSet(SkillSetModel skillSet);
        bool UpdateSkillSet(SkillSetModel skillSet);
        bool DeleteSkillSet(SkillSetModel skillSet);
        bool DeleteAllSkillSets(int userId);
        bool Save();
    }
}
