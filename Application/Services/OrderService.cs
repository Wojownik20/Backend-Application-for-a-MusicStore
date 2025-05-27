using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeverX.Domain.Models;
using System.Diagnostics.Eventing.Reader;
using LeverX.WebAPI.ModelsD;
using LeverX.Application.Interfaces;

namespace LeverX.Application.Services
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
            var orders = await _orderRepository.GetAllAsync();
            var order = orders.Select(o => new Order
            {
                ProductId = o.ProductId,
                CustomerId = o.CustomerId,
                EmployeeId = o.EmployeeId,
                TotalPrice = o.TotalPrice,
                PurchaseDate = o.PurchaseDate
            });
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return null;
            }
            else
            {
                return new Order
                {
                    ProductId = order.ProductId,
                    CustomerId = order.CustomerId,
                    EmployeeId = order.EmployeeId,
                    TotalPrice = order.TotalPrice,
                    PurchaseDate = order.PurchaseDate
                };
            }

        }

        public async Task CreateOrderAsync(Order order)
        {
            var orders = new Order
            {
                ProductId = order.ProductId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                TotalPrice = order.TotalPrice,
                PurchaseDate = order.PurchaseDate
            };
            await _orderRepository.AddAsync(orders);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var orders = new Order
            {
                ProductId = order.ProductId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                TotalPrice = order.TotalPrice,
                PurchaseDate = order.PurchaseDate
            };
            await _orderRepository.UpdateAsync(orders);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}