using MediatR;

namespace MusicStore.WebAPI.Features.Employees.Commands
{
    public class CreateEmployeeDapperCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }

        public CreateEmployeeDapperCommand(string name, DateTime birthDate, decimal salary)
        {
            Name = name;
            BirthDate = birthDate;
            Salary = salary;
        }
    }
}