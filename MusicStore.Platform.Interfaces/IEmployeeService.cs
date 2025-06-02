using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Core.Data;

namespace MusicStore.Platform.Services.Interfaces
{
    public interface IEmployeeService // Reminder : Interface is a bunch of essential methods
    {
        //EF CORE
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<int> CreateEmployeeAsync(Employee employee);
        Task<int> UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);

        //DAPPER
        Task<IEnumerable<Employee>> GetAllEmployeesAsyncByDapper();
        Task<Employee> GetEmployeeByIdAsyncByDapper(int id);
        Task<int> CreateEmployeeAsyncByDapper(Employee employee);
        Task<int> UpdateEmployeeAsyncByDapper(Employee employee);
        Task DeleteEmployeeAsyncByDapper(int id);
    }
}
