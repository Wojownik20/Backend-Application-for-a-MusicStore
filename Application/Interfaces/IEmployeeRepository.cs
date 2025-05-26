using System.Collections.Generic;
using System.Threading.Tasks;
using LeverX.Domain.Models;

namespace LeverX.Application.Interfaces
{
    public interface IEmployeeRepository // This guy is the one and only talking to the DB
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }

}