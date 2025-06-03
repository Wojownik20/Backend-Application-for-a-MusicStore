using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MusicStore.Core.Data;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.WebAPI.Features.Customers.Commands;

namespace MusicStore.WebAPI.Features.Customers.Handlers
{
    public class UpdateCustomerDapperCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerDapperCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with id {request.Id} not found.");
            }

            customer.Name = request.Name;
            customer.BirthDate = request.BirthDate;

            await _customerRepository.UpdateAsync(customer);
            return Unit.Value;
        }
    }
}