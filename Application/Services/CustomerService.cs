using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeverX.Domain.Models;
using System.Diagnostics.Eventing.Reader;
using LeverX.WebAPI.ModelsD;
using LeverX.Application.Interfaces;

namespace LeverX.Application.Services
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
            var customers = await _customerRepository.GetAllAsync();
            var customer = customers.Select(c => new Customer
            {
                Name = c.Name,
                BirthDate = c.BirthDate,
            });
            return customer;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return null;
            }
            else
            {
                return new Customer
                {
                    Name = customer.Name,
                    BirthDate = customer.BirthDate
                };
            }

        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            var customers = new Customer
            {
                Name = customer.Name,
                BirthDate= customer.BirthDate
            };
            await _customerRepository.AddAsync(customers);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var customers = new Customer
            {
                Name = customer.Name,
                BirthDate = customer.BirthDate
            };
            await _customerRepository.UpdateAsync(customers);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}