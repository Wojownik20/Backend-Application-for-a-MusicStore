using LeverX.WebAPI.Features.Authentication.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using MusicStore.Identity.Models;
using MusicStore.Identity.Services;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using WebAPI.Features.Authentication.Handlers;


namespace LeverX.WebAPI.Features.Authentication.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<RegisterUserCommandHandler> _logger;

    public RegisterUserCommandHandler(IUserRepository userRepository, ILogger<RegisterUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.UsernameExistsAsync(request.Username))
        {
            _logger.LogWarning("Attempted registration with existing username: {Username}", request.Username);
            throw new Exception("User already exists");
        }

        var user = new User
        {
            Username = request.Username,
            Password = PasswordHasher.Hash(request.Password),
            Role = UserRole.User
        };


        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        _logger.LogInformation("User registered successfully: {Username}", user.Username);

        return "User registered";
    }
}
