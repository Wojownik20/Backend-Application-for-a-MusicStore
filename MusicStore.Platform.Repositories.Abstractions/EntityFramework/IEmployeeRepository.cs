
using MusicStore.Core.Data;

namespace MusicStore.Platform.Repositories.Interfaces.EntityFramework;

public interface IEmployeeRepository // This guy is the one and only talking to the DB
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(int id);
    Task<int> AddAsync(Employee employee);
    Task<int> UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
}