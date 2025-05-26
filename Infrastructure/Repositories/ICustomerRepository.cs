using System.Collections.Generic;
using System.Threading.Tasks;
using LeverX.Models;

namespace LeverX.Repositories
{
    public interface ICustomerRepository // This guy is the one and only talking to the DB
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync (Customer customer);
        Task UpdateAsync (Customer customer); 
        Task DeleteAsync (int id);
    }

}