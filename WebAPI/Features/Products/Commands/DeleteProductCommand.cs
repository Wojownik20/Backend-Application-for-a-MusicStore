using MediatR;

namespace MusicStore.WebAPI.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
