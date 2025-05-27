using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.Shared.Models;
using System.Diagnostics.Eventing.Reader;
using MusicStore.Platform.Interfaces;
using MusicStore.Shared.Services.Abstractions;

namespace MusicStore.Platform.Services
{

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository; //Private Repo injected in here

        public ProductService(IProductRepository productRepository) // ICustomerRepo injected into Service
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        { 
           await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}