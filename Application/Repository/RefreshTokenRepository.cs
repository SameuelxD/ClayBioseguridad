using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Repository
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshToken
        {
            private readonly ClayContext _context;
    
            public RefreshTokenRepository(ClayContext context) : base(context)
            {
                _context = context;
            }
        }

}