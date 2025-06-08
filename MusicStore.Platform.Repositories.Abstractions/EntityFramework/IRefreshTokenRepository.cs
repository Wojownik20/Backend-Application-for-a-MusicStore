using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Identity.Models;

namespace MusicStore.Platform.Repositories.Interfaces.EntityFramework
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task AddAsync(RefreshToken token);
        Task SaveChangesAsync();
    }

}
