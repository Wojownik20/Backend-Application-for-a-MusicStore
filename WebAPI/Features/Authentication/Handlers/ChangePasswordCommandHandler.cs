using LeverXWebAPI.Features.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicStore.Identity.Services;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ChangePasswordCommandHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user == null || !PasswordHasher.Verify(request.OldPassword, user.Password))
            return false;
        var loggedInUsername = _httpContextAccessor.HttpContext?.User?.Identity?.Name;

        if (loggedInUsername == null || loggedInUsername != request.Username)
            throw new UnauthorizedAccessException("You can only change your own password.");

        user.Password = PasswordHasher.Hash(request.NewPassword);

        await _userRepository.SaveChangesAsync();
        return true;
    }

}
