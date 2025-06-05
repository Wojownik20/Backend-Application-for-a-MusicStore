using FluentValidation;
using MusicStore.WebAPI.Features.Orders.Commands;

namespace LeverX.WebAPI.Features.Orders.Validations
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.TotalPrice)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(y => y.PurchaseDate)
                .NotEmpty()
                .LessThan(DateTime.Today)
                .WithMessage("Purchase Date must be in the past.");

        }
    }
}