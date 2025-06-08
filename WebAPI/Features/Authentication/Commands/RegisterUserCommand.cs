using MediatR;

namespace LeverX.WebAPI.Features.Authentication.Commands;
public class RegisterUserCommand : IRequest<string>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
