using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public int? IdPersonaFk { get; set; }

        public string Nombre { get; set; }

        public DateOnly? FechaRegistro { get; set; }

        public int? IdTipoPersonaFk { get; set; }

        public int? IdCategoriaFk { get; set; }

        public int? IdCiudadFk { get; set; }
    }
}