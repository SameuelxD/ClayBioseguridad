using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        private readonly ClayContext _context;

        public UserRepository(ClayContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Users
                        .Include(u => u.Rols)
                        .Include(u => u.RefreshTokens)
                        .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                        .Include(u => u.Rols)
                        .Include(u => u.RefreshTokens)
                        .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}