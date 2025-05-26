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

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var employeeDtos = employees.Select(e => new EmployeeDto
            {
                Name = e.Name,
                BirthDate = e.BirthDate,
                Salary = e.Salary
            });
            return employeeDtos;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return null;
            }
            else
            {
                return new EmployeeDto
                {
                    Name = employee.Name,
                    BirthDate = employee.BirthDate,
                    Salary = employee.Salary
                };
            }

        }

        public async Task CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                BirthDate= employeeDto.BirthDate,
                Salary = employeeDto.Salary 
            };
            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                BirthDate = employeeDto.BirthDate,
                Salary= employeeDto.Salary
            };
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }
    }
}