

namespace MusicStore.Shared.Models.JWT_Authentication
{
    public record User
    {
        public int Id { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public UserRole Role { get; init; } = UserRole.User;

    }
}
