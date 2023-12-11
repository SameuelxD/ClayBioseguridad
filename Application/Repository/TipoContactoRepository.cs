using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository
{
    public class TipoContactoRepository : GenericRepository<Tipocontacto>, ITipoContacto
    {
        private readonly ClayContext _context;

        public TipoContactoRepository(ClayContext context) : base(context)
        {
            _context = context;
        }
    }
}