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
    public class EmployeeRepositoryDapper : IEmployeeRepositoryDapper //Dependency Inversion Principle
    {
        private readonly IDbConnection _dbConnection; 

        public EmployeeRepositoryDapper(IDbConnection DbConnection) // DB injection, thats what we work on
        {
            _dbConnection = DbConnection;
        }

        public async Task<IEnumerable<Employee>> GetAllAsyncByDapper()
        {
            var sql = "SELECT * FROM Employees"; 
            return await _dbConnection.QueryAsync<Employee>(sql);   
        }
        public async Task<Employee> GetByIdAsyncByDapper(int id)
        {
            var sql = "SELECT * FROM Employees WHERE Id = @Id"; 
            return await _dbConnection.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
        }

        public async Task<int> AddAsyncByDapper(Employee employee)
        {
            var sql = "INSERT INTO Employees (Name, BirthDate, Salary) VALUES (@Name, @BirthDate, @Salary); SELECT CAST(SCOPE_IDENTITY() as int)"; 
            return await _dbConnection.QuerySingleAsync<int>(sql, employee);
        }

        public async Task<int> UpdateAsyncByDapper(Employee employee)
        {
            var sql = "UPDATE Employees SET Name = @Name, BirthDate = @BirthDate, Salary = @Salary WHERE Id = @Id"; 
            return await _dbConnection.ExecuteAsync(sql, employee);
        }   

        public async Task DeleteAsyncByDapper(int id)
        {
            var sql = "DELETE FROM Employees WHERE Id = @Id"; 
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }



}