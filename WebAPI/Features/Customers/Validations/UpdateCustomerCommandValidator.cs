using FluentValidation;
using MusicStore.WebAPI.Features.Customers.Commands;

namespace LeverX.WebAPI.Features.Customers.Validations
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        private const int MinNameLength = 10;
        public UpdateCustomerCommandValidator()
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