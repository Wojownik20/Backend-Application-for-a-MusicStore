
using MediatR;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.WebAPI.Features.Employees.Commands;

namespace MusicStore.WebAPI.Features.Employees.Handlers
{
    public class UpdateEmployeeDapperCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeDapperCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with id {request.Id} not found.");
            }

            employee.Name = request.Name;
            employee.BirthDate = request.BirthDate;
            employee.Salary = request.Salary;

            await _employeeRepository.UpdateAsync(employee);
            return Unit.Value;
        }
    }
}