using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Platform.Repositories.Interfaces;
using MusicStore.Core.Db;
using MusicStore.Core.Data;
using Dapper;
using System.Data;

namespace MusicStore.Platform.Repositories
{
    public class CustomerRepository : ICustomerRepository //Dependency Inversion Principle
    {
        private readonly MusicStoreContext _context;
        private readonly IDbConnection _dbConnection;

        public CustomerRepository(MusicStoreContext context, IDbConnection DbConnection) // EF Core, Dapper
        {
            _context = context;
            _dbConnection = DbConnection;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync(); // Async getting list of customers
        }
        public async Task<IEnumerable<Customer>> GetAllAsyncByDapper()
        {
            var sql = "SELECT * FROM Customers"; 
            return await _dbConnection.QueryAsync<Customer>(sql);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
        public async Task<Customer> GetByIdAsyncByDapper(int id)
        {
            var sql = "SELECT * FROM Customers WHERE Id = @Id"; 
            return await _dbConnection.QueryFirstOrDefaultAsync<Customer>(sql, new { Id = id });
        }

        public async Task<int> AddAsync(Customer customer)
        {
           await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }
        public async Task<int> AddAsyncByDapper(Customer customer)
        {
            var sql = "INSERT INTO Customers (Name, BirthDate) VALUES (@Name, @BirthDate); SELECT CAST(SCOPE_IDENTITY() as int)"; 
            return await _dbConnection.QuerySingleAsync<int>(sql, customer);
        }

        public async Task<int> UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }
        public async Task<int> UpdateAsyncByDapper(Customer customer)
        {
            var sql = "UPDATE Customers SET Name = @Name, BirthDate = @BirthDate WHERE Id = @Id"; 
            return await _dbConnection.ExecuteAsync(sql, customer);
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
        public async Task DeleteAsyncByDapper(int id)
        {
            var sql = "DELETE FROM Customers WHERE Id = @Id"; 
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }



}