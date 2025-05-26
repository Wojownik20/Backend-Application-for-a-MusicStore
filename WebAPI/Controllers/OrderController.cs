using LeverX.Application.Interfaces;
using LeverX.Application.Services;
using LeverX.Domain.Models;
using LeverX.WebAPI.ModelsD;
using Microsoft.AspNetCore.Mvc;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/[controller]")] // Route for api/product
public class OrderController : ControllerBase //Base class
{
    private readonly IOrderService _orderService; // Injecting our DB
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Returns a list of Orders
    /// </summary>
    /// <returns>200 and JSON list of Orders</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var order = await _orderService.GetAllOrdersAsync();
        return Ok(order); // return 200 OK 
    }

    /// <summary>
    /// Returns Order by ID
    /// </summary>
    /// <param name="id">Id of Order</param>
    /// <returns>200 and a order, 404 if id not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
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
    public async Task<IActionResult> Create(OrderDto orderDto)
    {
        await _orderService.CreateOrderAsync(orderDto);
        return Ok();
    }

    /// <summary>
    /// Updates the order by id
    /// </summary>
    /// <param name="id">Id of the order</param>
    /// <param name="updatedOrder">Updated order</param>
    /// <returns>204 if Order updated, 404 if id not found</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(OrderDto orderDto)
    {

        await _orderService.UpdateOrderAsync(orderDto);
        return Ok();

    }

    /// <summary>
    /// Deleting Orders by id
    /// </summary>
    /// <param name="id">id of the order</param>
    /// <returns>204 if order deleted, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderService.DeleteOrderAsync(id);
        return Ok();
    }
}
