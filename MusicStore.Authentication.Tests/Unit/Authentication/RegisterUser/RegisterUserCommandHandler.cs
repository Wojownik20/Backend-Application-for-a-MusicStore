using LeverX.WebAPI.Features.Authentication.Commands;
using LeverX.WebAPI.Features.Authentication.Handlers;
using Microsoft.Extensions.Logging;
using Moq;
using MusicStore.Identity.Models;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using Xunit;

namespace MusicStore.Authentication.Tests.Unit.Authentication.RegisterUser;
public class RegisterUserCommandHandlerTests
{
    [Fact]
    public async Task Handle_WhenUserDoesNotExist_RegistersUserAndReturnsSuccessMessage()
    {
        var mockRepo = new Mock<IUserRepository>(); // Mock of real Interface IUserRepository
        var mockLogger = new Mock<ILogger<RegisterUserCommandHandler>>();
        var command = new RegisterUserCommand
        {
            Username = "newuser",
            Password = "test123"
        };

        mockRepo.Setup(r => r.UsernameExistsAsync(command.Username)).ReturnsAsync(false);

        var handler = new RegisterUserCommandHandler(mockRepo.Object, mockLogger.Object); // handler of Mock repo

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.Equal("User registered", result);
        mockRepo.Verify(r => r.AddAsync(It.Is<User>(u => u.Username == command.Username)), Times.Once); // was it once or more
        mockRepo.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenUserAlreadyExists_ThrowsException()
    {
        var mockRepo = new Mock<IUserRepository>();
        var mockLogger = new Mock<ILogger<RegisterUserCommandHandler>>();
        var command = new RegisterUserCommand
        {
            Username = "existinguser",
            Password = "123"
        };

        mockRepo.Setup(r => r.UsernameExistsAsync(command.Username)).ReturnsAsync(true);

        var handler = new RegisterUserCommandHandler(mockRepo.Object, mockLogger.Object);

        var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None)); //Assert that exception is thrown
        Assert.Equal("User already exists", exception.Message);

        mockRepo.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Never);
        mockRepo.Verify(r => r.SaveChangesAsync(), Times.Never);
    }
}
