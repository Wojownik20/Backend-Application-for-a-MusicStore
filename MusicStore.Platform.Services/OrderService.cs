using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Shared.Models;
using MusicStore.Platform.Services.Interfaces;
using MusicStore.Core.Data;
using MusicStore.Platform.Repositories.Interfaces;

namespace MusicStore.Platform.Services
{

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository; //Private Repo injected in here
        private readonly IOrderRepositoryDapper _orderRepositoryDapper; 

        public OrderService(IOrderRepository orderRepository, IOrderRepositoryDapper orderRepositoryDappercustomerRepository) // ICustomerRepo injected into Service
        {
            _orderRepository = orderRepository;
            _orderRepositoryDapper = orderRepositoryDappercustomerRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
            return order.Id;
        }

        public async Task<int> UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
            return order.Id;
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        //DAPPER
        public async Task<IEnumerable<Order>> GetAllOrdersAsyncByDapper()
        {
            return await _orderRepositoryDapper.GetAllAsyncByDapper();
        }
        public async Task<Order> GetOrderByIdAsyncByDapper(int id)
        {
            return await _orderRepositoryDapper.GetByIdAsyncByDapper(id);
        }
        public async Task<int> CreateOrderAsyncByDapper(Order order)
        {
            await _orderRepositoryDapper.AddAsyncByDapper(order);
            return order.Id;
        }
        public async Task<int> UpdateOrderAsyncByDapper(Order order)
        {
            await _orderRepositoryDapper.UpdateAsyncByDapper(order);
            return order.Id;
        }
        public async Task DeleteOrderAsyncByDapper(int id)
        {
            await _orderRepositoryDapper.DeleteAsyncByDapper(id);
        }
    }
}