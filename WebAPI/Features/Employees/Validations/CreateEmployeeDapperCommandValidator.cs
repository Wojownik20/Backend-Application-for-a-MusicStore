using FluentValidation;
using MusicStore.WebAPI.Features.Employees.Commands;

namespace LeverX.WebAPI.Features.Employees.Validations
{
    public class CreateEmployeeDapperCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        private const int MinAge = 18;
        private const decimal MinSalary = 3500;
        private readonly DateTime MinBirthDate = DateTime.Today.AddYears(-MinAge);
        public CreateEmployeeDapperCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThan(MinBirthDate)
                .WithMessage($"Birth Date must be at least {MinAge} years ago.");
            RuleFor(x => x.Salary)
                .GreaterThan(MinSalary)
                .WithMessage($"Salary must be greater than {MinSalary}.");



        }
    }
}