using CDN_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDN_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<HobbyModel> Hobby { get; set; }
        public DbSet<SkillSetModel> SkillSet { get; set; }
    }
}
