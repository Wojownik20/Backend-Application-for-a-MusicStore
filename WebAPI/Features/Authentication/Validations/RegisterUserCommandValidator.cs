using FluentValidation;
using LeverX.WebAPI.Features.Authentication.Commands;
using MusicStore.WebAPI.Features.Customers.Commands;

namespace LeverX.WebAPI.Features.Customers.Validations
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private const int MinLength = 10;
        private const int MaxLength = 30;
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(MinLength)
                .WithMessage($"Username must be at least {MinLength} characters long.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(MinLength)
                .MaximumLength(MaxLength)
                .WithMessage($"Password must be at least {MinLength} characters long.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");
        }
    }
}