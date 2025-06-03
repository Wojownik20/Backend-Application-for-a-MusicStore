using FluentValidation;
using MusicStore.WebAPI.Features.Products.Commands;


namespace LeverX.WebAPI.Validators
{
    public class CreateProductDapperCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductDapperCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Category)
                .NotEmpty();
            RuleFor(x => x.Price)
                .NotEmpty();
            RuleFor(x => x.ReleaseDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Release date cannot be in the future.");




        }
    }
}