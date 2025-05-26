using System.Collections.Generic;
using System.Threading.Tasks;
using LeverX.WebAPI.ModelsD;

namespace LeverX.Application.Interfaces
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
