using MediatR;
using MusicStore.Core.Data;
using System.Collections.Generic;

namespace MusicStore.WebAPI.Features.Customers.Queries
{
    public class GetCustomerByIdDapperQuery : IRequest<Customer>
    {
        public int Id { get; }

        public GetCustomerByIdDapperQuery(int id)
        {
            Id = id;
        }
    }
}