using LeverX.Application.Interfaces;
using LeverX.Application.Services;
using LeverX.Domain.Models;
using LeverX.WebAPI.ModelsD;
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
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Ok(employees); // return 200 OK 
    }

    /// <summary>
    /// Gets Employee by id
    /// </summary>
    /// <param name="id">Id of the employee</param>
    /// <returns>200 if Employee found by id, 404 if id not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDto>> GetById(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        if (employee == null)
            return NotFound();
        else
        {
            return Ok(employee); //200 Ok
        }
    }

    /// <summary>
    /// Creates an Employee
    /// </summary>
    /// <param name="newEmployee">New employee</param>
    /// <returns>201 when Employee created</returns>
    [HttpPost]
    public async Task<IActionResult> Create(EmployeeDto employeeDto)
    {
        await _employeeService.CreateEmployeeAsync(employeeDto);
        return Ok();
    }

    /// <summary>
    /// Updates an Employee record
    /// </summary>
    /// <param name="id">id of employee</param>
    /// <param name="updatedEmployee">Updated Employee</param>
    /// <returns>204 if updated succesfuly, 404 if id not found</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(EmployeeDto employeeDto)
    {

        await _employeeService.UpdateEmployeeAsync(employeeDto);
        return Ok();

    }

    /// <summary>
    /// Delete an employee
    /// </summary>
    /// <param name="id">id of an employee</param>
    /// <returns>204 if deletion successful, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _employeeService.DeleteEmployeeAsync(id);
        return Ok();
    }
}
