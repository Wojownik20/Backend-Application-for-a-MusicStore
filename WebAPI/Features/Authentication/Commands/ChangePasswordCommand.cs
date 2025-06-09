using MediatR;

namespace LeverXWebAPI.Features.Authentication.Commands;
public record ChangePasswordCommand(
    string Username,
    string OldPassword,
    string NewPassword
) : IRequest<bool>;
