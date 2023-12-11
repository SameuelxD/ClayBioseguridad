using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        private readonly ClayContext _context;

        public PersonaRepository(ClayContext context) : base(context)
        {
            _context = context;
        }
    }
}