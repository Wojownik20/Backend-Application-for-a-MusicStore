namespace LeverX.WebAPI.Features.JWT.Dto
{
    public record RegisterDto
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
