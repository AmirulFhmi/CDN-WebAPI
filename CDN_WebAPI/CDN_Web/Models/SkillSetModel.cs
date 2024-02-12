namespace CDN_Web.Models
{
    public class SkillSetModel
    {
        public int SkillSetId { get; set; }
        public string? SkillSet { get; set; }
        public int UserId { get; set; }
    }

    public class SkillSetViewModel
    {
        public List<SkillSetModel>? SkillSets { get; set; }
        public int UserId { get; set; }
    }

}
