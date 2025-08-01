using AutoMapper;
using LeverX.WebAPI.Features.Employees.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.WebAPI.Features.Employees.Commands;
using MusicStore.WebAPI.Features.Employees.Queries;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/employee")] // Route for api/product
public class EmployeeController : ControllerBase //Base class
{
    private readonly IMediator _mediator; // Injecting MediatR for CQRS
    private readonly IMapper _mapper; // Injecting AutoMapper
    public EmployeeController( IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
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

        var employeeDto = _mapper.Map<EmployeeReadDto>(employee);
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
}
