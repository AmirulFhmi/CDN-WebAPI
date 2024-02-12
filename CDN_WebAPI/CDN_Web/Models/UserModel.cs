namespace CDN_Web.Models
{
    public class UserViewModel
    {
        public List<UserModel>? Users { get; set; }
    }

    public class UserModel
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Name => FirstName + " " + LastName;
        public string? Email { get; set; }
        public int PhoneNumber { get; set; }

    }
}
