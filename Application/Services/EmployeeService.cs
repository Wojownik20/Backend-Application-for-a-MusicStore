using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeverX.Domain.Models;
using System.Diagnostics.Eventing.Reader;
using LeverX.WebAPI.ModelsD;
using LeverX.Application.Interfaces;

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
            var employees = await _employeeRepository.GetAllAsync();
            var employee = employees.Select(e => new Employee
            {
                Name = e.Name,
                BirthDate = e.BirthDate,
                Salary = e.Salary
            });
            return employee;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return null;
            }
            else
            {
                return new Employee
                {
                    Name = employee.Name,
                    BirthDate = employee.BirthDate,
                    Salary = employee.Salary
                };
            }

        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            var employees = new Employee
            {
                Name = employee.Name,
                BirthDate= employee.BirthDate,
                Salary = employee.Salary 
            };
            await _employeeRepository.AddAsync(employees);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var employees = new Employee
            {
                Name = employee.Name,
                BirthDate = employee.BirthDate,
                Salary= employee.Salary
            };
            await _employeeRepository.UpdateAsync(employees);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}