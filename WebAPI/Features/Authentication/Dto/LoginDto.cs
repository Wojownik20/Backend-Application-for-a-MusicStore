namespace LeverX.WebAPI.Features.JWT.Dto
{
    public record LoginDto
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
