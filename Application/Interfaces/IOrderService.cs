using System.Collections.Generic;
using System.Threading.Tasks;
using LeverX.WebAPI.ModelsD;

namespace LeverX.Application.Interfaces
{
    public interface IOrderService // Reminder : Interface is a bunch of essential methods
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(OrderDto orderDto);
        Task UpdateOrderAsync(OrderDto orderDto);
        Task DeleteOrderAsync(int id);
    }
}
