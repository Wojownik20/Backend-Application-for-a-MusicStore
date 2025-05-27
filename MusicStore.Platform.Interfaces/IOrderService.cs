using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Shared.Models;

namespace MusicStore.Platform.Interfaces
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
