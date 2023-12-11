using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository
{
    public class ContactoPersonaRepository : GenericRepository<Contactopersona>, IContactoPersona
    {
        private readonly ClayContext _context;

        public ContactoPersonaRepository(ClayContext context) : base(context)
        {
            _context = context;
        }
    }
}