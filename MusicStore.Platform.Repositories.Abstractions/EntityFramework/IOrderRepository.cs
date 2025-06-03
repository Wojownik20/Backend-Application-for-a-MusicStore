
using MusicStore.Core.Data;

namespace MusicStore.Platform.Repositories.Interfaces.EntityFramework;

    public interface IOrderRepository // This guy is the one and only talking to the DB
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<int> AddAsync(Order order);
        Task<int> UpdateAsync(Order order);
        Task DeleteAsync(int id);


    }
