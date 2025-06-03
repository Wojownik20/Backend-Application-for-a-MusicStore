using MediatR;

namespace MusicStore.WebAPI.Features.Products.Commands
{
    public class DeleteProductDapperCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteProductDapperCommand(int id)
        {
            Id = id;
        }
    }
}
