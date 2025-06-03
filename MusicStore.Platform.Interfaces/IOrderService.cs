
using MusicStore.Core.Data;

namespace MusicStore.Platform.Services.Interfaces
{
    public interface IOrderService // Reminder : Interface is a bunch of essential methods
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<int> CreateOrderAsync(Order order);
        Task<int> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);

        //DAPPER

        Task<IEnumerable<Order>> GetAllOrdersAsyncByDapper();
        Task<Order> GetOrderByIdAsyncByDapper(int id);
        Task<int> CreateOrderAsyncByDapper(Order order);
        Task<int> UpdateOrderAsyncByDapper(Order order);
        Task DeleteOrderAsyncByDapper(int id);
    }
}
