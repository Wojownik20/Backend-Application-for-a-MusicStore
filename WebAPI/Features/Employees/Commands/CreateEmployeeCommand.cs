using MediatR;

namespace MusicStore.WebAPI.Features.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }

        public CreateEmployeeCommand(string name, DateTime birthDate, decimal salary)
        {
            Name = name;
            BirthDate = birthDate;
            Salary = salary;
        }
    }
}