using AutoMapper;
using LeverX.WebAPI.Features.Customers.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.WebAPI.Features.Customers.Commands;
using MusicStore.WebAPI.Features.Customers.Queries;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/customer/dapper")] // Route for api/product
public class CustomerDapperController : ControllerBase //Base class
{
    private readonly IMediator _mediator; // Injecting MediatR for CQRS
    private readonly IMapper _mapper; // Injecting AutoMapper 
    public CustomerDapperController( IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    /// <summary>
    /// Returns list of customers using Dapper
    /// </summary>
    /// <returns>200 OK and JSON Lits</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAllAsyncByDapper() // WebAPI changed for Db
    {
        var customers = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(customers);
    }

    /// <summary>
    /// Returns a Customer by Id using Dapper
    /// </summary>
    /// <param name="id">Customer Id</param>
    /// <returns>200 OK or 404 NOT FOUND if Id do not exists</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerReadDto>> GetByIdByDapper([FromRoute] int id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
        if (customer == null)
            return NotFound();

        var customerDto = _mapper.Map<CustomerReadDto>(customer);
        return Ok(customerDto);
    }

    /// <summary>
    /// Creates a new Customer using Dapper
    /// </summary>
    /// <param name="customerDto">Customer Model</param>
    /// <returns>200 OK</returns>
    [HttpPost]
    public async Task<IActionResult> CreateByDapper([FromBody] CustomerDto customerDto)
    {
        await _mediator.Send(new CreateCustomerCommand(customerDto.Name, customerDto.BirthDate));
        return Ok();
    }

    /// <summary>
    /// Updates a Customer using Dapper
    /// </summary>
    /// <param name="id">Customer Id</param>
    /// <param name="customerDto">Customer Model</param>
    /// <returns>200 OK or 404 NOT FOUND if Id not existing</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateByDapper([FromRoute] int id, [FromBody] CustomerDto customerDto)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
        if (customer == null)
            return NotFound();
        else
        {
            await _mediator.Send(new UpdateCustomerCommand(id, customerDto.Name, customerDto.BirthDate));
            return NoContent();
        }
    }

    /// <summary>
    /// Deletes a Customer using Dapper
    /// </summary>
    /// <param name="id">Customer Id</param>
    /// <returns>200 OK or 404 NOT FOUND if Id not found</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteByDapper([FromRoute] int id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
        if (customer == null)
            return NotFound();
        else
        {
            await _mediator.Send(new DeleteCustomerCommand(id));
            return NoContent();
        }

    }


}

