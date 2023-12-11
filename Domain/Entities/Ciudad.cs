using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ciudad:BaseEntity
{

    public string Nombre { get; set; }

    public int? IdDepartamentoFk { get; set; }

    public virtual Departamento IdDepartamentoFkNavigation { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
