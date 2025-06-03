using MusicStore.Platform.Services.Interfaces;
using MusicStore.Core.Data;
using LeverX.WebAPI.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/[controller]")] // Route for api/product
public class CustomerController : ControllerBase //Base class
{

    private readonly ICustomerService _customerService; // Injecting our DB
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    /// <summary>
    /// Return a list of Customers
    /// </summary>
    /// <returns>200 OK and JSON list of customers</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var customers = await _customerService.GetAllCustomersAsync();
        var customerDtos = customers.Select(c => new CustomerReadDto
        {
            Id=c.Id,
            Name = c.Name,
            BirthDate = c.BirthDate
        });
        return Ok(customerDtos);
    }

    /// <summary>
    /// Return a Customer by Id
    /// </summary>
    /// <param name="id">Id of an customer</param>
    /// <returns>200 if Customer found, 404 if id not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerReadDto>> GetById([FromRoute] int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound();

        var customerDto = new CustomerReadDto
        {
            Id = customer.Id,
            Name = customer.Name,
            BirthDate = customer.BirthDate
        };
        return Ok(customer);
    }

    /// <summary>
    /// Creates a Customer
    /// </summary>
    /// <param name="newCustomer">New customer</param>
    /// <returns>201 when a new customer is created</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CustomerDto customerDto)
    {
        var customer = new Customer
        {
            Name = customerDto.Name,
            BirthDate = customerDto.BirthDate
        };

        await _customerService.CreateCustomerAsync(customer);
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
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if(customer == null)
            return NotFound();
        else
        {
            customer.Name = customerDto.Name;
            customer.BirthDate = customerDto.BirthDate;
        }

            await _customerService.UpdateCustomerAsync(customer);
        return Ok();
    }
    /// <summary>
    /// Deletion of customer
    /// </summary>
    /// <param name="id">id of the customer</param>
    /// <returns>204 if customer deleted, 404 if id not found</returns>
    [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound();
        else
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok();
        }
        }

    // DAPPER

    /// <summary>
    /// Returns list of customers using Dapper
    /// </summary>
    /// <returns>200 OK and JSON Lits</returns>
    [HttpGet("dapper")]
    public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAllAsyncByDapper() // WebAPI changed for Db
    {
        var customers = await _customerService.GetAllCustomersAsyncByDapper();
        var customerDtos = customers.Select(c => new CustomerReadDto
        {
            Id = c.Id,
            Name = c.Name,
            BirthDate = c.BirthDate
        });
        return Ok(customerDtos);
    }

    /// <summary>
    /// Returns a Customer by Id using Dapper
    /// </summary>
    /// <param name="id">Customer Id</param>
    /// <returns>200 OK or 404 NOT FOUND if Id do not exists</returns>
    [HttpGet("dapper/{id}")]
    public async Task<ActionResult<CustomerReadDto>> GetByIdByDapper([FromRoute] int id)
    {
        var customer = await _customerService.GetCustomerByIdAsyncByDapper(id);
        if (customer == null)
            return NotFound();

        var customerDto = new CustomerReadDto
        {
            Id = customer.Id,
            Name = customer.Name,
            BirthDate = customer.BirthDate
        };
        return Ok(customer);
    }

    /// <summary>
    /// Creates a new Customer using Dapper
    /// </summary>
    /// <param name="customerDto">Customer Model</param>
    /// <returns>200 OK</returns>
    [HttpPost("dapper")]
    public async Task<IActionResult> CreateByDapper([FromBody] CustomerDto customerDto)
    {
        var customer = new Customer
        {
            Name = customerDto.Name,
            BirthDate = customerDto.BirthDate
        };

        await _customerService.CreateCustomerAsyncByDapper(customer);
        return Ok();
    }

    /// <summary>
    /// Updates a Customer using Dapper
    /// </summary>
    /// <param name="id">Customer Id</param>
    /// <param name="customerDto">Customer Model</param>
    /// <returns>200 OK or 404 NOT FOUND if Id not existing</returns>
    [HttpPut("dapper/{id}")]
    public async Task<IActionResult> UpdateByDapper([FromRoute] int id, [FromBody] CustomerDto customerDto)
    {
        var customer = await _customerService.GetCustomerByIdAsyncByDapper(id);
        if (customer == null)
            return NotFound();
        else
        {
            customer.Name = customerDto.Name;
            customer.BirthDate = customerDto.BirthDate;
        }

        await _customerService.UpdateCustomerAsyncByDapper(customer);
        return Ok();
    }

    /// <summary>
    /// Deletes a Customer using Dapper
    /// </summary>
    /// <param name="id">Customer Id</param>
    /// <returns>200 OK or 404 NOT FOUND if Id not found</returns>
    [HttpDelete("dapper/{id}")]
    public async Task<IActionResult> DeleteByDapper([FromRoute] int id)
    {
        var customer = await _customerService.GetCustomerByIdAsyncByDapper(id);
        if (customer == null)
            return NotFound();
        else{
                await _customerService.DeleteCustomerAsyncByDapper(id);
        return Ok();
        }

    }


}

