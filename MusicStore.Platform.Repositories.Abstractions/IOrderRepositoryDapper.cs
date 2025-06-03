using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Core.Data;

namespace MusicStore.Platform.Repositories.Interfaces
{
    public interface IOrderRepositoryDapper // This guy is the one and only talking to the DB
    {
        Task<IEnumerable<Order>> GetAllAsyncByDapper();
        Task<Order> GetByIdAsyncByDapper(int id);
        Task<int> AddAsyncByDapper(Order order);
        Task<int> UpdateAsyncByDapper(Order order);
        Task DeleteAsyncByDapper(int id);
    }

}