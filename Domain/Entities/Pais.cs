using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pais:BaseEntity
{

    public string Nombre { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
