using MediatR;

namespace MusicStore.WebAPI.Features.Orders.Commands
{
    public class DeleteOrderDapperCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteOrderDapperCommand(int id)
        {
            Id = id;
        }
    }
}