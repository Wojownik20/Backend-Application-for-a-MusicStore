using FluentValidation;
using MusicStore.WebAPI.Features.Orders.Commands;

namespace LeverX.WebAPI.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.TotalPrice)
                .NotEmpty();
            RuleFor(y => y.PurchaseDate)
                .NotEmpty()
                .LessThan(DateTime.Today)
                .WithMessage("Purchase Date must be in the past.");

        }
    }
}