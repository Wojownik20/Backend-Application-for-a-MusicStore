

namespace MusicStore.Shared.Models.JWT_Authentication
{
    public record User
    {
        public int Id { get; init; }
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string Role { get; init; } = "User";
    }
}
