using MediatR;
using MusicStore.Core.Data;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.WebAPI.Features.Orders.Commands;

namespace MusicStore.WebAPI.Features.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                ProductId = request.ProductId,
                CustomerId = request.CustomerId,
                EmployeeId = request.EmployeeId,
                TotalPrice = request.TotalPrice,
                PurchaseDate = request.PurchaseDate
            };

            var id = await _orderRepository.AddAsync(order);
            return id;
        }
    }
}