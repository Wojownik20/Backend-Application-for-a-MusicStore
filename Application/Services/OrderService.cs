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

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderDtos = orders.Select(o => new OrderDto
            {
                ProductId = o.ProductId,
                CustomerId = o.CustomerId,
                EmployeeId = o.EmployeeId,
                TotalPrice = o.TotalPrice,
                PurchaseDate = o.PurchaseDate
            });
            return orderDtos;
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return null;
            }
            else
            {
                return new OrderDto
                {
                    ProductId = order.ProductId,
                    CustomerId = order.CustomerId,
                    EmployeeId = order.EmployeeId,
                    TotalPrice = order.TotalPrice,
                    PurchaseDate = order.PurchaseDate
                };
            }

        }

        public async Task CreateOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                ProductId = orderDto.ProductId,
                CustomerId = orderDto.CustomerId,
                EmployeeId = orderDto.EmployeeId,
                TotalPrice = orderDto.TotalPrice,
                PurchaseDate = orderDto.PurchaseDate
            };
            await _orderRepository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            var order = new Order
            {
                ProductId = orderDto.ProductId,
                CustomerId = orderDto.CustomerId,
                EmployeeId = orderDto.EmployeeId,
                TotalPrice = orderDto.TotalPrice,
                PurchaseDate = orderDto.PurchaseDate
            };
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}