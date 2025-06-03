using FluentValidation;
using MusicStore.WebAPI.Features.Customers.Commands;

namespace LeverX.WebAPI.Validators
{
    public class CreateCustomerDapperCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerDapperCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(8);
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThan(DateTime.Today)
                .WithMessage("Birthdate must be in the past.");

        }
    }
}