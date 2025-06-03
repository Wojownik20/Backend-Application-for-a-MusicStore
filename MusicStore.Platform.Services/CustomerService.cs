
using MusicStore.Platform.Services.Interfaces;
using MusicStore.Core.Data;
using MusicStore.Platform.Repositories.Interfaces;
using MusicStore.Platform.Repositories.Interfaces.Dapper;

namespace MusicStore.Platform.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository; //Private Repo injected in here
        private readonly ICustomerRepositoryDapper _customerRepositoryDapper;

        public CustomerService(ICustomerRepository customerRepository, ICustomerRepositoryDapper customerRepositoryDapper) // ICustomerRepo injected into Service
        {
            _customerRepository = customerRepository;
            _customerRepositoryDapper = customerRepositoryDapper;
        }


        // EF CORE
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
           return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);

        }

        public async Task<int> CreateCustomerAsync(Customer customer)
        {
            await _customerRepository.AddAsync(customer);
            return customer.Id;
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
            return customer.Id;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        // DAPPER
        public async Task<IEnumerable<Customer>> GetAllCustomersAsyncByDapper()
        {
            return await _customerRepositoryDapper.GetAllAsync();
        }
        public async Task<Customer> GetCustomerByIdAsyncByDapper(int id)
        {
            return await _customerRepositoryDapper.GetByIdAsync(id);
        }
        public async Task<int> CreateCustomerAsyncByDapper(Customer customer)
        {
            return await _customerRepositoryDapper.AddAsync(customer);
        }
        public async Task<int> UpdateCustomerAsyncByDapper(Customer customer)
        {
            return await _customerRepositoryDapper.UpdateAsync(customer);
        }
        public async Task DeleteCustomerAsyncByDapper(int id)
        {
            await _customerRepositoryDapper.DeleteAsync(id);
        }
    }
}