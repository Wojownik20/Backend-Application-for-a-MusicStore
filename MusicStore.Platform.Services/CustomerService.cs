using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Shared.Models;
using System.Diagnostics.Eventing.Reader;
using MusicStore.Platform.Interfaces;
using MusicStore.Shared.Services.Abstractions;

namespace MusicStore.Platform.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository; //Private Repo injected in here

        public CustomerService(ICustomerRepository customerRepository) // ICustomerRepo injected into Service
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
           return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);

        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}