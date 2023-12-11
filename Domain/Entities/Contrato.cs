using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contrato:BaseEntity
{

    public int? IdClienteFk { get; set; }

    public DateOnly? FechaContrato { get; set; }

    public int? IdEmpleadoFk { get; set; }

    public DateOnly? FechaFin { get; set; }

    public int? IdEstadoFk { get; set; }

    public virtual Persona IdClienteFkNavigation { get; set; }

    public virtual Persona IdEmpleadoFkNavigation { get; set; }

    public virtual Estado IdEstadoFkNavigation { get; set; }

    public virtual ICollection<Programacion> Programaciones { get; set; } = new List<Programacion>();
}
