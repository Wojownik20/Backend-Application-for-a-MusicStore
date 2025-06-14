using AutoMapper;
using LeverX.WebAPI.Features.Customers.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Platform.Services.Interfaces;
using MusicStore.WebAPI.Features.Customers.Commands;
using MusicStore.WebAPI.Features.Customers.Queries;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/customer")] // Route for api/product
public class CustomerController : ControllerBase //Base class
{
    private readonly IMediator _mediator; // Injecting MediatR for CQRS
    private readonly IMapper _mapper; // Injecting AutoMapper 
    public CustomerController(ICustomerService customerService, IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Return a list of Customers
    /// </summary>
    /// <returns>200 OK and JSON list of customers</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var customers = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(customers);
    }

    /// <summary>
    /// Return a Customer by Id
    /// </summary>
    /// <param name="id">Id of an customer</param>
    /// <returns>200 if Customer found, 404 if id not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerReadDto>> GetById([FromRoute] int id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
        if (customer == null)
            return NotFound();

        var customerDto = _mapper.Map<CustomerReadDto>(customer);
        return Ok(customerDto);
    }

    /// <summary>
    /// Creates a Customer
    /// </summary>
    /// <param name="newCustomer">New customer</param>
    /// <returns>201 when a new customer is created</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CustomerDto customerDto)
    {
        await _mediator.Send(new CreateCustomerCommand(customerDto.Name, customerDto.BirthDate));
        return Ok();
    }

    /// <summary>
    /// Updates a customer record
    /// </summary>
    /// <param name="id">id of customer</param>
    /// <param name="updatedCustomer">updated customer record</param>
    /// <returns>204 if customer updated, 404 if id not found</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CustomerDto customerDto)
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
    /// Deletion of customer
    /// </summary>
    /// <param name="id">id of the customer</param>
    /// <returns>204 if customer deleted, 404 if id not found</returns>
    [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
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

