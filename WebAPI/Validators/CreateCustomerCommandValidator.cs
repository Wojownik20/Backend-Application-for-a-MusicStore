using FluentValidation;
using MusicStore.WebAPI.Features.Customers.Commands;

namespace LeverX.WebAPI.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
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