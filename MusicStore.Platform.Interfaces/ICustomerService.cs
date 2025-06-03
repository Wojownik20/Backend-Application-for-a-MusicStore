
using MusicStore.Core.Data;

namespace MusicStore.Platform.Services.Interfaces
{
    public interface ICustomerService // Reminder : Interface is a bunch of essential methods
    {
        // EF CORE
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<int> CreateCustomerAsync (Customer customer);
        Task<int> UpdateCustomerAsync (Customer customer);
        Task DeleteCustomerAsync (int id);  

        // DAPPER
        Task<IEnumerable<Customer>> GetAllCustomersAsyncByDapper();
        Task<Customer> GetCustomerByIdAsyncByDapper(int id);
        Task<int> CreateCustomerAsyncByDapper (Customer customer);
        Task<int> UpdateCustomerAsyncByDapper (Customer customer);
        Task DeleteCustomerAsyncByDapper (int id);
    }
}
