using MediatR;
using MusicStore.Core.Data;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.WebAPI.Features.Orders.Queries;

namespace LeverX.WebAPI.Features.Orders.Handlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllAsync();
        }
    }
}