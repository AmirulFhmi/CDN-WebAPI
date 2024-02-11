using System.ComponentModel.DataAnnotations;

namespace CDN_WebAPI.Models
{
    public class HobbyModel
    {
        [Key]
        public int HobbyId { get; set; }
        public required string Hobby { get; set; }
        public int UserId { get; set; }
    }
}
