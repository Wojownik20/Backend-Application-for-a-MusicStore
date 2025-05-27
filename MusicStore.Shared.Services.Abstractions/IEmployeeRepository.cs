using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Shared.Models;

namespace MusicStore.Shared.Services.Abstractions
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