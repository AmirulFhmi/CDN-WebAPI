namespace CDN_Web.Models
{
    public class HobbyModel
    {
        public int HobbyId { get; set; }
        public string? Hobby { get; set; }
        public int UserId { get; set; }
    }

    public class HobbyViewModel
    {
        public List<HobbyModel>? Hobbies { get; set; }
        public int UserId {  get; set; }
    }
}
