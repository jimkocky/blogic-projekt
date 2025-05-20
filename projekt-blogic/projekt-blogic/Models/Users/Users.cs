namespace projekt_blogic.Models.Users
{
    public enum Role
    {
        User = 0,
        Admin = 1
    }

    public class Users
    {
        public Role Role { get; set; }
    }
}
