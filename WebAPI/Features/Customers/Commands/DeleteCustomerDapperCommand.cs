using MediatR;

namespace MusicStore.WebAPI.Features.Customers.Commands
{
    public class DeleteCustomerDapperCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteCustomerDapperCommand(int id)
        {
            Id = id;
        }
    }
}