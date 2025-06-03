using FluentValidation;
using MusicStore.WebAPI.Features.Employees.Commands;

namespace LeverX.WebAPI.Validators
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThan(DateTime.Today.AddYears(-18))
                .WithMessage("Birth Date must be at least 18 years ago.");
            RuleFor(x => x.Salary)
                .GreaterThan(3500)
                .WithMessage("Salary must be greater than 3500.");



        }
    }
}