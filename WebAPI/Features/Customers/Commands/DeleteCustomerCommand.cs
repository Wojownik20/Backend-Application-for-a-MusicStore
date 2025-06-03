using MediatR;

namespace MusicStore.WebAPI.Features.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}