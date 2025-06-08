

namespace MusicStore.Identity.Models
{
    public record User
    {
        public int Id { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public UserRole Role { get; init; } = UserRole.User;

        public ICollection<RefreshToken> RefreshTokens { get; init; } = new List<RefreshToken>();
    }
}
