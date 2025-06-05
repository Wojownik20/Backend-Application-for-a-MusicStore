using AutoMapper;
using LeverX.WebAPI.Features.Orders.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.WebAPI.Features.Customers.Queries;
using MusicStore.WebAPI.Features.Employees.Queries;
using MusicStore.WebAPI.Features.Orders.Commands;
using MusicStore.WebAPI.Features.Orders.Queries;
using MusicStore.WebAPI.Features.Products.Queries;

namespace LeverX.WebAPI.Controllers;

[ApiController] //Tells ASP.NET that its a Controller
[Route("api/order/dapper")] // Route for api/product
public class OrderDapperController : ControllerBase //Base class
{
    private readonly IMediator _mediator; // Injecting MediatR for CQRS
    private readonly IMapper _mapper; // Injecting AutoMapper
    public OrderDapperController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAllAsyncByDapper()
    {
        var order = await _mediator.Send(new GetAllOrdersQuery());
        return Ok(order);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderReadDto>> GetByIdByDapper([FromRoute] int id)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null)
            return NotFound();

        var orderDto = _mapper.Map<OrderReadDto>(order);
        return Ok(orderDto);
    }


    [HttpPost]
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

    [HttpPut("{id}")]
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

    [HttpDelete("{id}")]
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
