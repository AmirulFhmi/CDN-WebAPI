using CDN_WebAPI.Data;
using CDN_WebAPI.Interfaces;
using CDN_WebAPI.Models;

namespace CDN_WebAPI.Repositories
{
    public class HobbyRepository : IHobbyRepository
    {
        public readonly DataContext _context;

        public HobbyRepository(DataContext context)
        {
            this._context = context;
        }
        #region Get Hobby

        public ICollection<HobbyModel> GetHobbies(int userId)
        {
            return _context.Hobby.Where(u => u.UserId == userId).OrderBy(h => h.HobbyId).ToList();
        }

        public HobbyModel? GetHobby(int hobbyId)
        {
            return _context.Hobby.Where(h => h.HobbyId == hobbyId).FirstOrDefault();
        }

        public bool CreateHobby(HobbyModel hobby)
        {
            _context.Hobby.Add(hobby);

            return Save();
        }

        #endregion

        #region Update Hobby
        public bool UpdateHobby(HobbyModel hobby)
        {
            _context.Hobby.Update(hobby);
            return Save();
        }

        #endregion

        #region Delete Hobby
        public bool DeleteHobby(HobbyModel hobby)
        {
            _context.Remove(hobby);
            return Save();
        }

        public bool DeleteAllHobbies(int userId)
        {
            var hobbies = _context.Hobby.Where(u => u.UserId == userId);
            _context.Hobby.RemoveRange(hobbies); //remove all hobbies inside query
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
