using MediatR;
using MusicStore.Core.Data;

namespace MusicStore.WebAPI.Features.Orders.Queries
{
    public class GetOrderByIdDapperQuery : IRequest<Order>
    {
        public int Id { get; }

        public GetOrderByIdDapperQuery(int id)
        {
            Id = id;
        }
    }
}