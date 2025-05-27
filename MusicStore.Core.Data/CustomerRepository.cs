using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Shared.Services.Abstractions;
using MusicStore.Core.Db;
using MusicStore.Shared.Models;

namespace MusicStore.Core.Data
{
    public class CustomerRepository : ICustomerRepository //Dependency Inversion Principle
    {
        private readonly MusicStoreContext _context;

        public CustomerRepository(MusicStoreContext context) // DB injection, thats what we work on
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync(); // Async getting list of customers
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
    }



}