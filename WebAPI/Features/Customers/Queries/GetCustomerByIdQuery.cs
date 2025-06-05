using MediatR;
using MusicStore.Core.Data;

namespace MusicStore.WebAPI.Features.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; }

        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}