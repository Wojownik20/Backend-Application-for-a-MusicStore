using Microsoft.AspNetCore.Mvc;
using LeverX.Models;

namespace LeverX.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/[controller]")] // Route for api/product
public class OrderController : ControllerBase //Base class
{
    private static List<Order> _orders = new List<Order>
    {
        new Order {Id = 1 , ProductId = 1, CustomerId = 1, EmployeeId=1, TotalPrice=150m, PurchaseDate = new DateTime(2004, 9,16)},
        new Order {Id = 2 , ProductId = 2, CustomerId = 2, EmployeeId=2, TotalPrice=56m, PurchaseDate = new DateTime(2014, 1, 17)},
        new Order {Id = 3 , ProductId = 3, CustomerId = 3, EmployeeId=3, TotalPrice=189m, PurchaseDate = new DateTime(2024, 5, 16)}
    };

    /// <summary>
    /// Returns a list of Orders
    /// </summary>
    /// <returns>200 and JSON list of Orders</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetAll()
    {
        return Ok(_orders); // return 200 OK 
    }

    /// <summary>
    /// Returns Order by ID
    /// </summary>
    /// <param name="id">Id of Order</param>
    /// <returns>200 and a order, 404 if id not found</returns>
    [HttpGet("{Id}")]
    public ActionResult<Order> GetById(int id)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
            return NotFound();
        else
        {
            return Ok(order); //200 Ok
        }
    }

    /// <summary>
    /// Creates new order
    /// </summary>
    /// <param name="newOrder">New order</param>
    /// <returns>201 when order created</returns>
    [HttpPost]
    public ActionResult<Order> Create(Order newOrder)
    {
        newOrder.Id = _orders.Max(o => o.Id) + 1;
        _orders.Add(newOrder);
        return CreatedAtAction(nameof(GetById), new { id = newOrder.Id }, newOrder);
    }

    /// <summary>
    /// Updates the order by id
    /// </summary>
    /// <param name="id">Id of the order</param>
    /// <param name="updatedOrder">Updated order</param>
    /// <returns>204 if Order updated, 404 if id not found</returns>
    [HttpPut("{id}")]
    public IActionResult Update(int id, Order updatedOrder)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        else
        {
            order.ProductId = updatedOrder.ProductId;
            order.CustomerId = updatedOrder.CustomerId;
            order.EmployeeId = updatedOrder.EmployeeId;
            order.PurchaseDate = updatedOrder.PurchaseDate;
            order.TotalPrice = updatedOrder.TotalPrice;
            return NoContent();
        }
    }

    /// <summary>
    /// Deleting Orders by id
    /// </summary>
    /// <param name="id">id of the order</param>
    /// <returns>204 if order deleted, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        else
        {
            _orders.Remove(order);
            return NoContent();
        }
    }
}
