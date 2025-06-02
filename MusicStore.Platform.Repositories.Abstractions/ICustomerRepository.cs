using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Core.Data;

namespace MusicStore.Platform.Repositories.Interfaces;

public interface ICustomerRepository // This guy is the one and only talking to the DB
{
    // EF CORE
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(int id);
    Task<int> AddAsync (Customer customer);
    Task<int> UpdateAsync (Customer customer); 
    Task DeleteAsync (int id);

    // DAPPER
    Task<IEnumerable<Customer>> GetAllAsyncByDapper();
    Task<Customer> GetByIdAsyncByDapper(int id);
    Task<int> AddAsyncByDapper(Customer customer);
    Task<int> UpdateAsyncByDapper(Customer customer);
    Task DeleteAsyncByDapper(int id);
}