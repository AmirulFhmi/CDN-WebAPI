using CDN_WebAPI.Data;
using CDN_WebAPI.Interfaces;
using CDN_WebAPI.Models;

namespace CDN_WebAPI.Repositories
{
    public class SkillSetRepository : ISkillSetRepository
    {
        private readonly DataContext _context;

        public SkillSetRepository(DataContext context)
        {
            this._context = context;
        }

        #region Get skillset
        public ICollection<SkillSetModel> GetSkillSets(int userId)
        {
            return _context.SkillSet.Where(u => u.UserId == userId).OrderBy(s => s.SkillSetId).ToList();
        }

        public SkillSetModel? GetSkillSet(int skillSetId)
        {
            return _context.SkillSet.Where(s => s.SkillSetId == skillSetId).FirstOrDefault();
        }

        public bool CreateSkillSet(SkillSetModel skillSet)
        {
            _context.SkillSet.Add(skillSet);
            return Save();
        }
        #endregion

        #region Update skillset
        public bool UpdateSkillSet(SkillSetModel skillSet)
        {
            _context.SkillSet.Update(skillSet);
            return Save();
        }

        #endregion

        #region Delete skillset

        public bool DeleteSkillSet(SkillSetModel skillSet)
        {
            _context.SkillSet.Remove(skillSet);
            return Save();
        }

        public bool DeleteAllSkillSets(int userId)
        {
            var skillSets = _context.SkillSet.Where(u => u.UserId == userId);
            _context.SkillSet.RemoveRange(skillSets); //remove all skillsets inside query
            return Save();
        }
        #endregion

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
