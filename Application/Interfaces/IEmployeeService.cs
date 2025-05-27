using System.Collections.Generic;
using System.Threading.Tasks;
using LeverX.Domain.Models;

namespace LeverX.Application.Interfaces
{
    public interface IEmployeeService // Reminder : Interface is a bunch of essential methods
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
