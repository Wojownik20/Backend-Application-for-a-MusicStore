using MediatR;
using MusicStore.Core.Data;
using System.Collections.Generic;

namespace MusicStore.WebAPI.Features.Products.Queries
{
    public class GetProductByIdDapperQuery : IRequest<Product>
    {
        public int Id { get; }

        public GetProductByIdDapperQuery(int id)
        {
            Id = id;
        }
    }
}