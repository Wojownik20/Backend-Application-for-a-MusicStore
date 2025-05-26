using LeverX.Application.Interfaces;
using LeverX.Application.Services;
using LeverX.Domain.Models;
using LeverX.WebAPI.ModelsD;
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
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(customers); // return 200 OK 
    }

    /// <summary>
    /// Return a Customer by Id
    /// </summary>
    /// <param name="id">Id of an customer</param>
    /// <returns>200 if Customer found, 404 if id not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetById(int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);
        if (customer == null)
            return NotFound();
        else
        {
            return Ok(customer); //200 Ok
        }
    }

    /// <summary>
    /// Creates a Customer
    /// </summary>
    /// <param name="newCustomer">New customer</param>
    /// <returns>201 when a new customer is created</returns>
    [HttpPost]
    public async Task<IActionResult> Create(CustomerDto customerDto)
    {
        await _customerService.CreateCustomerAsync(customerDto);
        return Ok();
    }

    /// <summary>
    /// Updates a customer record
    /// </summary>
    /// <param name="id">id of customer</param>
    /// <param name="updatedCustomer">updated customer record</param>
    /// <returns>204 if customer updated, 404 if id not found</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(CustomerDto customerDto) {
        
            await _customerService.UpdateCustomerAsync(customerDto);
            return Ok();
        
    }
        /// <summary>
        /// Deletion of customer
        /// </summary>
        /// <param name="id">id of the customer</param>
        /// <returns>204 if customer deleted, 404 if id not found</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _customerService.DeleteCustomerAsync(id);
            return Ok();
        }
    }

