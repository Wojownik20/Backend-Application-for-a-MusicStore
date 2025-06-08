using LeverX.WebAPI.Features.Authentication.Commands;
using MusicStore.Identity.Services;
using MediatR;
using MusicStore.Identity.Models;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;

namespace LeverX.WebAPI.Features.Authentication.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.UsernameExistsAsync(request.Username))
            throw new Exception("User already exists");

        var user = new User
        {
            Username = request.Username,
            Password = PasswordHasher.Hash(request.Password),
            Role = UserRole.User
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return "User registered";
    }
}
