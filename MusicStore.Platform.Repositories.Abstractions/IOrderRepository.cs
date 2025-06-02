using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Core.Data;

namespace MusicStore.Platform.Repositories.Interfaces
{
    public interface IOrderRepository // This guy is the one and only talking to the DB
    {
        //EF Core
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<int> AddAsync(Order order);
        Task<int> UpdateAsync(Order order);
        Task DeleteAsync(int id);

        //DAPPER
        Task<IEnumerable<Order>> GetAllAsyncByDapper();
        Task<Order> GetByIdAsyncByDapper(int id);
        Task<int> AddAsyncByDapper(Order order);
        Task<int> UpdateAsyncByDapper(Order order);
        Task DeleteAsyncByDapper(int id);
    }

}