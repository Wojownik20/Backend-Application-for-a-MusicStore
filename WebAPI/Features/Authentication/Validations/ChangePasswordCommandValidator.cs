using FluentValidation;
using LeverX.WebAPI.Features.Authentication.Commands;
using LeverXWebAPI.Features.Authentication.Commands;
using MusicStore.WebAPI.Features.Customers.Commands;

namespace LeverX.WebAPI.Features.Customers.Validations
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        private const int MinLength = 10;
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .MinimumLength(MinLength)
                .WithMessage($"Password must be at least {MinLength} characters long.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

        }
    }
}