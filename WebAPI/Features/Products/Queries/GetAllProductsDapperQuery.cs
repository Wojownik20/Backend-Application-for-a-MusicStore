using MediatR;
using MusicStore.Core.Data;
using System.Collections.Generic;

namespace MusicStore.WebAPI.Features.Products.Queries
{
    public class GetAllProductsDapperQuery : IRequest<IEnumerable<Product>>
    {
    }
}