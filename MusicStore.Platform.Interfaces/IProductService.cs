using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Shared.Models;

namespace MusicStore.Platform.Interfaces
{
    public interface IProductService // Reminder : Interface is a bunch of essential methods
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
