using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Core.Data;

namespace MusicStore.Platform.Repositories.Interfaces;

public interface ICustomerRepositoryDapper // This guy is the one and only talking to the DB
{
    Task<IEnumerable<Customer>> GetAllAsyncByDapper();
    Task<Customer> GetByIdAsyncByDapper(int id);
    Task<int> AddAsyncByDapper(Customer customer);
    Task<int> UpdateAsyncByDapper(Customer customer);
    Task DeleteAsyncByDapper(int id);
}