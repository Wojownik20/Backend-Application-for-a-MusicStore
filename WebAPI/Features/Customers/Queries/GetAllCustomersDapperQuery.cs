using MediatR;
using MusicStore.Core.Data;

namespace MusicStore.WebAPI.Features.Customers.Queries
{
    public class GetAllCustomersDapperQuery : IRequest<IEnumerable<Customer>>
    {
    }
}