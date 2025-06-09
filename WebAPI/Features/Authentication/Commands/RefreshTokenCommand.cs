
using MediatR;
using WebAPI.Features.Authentication.Dto;

namespace LeverX.WebAPI.Features.Authentication.Commands;

public class RefreshTokenCommand : IRequest<AuthResultDto>
{
    public string RefreshToken { get; set; } = string.Empty;
}
