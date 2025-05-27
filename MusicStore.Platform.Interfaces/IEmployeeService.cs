using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Shared.Models;

namespace MusicStore.Platform.Interfaces
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
