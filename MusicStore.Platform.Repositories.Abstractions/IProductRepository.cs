using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Core.Data;

namespace MusicStore.Platform.Repositories.Interfaces
{
    public interface IProductRepository // This guy is the one and only talking to the DB
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }

}