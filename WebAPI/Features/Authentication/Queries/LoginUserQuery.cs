using MediatR;
using WebAPI.Features.Authentication.Dto;

public class LoginUserQuery : IRequest<AuthResultDto>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
