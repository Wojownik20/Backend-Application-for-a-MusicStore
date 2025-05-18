using Microsoft.AspNetCore.Mvc;
using LeverX.Models;

namespace LeverX.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/[controller]")] // Route for api/product
public class CustomerController : ControllerBase //Base class
{
    private static List<Customer> _customers = new List<Customer>
    {
        new Customer {Id = 1 , Name = "Mohamed Salah", BirthDate = new DateTime(1992,6,15)},
        new Customer {Id = 2 , Name = "Roberto Firmino", BirthDate = new DateTime(1991,10,2)},
        new Customer {Id = 3 , Name = "Sadio Mane", BirthDate = new DateTime(1992,4,10)}
    };

    /// <summary>
    /// Return a list of Customers
    /// </summary>
    /// <returns>200 OK and JSON list of customers</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetAll()
    {
        return Ok(_customers); // return 200 OK 
    }

    /// <summary>
    /// Return a Customer by Id
    /// </summary>
    /// <param name="id">Id of an customer</param>
    /// <returns>200 if Customer found, 404 if id not found</returns>
    [HttpGet("{id}")]
    public ActionResult<Customer> GetById(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
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
    public ActionResult<Customer> Create(CustomerDto customerDto)
    {
        var newCustomer = new Customer
        {
            Name = customerDto.Name,
            BirthDate = customerDto.BirthDate
        };
        _customers.Add(newCustomer);
        return CreatedAtAction(nameof(GetById), new { id = newCustomer.Id }, newCustomer);
    }

    /// <summary>
    /// Updates a customer record
    /// </summary>
    /// <param name="id">id of customer</param>
    /// <param name="updatedCustomer">updated customer record</param>
    /// <returns>204 if customer updated, 404 if id not found</returns>
    [HttpPut("{id}")]
    public IActionResult Update(int id, CustomerDto customerDto)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return NotFound();
        }
        else {
            customer.Name = customerDto.Name;
            customer.BirthDate = customerDto.BirthDate;
            return NoContent();
        }
    }

    /// <summary>
    /// Deletion of customer
    /// </summary>
    /// <param name="id">id of the customer</param>
    /// <returns>204 if customer deleted, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return NotFound();
        }
        else
        {
            _customers.Remove(customer);
            return NoContent();
        }
    }
}
