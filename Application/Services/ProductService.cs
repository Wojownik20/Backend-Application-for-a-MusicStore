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

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = products.Select(p => new ProductDto
            {
                Name = p.Name,
                Category = p.Category,
                Price = p.Price,
                ReleaseDate = p.ReleaseDate
            });
            return productDtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            else
            {
                return new ProductDto
                {
                    Name = product.Name,
                    Category = product.Category,
                    Price = product.Price,
                    ReleaseDate = product.ReleaseDate
                };
            }

        }

        public async Task CreateProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Category = productDto.Category,
                Price = productDto.Price,
                ReleaseDate = productDto.ReleaseDate 
            };
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Category = productDto.Category,
                Price = productDto.Price,
                ReleaseDate = productDto.ReleaseDate
            };
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}