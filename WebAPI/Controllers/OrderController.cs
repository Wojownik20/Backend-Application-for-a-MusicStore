using AutoMapper;
using LeverX.WebAPI.ModelsDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Platform.Services.Interfaces;
using MusicStore.WebAPI.Features.Customers.Queries;
using MusicStore.WebAPI.Features.Employees.Queries;
using MusicStore.WebAPI.Features.Orders.Commands;
using MusicStore.WebAPI.Features.Orders.Queries;
using MusicStore.WebAPI.Features.Products.Queries;
using WebAPI.ModelsDto;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/[controller]")] // Route for api/product
public class OrderController : ControllerBase //Base class
{
    private readonly IOrderService _orderService; // Injecting our DB
    private readonly IMediator _mediator; // Injecting MediatR for CQRS
    private readonly IMapper _mapper; // Injecting AutoMapper
    public OrderController(IOrderService orderService, IMediator mediator, IMapper mapper)
    {
        _orderService = orderService;
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns a list of Orders
    /// </summary>
    /// <returns>200 and JSON list of Orders</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAllAsync() // WebAPI changed for Db
    {
        var order = await _mediator.Send(new GetAllOrdersQuery());
        return Ok(order);
    }

    /// <summary>
    /// Returns Order by ID
    /// </summary>
    /// <param name="id">Id of Order</param>
    /// <returns>200 and a order, 404 if id not found</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderReadDto>> GetById([FromRoute] int id)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null)
            return NotFound();

        var orderDto = _mapper.Map<OrderReadDto>(order);
        return Ok(orderDto);
    }

    /// <summary>
    /// Creates new order
    /// </summary>
    /// <param name="newOrder">New order</param>
    /// <returns>201 when order created</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(orderDto.CustomerId));
        if (customer == null)
        {
            return NotFound($"Customer with ID {orderDto.CustomerId} not found.");
        }
        var product = await _mediator.Send(new GetProductByIdQuery(orderDto.ProductId));
        if (product==null)
        {
            return NotFound($"Product with ID {orderDto.ProductId} not found.");
        }
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(orderDto.EmployeeId));
        if (employee==null)
        {
            return NotFound($"Employee with ID {orderDto.EmployeeId} not found.");
        }

        await _mediator.Send(new CreateOrderCommand(orderDto.ProductId, orderDto.CustomerId, orderDto.EmployeeId, orderDto.TotalPrice, orderDto.PurchaseDate));
        return Ok();
    }

    /// <summary>
    /// Updates the order by id
    /// </summary>
    /// <param name="id">Id of the order</param>
    /// <param name="updatedOrder">Updated order</param>
    /// <returns>204 if Order updated, 404 if id not found</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] OrderDto orderDto)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(orderDto.CustomerId));
        if (customer == null)
        {
            return NotFound($"Customer with ID {orderDto.CustomerId} not found.");
        }
        var product = await _mediator.Send(new GetProductByIdQuery(orderDto.ProductId));
        if (product == null)
        {
            return NotFound($"Product with ID {orderDto.ProductId} not found.");
        }
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(orderDto.EmployeeId));
        if (employee == null)
        {
            return NotFound($"Employee with ID {orderDto.EmployeeId} not found.");
        }
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null)
            return NotFound();
        else
        {
            await _mediator.Send(new UpdateOrderCommand(id, orderDto.ProductId, orderDto.CustomerId, orderDto.EmployeeId, orderDto.TotalPrice, orderDto.PurchaseDate));
            return NoContent();
        }
    }

    /// <summary>
    /// Deleting Orders by id
    /// </summary>
    /// <param name="id">id of the order</param>
    /// <returns>204 if order deleted, 404 if id not found</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null)
            return NotFound();
        else
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return NoContent();
        }
    }

    //DAPPER
    [HttpGet("dapper")]
    public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAllAsyncByDapper()
    {
        var order = await _mediator.Send(new GetAllOrdersQuery());
        return Ok(order);
    }

    [HttpGet("dapper/{id}")]
    public async Task<ActionResult<OrderReadDto>> GetByIdByDapper([FromRoute] int id)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null)
            return NotFound();

        var orderDto = _mapper.Map<OrderReadDto>(order);
        return Ok(orderDto);
    }


    [HttpPost("dapper")]
    public async Task<IActionResult> CreateByDapper([FromBody] OrderDto orderDto)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(orderDto.CustomerId));
        if (customer == null)
        {
            return NotFound($"Customer with ID {orderDto.CustomerId} not found.");
        }
        var product = await _mediator.Send(new GetProductByIdQuery(orderDto.ProductId));
        if (product == null)
        {
            return NotFound($"Product with ID {orderDto.ProductId} not found.");
        }
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(orderDto.EmployeeId));
        if (employee == null)
        {
            return NotFound($"Employee with ID {orderDto.EmployeeId} not found.");
        }

        await _mediator.Send(new CreateOrderCommand(orderDto.ProductId, orderDto.CustomerId, orderDto.EmployeeId, orderDto.TotalPrice, orderDto.PurchaseDate));
        return Ok();
    }

    [HttpPut("dapper/{id}")]
    public async Task<IActionResult> UpdateByDapper([FromRoute] int id, [FromBody] OrderDto orderDto)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(orderDto.CustomerId));
        if (customer == null)
        {
            return NotFound($"Customer with ID {orderDto.CustomerId} not found.");
        }
        var product = await _mediator.Send(new GetProductByIdQuery(orderDto.ProductId));
        if (product == null)
        {
            return NotFound($"Product with ID {orderDto.ProductId} not found.");
        }
        var employee = await _mediator.Send(new GetEmployeeByIdQuery(orderDto.EmployeeId));
        if (employee == null)
        {
            return NotFound($"Employee with ID {orderDto.EmployeeId} not found.");
        }
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null)
            return NotFound();
        else
        {
            await _mediator.Send(new UpdateOrderCommand(id, orderDto.ProductId, orderDto.CustomerId, orderDto.EmployeeId, orderDto.TotalPrice, orderDto.PurchaseDate));
            return NoContent();
        }
    }

    [HttpDelete("dapper/{id}")]
    public async Task<IActionResult> DeleteByDapper([FromRoute] int id)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null)
            return NotFound();
        else
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return NoContent();
        }
    }
}
