using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Core.Db;
using MusicStore.Identity.Models;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.Identity.Db;

namespace MusicStore.Platform.Repositories.EntityFramework
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext _context;

        public UserRepository(IdentityDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
            => await _context.Users.Include(u => u.RefreshTokens)
                                   .FirstOrDefaultAsync(u => u.Username == username);

        public async Task<User?> GetByIdAsync(int id)
            => await _context.Users.Include(u => u.RefreshTokens)
                                   .FirstOrDefaultAsync(u => u.Id == id);

        public async Task AddAsync(User user)
            => await _context.Users.AddAsync(user);

        public async Task<bool> UsernameExistsAsync(string username)
            => await _context.Users.AnyAsync(u => u.Username == username);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }

}
