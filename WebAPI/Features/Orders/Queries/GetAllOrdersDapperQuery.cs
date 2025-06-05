using MediatR;
using MusicStore.Core.Data;
using System.Collections.Generic;

namespace MusicStore.WebAPI.Features.Orders.Queries
{
    public class GetAllOrdersDapperQuery : IRequest<IEnumerable<Order>>
    {
    }
}