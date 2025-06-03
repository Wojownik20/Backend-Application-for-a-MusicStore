using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Core.Data;

namespace MusicStore.Platform.Repositories.Interfaces;

public interface IEmployeeRepositoryDapper // This guy is the one and only talking to the DB
{

    Task<IEnumerable<Employee>> GetAllAsyncByDapper();
    Task<Employee> GetByIdAsyncByDapper(int id);
    Task<int> AddAsyncByDapper(Employee employee);
    Task<int> UpdateAsyncByDapper(Employee employee);
    Task DeleteAsyncByDapper(int id);
}