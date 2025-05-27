using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Shared.Models;

namespace MusicStore.Shared.Services.Abstractions
{
    public interface ICustomerRepository // This guy is the one and only talking to the DB
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync (Customer customer);
        Task UpdateAsync (Customer customer); 
        Task DeleteAsync (int id);
    }

}