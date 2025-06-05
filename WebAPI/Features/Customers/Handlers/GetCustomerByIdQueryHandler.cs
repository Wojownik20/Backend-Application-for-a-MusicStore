using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MusicStore.Core.Data;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.WebAPI.Features.Customers.Queries;

namespace LeverX.WebAPI.Features.Customers.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetByIdAsync(request.Id);
    }
}
}