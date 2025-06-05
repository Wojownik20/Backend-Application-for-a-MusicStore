
namespace MusicStore.Shared.Models.JWT_Authentication
{
    public record LoginDto
    {
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}
