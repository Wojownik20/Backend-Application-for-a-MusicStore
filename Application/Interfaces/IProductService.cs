using System.Collections.Generic;
using System.Threading.Tasks;
using LeverX.WebAPI.ModelsD;

namespace LeverX.Application.Interfaces
{
    public interface IProductService // Reminder : Interface is a bunch of essential methods
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task CreateProductAsync(ProductDto productDto);
        Task UpdateProductAsync(ProductDto productDto);
        Task DeleteProductAsync(int id);
    }
}
