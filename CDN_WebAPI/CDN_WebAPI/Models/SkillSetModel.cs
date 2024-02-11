using System.ComponentModel.DataAnnotations;

namespace CDN_WebAPI.Models
{
    public class SkillSetModel
    {
        [Key] //Define primary key using key attribute
        public int SkillSetId { get; set; }
        public required string SkillSet { get; set; }
        public int UserId { get; set; }
    }
}
