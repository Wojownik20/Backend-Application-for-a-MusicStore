
using MusicStore.Core.Data;

namespace MusicStore.Platform.Repositories.Interfaces.EntityFramework
{
    public interface IProductRepository // This guy is the one and only talking to the DB
    {
        //EF Core
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<int> AddAsync(Product product);
        Task<int> UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }

}