
using Microsoft.EntityFrameworkCore;
using MusicStore.Core.Data;
using Dapper;
using System.Data;
using MusicStore.Platform.Repositories.Interfaces.Dapper;

namespace MusicStore.Platform.Repositories.Dapper
{
    public class CustomerRepositoryDapper : ICustomerRepositoryDapper //Dependency Inversion Principle
    {
        private readonly IDbConnection _dbConnection;

        public CustomerRepositoryDapper(IDbConnection DbConnection) //Dapper
        {
            _dbConnection = DbConnection;
        }


        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var sql = "SELECT * FROM Customers"; 
            return await _dbConnection.QueryAsync<Customer>(sql);
        }


        public async Task<Customer> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Customers WHERE Id = @Id"; 
            return await _dbConnection.QueryFirstOrDefaultAsync<Customer>(sql, new { Id = id });
        }


        public async Task<int> AddAsync(Customer customer)
        {
            var sql = "INSERT INTO Customers (Name, BirthDate) VALUES (@Name, @BirthDate); SELECT CAST(SCOPE_IDENTITY() as int)"; 
            return await _dbConnection.QuerySingleAsync<int>(sql, customer);
        }


        public async Task<int> UpdateAsync(Customer customer)
        {
            var sql = "UPDATE Customers SET Name = @Name, BirthDate = @BirthDate WHERE Id = @Id"; 
            return await _dbConnection.ExecuteAsync(sql, customer);
        }


        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Customers WHERE Id = @Id"; 
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }



}