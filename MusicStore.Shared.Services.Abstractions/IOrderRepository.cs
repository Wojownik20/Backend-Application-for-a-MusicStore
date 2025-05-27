using System.Collections.Generic;
using System.Threading.Tasks;
using MusicStore.Shared.Models;

namespace MusicStore.Shared.Services.Abstractions
{
    public interface IOrderRepository // This guy is the one and only talking to the DB
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }

}