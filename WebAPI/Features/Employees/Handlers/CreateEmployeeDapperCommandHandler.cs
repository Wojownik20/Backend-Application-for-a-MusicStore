
using MediatR;
using MusicStore.Core.Data;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.WebAPI.Features.Employees.Commands;

namespace MusicStore.WebAPI.Features.Employees.Handlers
{
    public class CreateEmployeeDapperCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeDapperCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                BirthDate = request.BirthDate,
                Salary = request.Salary
            };

            var id = await _employeeRepository.AddAsync(employee);
            return id;
        }
    }
}