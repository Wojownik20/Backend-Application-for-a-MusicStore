using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using LeverX.Application.Interfaces;
using LeverX.Domain.Models;
using LeverX.Infrastructure.Repositories;
using LeverX.WebAPI.ModelsD;

namespace LeverX.Application.Services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository; //Private Repo injected in here

        public EmployeeService(IEmployeeRepository employeeRepository) // ICustomerRepo injected into Service
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);

        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}