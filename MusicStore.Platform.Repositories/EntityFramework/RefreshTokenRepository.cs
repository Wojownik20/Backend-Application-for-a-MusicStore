using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Core.Db;
using MusicStore.Identity.Db;
using MusicStore.Identity.Models;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;

namespace MusicStore.Platform.Repositories.EntityFramework
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IdentityDbContext _context;

        public RefreshTokenRepository(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
            => await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token);

        public async Task AddAsync(RefreshToken token)
            => await _context.RefreshTokens.AddAsync(token);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }

}
