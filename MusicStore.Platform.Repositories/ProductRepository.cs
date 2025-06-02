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
    public class ProductRepository : IProductRepository //Dependency Inversion Principle
    {
        private readonly MusicStoreContext _context;
        private readonly IDbConnection _dbConnection;

        public ProductRepository(MusicStoreContext context, IDbConnection DbConnection) // DB injection, thats what we work on
        {
            _context = context;
            _dbConnection = DbConnection;
        }

        //EF Core
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); // Async getting list of customers
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<int> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        //DAPPER
        public async Task<IEnumerable<Product>> GetAllAsyncByDapper()
        {
            var sql = "SELECT * FROM Products"; // Assuming you have a Products table
            return await _dbConnection.QueryAsync<Product>(sql);
        }
        public async Task<Product> GetByIdAsyncByDapper(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id"; // Assuming you have a Products table
            return await _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }
        public async Task<int> AddAsyncByDapper(Product product)
        {
            var sql = "INSERT INTO Products (Name, Category, Price, ReleaseDate) VALUES (@Name, @Category, @Price, @ReleaseDate); SELECT CAST(SCOPE_IDENTITY() as int)"; // Assuming you have a Products table
            return await _dbConnection.ExecuteScalarAsync<int>(sql, product);
        }
        public async Task<int> UpdateAsyncByDapper(Product product)
        {
            var sql = "UPDATE Products SET Name = @Name, Category = @Category, Price = @Price, ReleaseDate = @ReleaseDate WHERE Id = @Id"; // Assuming you have a Products table
            return await _dbConnection.ExecuteAsync(sql, product);
        }
        public async Task DeleteAsyncByDapper(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id"; // Assuming you have a Products table
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }



}