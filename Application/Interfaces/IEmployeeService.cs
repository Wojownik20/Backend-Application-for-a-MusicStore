using System.Collections.Generic;
using System.Threading.Tasks;
using LeverX.WebAPI.ModelsD;

namespace LeverX.Application.Interfaces
{
    public interface IEmployeeService // Reminder : Interface is a bunch of essential methods
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(EmployeeDto employeeDto);
        Task UpdateEmployeeAsync(EmployeeDto employeeDto);
        Task DeleteEmployeeAsync(int id);
    }
}
