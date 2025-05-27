using System.Collections.Generic;
using System.Threading.Tasks;
using LeverX.Domain.Models;

namespace LeverX.Application.Interfaces
{
    public interface IOrderService // Reminder : Interface is a bunch of essential methods
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
    }
}
