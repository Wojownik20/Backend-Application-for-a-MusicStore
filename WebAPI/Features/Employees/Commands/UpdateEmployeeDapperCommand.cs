using MediatR;

namespace MusicStore.WebAPI.Features.Employees.Commands
{
    public class UpdateEmployeeDapperCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }

        public UpdateEmployeeDapperCommand(int id, string name, DateTime birthDate, decimal salary)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Salary = salary;
        }
    }
}