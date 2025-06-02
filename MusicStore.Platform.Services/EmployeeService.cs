using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Core.Data;
using MusicStore.Platform.Services.Interfaces;
using MusicStore.Platform.Repositories.Interfaces;

namespace MusicStore.Platform.Services
{
    public class EmployeeService : IEmployeeService //Dependency Inversion Principle
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //EF CORE
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id); // Async getting list of customers
        }
        public async Task<int> CreateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.AddAsync(employee);
            return employee.Id;
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
            return employee.Id;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        //DAPPER

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsyncByDapper()
        {
            return await _employeeRepository.GetAllAsyncByDapper();
        }
        public async Task<Employee> GetEmployeeByIdAsyncByDapper(int id)
        {
            return await _employeeRepository.GetByIdAsyncByDapper(id); // Async getting list of customers
        }
        public async Task<int> CreateEmployeeAsyncByDapper(Employee employee)
        {
            await _employeeRepository.AddAsyncByDapper(employee);
            return employee.Id;
        }
        public async Task<int> UpdateEmployeeAsyncByDapper(Employee employee)
        {
            await _employeeRepository.UpdateAsyncByDapper(employee);
            return employee.Id;
        }
        public async Task DeleteEmployeeAsyncByDapper(int id)
        {
            await _employeeRepository.DeleteAsyncByDapper(id);
        }
    }



}