
using MusicStore.Platform.Services.Interfaces;
using MusicStore.Core.Data;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.Platform.Repositories.Interfaces.Dapper;

namespace MusicStore.Platform.Services
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository; //Private Repo injected in here
        private readonly IProductRepositoryDapper _productRepositoryDapper; //Private Repo injected in here

        public ProductService(IProductRepository productRepository, IProductRepositoryDapper productRepositoryDapper) // ICustomerRepo injected into Service
        {
            _productRepository = productRepository;
            _productRepositoryDapper = productRepositoryDapper;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            return product.Id;
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return product.Id;
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        //DAPPER
        public async Task<IEnumerable<Product>> GetAllProductsAsyncByDapper()
        {
            return await _productRepositoryDapper.GetAllAsync();
        }
        public async Task<Product> GetProductByIdAsyncByDapper(int id)
        {
            return await _productRepositoryDapper.GetByIdAsync(id);
        }
        public async Task<int> CreateProductAsyncByDapper(Product product)
        {
            await _productRepositoryDapper.AddAsync(product);
            return product.Id;
        }
        public async Task<int> UpdateProductAsyncByDapper(Product product)
        {
            await _productRepositoryDapper.UpdateAsync(product);
            return product.Id;
        }
        public async Task DeleteProductAsyncByDapper(int id)
        {
            await _productRepositoryDapper.DeleteAsync(id);
        }
    }
}