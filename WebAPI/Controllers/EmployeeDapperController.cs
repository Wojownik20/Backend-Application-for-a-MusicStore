using AutoMapper;
using LeverX.WebAPI.Features.Employees.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.WebAPI.Features.Employees.Commands;
using MusicStore.WebAPI.Features.Employees.Queries;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/employee/dapper")] // Route for api/product
public class EmployeeDapperController : ControllerBase //Base class
{
    private readonly IMediator _mediator; // Injecting MediatR for CQRS
    private readonly IMapper _mapper; // Injecting AutoMapper
    public EmployeeDapperController( IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    /// <summary>
    /// Returns JSON list of Employees by Dapper
    /// </summary>
    /// <returns>OK 200</returns>
    [HttpGet]
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
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeReadDto>> GetByIdByDapper([FromRoute] int id)
    {
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
        if (employee == null)
            return NotFound();

        var employeeDto = _mapper.Map<EmployeeReadDto>(employee);
        return Ok(employeeDto);
    }

    /// <summary>
    /// Creates an Employee by Dapper
    /// </summary>
    /// <param name="employeeDto">Employee Model</param>
    /// <returns>200 OK</returns>
    [HttpPost]
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
    [HttpPut("{id}")]
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
    [HttpDelete("{id}")]
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
