using MediatR;
using MusicStore.Core.Data;

namespace MusicStore.WebAPI.Features.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }
}