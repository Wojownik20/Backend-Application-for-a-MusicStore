using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Platform.Repositories.Interfaces;
using MusicStore.Core.Db;
using MusicStore.Core.Data;
using System.Data;
using Dapper;

namespace MusicStore.Platform.Repositories
{
    public class OrderRepository : IOrderRepository //Dependency Inversion Principle
    {
        private readonly MusicStoreContext _context;
        private readonly IDbConnection _dbConnection;

        public OrderRepository(MusicStoreContext context, IDbConnection dbConnection) // DB injection, thats what we work on
        {
            _dbConnection = dbConnection;
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync(); // Async getting list of customers
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<int> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }


        // DAPPER
        public async Task<IEnumerable<Order>> GetAllAsyncByDapper()
        {
            var sql = "SELECT * FROM Orders";
            return await _dbConnection.QueryAsync<Order>(sql);
        }
        public async Task<Order> GetByIdAsyncByDapper(int id)
        {
            var sql = "SELECT * FROM Orders WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Order>(sql, new { Id = id });
        }
        public async Task<int> AddAsyncByDapper(Order order)
        {
            var sql = "INSERT INTO Orders (ProductId, CustomerId, EmployeeId, TotalPrice, PurchaseDate) VALUES (@ProductId, @CustomerId, @EmployeeId, @TotalPrice, @PurchaseDate); SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _dbConnection.ExecuteScalarAsync<int>(sql, order);
        }
        public async Task<int> UpdateAsyncByDapper(Order order)
        {
            var sql = "UPDATE Orders SET ProductId = @ProductId, CustomerId = @CustomerId, EmployeeId = @EmployeeId, TotalPrice = @TotalPrice, PurchaseDate = @PurchaseDate WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, order);
        }
        public async Task DeleteAsyncByDapper(int id)
        {
            var sql = "DELETE FROM Orders WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });

        }
    }
}