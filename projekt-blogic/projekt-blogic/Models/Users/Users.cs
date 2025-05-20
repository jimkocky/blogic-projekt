namespace projekt_blogic.Models.Users
{
    public enum Role
    {
        User = 0,
        Admin = 1
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public string Role { get; set; }
    }
}