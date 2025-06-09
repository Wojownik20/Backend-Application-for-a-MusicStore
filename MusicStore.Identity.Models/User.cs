

namespace MusicStore.Identity.Models
{
    public class User
    {
        public User() { }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get;} 

        public ICollection<RefreshToken> RefreshTokens { get; init; } = new List<RefreshToken>();

        public User (string username, string password, UserRole role = UserRole.User)
        {
            Username = username;
            Password = password;
            Role = UserRole.User;
        }
    }
}
