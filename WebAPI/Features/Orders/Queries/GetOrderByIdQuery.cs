using MediatR;
using MusicStore.Core.Data;
using System.Collections.Generic;

namespace MusicStore.WebAPI.Features.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int Id { get; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}