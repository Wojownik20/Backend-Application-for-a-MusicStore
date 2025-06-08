

namespace MusicStore.Identity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;

        public ICollection<RefreshToken> RefreshTokens { get; init; } = new List<RefreshToken>();
    }
}
