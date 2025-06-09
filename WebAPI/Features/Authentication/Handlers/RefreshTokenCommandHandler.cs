using LeverX.WebAPI.Features.Authentication.Commands;
using MusicStore.Identity.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using MusicStore.Identity.Models;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using WebAPI.Features.Authentication.Dto;

namespace LeverX.WebAPI.Features.Authentication.Handlers;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthResultDto>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _config;

    public RefreshTokenCommandHandler(
        IRefreshTokenRepository refreshTokenRepository,
        IUserRepository userRepository,
        IConfiguration config)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
        _config = config;
    }

    public async Task<AuthResultDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var tokenEntry = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);

        if (tokenEntry == null || tokenEntry.RefreshTokenExpiryTime <= DateTime.UtcNow)
            throw new UnauthorizedAccessException("Invalid or expired refresh token");

        var user = await _userRepository.GetByIdAsync(tokenEntry.UserId);
        if (user == null)
            throw new UnauthorizedAccessException("User not found");

        var newAccessToken = JwtHelper.GenerateJwtToken(user, _config);
        var newRefreshToken = JwtHelper.GenerateRefreshToken();

        tokenEntry.Token = newRefreshToken;
        tokenEntry.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(10);

        await _refreshTokenRepository.SaveChangesAsync();

        return new AuthResultDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }
}
