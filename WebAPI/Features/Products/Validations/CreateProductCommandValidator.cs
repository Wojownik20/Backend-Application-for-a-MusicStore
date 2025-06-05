using FluentValidation;
using MusicStore.WebAPI.Features.Products.Commands;


namespace LeverX.WebAPI.Features.Products.Validations
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Category)
                .NotEmpty();
            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.ReleaseDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Release date cannot be in the future.");




        }
    }
}