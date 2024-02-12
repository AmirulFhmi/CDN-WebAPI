using System.ComponentModel.DataAnnotations;

namespace CDN_WebAPI.Models
{
    public class UserModel
    {
        [Key] //Define primary key using key attribute
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<HobbyModel>? Hobbies { get; set; }
        public List<SkillSetModel>? Skillsets { get; set; }
    }

}
