using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeverX.ModelsD;
using LeverX.Repositories;
using LeverX.Models;
using System.Diagnostics.Eventing.Reader;

namespace LeverX.Services
{

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository; //Private Repo injected in here

        public CustomerService(ICustomerRepository customerRepository) // ICustomerRepo injected into Service
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            var customerDtos = customers.Select(c => new CustomerDto
            {
                Name = c.Name,
                BirthDate = c.BirthDate,
            });
            return customerDtos;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return null;
            }
            else
            {
                return new CustomerDto
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate
                };
            }

        }

        public async Task CreateCustomerAsync(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name
            };
            await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                BirthDate = customerDto.BirthDate
            };
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}