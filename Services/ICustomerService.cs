using System.Collections.Generic;
using System.Threading.Tasks;
using LeverX.Models;
using LeverX.ModelsD;

namespace LeverX.Services
{
    public interface ICustomerService // Reminder : Interface is a bunch of essential methods
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task CreateCustomerAsync (CustomerDto customerDto);
        Task UpdateCustomerAsync (CustomerDto customerDto);
        Task DeleteCustomerAsync (int id);  
    }
}
