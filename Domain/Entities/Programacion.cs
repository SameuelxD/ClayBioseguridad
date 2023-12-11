using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Programacion:BaseEntity
{
    public int? IdContratoFk { get; set; }

    public int? IdTurnoFk { get; set; }

    public int? IdEmpleadoFk { get; set; }

    public virtual Contrato IdContratoFkNavigation { get; set; }

    public virtual Persona IdEmpleadoFkNavigation { get; set; }

    public virtual Turno IdTurnoFkNavigation { get; set; }
}
