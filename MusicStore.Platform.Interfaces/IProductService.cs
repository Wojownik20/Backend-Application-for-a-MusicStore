
using MusicStore.Core.Data;

namespace MusicStore.Platform.Services.Interfaces
{
    public interface IProductService // Reminder : Interface is a bunch of essential methods
    {
        //EF Core
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<int> CreateProductAsync(Product product);
        Task<int> UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);

        //DAPPER
        Task<IEnumerable<Product>> GetAllProductsAsyncByDapper();
        Task<Product> GetProductByIdAsyncByDapper(int id);
        Task<int> CreateProductAsyncByDapper(Product product);
        Task<int> UpdateProductAsyncByDapper(Product product);
        Task DeleteProductAsyncByDapper(int id);    
    }
}
