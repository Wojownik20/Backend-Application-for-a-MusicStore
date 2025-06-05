using MediatR;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.WebAPI.Features.Products.Commands;

namespace MusicStore.WebAPI.Features.Products.Handlers
{
    public class UpdateProductDapperCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductDapperCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {request.Id} not found.");
            }

            product.Name = request.Name;
            product.Category = request.Category;
            product.Price = request.Price;
            product.ReleaseDate = request.ReleaseDate;

            await _productRepository.UpdateAsync(product);
            return Unit.Value;
        }
    }
}