using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MusicStore.Core.Data;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.WebAPI.Features.Customers.Commands;

namespace MusicStore.WebAPI.Features.Customers.Handlers
{
    public class CreateCustomerCommandDapperHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandDapperHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Name = request.Name,
                BirthDate = request.BirthDate
            };

            var id = await _customerRepository.AddAsync(customer);
            return id;
        }
    }
}