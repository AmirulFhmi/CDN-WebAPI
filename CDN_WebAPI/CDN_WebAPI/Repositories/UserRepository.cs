using CDN_WebAPI.Data;
using CDN_WebAPI.Interfaces;
using CDN_WebAPI.Models;

namespace CDN_WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        #region Get User

        public ICollection<UserModel> GetAllUsers()
        {
            return _context.Users.OrderBy(u => u.UserId).ToList();
        }

        public UserModel? GetUser(int userId)
        {
            var user = _context.Users.Where(u => u.UserId == userId).FirstOrDefault();

            if (user != null)
            {
                return user;
            }

            return null;
        }

        //Checks if user exists or not
        public bool IsUserExists(int userId)
        {
            var user = _context.Users.Any(u => u.UserId == userId);

            return user;
        }

        #endregion

        #region Create User

        public bool CreateUser(UserModel user)
        {
            _context.Users.Add(user);

            return Save();
        }

        #endregion

        #region Update User

        public bool UpdateUser(UserModel user)
        {
            _context.Users.Update(user);
            return Save();
        }

        #endregion

        #region Delete User

        public bool DeleteUser(UserModel user)
        {
            _context.Users.Remove(user);
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
