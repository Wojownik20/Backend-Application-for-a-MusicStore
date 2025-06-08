using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Identity.Models;

namespace MusicStore.Platform.Repositories.Interfaces.EntityFramework
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<bool> UsernameExistsAsync(string username);
        Task SaveChangesAsync();
    }

}
