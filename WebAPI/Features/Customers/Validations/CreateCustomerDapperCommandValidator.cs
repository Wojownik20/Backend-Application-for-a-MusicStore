using FluentValidation;
using MusicStore.WebAPI.Features.Customers.Commands;

namespace LeverX.WebAPI.Features.Customers.Validations
{
    public class CreateCustomerDapperCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private const int MinNameLength = 10;
        public CreateCustomerDapperCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(MinNameLength);
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThan(DateTime.Today)
                .WithMessage("Birthdate must be in the past.");

        }
    }
}