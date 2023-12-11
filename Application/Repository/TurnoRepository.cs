using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository
{
    public class TurnoRepository : GenericRepository<Turno>, ITurno
    {
        private readonly ClayContext _context;

        public TurnoRepository(ClayContext context) : base(context)
        {
            _context = context;
        }
    }
}