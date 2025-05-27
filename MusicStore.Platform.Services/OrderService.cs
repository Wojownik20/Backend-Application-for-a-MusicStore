using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Shared.Models;
using System.Diagnostics.Eventing.Reader;
using MusicStore.Platform.Interfaces;
using MusicStore.Shared.Services.Abstractions;

namespace MusicStore.Platform.Services
{

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository; //Private Repo injected in here

        public OrderService(IOrderRepository orderRepository) // ICustomerRepo injected into Service
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}