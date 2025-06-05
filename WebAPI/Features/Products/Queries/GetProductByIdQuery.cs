using MediatR;
using MusicStore.Core.Data;
using System.Collections.Generic;

namespace MusicStore.WebAPI.Features.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}