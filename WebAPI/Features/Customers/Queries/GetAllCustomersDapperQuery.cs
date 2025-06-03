using MediatR;
using MusicStore.Core.Data;
using System.Collections.Generic;

namespace MusicStore.WebAPI.Features.Customers.Queries
{
    public class GetAllCustomersDapperQuery : IRequest<IEnumerable<Customer>>
    {
    }
}