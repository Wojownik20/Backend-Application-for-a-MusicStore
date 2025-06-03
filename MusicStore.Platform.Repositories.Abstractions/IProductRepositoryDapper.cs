using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Core.Data;

namespace MusicStore.Platform.Repositories.Interfaces
{
    public interface IProductRepositoryDapper // This guy is the one and only talking to the DB
    {

        Task<IEnumerable<Product>> GetAllAsyncByDapper();
        Task<Product> GetByIdAsyncByDapper(int id);
        Task<int> AddAsyncByDapper(Product product);
        Task<int> UpdateAsyncByDapper(Product product);
        Task DeleteAsyncByDapper(int id);
    }

}