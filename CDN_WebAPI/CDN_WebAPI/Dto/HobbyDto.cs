namespace CDN_WebAPI.Dto
{
    public class HobbyDto
    {
        public int HobbyId { get; set; }
        public required string Hobby { get; set; }
        public int UserId { get; set; }
    }
}
