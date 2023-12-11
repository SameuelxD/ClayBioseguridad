using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoriaPersona CategoriaPersonas { get; }
        public ICiudad Ciudades { get; }
        public IContactoPersona ContactoPersonas { get; }
        public IContrato Contratos { get; }
        public IDepartamento Departamentos { get; }
        public IDireccionPersona DireccionPersonas { get; }
        public IEstado Estados { get; }
        public IPais Paises { get; }
        public IPersona Personas { get; }
        public IProgramacion Programaciones { get; }
        public ITipoContacto TipoContactos { get; }
        public ITipoDireccion TipoDirecciones { get; }
        public ITipoPersona TipoPersonas { get; }
        public ITurno Turnos { get; }
        public IUser Users { get; }
        public IRol Roles { get; }
        public IRefreshToken RefreshTokens { get; }

        Task<int> SaveAsync();
    }
}
