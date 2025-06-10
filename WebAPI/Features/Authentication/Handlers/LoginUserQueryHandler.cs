using MusicStore.Identity.Services;
using MediatR;
using MusicStore.Identity.Models;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using WebAPI.Features.Authentication.Dto;
using Microsoft.Extensions.Logging;


namespace WebAPI.Features.Authentication.Handlers;
public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, AuthResultDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IConfiguration _config;
    private readonly ILogger<LoginUserQueryHandler> _logger;

    public LoginUserQueryHandler(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, IConfiguration config, ILogger<LoginUserQueryHandler> logger)
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _config = config;
        _logger = logger;
    }


    public async Task<AuthResultDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user == null || !PasswordHasher.Verify(request.Password, user.Password))
        {
            _logger.LogWarning("Login failed for {Username}", request.Username);
            throw new Exception("Invalid credentials");
        }

        var accessToken = JwtHelper.GenerateJwtToken(user, _config);
        var refreshToken = JwtHelper.GenerateRefreshToken();

        var tokenEntry = new RefreshToken
        {
            Token = refreshToken,
            UserId = user.Id,
            RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(10)
        };

        await _refreshTokenRepository.AddAsync(tokenEntry);
        await _refreshTokenRepository.SaveChangesAsync();

        _logger.LogInformation("User {Username} logged in successfully", user.Username);

        return new AuthResultDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

}
