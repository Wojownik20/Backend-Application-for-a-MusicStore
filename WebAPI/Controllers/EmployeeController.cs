using LeverX.WebAPI.ModelsDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Platform.Services.Interfaces;
using MusicStore.WebAPI.Features.Employees.Commands;
using MusicStore.WebAPI.Features.Employees.Queries;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/[controller]")] // Route for api/product
public class EmployeeController : ControllerBase //Base class
{
    private readonly IEmployeeService _employeeService; // Injecting our DB
    private readonly IMediator _mediator; // Injecting MediatR for CQRS
    public EmployeeController(IEmployeeService employeeService, IMediator mediator)
    {
        _employeeService = employeeService;
        _mediator = mediator;
    }


    /// <summary>
    /// Gets all employees
    /// </summary>
    /// <returns>200 and JSON list of Employees</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var employee = await _mediator.Send(new GetAllEmployeesQuery());
        return Ok(employee);
    }

    /// <summary>
    /// Gets Employee by id
    /// </summary>
    /// <param name="id">Id of the employee</param>
    /// <returns>200 if Employee found by id, 404 if id not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeReadDto>> GetById([FromRoute] int id)
    {
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
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
    /// Creates an Employee
    /// </summary>
    /// <param name="newEmployee">New employee</param>
    /// <returns>201 when Employee created</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeDto employeeDto)
    {
        await _mediator.Send(new CreateEmployeeCommand(employeeDto.Name, employeeDto.BirthDate, employeeDto.Salary));
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
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
        if (employee == null)
            return NotFound();
        else
        {
            await _mediator.Send(new UpdateEmployeeCommand(id, employeeDto.Name, employeeDto.BirthDate, employeeDto.Salary));
            return NoContent();
        }
    }

    /// <summary>
    /// Delete an employee
    /// </summary>
    /// <param name="id">id of an employee</param>
    /// <returns>204 if deletion successful, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
        if (employee == null)
            return NotFound();
        else
        {
            await _mediator.Send(new DeleteEmployeeCommand(id));
            return NoContent();
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
        var employees = await _mediator.Send(new GetAllEmployeesQuery());
        return Ok(employees);
    }

    /// <summary>
    /// Return employee by Id by Dapper
    /// </summary>
    /// <param name="id">Employee Id</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpGet("dapper/{id}")]
    public async Task<ActionResult<EmployeeReadDto>> GetByIdByDapper([FromRoute] int id)
    {
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
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
        await _mediator.Send(new CreateEmployeeCommand(employeeDto.Name, employeeDto.BirthDate, employeeDto.Salary));
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
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
        if (employee == null)
            return NotFound();
        else
        {
            await _mediator.Send(new UpdateEmployeeCommand(id, employeeDto.Name, employeeDto.BirthDate, employeeDto.Salary));
            return NoContent();
        }
    }

    /// <summary>
    /// Deletes an Employee by Dapper
    /// </summary>
    /// <param name="id">EmployeeId</param>
    /// <returns>200 OK or 404 NOT FOUND</returns>
    [HttpDelete("dapper/{id}")]
    public async Task<IActionResult> DeleteByDapper([FromRoute] int id)
    {
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
        if (employee == null)
            return NotFound();
        else
        {
            await _mediator.Send(new DeleteEmployeeCommand(id));
            return NoContent();
        }

    }

}
