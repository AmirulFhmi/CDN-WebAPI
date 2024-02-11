namespace CDN_WebAPI.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string Name => FirstName + " " + LastName;
    }
}
