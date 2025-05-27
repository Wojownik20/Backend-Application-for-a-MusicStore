using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeverX.Domain.Models;
using System.Diagnostics.Eventing.Reader;
using LeverX.WebAPI.ModelsD;
using LeverX.Application.Interfaces;

namespace LeverX.Application.Services
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
            var products = await _productRepository.GetAllAsync();
            var product = products.Select(p => new Product
            {
                Name = p.Name,
                Category = p.Category,
                Price = p.Price,
                ReleaseDate = p.ReleaseDate
            });
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            else
            {
                return new Product
                {
                    Name = product.Name,
                    Category = product.Category,
                    Price = product.Price,
                    ReleaseDate = product.ReleaseDate
                };
            }

        }

        public async Task CreateProductAsync(Product product)
        {
            var products = new Product
            {
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                ReleaseDate = product.ReleaseDate 
            };
            await _productRepository.AddAsync(products);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var products = new Product
            {
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                ReleaseDate = product.ReleaseDate
            };
            await _productRepository.UpdateAsync(products);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}