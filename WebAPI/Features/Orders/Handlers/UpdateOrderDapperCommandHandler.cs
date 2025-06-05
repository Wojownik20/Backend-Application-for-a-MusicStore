using MediatR;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.WebAPI.Features.Orders.Commands;

namespace MusicStore.WebAPI.Features.Orders.Handlers
{
    public class UpdateOrderDapperCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderDapperCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with id {request.Id} not found.");
            }

            order.CustomerId = request.CustomerId;
            order.ProductId = request.ProductId;
            order.EmployeeId = request.EmployeeId;
            order.TotalPrice = request.TotalPrice;
            order.PurchaseDate = request.PurchaseDate;


            await _orderRepository.UpdateAsync(order);
            return Unit.Value;
        }
    }
}