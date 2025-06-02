using MusicStore.Platform.Services.Interfaces;
using MusicStore.Core.Data;
using MusicStore.Shared.Models;
using LeverX.WebAPI.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/[controller]")] // Route for api/product
public class EmployeeController : ControllerBase //Base class
{
    private readonly IEmployeeService _employeeService; // Injecting our DB
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    /// <summary>
    /// Gets all employees
    /// </summary>
    /// <returns>200 and JSON list of Employees</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        var employeeDtos = employees.Select(e => new EmployeeReadDto
        {
            Id=e.Id,
            Name = e.Name,
            BirthDate = e.BirthDate,
            Salary = e.Salary
        });
        return Ok(employeeDtos);
    }

    /// <summary>
    /// Gets Employee by id
    /// </summary>
    /// <param name="id">Id of the employee</param>
    /// <returns>200 if Employee found by id, 404 if id not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeReadDto>> GetById([FromRoute] int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
            return NotFound();

        var employeeDto = new EmployeeReadDto
        {
            Id=employee.Id,
            Name = employee.Name,
            BirthDate = employee.BirthDate,
            Salary = employee.Salary
        };

        return Ok(employeeDto);
    }

    /// <summary>
    /// Creates an Employee
    /// </summary>
    /// <param name="newEmployee">New employee</param>
    /// <returns>201 when Employee created</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeDto employeeDto)
    {
        var employee = new Employee
        {
            Name = employeeDto.Name,
            BirthDate = employeeDto.BirthDate,
            Salary = employeeDto.Salary
        };

        await _employeeService.CreateEmployeeAsync(employee);
        return Ok();
    }

    /// <summary>
    /// Updates an Employee record
    /// </summary>
    /// <param name="id">id of employee</param>
    /// <param name="updatedEmployee">Updated Employee</param>
    /// <returns>204 if updated succesfuly, 404 if id not found</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EmployeeDto employeeDto)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if(employee == null)
            return NotFound();
        else
        {
            employee.Name = employeeDto.Name;
            employee.BirthDate = employeeDto.BirthDate; 
            employee.Salary = employeeDto.Salary;
        }

        await _employeeService.UpdateEmployeeAsync(employee);
        return Ok();
    }

    /// <summary>
    /// Delete an employee
    /// </summary>
    /// <param name="id">id of an employee</param>
    /// <returns>204 if deletion successful, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
            return NotFound();
        else
        {
            await _employeeService.DeleteEmployeeAsync(id);
        return Ok();
        }

    }

    //DAPPER
    /// <summary>
    /// Returns JSON list of Employees by Dapper
    /// </summary>
    /// <returns>OK 200</returns>
    [HttpGet("dapper")]
    public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAllAsyncByDapper() 
    {
        var employees = await _employeeService.GetAllEmployeesAsyncByDapper();
        var employeeDtos = employees.Select(e => new EmployeeReadDto
        {
            Id = e.Id,
            Name = e.Name,
            BirthDate = e.BirthDate,
            Salary = e.Salary
        });
        return Ok(employeeDtos);
    }

    /// <summary>
    /// Return employee by Id by Dapper
    /// </summary>
    /// <param name="id">Employee Id</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpGet("dapper/{id}")]
    public async Task<ActionResult<EmployeeReadDto>> GetByIdByDapper([FromRoute] int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsyncByDapper(id);
        if (employee == null)
            return NotFound();

        var employeeDto = new EmployeeReadDto
        {
            Id = employee.Id,
            Name = employee.Name,
            BirthDate = employee.BirthDate,
            Salary = employee.Salary
        };

        return Ok(employeeDto);
    }

    /// <summary>
    /// Creates an Employee by Dapper
    /// </summary>
    /// <param name="employeeDto">Employee Model</param>
    /// <returns>200 OK</returns>
    [HttpPost("dapper")]
    public async Task<IActionResult> CreateByDapper([FromBody] EmployeeDto employeeDto)
    {
        var employee = new Employee
        {
            Name = employeeDto.Name,
            BirthDate = employeeDto.BirthDate,
            Salary = employeeDto.Salary
        };

        await _employeeService.CreateEmployeeAsyncByDapper(employee);
        return Ok();
    }

    /// <summary>
    /// Updates an Employee by Dapper
    /// </summary>
    /// <param name="id">Employee Id</param>
    /// <param name="employeeDto">Employee model</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpPut("dapper/{id}")]
    public async Task<IActionResult> UpdateByDapper([FromRoute] int id, [FromBody] EmployeeDto employeeDto)
    {
        var employee = await _employeeService.GetEmployeeByIdAsyncByDapper(id);
        if (employee == null)
            return NotFound();
        else
        {
            employee.Name = employeeDto.Name;
            employee.BirthDate = employeeDto.BirthDate;
            employee.Salary = employeeDto.Salary;
        }

        await _employeeService.UpdateEmployeeAsyncByDapper(employee);
        return Ok();
    }

    /// <summary>
    /// Deletes an Employee by Dapper
    /// </summary>
    /// <param name="id">EmployeeId</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpDelete("dapper/{id}")]
    public async Task<IActionResult> DeleteByDapper([FromRoute] int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsyncByDapper(id);
        if (employee == null)
            return NotFound();
        else
        {
            await _employeeService.DeleteEmployeeAsyncByDapper(id);
            return Ok();
        }

    }

}
